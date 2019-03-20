var app = angular.module('ERP').controller('EmployeeController', EmployeeController);

function EmployeeController($scope, Service, $window) {

    var form = $(".student-admission-wrapper");
    $scope.ViewGetStudentInfoes = {};
    $scope.UserCredentialModel = {};
    $scope.btnactive = 1;
    $scope.IsAddress = false;
    var index = 0;
    $scope.Store = [];
    $scope.Customers = [];
    $scope.Sample = [];
    $scope.StoreData = [];
    $scope.SaveContinue = false;
    $scope.IsVisible = false;
    $scope.Visible = true;
    $scope.btnupdate = true;
    $scope.btnsave = true;
    $scope.UpdateDetails = false;
    $scope.SaveDetails = true;
    $scope.RemoveED = true;
    $scope.RemoveSave = true;
    $scope.ExperienceSBtn = true;
    $scope.ExperienceUBtn = false;
    $scope.AddExp = true;
    $scope.RemoveExp = false;
    $scope.Initialize = function () {
        debugger;
        Data = {
            Status: $scope.btnactive
        }
        Service.Post("EmployeeMaster/GetEmployeeInfo", JSON.stringify(Data)).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.EmployeeInfoData = result.data;
            //console.log(result.data);

        })
    }

    //Drop down methods
    //1.Get EmployeeTyep
    $scope.GetEmployeeType = function () {
        debugger;
        $scope.UserCredentialModel.Status = $scope.btnactive;
        Service.Post("EmployeeMaster/GetEmployeeType", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.EmployeeData = result.data.ResultData;
            //console.log(result.data);

        })
    }
    //2.Section
    $scope.GetSection = function () {
        debugger;
        $scope.UserCredentialModel.Status = $scope.btnactive;
        Service.Post("EmployeeMaster/GetSection", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.SectionData = result.data.ResultData;
            //console.log(result.data);

        })
    }
    //3.State
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
    //4.District
    $scope.GetDistrict = function (StateID) {
        debugger;
        var Data = {
            StateID: StateID
        };
        Service.Post("StateMaster/GetStateUnderTaluka", JSON.stringify(Data)).then(function (result) {
            $scope.ParentDistrict = result.data;
            console.log(result.data);

        })
    }
    //5.Taluka
    $scope.GetTaluka = function (StateID, DistrictID) {
        debugger;
        var Data = {
            StateID: StateID,
            DistrictID: DistrictID
        };
        Service.Post("EmployeeMaster/GetStateDistrictUnderTaluka", JSON.stringify(Data)).then(function (result) {
            $scope.TalukaList = result.data;
            console.log(result.data);

        })
    }
    //6.Shift
    $scope.GetShift = function () {
        debugger;
        $scope.UserCredentialModel = {};
        Service.Post("ShiftMaster/GetShiftInfo", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.ShiftDetails = result.data;
            //console.log(result.data);

        })
    }
    //7.Designation
    $scope.GetDesignation = function () {
        debugger;
        $scope.UserCredentialModel = {};
        Service.Post("EmployeeMaster/GetDesignation", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.DesignationData = result.data.ResultData;
            //console.log(result.data);

        })
    }
    //8.Caste
    $scope.GetCaste = function () {
        debugger;
        $scope.UserCredentialModel.Status = 1;
        Service.Post("EmployeeMaster/GetCategoryList", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.CasteData = result.data.ResultData;
            //console.log(result.data);

        })
    }
    //Religion
    $scope.GetReligion = function (CasteID) {
        debugger;
        var Data = {
            CasteID: CasteID,
            Status:1
        };
        Service.Post("EmployeeMaster/GetReligionList", JSON.stringify(Data)).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.ReligionData = result.data.ResultData;
            //console.log(result.data);

        })
    }
    //CorrospondAddress For Drodownlist
    $scope.GetCorrState = function () {
        debugger;
        $scope.UserCredentialModel = {};
        Service.Post("StateMaster/GetState", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.StateCorrList = result.data;
            //console.log(result.data);

        })
    }
    //9.District
    $scope.GetCorrDistrict = function (CorrespondanceStateID) {
        debugger;
        var Data = {
            StateID: CorrespondanceStateID
        };
        Service.Post("StateMaster/GetStateUnderTaluka", JSON.stringify(Data)).then(function (result) {
            $scope.ParentCorrDistrict = result.data;
            console.log(result.data);

        })
    }
    //10.Taluka
    $scope.GetCorrTaluka = function (CorrespondanceStateID, CorrespondanceDistrictID) {
        debugger;
        var Data = {
            StateID: CorrespondanceStateID,
            DistrictID: CorrespondanceDistrictID
        };
        Service.Post("EmployeeMaster/GetStateDistrictUnderTaluka", JSON.stringify(Data)).then(function (result) {
            $scope.TalukaCorrList = result.data;
            console.log(result.data);

        })
    }
   //11.ExperienceType
    $scope.GetExperienceType = function () {
        debugger;
        $scope.UserCredentialModel = {};
        Service.Post("ExperienceType/GetExprienceTypeInfo", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.ExperienceTypeList = result.data;
            //console.log(result.data);

        })
    };


    $scope.ShowDiv = function () {
        //alert('Heloooo');
        $scope.IsAddress = true;
        if ($scope.Selected == true)
        {
            $scope.CorrespondanceAddress = $scope.PermanentAddress;
            $scope.CorrespondanceStateID = $scope.PermanantStateID;
            $scope.CorrespondanceDistrictID = $scope.PermanantDistrictID;
            $scope.CorrespondanceTalukaID = $scope.PermanantTalukaID;
            $scope.CorrespondancePincode = $scope.PermanantPincode;
            $scope.CorrespondanceCountry = $scope.PermanentCountry;

        }
        else
        {
            $scope.CorrespondanceAddress = "";
            $scope.CorrespondanceStateID = "";
            $scope.CorrespondanceDistrictID = "";
            $scope.CorrespondanceTalukaID = "";
            $scope.CorrespondancePincode = "";
            $scope.CorrespondanceCountry = "";
        }
    }
    //Upload Documents
    $scope.UploadData = function (Path, DocumentType) {
        debugger;
        if ($scope.DetailsDocument == null) {
            if ($scope.UploadDocument == null) {
                $scope.UploadDocument = [];
                $scope.PathDocument = [];
                $scope.UploadDocument.push(Path);
                $scope.PathDocument.push({ DocumentType: DocumentType });
                $scope.Details = $scope.UploadDocument;
                $scope.DetailsDocument = $scope.PathDocument;
            }
            else {
                $scope.UploadDocument.push(Path);

                $scope.Details = $scope.UploadDocument;
                $scope.PathDocument.push({ DocumentType: DocumentType });
                $scope.DetailsDocument = $scope.PathDocument;
            }
        }
        else {
            if ($scope.UploadDocument == null) {
                $scope.UploadDocument = [];
                $scope.UploadDocument.push(Path);

                $scope.Details = $scope.UploadDocument;
                $scope.DetailsDocument.push({ DocumentType: DocumentType });
            }
            else {
                $scope.UploadDocument.push(Path);
                $scope.DetailsDocument.push({ DocumentType: DocumentType });
            }
            //$scope.DetailsDocument = $scope.PathDocument;
        }
        



    }
    
    $scope.RemoveDocument = function (index) {
        debugger;
        //Find the record using Index from Array.
        var AttachmentID = $scope.DetailsDocument[index].AttachmentID;
        var EmployeeID = $scope.DetailsDocument[index].EmployeeID;
        if ($window.confirm("Do you want to delete: " + DocumentType)) {
            //Remove the item from Array using Index.
            $scope.DetailsDocument.splice(index, 1);
            if (EmployeeID == undefined)
            {
                alert('un')
            }
            else
            {
                $scope.GetEmployeeDocumentUpdate(EmployeeID, AttachmentID)

            }
           
           
        }
    }
    //	Educational Details for add row and remove
    $scope.AddRow = function (index) {
        debugger;
        //Add the new item to the Array.
        var customer = [];
        customer.CourseName = $scope.CourseName;
        customer.PassingMothYear = $scope.PassingMothYear;
        customer.SchoolCollege = $scope.SchoolCollege;
        customer.UniversityBoard = $scope.UniversityBoard;
        customer.BoardDivisionState = $scope.BoardDivisionState;
        customer.CreditPercentageSGPA = $scope.CreditPercentageSGPA;
        $scope.Customers.push(customer);
        $scope.SaveContinue = true;
    }
    $scope.AddRowSave = function (index) {
        if (CourseName.length == null) {
            var EducationDetails = {
                CourseName: CourseName.value,
                PassingMothYear: PassingMothYear.value,
                SchoolCollege: SchoolCollege.value,
                UniversityBoard: UniversityBoard.value,
                BoardDivisionState: BoardDivisionState.value,
                CreditPercentageSGPA: CreditPercentageSGPA.value

            }
            $scope.StoreData.push(EducationDetails);
        }
        for (var i = 0; i < CourseName.length; i++) {
        EducationDetails = {
                CourseName: CourseName[i].value,
                PassingMothYear: PassingMothYear[i].value,
                SchoolCollege: SchoolCollege[i].value,
                UniversityBoard: UniversityBoard[i].value,
                BoardDivisionState: BoardDivisionState[i].value,
                CreditPercentageSGPA: CreditPercentageSGPA[i].value

            }
        $scope.StoreData.push(EducationDetails);
        }

       
        $scope.SaveContinue = false;
        //$scope.Customers.splice(0, 1);
        //Clear the TextBoxes.
        $scope.CourseName = "";
        $scope.PassingMothYear = "";
        $scope.SchoolCollege = "";
        $scope.UniversityBoard = "";
        $scope.BoardDivisionState = "";
        $scope.CreditPercentageSGPA = "";
    }



    $scope.Remove = function (index) {
        debugger;
        //Find the record using Index from Array.
        var name = $scope.Customers[index].CourseName;
        if ($window.confirm("Do you want to delete: " + name)) {
            //Remove the item from Array using Index.
            $scope.Customers.splice(index, 1);
        }
    }
    $scope.AddRowUpdate = function (index) {
        $scope.Customers = [];
        EmployeeID = $scope.EmployeeID;
        if (CourseName.length == null) {
            var EducationDetails = {
                CourseName: CourseName.value,
                PassingMothYear: PassingMothYear.value,
                SchoolCollege: SchoolCollege.value,
                UniversityBoard: UniversityBoard.value,
                BoardDivisionState: BoardDivisionState.value,
                CreditPercentageSGPA: CreditPercentageSGPA.value,
                EmployeeID: EmployeeID
            }
            $scope.Customers.push(EducationDetails);
        }
        for (var i = 0; i < CourseName.length; i++) {
            EducationDetails = {
                CourseName: CourseName[i].value,
                PassingMothYear: PassingMothYear[i].value,
                SchoolCollege: SchoolCollege[i].value,
                UniversityBoard: UniversityBoard[i].value,
                BoardDivisionState: BoardDivisionState[i].value,
                CreditPercentageSGPA: CreditPercentageSGPA[i].value,
                EmployeeID: EmployeeID

            }
            $scope.Customers.push(EducationDetails);
        }


        $scope.SaveContinue = false;
        //$scope.Customers.splice(0, 1);
        //Clear the TextBoxes.
        $scope.CourseName = "";
        $scope.PassingMothYear = "";
        $scope.SchoolCollege = "";
        $scope.UniversityBoard = "";
        $scope.BoardDivisionState = "";
        $scope.CreditPercentageSGPA = "";
    }
    $scope.RemoveEDUCATION = function (index) {
        debugger;
        //Find the record using Index from Array.
        var EducationID = $scope.Customers[index].EducationID;
        var EmployeeID = $scope.Customers[index].EmployeeID;
        if ($window.confirm("Do you want to delete: " + CourseName)) {
            //Remove the item from Array using Index.
            $scope.Customers.splice(index, 1);
            if (EmployeeID == undefined) {
                alert('Undefin');

            } else
            {
                $scope.GetEmployeeEducationUpdate(EmployeeID, EducationID)

            }


        }
    }
    //Experiance Details for add row and remove
    $scope.AddEXRow = function (index) {
        debugger;
        //Add the new item to the Array.
        var Experiance = [];
        Experiance.ExprienceTypeID = $scope.ExprienceTypeID;
        Experiance.Organization = $scope.Organization;
        Experiance.OrganizationAddress = $scope.OrganizationAddress;
        Experiance.Designation = $scope.Designation;
        Experiance.PeriodFrom = $scope.PeriodFrom;
        Experiance.PeriodTo = $scope.PeriodTo;
        Experiance.TotalExprience = $scope.TotalExprience;
        Experiance.ExperienceDocumentType = $scope.ExperienceDocumentType;
        $scope.Sample.push(Experiance);
        $scope.SaveContinue = true;
    }
    $scope.AddEXRowSave = function (index) {
        if (ExprienceTypeID.length == null) {
            debugger;
            var EXDetails = {
                
                ExprienceTypeID: ExprienceTypeID.value,
                Organization: Organization.value,
                OrganizationAddress: OrganizationAddress.value,
                Designation: Designation.value,
                PeriodFrom: PeriodFrom.value,
                PeriodTo: PeriodTo.value,
                TotalExprience: TotalExprience.value,
                ExperienceDocumentType: ExperienceDocumentType.files[0]["name"]

            }
            $scope.Store.push(EXDetails);
        }

        for (var i = 0; i < ExprienceTypeID.length; i++) {
            debugger;
            //if (ExperienceDocumentType[i].value == "") {
            //    ExperienceDocumentType == null;
            //} else {
            //    ExperienceDocumentType= ExperienceDocumentType[i].files[0]["name"]
            //}
             EXDetails = {
                ExprienceTypeID: ExprienceTypeID[i].value,
                Organization: Organization[i].value,
                OrganizationAddress: OrganizationAddress[i].value,
                Designation: Designation[i].value,
                PeriodFrom: PeriodFrom[i].value,
                PeriodTo: PeriodTo[i].value,
                TotalExprience: TotalExprience[i].value,
                
                ExperienceDocumentType: ExperienceDocumentType

            }
             $scope.Store.push(EXDetails);

        }

        
        $scope.SaveContinue = false;
        //$scope.Customers.splice(0, 1);
        //Clear the TextBoxes.
        $scope.CourseName = "";
        $scope.PassingMothYear = "";
        $scope.SchoolCollege = "";
        $scope.UniversityBoard = "";
        $scope.BoardDivisionState = "";
        $scope.CreditPercentageSGPA = "";
    }



    $scope.RemoveEX = function (index) {
        debugger;
        //Find the record using Index from Array.
        var name = $scope.Sample[index].CourseName;
        if ($window.confirm("Do you want to delete: " + name)) {
            //Remove the item from Array using Index.
            $scope.Sample.splice(index, 1);
        }
    }
    $scope.RemoveExperience= function (index) {
        debugger;
        //Find the record using Index from Array.
        var ExprienceID = $scope.Sample[index].ExprienceID;
        var EmployeeID = $scope.Sample[index].EmployeeID;
        if ($window.confirm("Do you want to delete: " + CourseName)) {
            //Remove the item from Array using Index.
            $scope.Sample.splice(index, 1);
            if (EmployeeID == undefined) {
                alert('Undefin');

            } else {
                $scope.GetEmployeeExperienceUpdate(EmployeeID, ExprienceID)

            }


        }
    }
    $scope.UpdateEXRowSave = function (index) {
        $scope.Store = [];
        EmployeeID = $scope.EmployeeID;
        if (ExprienceTypeID.length == null) {
            debugger;
            
            var EXDetails = {

                ExprienceTypeID: ExprienceTypeID.value,
                Organization: Organization.value,
                OrganizationAddress: OrganizationAddress.value,
                Designation: Designation.value,
                PeriodFrom: PeriodFrom.value,
                PeriodTo: PeriodTo.value,
                TotalExprience: TotalExprience.value,
                ExperienceDocumentType: ExperienceDocumentType.files[0]["name"],
                EmployeeID: EmployeeID,
                ExprienceID: ExprienceID.value
            }
            $scope.Store.push(EXDetails);
        }
        for (var i = 0; i < ExprienceTypeID.length; i++) {
            debugger;
            if (ExperienceDocumentType[i].value == "") {
                var Document = null;
            }
            else {
                Document = ExperienceDocumentType[i].files[0]["name"]
            }
            EXDetails = {
                ExprienceTypeID: ExprienceTypeID[i].value,
                Organization: Organization[i].value,
                OrganizationAddress: OrganizationAddress[i].value,
                Designation: Designation[i].value,
                PeriodFrom: PeriodFrom[i].value,
                PeriodTo: PeriodTo[i].value,
                TotalExprience: TotalExprience[i].value,
                EmployeeID: EmployeeID,
                ExperienceDocumentType: Document,
                ExprienceID: ExprienceID[i].value

            }
            $scope.Store.push(EXDetails);

        }


        $scope.SaveContinue = false;
        //$scope.Customers.splice(0, 1);
        //Clear the TextBoxes.
        $scope.Organization = "";
        $scope.OrganizationAddress = "";
        $scope.Designation = "";
        $scope.PeriodFrom = "";
        $scope.PeriodTo = "";
        $scope.TotalExprience = "";
    }

    //Appointment Details
    $scope.GradeScale = function (SrGradeScaleApplicable) {
        debugger;
        if (SrGradeScaleApplicable == "Yes")
        {
            $scope.GradeScaleDate = false;
        }
        else
        {
            $scope.GradeScaleDate = true;
        }

    }
    
    $scope.ChnageID = function (SelectionGradeScaleApplicable) {
        debugger;
        if (SelectionGradeScaleApplicable == "Yes") {
            
            $scope.ISHiide = false;
        }
        else {
            $scope.ISHiide = true;
        }

    }

    //Save Employee
    $scope.Add = function () {
        debugger;
       
        var DateofBirth = $('#m_datepicker_1').val();
        var JoiningDate = $('#m_datepicker_2').val();
        var SrGradeScaleApplicableDate = $('#m_datepicker_3').val();
        var SelectionGradeScaleApplicableDate = $('#m_datepicker_4_1').val();

        var EmployeeData = {
            EmployeeName:$scope.EmployeeName,
            EmployeeCode: $scope.EmployeeCode,
            EmployeeTypeID: $scope.EmployeeTypeID,
            SectionID: $scope.SectionID,
            DepartmentID: $scope.DepartmentID,
            DesignationID: $scope.DesignationID,
            Gender: $scope.Gender,
            MobileNo: $scope.MobileNo,
            AlternateMobileNo: $scope.AlternateMobileNo,
            EmailID: $scope.EmailID,
            AlternateEmailID: $scope.AlternateEmailID,
            BloodGroup: $scope.BloodGroup,
            ReligionID: $scope.ReligionID,
            CategoryID: $scope.CategoryID,
            CasteID: $scope.CasteID,
            SubCasteID: $scope.SubCasteID,
            DateofBirth: DateofBirth,
            ShiftID: $scope.ShiftID
           

        };
        var AddressDetails = {
            PermanentAddress: $scope.PermanentAddress,
            PermanantStateID: $scope.PermanantStateID,
            PermanantDistrictID: $scope.PermanantDistrictID,
            PermanantTalukaID: $scope.PermanantTalukaID,
            PermanantPincode: $scope.PermanantPincode,
            PermanentCountry: $scope.PermanentCountry,
            CorrespondanceAddress: $scope.CorrespondanceAddress,
            CorrespondanceStateID: $scope.CorrespondanceStateID,
            CorrespondanceDistrictID: $scope.CorrespondanceDistrictID,
            CorrespondanceTalukaID: $scope.CorrespondanceTalukaID,
            CorrespondancePincode: $scope.CorrespondancePincode,
            CorrespondanceCountry: $scope.CorrespondanceCountry

        }
        var EducationDetails = {
            CourseName: $scope.CourseName,
            PassingMothYear: $scope.PassingMothYear,
            SchoolCollege: $scope.SchoolCollege,
            UniversityBoard: $scope.UniversityBoard,
            BoardDivisionState: $scope.BoardDivisionState,
            CreditPercentageSGPA: $scope.CreditPercentageSGPA

        }
        var AppointmentDetails = {
            AppointmentType: $scope.AppointmentType,
            JobType: $scope.JobType,
            JoiningDate:JoiningDate,
            SrGradeScaleApplicable: $scope.SrGradeScaleApplicable,
            SrGradeScaleApplicableDate: SrGradeScaleApplicableDate,
            SelectionGradeScaleApplicable: $scope.SelectionGradeScaleApplicable,
            SelectionGradeScaleApplicableDate:SelectionGradeScaleApplicableDate

        }
        var BankDetails = {
            BankName: $scope.BankName,
            AccountNumber: $scope.AccountNumber,
            BranchName: $scope.BranchName,
            IFSCCode: $scope.IFSCCode,
            MICRCode: $scope.MICRCode,
            UAN: $scope.UAN,
            PF:$scope.PF
        }
        var payload = new FormData();
       
        payload.append("data", JSON.stringify(EmployeeData));
        payload.append("ImagePath",$scope.ImagePath);
        payload.append("Sign", $scope.Sign); 

        
         if ($scope.form.$valid) {

            Service.PostFile("EmployeeMaster/AddEmployee", payload).then(function (response) {
                debugger;
              
                if (response.data.IsSucess) {
                    debugger;
                    $scope.SaveAddressDetail(AddressDetails);
                    $scope.BankDetail(BankDetails);
                    $scope.EducationDetail();
                    $scope.AppointmentDetail(AppointmentDetails);    
                    $scope.DocumentDetailSave();
                    $scope.ExperienceDetail();
                    //CustomizeApp.UpdateMessage();
                    $scope.Clear();
                    $scope.IsVisible = false;
                    $scope.Initialize();
                    alert(response.data.ResultData);
                    // window.location = "./ParentGrievance"

                    //alert(result.data);

                }
                else {
                    debugger;
                    //ShowMessage(0, response.data.Message);
                    alert(response.data.Message);
                    //$scope.clear();
                    //window.location = "./PostGrievance"
                }

            });
        }
    }
    $scope.SaveAddressDetail = function (AddressDetails) {
        debugger;
        Service.Post("EmployeeMaster/AddAddressDetails", JSON.stringify(AddressDetails)).then(function (response) {
            alert('Address');
        });

    }
    $scope.EducationDetail = function () {
        Service.Post("EmployeeMaster/AddEducationDetails", JSON.stringify($scope.StoreData)).then(function (response) {
            alert('Education');
        });

    }
    $scope.BankDetail = function (BankDetails) {
        Service.Post("EmployeeMaster/AddBankDetails", JSON.stringify(BankDetails)).then(function (response) {
            alert('Bank');
        });

    }
    $scope.AppointmentDetail = function (AppointmentDetails) {
        Service.Post("EmployeeMaster/AddAppointmentDetails", JSON.stringify(AppointmentDetails)).then(function (response) {
            alert('Appointment');
        });

    }
    $scope.ExperienceDetail = function () {
        debugger;
        Service.Post("EmployeeMaster/AddExperienceDetails", JSON.stringify($scope.Store)).then(function (response) {
            alert('ExperienceDetail');
        });

    }
    $scope.DocumentDetailSave = function () {
        $scope.s = [];
        $scope.b = [];
        for (var i = 0; i < $scope.DetailsDocument.length; i++) {

            var payload1 = new FormData();

            alert($scope.DetailsDocument[i].Document);
            $scope.s.push($scope.DetailsDocument[i]["DocumentType"]);
            $scope.b.push($scope.Details[i]["name"]);
            var temp = $scope.s;
            var tempr = $scope.b;
           // alert($scope.Details[i]);
           //var tempr = $scope.Details[i]["name"] + "," + $scope.Details[i]["name"];
            payload1.append("UploadName", $scope.s);
            payload1.append("file1", $scope.b);
        }
       
        debugger;
        Service.PostFile("EmployeeMaster/AddUploadDetails", payload1).then(function (response) {
            alert('Appointment');
        });

    }

    $scope.Verify = function (EmployeeID,EmployeeCode) {
        debugger;
        $scope.Initialize();
        var data = {
            EmployeeCode: EmployeeCode,
            EmployeeID: EmployeeID
            //BoardId: BoardId
        };
        Service.Post("EmployeeMaster/GetSingleEmployee", JSON.stringify(data)).then(function (rd) {
            alert('getsingle')
            debugger;
            $scope.IsVisible = true;
            $scope.Visible = false;
            $scope.isDisabled = true;
            $scope.btnupdate = false;
            $scope.btnsave = true;
            $scope.passwordvisible = false;
            $scope.UpdateDetails = true;
            $scope.SaveDetails = false;
            $scope.RemoveED = true;
            $scope.RemoveSave = false;
            $scope.ExperienceSBtn = false;
            $scope.ExperienceUBtn = true;
            $scope.AddExp = false;
            $scope.RemoveExp = true;
            $scope.SchoolInfo = rd.data.ResultData;
            $scope.Department = rd.data.ResultData.Department;
            $scope.DepartmentID = rd.data.ResultData.DepartmentID;
            $scope.Designation = rd.data.ResultData.Designation;
            $scope.DesignationID = rd.data.ResultData.DesignationID;
            $scope.District = rd.data.ResultData.District;
            $scope.EmployeeCode = rd.data.ResultData.EmployeeCode;
            $scope.EmployeeID = rd.data.ResultData.EmployeeID;
            $scope.EmployeeName = rd.data.ResultData.EmployeeName;
            $scope.Gender = rd.data.ResultData.Gender;
            $scope.MobileNo = rd.data.ResultData.MobileNo;
            $scope.DistrictID = rd.data.ResultData.DistrictID;
            $scope.PermanantDistrictID = rd.data.ResultData.PermanantDistrictID;
            $scope.PermanantStateID = rd.data.ResultData.PermanantStateID;
            $scope.PermanantTalukaID = rd.data.ResultData.PermanantTalukaID;
            $scope.PermanentAddress = rd.data.ResultData.PermanentAddress;
            $scope.SectionID = rd.data.ResultData.SectionID;
            $scope.SectionName = rd.data.ResultData.SectionName;
            $scope.State = rd.data.ResultData.State;
            $scope.PermanantPincode = rd.data.ResultData.PermanantPincode;
            $scope.AlternateEmailID = rd.data.ResultData.AlternateEmailID;
            $scope.AlternateMobileNo = rd.data.ResultData.AlternateMobileNo;
            $scope.BloodGroup = rd.data.ResultData.BloodGroup;
            $scope.CasteID = rd.data.ResultData.CasteID;
            $scope.CasteName = rd.data.ResultData.CasteName;
            $scope.CategoryID = rd.data.ResultData.CategoryID;
            $scope.CategoryName = rd.data.ResultData.CategoryName;
            $scope.DateofBirth = rd.data.ResultData.DateofBirth;
            $scope.EmailID = rd.data.ResultData.EmailID;
            $scope.ImagePath = rd.data.ResultData.ImagePath;
            $scope.PermanentCountry = rd.data.ResultData.PermanentCountry;
            $scope.ReligionID = rd.data.ResultData.ReligionID;
            $scope.ReligionName = rd.data.ResultData.ReligionName;
            $scope.ShiftID = rd.data.ResultData.ShiftID;
            $scope.ShiftName = rd.data.ResultData.ShiftName;
            $scope.Sign = rd.data.ResultData.Sign;
            $scope.SubCasteID = rd.data.ResultData.SubCasteID;

            $scope.AccountNumber = rd.data.ResultData.AccountNumber;
            $scope.AppointmentType = rd.data.ResultData.AppointmentType;
            $scope.BankName = rd.data.ResultData.BankName;
            $scope.BranchName = rd.data.ResultData.BranchName;
            $scope.CorrespondanceAddress = rd.data.ResultData.CorrespondanceAddress;
            $scope.CorrespondanceCountry = rd.data.ResultData.CorrespondanceCountry;
            $scope.CorrespondanceDistrictID = rd.data.ResultData.CorrespondanceDistrictID;
            $scope.CorrespondancePincode = rd.data.ResultData.CorrespondancePincode;
            $scope.CorrespondanceStateID = rd.data.ResultData.CorrespondanceStateID;
            $scope.CorrespondanceTalukaID = rd.data.ResultData.CorrespondanceTalukaID;
            $scope.IFSCCode = rd.data.ResultData.IFSCCode;
            $scope.MICRCode = rd.data.ResultData.MICRCode;
            $scope.PF = rd.data.ResultData.PF;
            $scope.SelectionGradeScaleApplicable = rd.data.ResultData.SelectionGradeScaleApplicable;
            $scope.SelectionGradeScaleApplicableDate = rd.data.ResultData.SelectionGradeScaleApplicableDate;
            $scope.SrGradeScaleApplicable = rd.data.ResultData.SrGradeScaleApplicable;
            $scope.SrGradeScaleApplicableDate = rd.data.ResultData.SrGradeScaleApplicableDate;
            $scope.UAN = rd.data.ResultData.UAN;
            $scope.JoiningDate = rd.data.ResultData.JoiningDate;
            $scope.JobType = rd.data.ResultData.JobType;

            $scope.ExprienceType = rd.data.ResultData.ExprienceType;
            $scope.ExprienceTypeID = rd.data.ResultData.ExprienceTypeID;

            debugger;
            $scope.GetEmployeeEducation(EmployeeCode);
            $scope.GetEmployeeExperience(EmployeeCode);
            $scope.GetEmployeeDocument(EmployeeCode);
            //$scope.boardidarray = $scope.BoardID.split(',');
            //for (var i = 0; i < $scope.boardidarray.length; i++) {
            //    $scope.change($scope.boardidarray[i], true);
            //    $scope.checkID($scope.boardidarray[i]);
            //    if ($scope.board["BoardId"] === $scope.boardidarray[i][""])
            //    {
            //        alert("Hiiiye");
            //        $scope.checkID(BoardId)=true;
            //    }
            //    $scope.checkID($scope.boardidarray[i]);
            //}

        })
    }
    $scope.GetEmployeeEducation = function (EmployeeCode) {
        debugger;
      
        var data = {

            EmployeeCode: EmployeeCode
            //BoardId: BoardId
        };
        Service.Post("EmployeeMaster/GetSingleEducationDetails", JSON.stringify(data)).then(function (rd) {
            //alert('getsingle')
            debugger;          
            $scope.Customers = rd.data.ResultData;
          

        })
    }
    $scope.GetEmployeeExperience = function (EmployeeCode) {
        debugger;
        
        var data = {

            EmployeeCode: EmployeeCode
            //BoardId: BoardId
        };
        Service.Post("EmployeeMaster/GetSingleExperienceDetails", JSON.stringify(data)).then(function (rd) {
            //alert('getsingle')
            debugger;
            $scope.Sample= rd.data.ResultData;


        })
    }
    $scope.GetEmployeeDocument = function (EmployeeCode) {
        debugger;

        var data = {

            EmployeeCode: EmployeeCode
            //BoardId: BoardId
        };
        Service.Post("EmployeeMaster/GetSingleDucumentDetails", JSON.stringify(data)).then(function (rd) {
            //alert('getsingle')
            debugger;
            $scope.DetailsDocument = rd.data.ResultData;


        })
    }
    $scope.GetEmployeeDocumentUpdate = function (EmployeeID, AttachmentID) {
        debugger;

        var data = {

            EmployeeID: EmployeeID,
            AttachmentID: AttachmentID
            //BoardId: BoardId
        };
        Service.Post("EmployeeMaster/GetSingleDucumentDetailsUpdate", JSON.stringify(data)).then(function (rd) {
            //alert('getsingle')
            debugger;
            $scope.DetailsDocument;
            
        })
    }
    $scope.GetEmployeeEducationUpdate = function (EmployeeID, EducationID) {
        debugger;

        var data = {

            EmployeeID: EmployeeID,
            EducationID: EducationID
            //BoardId: BoardId
        };
        Service.Post("EmployeeMaster/GetSinglEducationDetailsUpdate", JSON.stringify(data)).then(function (rd) {
            //alert('getsingle')
            debugger;
            $scope.Customers;

        })
    }
    $scope.GetEmployeeExperienceUpdate = function (EmployeeID, ExprienceID) {
        debugger;

        var data = {

            EmployeeID: EmployeeID,
            ExprienceID: ExprienceID
            //BoardId: BoardId
        };
        Service.Post("EmployeeMaster/GetSinglExperianceDetailsUpdate", JSON.stringify(data)).then(function (rd) {
            //alert('getsingle')
            debugger;
            $scope.Sample;

        })
    }
    $scope.Update = function ()
    {
        debugger;
        var DateofBirth = $('#m_datepicker_1').val();
        var JoiningDate = $('#m_datepicker_2').val();
        var SrGradeScaleApplicableDate = $('#m_datepicker_3').val();
        var SelectionGradeScaleApplicableDate = $('#m_datepicker_4_1').val();
        var Data = {
            EmployeeID: $scope.EmployeeID
        };

        var EmployeeData = {
            EmployeeName: $scope.EmployeeName,
            EmployeeCode: $scope.EmployeeCode,
            //EmployeeTypeID: $scope.EmployeeTypeID,
            SectionID: $scope.SectionID,
            DepartmentID: $scope.DepartmentID,
            DesignationID: $scope.DesignationID,
            Gender: $scope.Gender,
            MobileNo: $scope.MobileNo,
            AlternateMobileNo: $scope.AlternateMobileNo,
            EmailID: $scope.EmailID,
            AlternateEmailID: $scope.AlternateEmailID,
            BloodGroup: $scope.BloodGroup,
            ReligionID: $scope.ReligionID,
            CategoryID: $scope.CategoryID,
            CasteID: $scope.CasteID,
            SubCasteID: $scope.SubCasteID,
            DateofBirth: DateofBirth,
            ShiftID: $scope.ShiftID


        };
        var EmployeeAddressDetails = {
            EmployeeID: $scope.EmployeeID,
            PermanentAddress: $scope.PermanentAddress,
            PermanantStateID: $scope.PermanantStateID,
            PermanantDistrictID: $scope.PermanantDistrictID,
            PermanantTalukaID: $scope.PermanantTalukaID,
            PermanantPincode: $scope.PermanantPincode,
            PermanentCountry: $scope.PermanentCountry,
            CorrespondanceAddress: $scope.CorrespondanceAddress,
            CorrespondanceStateID: $scope.CorrespondanceStateID,
            CorrespondanceDistrictID: $scope.CorrespondanceDistrictID,
            CorrespondanceTalukaID: $scope.CorrespondanceTalukaID,
            CorrespondancePincode: $scope.CorrespondancePincode,
            CorrespondanceCountry: $scope.CorrespondanceCountry

        }
        var EducationDetails = {
            EmployeeID: $scope.EmployeeID,
            CourseName: $scope.CourseName,
            PassingMothYear: $scope.PassingMothYear,
            SchoolCollege: $scope.SchoolCollege,
            UniversityBoard: $scope.UniversityBoard,
            BoardDivisionState: $scope.BoardDivisionState,
            CreditPercentageSGPA: $scope.CreditPercentageSGPA

        }
        var AppointmentDetails = {
            EmployeeID: $scope.EmployeeID,
            AppointmentType: $scope.AppointmentType,
            JobType: $scope.JobType,
            JoiningDate: JoiningDate,
            SrGradeScaleApplicable: $scope.SrGradeScaleApplicable,
            SrGradeScaleApplicableDate: SrGradeScaleApplicableDate,
            SelectionGradeScaleApplicable: $scope.SelectionGradeScaleApplicable,
            SelectionGradeScaleApplicableDate: SelectionGradeScaleApplicableDate

        }
        var BankDetails = {
            EmployeeID: $scope.EmployeeID,
            BankName: $scope.BankName,
            AccountNumber: $scope.AccountNumber,
            BranchName: $scope.BranchName,
            IFSCCode: $scope.IFSCCode,
            MICRCode: $scope.MICRCode,
            UAN: $scope.UAN,
            PF: $scope.PF
        }
        var payload = new FormData();

        payload.append("data", JSON.stringify(EmployeeData));
        payload.append("ImagePath", $scope.ImagePath);
        payload.append("Sign", $scope.Sign);
       
       
        Service.PostFile("EmployeeMaster/UpdateEmployee", payload).then(function (response) {
            $scope.UpdateAddressDetail(EmployeeAddressDetails);
            $scope.UpdateEducationDetail(Data);
           $scope.UpdateAppointmentDetail(AppointmentDetails);
           $scope.UpdateBankDetail(BankDetails);
           $scope.UpdateExperienceDetail();

        });
    }

    $scope.UpdateAddressDetail = function (EmployeeAddressDetails) {
        debugger;
        Service.Post("EmployeeMaster/UpdateEmployeeAddressDetails", JSON.stringify(EmployeeAddressDetails)).then(function (response) {
            alert('Address');
        });

    }
    $scope.UpdateEducationDetail = function (Data) {
        //$scope.Customers.push({ EmployeeID: Data });
        Service.Post("EmployeeMaster/UpdateEducationDetails", JSON.stringify($scope.Customers)).then(function (response) {
            alert('Education');
        });

    }
    $scope.UpdateAppointmentDetail = function (AppointmentDetails) {
        Service.Post("EmployeeMaster/UpdateAppointmentDetails", JSON.stringify(AppointmentDetails)).then(function (response) {
            alert('Appointment');
        });

    }
    $scope.UpdateBankDetail = function (BankDetails) {
        Service.Post("EmployeeMaster/UpdateBankDetails", JSON.stringify(BankDetails)).then(function (response) {
            alert('Bank');
        });

    }
    $scope.UpdateExperienceDetail = function () {
        debugger;
        Service.Post("EmployeeMaster/UpdateExperienceDetails", JSON.stringify($scope.Store)).then(function (response) {
            alert('ExperienceDetail');
        });

    }
    $scope.ShowHide = function () {
        $scope.IsVisible = true;
        $scope.Visible = false;
        $scope.btnupdate = true;
        $scope.btnsave = false;
    }
    $scope.Clear = function () {

        $scope.IsVisible = false;
        $scope.Visible = true;
    }
    $scope.Delete = function (EmployeeID) {
        debugger;

        var data = {

            EmployeeID: EmployeeID

        };
        Service.Post("EmployeeMaster/DeleteEmployee", JSON.stringify(data)).then(function (rd) {
            $scope.Initialize()
            if (rd.data.IsSucess) {
                alert('Success')
            }
        })

    }
}
