var app = angular.module('ERP').controller('ReligionController', ReligionController);

function ReligionController($scope, Service, $timeout) {

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
        Service.Post("Caste/GetReligionMaster", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.Religions = result.data.ResultData;
            //console.log(result.data);
        })
    }

    $scope.ShowHide = function (ReligionID) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.IsVisible = true;
        var data = {
            ReligionID: ReligionID
        };

        Service.Post("Caste/GetSingleReligionInfo", JSON.stringify(data), $scope.UserCredentialModel).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;

            $scope.ReligionName = result.data.ReligionName;
            $scope.ReligionID = result.data.ReligionID;
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

        $scope.ReligionName = null;
        $scope.ReligionID = null;
        $scope.IsVisible = false;
        // $scope.Initialize();
    }

    $scope.AddUpdate = function (ReligionID, ReligionName,BtnStatus) {
        var data = {
            ReligionID: ReligionID,
            ReligionName: ReligionName,
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
                Service.Post("Caste/SaveReligion", JSON.stringify(data)).then(function (response) {

                    if (response.data.IsSucess) {
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


    $scope.Delete = function (ReligionID) {
        debugger;
        var data = {

            ReligionID: ReligionID
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the religion?");

        }
        else {
            var confirm = window.confirm("Do you want to active the religion?");
        }
        if (confirm == true) {
            Service.Post("Caste/DeleteReligion", JSON.stringify(data)).then(function (response) {

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
