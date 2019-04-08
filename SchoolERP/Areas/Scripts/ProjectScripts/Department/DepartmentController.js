var app = angular.module('ERP').controller('DepartmentController', DepartmentController);

function DepartmentController($scope, Service) {

    var form = $(".student-admission-wrapper");
    $scope.ViewGetStudentInfoes = {};
    $scope.UserCredentialModel = {};
    $scope.btnactive = 1;


    $scope.Initialize = function () {
        debugger;
        $scope.UserCredentialModel.Status = $scope.btnactive;
        Service.Post("Department/GetDepartmentMaster", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.Departments = result.data.ResultData;
            //console.log(result.data);
        })
    }

    $scope.ShowHide = function (DepartmentID) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.IsVisible = true;
        var data = {
            DepartmentID: DepartmentID
        };

        Service.Post("Department/GetSingleDepartmentInfo", JSON.stringify(data), $scope.UserCredentialModel).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;

            $scope.Department = result.data.Department;
            $scope.DepartmentID = result.data.DepartmentID;
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

        $scope.Department = null;
        $scope.DepartmentID = null;
        $scope.IsVisible = false;
        // $scope.Initialize();
    }

    $scope.AddUpdate = function (DepartmentID, Department, BtnStatus) {
        var data = {
            DepartmentID: DepartmentID,
            Department: Department,
            BtnStatus: BtnStatus
        };
        if ($scope.form.$valid) {
            Service.Post("Department/SaveDepartment", JSON.stringify(data)).then(function (response) {

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
        }
    }


    $scope.Delete = function (DepartmentID) {
        debugger;
        var data = {

            DepartmentID: DepartmentID
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the department?");

        }
        else {
            var confirm = window.confirm("Do you want to active the department?");
        }
        if (confirm == true) {
            Service.Post("Department/DeleteDepartment", JSON.stringify(data)).then(function (response) {

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
