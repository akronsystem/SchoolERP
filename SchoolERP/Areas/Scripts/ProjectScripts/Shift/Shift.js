var app = angular.module('ERP').controller('ShiftController', ShiftController);

function ShiftController($scope, Service) {

    var form = $(".student-admission-wrapper");
    $scope.ViewGetStudentInfoes = {};
    $scope.UserCredentialModel = {};
    $scope.btnactive = 1;


    $scope.Initialize = function () {
        debugger;
        $scope.UserCredentialModel.Status = $scope.btnactive;
        Service.Post("ShiftMaster/GetShiftInfo", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.ShiftData = result.data;
            //console.log(result.data);

        })
    }

    $scope.ShowHide = function (ShiftID) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.IsVisible = true;
        var data = {

            ShiftID: ShiftID

        };

        Service.Post("ShiftMaster/GetSingleShiftInfo", JSON.stringify(data)).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;

            $scope.ShiftName = result.data.ResultData.ShiftName;
            $scope.ShiftID = result.data.ResultData.ShiftID;
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

        $scope.ShiftName = null;
        $scope.ShiftID = null;
        $scope.IsVisible = false;
       $scope.Initialize();
    }
    $scope.Add = function (ShiftID, ShiftName) {
        var data = {
            ShiftID: ShiftID,
            ShiftName: ShiftName

        };
        if ($scope.form.$valid) {
            Service.Post("ShiftMaster/AddShift", JSON.stringify(data)).then(function (response) {

                if (response.data.IsSucess) {
                    debugger;
                   CustomizeApp.AddMessage();
                    $scope.Clear();
                    $scope.IsVisible = false;
                    $scope.Initialize();
                    //alert(response.data.ResultData);
                    // window.location = "./ParentGrievance"

                    //alert(result.data);

                }
                else {
                    debugger;
                   ShowMessage(0, response.data.Message);
                    //alert(response.data.Message);
                    //$scope.clear();
                    //window.location = "./PostGrievance"
                }

            });
        }
    }

    $scope.AddUpdate = function (ShiftID, ShiftName) {
        var data = {
            ShiftID: ShiftID,
            ShiftName: ShiftName

        };
        if ($scope.form.$valid) {
            Service.Post("ShiftMaster/UpdateShift", JSON.stringify(data)).then(function (response) {

                if (response.data.IsSucess) {
                    debugger;
                    CustomizeApp.UpdateMessage();
                    $scope.Clear();
                    $scope.IsVisible = false;
                    $scope.Initialize();
                    //alert(response.data.ResultData);
                    // window.location = "./ParentGrievance"

                    //alert(result.data);

                }
                else {
                    debugger;
                    ShowMessage(0, response.data.Message);
                    //alert(response.data.Message);
                    //$scope.clear();
                    //window.location = "./PostGrievance"
                }

            });
        }
    }


    $scope.Delete = function (ShiftID) {
        debugger;
        var data = {

            ShiftID: ShiftID
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the Shift?");

        }
        else {
            var confirm = window.confirm("Do you want to active the Shift?");
        }
        if (confirm == true) {
            Service.Post("ShiftMaster/DeleteShift", JSON.stringify(data)).then(function (response) {

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
