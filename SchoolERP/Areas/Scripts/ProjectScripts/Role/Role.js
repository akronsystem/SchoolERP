var app = angular.module('ERP').controller('RoleController', RoleController);

function RoleController($scope, Service, $timeout) {

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
        Service.Post("RoleMaster/GetRoleInfo", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.RoleData = result.data;
            //console.log(result.data);

        })
    }

    $scope.ShowHide = function (RoleID) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.IsVisible = true;
        var data = {

            RoleID: RoleID

        };

        Service.Post("RoleMaster/GetSingleRoleInfo", JSON.stringify(data)).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;

            $scope.Role = result.data.ResultData.Role;
            $scope.RoleID = result.data.ResultData.RoleID;
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

        $scope.Role = null;
        $scope.RoleID = null;
     
        $scope.IsVisible = false;
        $scope.Initialize();
        // $scope.Initialize();
    }
    $scope.Add = function (RoleID, Role) {
        
        var data = {
            RoleID: RoleID,
            Role: Role

        };
        if ($scope.form.$valid) {
            $scope.btns = true;
            $scope.isCheck = false;
            $scope.btnValue = "SAVING.........";
            $timeout(function () {
                $scope.isCheck = true;
                $scope.btnSave = false;
                $scope.btnValue = "SAVE";
                Service.Post("RoleMaster/AddRole", JSON.stringify(data)).then(function (response) {

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
            }, 3000);
        }
    }

    $scope.AddUpdate = function (RoleID, Role) {
       
        var data = {
            RoleID: RoleID,
            Role: Role

        };
        if ($scope.form.$valid) {
            $scope.btnu = true;
            $scope.isCheck = false;
            $scope.btnValue = "SAVING.........";
            $timeout(function () {
                $scope.isCheck = true;
                $scope.btnSave = false;
                $scope.btnValue = "SAVE";
                Service.Post("RoleMaster/UpdateRole", JSON.stringify(data)).then(function (response) {

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
            }, 3000);
        }
    }


    $scope.Delete = function (RoleID) {
        debugger;
        var data = {

            RoleID: RoleID
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the Role?");

        }
        else {
            var confirm = window.confirm("Do you want to active the Role?");
        }
        if (confirm == true) {
            Service.Post("RoleMaster/DeleteRole", JSON.stringify(data)).then(function (response) {

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
