angular.module('ERP').controller('SectionController', SectionController);
function SectionController($scope, Service) {

    $scope.UserCredentialModel = {};
    $scope.ViewGetStandardInfoes = {};
    $scope.btnactive = 1;
    //Hide Show Div
    $scope.ShowHideSave = function () {
        $scope.MainDiv = true;
        $scope.btnUpdate = false;
        $scope.btnSave = true;
    }
    //code for Display all data
    $scope.Initialize = function () {
        debugger;
        $scope.UserCredentialModel.Status = $scope.btnactive;
        Service.Post("SectionMaster/DisplaySection", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStandardInfoes = result.data;
            $scope.SectionData = result.data;


        })
    }

    //code for Add Section
    $scope.Add = function (SectionName) {
        debugger;
        var data = {

            SectionName: SectionName

        };
        if ($scope.form.$valid) {
            Service.Post("SectionMaster/AddSection", JSON.stringify(data)).then(function (response) {
                $scope.MainDiv = false;
                $scope.btnUpdate = false;
                $scope.btnSave = true;
                if (response.data.IsSucess) {
                    $scope.Initialize();
                    alert(response.data.ResultData);
                }
                else {


                    alert(response.data.ResultData);
                }

            });
        }
    }
    //code for Get Single Value
    $scope.SingleValue = function (SectionId, SectionName) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.MainDiv = true;
        var data = {

            SectionId: SectionId,
            SectionName: SectionName

        };

        Service.Post("SectionMaster/GetSingleSection", JSON.stringify(data)).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;

            $scope.SectionName = result.data.ResultData.SectionName;
            $scope.SectionId = result.data.ResultData.SectionId;


            $scope.Initialize();
        })
    }

    //code for Update Section

    $scope.Update = function (SectionId, SectionName) {
        debugger;
        var data = {
            SectionId: SectionId,
            SectionName: SectionName

        };
        if ($scope.form.$valid) {
            Service.Post("SectionMaster/UpdateSection", JSON.stringify(data)).then(function (response) {
                $scope.btnUpdate = true;
                $scope.btnSave = false;
                $scope.MainDiv = false;
                if (response.data.IsSucess) {
                    debugger;


                    $scope.Initialize();

                    alert(response.data.ResultData);


                }
                else {
                    debugger;

                    alert(response.data.Message);
                }

            });
        }
    }



    $scope.Delete = function (SectionId) {
        debugger;
        var data = {
            Status: $scope.btnactive,
            SectionId: SectionId
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the Section?");

        }
        else {
            var confirm = window.confirm("Do you want to active the Section?");
        }
        if (confirm == true) {
            Service.Post("SectionMaster/DeleteSection", JSON.stringify(data)).then(function (response) {

                debugger;
                if (response.data)
                    $scope.Initialize();
                alert(response.data.ResultData);
            });
        }

        $scope.IsVisible = false;
        $scope.Initialize();

    }
    //Code For Clear
    $scope.Clear = function () {


        $scope.AddDiv = false;
        $scope.StandardName = null;
        $scope.IsVisible = false;

    }
}