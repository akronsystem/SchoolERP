var app = angular.module('ERP').controller('TermController', TermController);

function TermController($scope, Service) {

    var form = $(".m-form m-form--fit m-form--label-align-right");
    $scope.ViewGetStudentInfoes = {};
    $scope.UserCredentialModel = {};
    $scope.btnactive = 1;


    $scope.Initialize = function () {
        debugger;
        $scope.UserCredentialModel.Status = $scope.btnactive;
        Service.Post("TermMaster/GetTermInfo", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.TermList = result.data;
            //console.log(result.data);

        })
    }

    $scope.ShowHide = function (TermID) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.IsVisible = true;
        var data = {

            TermID: TermID

        };

        Service.Post("TermMaster/GetSingleTermInfo", JSON.stringify(data)).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;

            $scope.TermName = result.data.ResultData.TermName;
            $scope.TermID = result.data.ResultData.TermID;
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

        $scope.IsVisible = false;
        $scope.Initialize();
        $scope.TermName = "";
    }
    $scope.Add = function (TermID, TermName) {
        var data = {
            TermID: TermID,
            TermName: TermName

        };
        if ($scope.form.$valid) {
            Service.Post("TermMaster/AddTerm", JSON.stringify(data)).then(function (response) {

                if (response.data.IsSucess) {
                    debugger;
                    CustomizeApp.AddMessage();
                    $scope.Clear();
                    $scope.IsVisible = false;
                    $scope.Initialize();
                   
                }
                else {
                    ShowMessage(0, response.data.Message);
                 
                }

            });
        }
    }

    $scope.AddUpdate = function (TermID, TermName) {
        var data = {
            TermID: TermID,
            TermName: TermName

        };
        if ($scope.form.$valid) {
            Service.Post("TermMaster/UpdateTerm", JSON.stringify(data)).then(function (response) {

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
        }
    }


    $scope.Delete = function (TermID) {
        debugger;
        var data = {

            TermID: TermID
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the Term?");

        }
        else {
            var confirm = window.confirm("Do you want to active the Term?");
        }
        if (confirm == true) {
            Service.Post("TermMaster/DeleteTerm", JSON.stringify(data)).then(function (response) {

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
