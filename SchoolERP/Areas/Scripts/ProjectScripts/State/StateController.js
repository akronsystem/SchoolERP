var app = angular.module('ERP').controller('StateController', StateController);

function StateController($scope, Service, $timeout) {

    var form = $(".m-form m-form--fit m-form--label-align-right");
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
        Service.Post("StateMaster/GetStateInfo", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.StateList = result.data;
            //console.log(result.data);

        })
    }

    $scope.ShowHide = function (StateID) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.IsVisible = true;
        var data = {

            StateID: StateID

        };

        Service.Post("StateMaster/GetSingleStateInfo", JSON.stringify(data)).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;

            $scope.State = result.data.ResultData.State;
            $scope.StateID = result.data.ResultData.StateID;
            // $scope.Students = result.data.ResultData;

            //$scope.Initialize();
        })
    }


    $scope.ShowHideSave = function () {
        debugger;
        $scope.btnUpdate = false;
        $scope.btnSave = true;
        $scope.IsVisible = true;
    }


    $scope.Clear = function () {
        $scope.Initialize();
        $scope.IsVisible = false;      
        $scope.State = "";
    }
    $scope.Add = function (StateID, State) {
        var data = {
            StateID: StateID,
            State: State

        };
        if ($scope.form.$valid) {
            $scope.btns = true;
            $scope.isCheck = false;
            $scope.btnValue = "SAVING.........";
            $timeout(function () {
                $scope.isCheck = true;
                $scope.btnSave = false;
                $scope.btnValue = "SAVE";
                Service.Post("StateMaster/AddState", JSON.stringify(data)).then(function (response) {

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

    $scope.AddUpdate = function (StateID, State) {
        var data = {
            StateID: StateID,
            State: State

        };
        if ($scope.form.$valid) {
            $scope.btnu = true;
            $scope.isCheck = false;
            $scope.btnValue = "SAVING.........";
            $timeout(function () {
                $scope.isCheck = true;
                $scope.btnUpdate = false;

                $scope.btnValue = "SAVE";
                Service.Post("StateMaster/UpdateState", JSON.stringify(data)).then(function (response) {

                    if (response.data.IsSucess) {
                        debugger;
                        CustomizeApp.UpdateMessage();
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


    $scope.Delete = function (StateID) {
        debugger;
        var data = {

            StateID: StateID
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the State?");

        }
        else {
            var confirm = window.confirm("Do you want to active the State?");
        }
        if (confirm == true) {
            Service.Post("StateMaster/DeleteState", JSON.stringify(data)).then(function (response) {

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
