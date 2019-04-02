var app = angular.module('ERP').controller('EmployeeController', EmployeeController);

function EmployeeController($scope, Service) {
    var form = $(".m-form m-form--label-align-left- m-form--state-");
    $scope.ViewGetStudentInfoes = {};
    $scope.btnactive = 1;
    $scope.UserCredentialModel = {};
    $scope.IsVisible = false;
    $scope.Visible = true;
    $scope.btnupdate = true;
    $scope.SaveSubmit = true;


    $scope.Initialize = function () {
        debugger;
        Data = {
            Status: $scope.btnactive
        }
        Service.Post("Institute/GetInstituteInfo", JSON.stringify(Data)).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.InstituteInfoData = result.data;
            //console.log(result.data);

        })
    }
    $scope.GetSection = function () {
        debugger;
        $scope.UserCredentialModel.Status = $scope.btnactive;
        Service.Post("Institute/GetSection", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.SectionData = result.data.ResultData;
            //console.log(result.data);

        })
    }
    $scope.GetState = function () {
        debugger;
        $scope.UserCredentialModel = {};
        Service.Post("StateMaster/GetState", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.StateList = result.data;
            //console.log(result.data);

        })
    }
    $scope.GetBoard = function () {
        debugger;
        $scope.UserCredentialModel = {};
        Service.Post("Institute/GetBoard", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.BoardData = result.data;
            //console.log(result.data);

        })
    }
    $scope.Add = function () {
        debugger;
        var EstablishedYear = $('#m_datepicker_2').val();
        var InstituteData = {
            SectionId:$scope.SectionId,
            UdiseNo: $scope.UdiseNo,
            InstituteName: $scope.InstituteName,
            BoardId: $scope.BoardId,
            AffilationNo: $scope.AffilationNo,
            EstablishedYear:EstablishedYear,
            InstituteOrganizationName: $scope.InstituteOrganizationName,
            OrganizationAddress: $scope.OrganizationAddress,
            OrganizationRegistrationNo: $scope.OrganizationRegistrationNo,
            //RegistrationCertificateNo: $scope.RegistrationCertificateNo,
            //InstituteRecognitionNoPrimary: $scope.InstituteRecognitionNoPrimary
        }
        var AddressData = {
            Address1: $scope.Address1,
            Address2: $scope.Address2,
            CityName: $scope.CityName,
            StateId: $scope.StateId,
            Pincode: $scope.Pincode,
            LandlineNumber: $scope.LandlineNumber,
            PhoneNumber1: $scope.PhoneNumber1,
            PhoneNumber2: $scope.PhoneNumber2,
            Fax: $scope.Fax,
            InstituteEmail: $scope.InstituteEmail,
            PrinciaplEmail: $scope.PrinciaplEmail,
            Website: $scope.Website
        }
        var BankData = {
            IndexNo: $scope.IndexNo,
            PanNo: $scope.PanNo,
            TanNo: $scope.TanNo,
            Gstin: $scope.Gstin,
            BankName: $scope.BankName,
            Ifsc: $scope.Ifsc,
            Micr: $scope.Micr,
            AccountNumber: $scope.AccountNumber,

        }    
          
            Service.Post("Institute/AddInstitute", JSON.stringify(InstituteData)).then(function (response) {
                debugger;
                $scope.AddressAdd(AddressData);
                $scope.AddBank(BankData);
                $scope.AddLogo();
                $scope.Initialize();
                $scope.IsVisible = false;
                $scope.Visible = true;
            });
       
    }
    $scope.AddressAdd = function (AddressData)
    {
        debugger;
        Service.Post("Institute/AddInstituteAddress", JSON.stringify(AddressData)).then(function (response) {
            debugger;

        });

    }
    $scope.AddBank = function (BankData) {
        debugger;
        Service.Post("Institute/AddInstituteBank", JSON.stringify(BankData)).then(function (response) {
            debugger;

        });

    }
    $scope.AddLogo = function () {
        debugger;
        var payload = new FormData();
        payload.append("HeaderName", $scope.HeaderName);
        payload.append("LogoName", $scope.LogoName);       
        Service.PostFile("Institute/AddInstituteLogo", payload).then(function (response) {
            debugger;

        });

    }
    $scope.ShowHide = function () {
        $scope.IsVisible = true;
        $scope.Visible = false;
        $scope.btnupdate = false;
        $scope.SaveSubmit = true;
        //$scope.btnupdate = false;
        //$scope.BTNSAVE = true;
        //$scope.RemoveED = false;
        //$scope.RemoveSave = true;
       
    }
    $scope.Verify = function (InstituteId) {
        debugger;
        var data = {
            InstituteId: InstituteId
           
        };
        Service.Post("Institute/GetSingleInstitute", JSON.stringify(data)).then(function (rd) {
            $scope.IsVisible = true;
            $scope.Visible = false;
            $scope.btnupdate = true;
            $scope.SaveSubmit = false;
            $scope.AccountNumber = rd.data.ResultData.AccountNumber;
            $scope.Address1 = rd.data.ResultData.Address1;
            $scope.Address2 = rd.data.ResultData.Address2;
            $scope.AffilationNo = rd.data.ResultData.AffilationNo;
            $scope.BankName = rd.data.ResultData.BankName;
            $scope.BoardId = rd.data.ResultData.BoardId;
            $scope.CityName = rd.data.ResultData.CityName;
            $scope.EstablishedYear = rd.data.ResultData.EstablishedYear;

            $scope.Fax = rd.data.ResultData.Fax;
            $scope.Gstin = rd.data.ResultData.Gstin;
            $scope.LogoName = rd.data.ResultData.LogoName;
            $scope.HeaderName = rd.data.ResultData.HeaderName;
            $scope.Ifsc = rd.data.ResultData.Ifsc;
            $scope.IndexNo = rd.data.ResultData.IndexNo;
            $scope.InstituteId = rd.data.ResultData.InstituteId,
            $scope.InstituteBankDid = rd.data.ResultData.InstituteBankDid;
            $scope.InstituteEmail = rd.data.ResultData.InstituteEmail;
            $scope.InstituteDid = rd.data.ResultData.InstituteDid;

            $scope.InstituteName = rd.data.ResultData.InstituteName;
            $scope.InstituteOrganizationName = rd.data.ResultData.InstituteOrganizationName;
            $scope.LandlineNumber = rd.data.ResultData.LandlineNumber;
            $scope.LogoDid = rd.data.ResultData.LogoDid;
            $scope.Micr = rd.data.ResultData.Micr;
            $scope.OrganizationAddress = rd.data.ResultData.OrganizationAddress;
            $scope.OrganizationRegistrationNo = rd.data.ResultData.OrganizationRegistrationNo;
            $scope.PanNo = rd.data.ResultData.PanNo;

            $scope.PhoneNumber1 = rd.data.ResultData.PhoneNumber1;
            $scope.PhoneNumber2 = rd.data.ResultData.PhoneNumber2;
            $scope.Pincode = rd.data.ResultData.Pincode;
            $scope.PrinciaplEmail = rd.data.ResultData.PrinciaplEmail;
            $scope.SectionId = rd.data.ResultData.SectionId;
            $scope.StateId = rd.data.ResultData.StateId;
            $scope.TanNo = rd.data.ResultData.TanNo;
            $scope.UdiseNo = rd.data.ResultData.UdiseNo;
            $scope.Website = rd.data.ResultData.Website;

        });
    }
    $scope.Update = function () {
        debugger;
        var EstablishedYear = $('#m_datepicker_2').val();
        var InstituteData = {
            SectionId: $scope.SectionId,
            UdiseNo: $scope.UdiseNo,
            InstituteName: $scope.InstituteName,
            BoardId: $scope.BoardId,
            AffilationNo: $scope.AffilationNo,
            EstablishedYear: EstablishedYear,
            InstituteOrganizationName: $scope.InstituteOrganizationName,
            OrganizationAddress: $scope.OrganizationAddress,
            OrganizationRegistrationNo: $scope.OrganizationRegistrationNo,
            InstituteId: $scope.InstituteId
            //RegistrationCertificateNo: $scope.RegistrationCertificateNo,
            //InstituteRecognitionNoPrimary: $scope.InstituteRecognitionNoPrimary
        }
        var AddressData = {
            InstituteId: $scope.InstituteId,
            Address1: $scope.Address1,
            Address2: $scope.Address2,
            CityName: $scope.CityName,
            StateId: $scope.StateId,
            Pincode: $scope.Pincode,
            LandlineNumber: $scope.LandlineNumber,
            PhoneNumber1: $scope.PhoneNumber1,
            PhoneNumber2: $scope.PhoneNumber2,
            Fax: $scope.Fax,
            InstituteEmail: $scope.InstituteEmail,
            PrinciaplEmail: $scope.PrinciaplEmail,
            Website: $scope.Website
        }
        var BankData = {
            InstituteId: $scope.InstituteId,
            IndexNo: $scope.IndexNo,
            PanNo: $scope.PanNo,
            TanNo: $scope.TanNo,
            Gstin: $scope.Gstin,
            BankName: $scope.BankName,
            Ifsc: $scope.Ifsc,
            Micr: $scope.Micr,
            AccountNumber: $scope.AccountNumber,

        }  
        var LogoData = {
            InstituteId: $scope.InstituteId
        }
         
        Service.Post("Institute/UpdateInstitute", JSON.stringify(InstituteData)).then(function (response) {
            $scope.UpdateAddressDetail(AddressData);
            $scope.UpdateBankDetail(BankData);
            $scope.UpdateLogoDetail(LogoData);

        });
        $scope.Initialize();
        $scope.IsVisible = false;
        $scope.Visible = true;

    }
    $scope.UpdateAddressDetail = function (AddressData) {
        debugger;
        Service.Post("Institute/UpdateInstituteAddress", JSON.stringify(AddressData)).then(function (response) {
            alert('Address');
        });

    }
    $scope.UpdateBankDetail = function (BankData) {
        debugger;
        Service.Post("Institute/UpdateInstituteBank", JSON.stringify(BankData)).then(function (response) {
            alert('Bank');
        });

    }
    $scope.UpdateLogoDetail = function (LogoData) {
        debugger;
        var payload = new FormData();
        payload.append("Data", JSON.stringify(LogoData));
        payload.append("HeaderName", $scope.HeaderName);
        payload.append("LogoName", $scope.LogoName);  
        Service.PostFile("Institute/UpdateInstituteLogo", payload).then(function (response) {
            alert('Logo');
        });

    }
    $scope.Delete = function (InstituteId) {
        debugger;

        var data = {

            InstituteId: InstituteId

        };
        Service.Post("Institute/DeleteInstitute", JSON.stringify(data)).then(function (rd) {
            $scope.Initialize()
            if (rd.data.IsSucess) {
                alert('Success')
            }
        })

    }
    $scope.Clear = function () {
        debugger;
        $scope.SectionId = null;
        $scope.UdiseNo = null;
        $scope.InstituteName = null;
        $scope.BoardId = null;
        $scope.AffilationNo = null;
        $scope.InstituteOrganizationName = null;
        $scope.OrganizationAddress = null;
        $scope.OrganizationRegistrationNo = null;
        $scope.InstituteId = null;
        $scope.InstituteId = null;
        $scope.Address1 = null;
        $scope.Address2 = null;
        $scope.CityName = null;
        $scope.StateId = null;
        $scope.Pincode = null;
        $scope.LandlineNumber = null;
        $scope.PhoneNumber1 = null;
        $scope.PhoneNumber2 = null;
        $scope.Fax = null;
        $scope.InstituteEmail = null;
        $scope.PrinciaplEmail = null;
        $scope.Website = null;
        $scope.InstituteId = null;
        $scope.IndexNo = null;
        $scope.PanNo = null;
        $scope.TanNo = null;
        $scope.Gstin = null;
        $scope.BankName = null;
        $scope.Ifsc = null;
        $scope.Micr = null;
        $scope.AccountNumber = null;
        $scope.HeaderName = null;
        $scope.LogoName = null;
        $scope.IsVisible = false;
        $scope.Visible = true;
    }
}