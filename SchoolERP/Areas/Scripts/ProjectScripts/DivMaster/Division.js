﻿angular.module('ERP').controller('DivisionController', DivisionController);
function DivisionController($scope, Service, $timeout)
{
    $scope.UserCredentialModel = {};
    $scope.MainDiv = false;
    $scope.btnUpdate = false;
    $scope.btnSave = true;
    $scope.btnactive = 1;
    $scope.myText = "/Content/Loader4.gif";
    $scope.isCheck = true;
    $scope.btnu = false;
    $scope.btns = false;
    $scope.btnValue = "SAVE";

    //Display

    $scope.Initialize = function () {
        debugger;
  
      $scope.UserCredentialModel.Status = $scope.btnactive;
      Service.Post("Division/DisplayDivision", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStandardInfoes = result.data;
            $scope.DivisionData = result.data;
           

        })
    }

    //code for Hide Show Div
    $scope.ShowHideSave = function ()
    {
        $scope.MainDiv = true;
        $scope.btnUpdate = false;
        $scope.btnSave = true;
    }

    //code for add Division
    $scope.Add = function (DivisionName) {
        debugger;
        var data = {

            DivisionName: DivisionName

        };
        if ($scope.form.$valid) {
            $scope.btns = true;
            $scope.isCheck = false;
            $scope.btnValue = "SAVING.........";
            $timeout(function () {
                $scope.isCheck = true;
                $scope.btnSave = false;
                $scope.btnValue = "SAVE";
                Service.Post("Division/AddDivision", JSON.stringify(data)).then(function (response) {
                    $scope.MainDiv = false;
                    $scope.btnUpdate = false;
                    $scope.btnSave = true;
                    if (response.data.IsSucess) {
                        CustomizeApp.AddMessage();
                        $scope.Initialize();
                        
                    }
                    else {


                        ShowMessage(0, response.data.Message);
                    }

                });
            }, 3000);
        }
    }
    //code for get single standard
    $scope.SingleValue = function (DivisionId, DivisionName) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.MainDiv = true;
        var data = {

            DivisionId: DivisionId,
            DivisionName: DivisionName

        };

        Service.Post("Division/GetSingleDivision", JSON.stringify(data)).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;

            $scope.DivisionName = result.data.DivisionName;
            $scope.DivisionID = result.data.DivisionID;


            $scope.Initialize();
        })
    }

    $scope.Update = function (DivisionID, DivisionName) {
        debugger;
        var data = {
            DivisionID: DivisionID,
           DivisionName: DivisionName

        };
        if ($scope.form.$valid) {
            $scope.btnu = true;
            $scope.isCheck = false;
            $scope.btnValue = "SAVING.........";
            $timeout(function () {
                $scope.isCheck = true;
                $scope.btnUpdate = false;

                $scope.btnValue = "SAVE";
                Service.Post("Division/UpdateDivision", JSON.stringify(data)).then(function (response) {
                    $scope.btnUpdate = true;
                    $scope.btnSave = false;
                    $scope.AddDiv = false;
                    if (response.data.IsSucess) {
                        debugger;
                        CustomizeApp.UpdateMessage();
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
    $scope.Clear = function () {


        $scope.MainDiv = false;
        $scope.DivisionName = null;
        $scope.IsVisible = false;

    }


    //Code For Delete
    $scope.Delete = function (DivisionID) {
        debugger;
        var data = {
            Status: $scope.btnactive,
            DivisionID: DivisionID
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the Division?");

        }
        else {
            var confirm = window.confirm("Do you want to active the Division?");
        }
        if (confirm == true) {
            Service.Post("Division/DeleteDivision", JSON.stringify(data)).then(function (response) {

                debugger;
                if (response.data)
                    $scope.Initialize();
                alert(response.data.ResultData);
            });
        }

        $scope.IsVisible = false;
        $scope.Initialize();

    }

}