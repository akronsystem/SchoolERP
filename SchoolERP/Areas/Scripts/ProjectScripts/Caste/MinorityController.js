var app = angular.module('ERP').controller('MinorityController', MinorityController);

function MinorityController($scope, Service) {

    var form = $(".student-admission-wrapper");
    $scope.ViewGetStudentInfoes = {};
    $scope.UserCredentialModel = {};
    $scope.btnactive = 1;


    $scope.Initialize = function () {
        debugger;
        $scope.UserCredentialModel.Status = $scope.btnactive;
        Service.Post("Caste/GetMinorityMaster", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.Minoritys = result.data.ResultData;
            //console.log(result.data);
        })
    }

    $scope.ShowHide = function (MinorityID) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.IsVisible = true;
        var data = {
            MinorityID: MinorityID
        };

        Service.Post("Caste/GetSingleMinorityInfo", JSON.stringify(data), $scope.UserCredentialModel).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;

            $scope.MinorityName = result.data.MinorityName;
            $scope.MinorityID = result.data.MinorityID;
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

        $scope.MinorityName = null;
        $scope.MinorityID = null;
        $scope.IsVisible = false;
        // $scope.Initialize();
    }

    $scope.AddUpdate = function (MinorityID, MinorityName, BtnStatus) {
        var data = {
            MinorityID: MinorityID,
            MinorityName: MinorityName,
            BtnStatus: BtnStatus
        };
        if ($scope.form.$valid) {
            Service.Post("Caste/SaveMinority", JSON.stringify(data)).then(function (response) {

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
        }
    }


    $scope.Delete = function (MinorityID) {
        debugger;
        var data = {

            MinorityID: MinorityID
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the minority?");

        }
        else {
            var confirm = window.confirm("Do you want to active the minority?");
        }
        if (confirm == true) {
            Service.Post("Caste/DeleteMinority", JSON.stringify(data)).then(function (response) {

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
