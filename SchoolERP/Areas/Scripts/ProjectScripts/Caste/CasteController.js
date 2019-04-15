var app = angular.module('ERP').controller('CasteController', CasteController);

function CasteController($scope, Service, $timeout) {

    var form = $(".student-admission-wrapper");
    $scope.ViewGetStudentInfoes = {};
    $scope.UserCredentialModel = {};
    $scope.btnactive = 1;
    $scope.myText = "/Content/Loader4.gif";
    $scope.isCheck = true;
    $scope.btnu = false;
    $scope.btns = false;
    $scope.btnValue = "SAVE";


    $scope.Initialize = function () {
        debugger;
        $scope.UserCredentialModel.Status = $scope.btnactive;
        Service.Post("Caste/GetCasteMaster", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.Castes = result.data.ResultData;
            $scope.GetReligion();
            $scope.GetCategory();
            //console.log(result.data);
        })
    }

    $scope.GetReligion = function () {

        Service.Post("Caste/GetReligion").then(function (result) {
            debugger;
            $scope.Religions = result.data.ResultData;
            console.log(result.data);
        })
    }

    $scope.GetCategory = function () {

        Service.Post("Caste/GetCategory").then(function (result) {
            debugger;
            $scope.Categorys = result.data.ResultData;
            console.log(result.data);
        })
    }

    $scope.ShowHide = function (CasteID) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.IsVisible = true;
        var data = {
            CasteID: CasteID
        };

        Service.Post("Caste/GetSingleCasteInfo", JSON.stringify(data), $scope.UserCredentialModel).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;

            $scope.CasteName = result.data.CasteName;
            $scope.ReligionID = result.data.ReligionID;
            $scope.CategoryID = result.data.CategoryID;
            $scope.CasteID = result.data.CasteID;
            // $scope.Students = result.data.ResultData;

            $scope.Initialize();
        })
    }


    $scope.ShowHideSave = function () {
        debugger;
        $scope.btnUpdate = false;
        $scope.btnSave = true;
        $scope.IsVisible = true;
    }


    $scope.Clear = function () {

        $scope.CasteName = null;
        $scope.ReligionID = null;
        $scope.CategoryID = null;
        $scope.CasteID = null;
        $scope.IsVisible = false;
        // $scope.Initialize();
    }

    $scope.AddUpdate = function (CasteID,ReligionID,CategoryID, CasteName, BtnStatus) {
        var data = {
            CasteID: CasteID,
            ReligionID: ReligionID,
            CategoryID:CategoryID,
            CasteName: CasteName,
            BtnStatus: BtnStatus 
        };
        if ($scope.form.$valid) {
            $scope.btns = true;
            $scope.btnu = true;
            $scope.isCheck = false;
            $scope.btnValue = "SAVING.........";
            $timeout(function () {
                $scope.isCheck = true;
                $scope.btnSave = false;
                $scope.btnValue = "SAVE";
                Service.Post("Caste/SaveCaste", JSON.stringify(data)).then(function (response) {

                    if (response.data.IsSucess) {
                        debugger;
                        CustomizeApp.AddMessage();
                        $scope.Clear();
                        $scope.IsVisible = false;
                        $scope.Initialize();

                    }
                    else {
                        debugger;
                        ShowMessage(0, response.data.Message);

                    }
                });
            }, 3000);
        }
    }


    $scope.Delete = function (CasteID) {
        debugger;
        var data = {

            CasteID: CasteID
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the caste?");

        }
        else {
            var confirm = window.confirm("Do you want to active the caste?");
        }
        if (confirm == true) {
            Service.Post("Caste/DeleteCaste", JSON.stringify(data)).then(function (response) {

                debugger;
                if (response.data)
                    $scope.Initialize();
                alert(response.data.ResultData);
            });
        }
        $scope.Clear();
        $scope.IsVisible = false;
        $scope.Initialize();

    }

}
