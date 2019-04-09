var app = angular.module('ERP').controller('UnitController', UnitController);

function UnitController($scope, Service) {

    var form = $(".m-form m-form--fit m-form--label-align-right");
    $scope.ViewGetStudentInfoes = {};
    $scope.UserCredentialModel = {};
    $scope.btnactive = 1;


    $scope.Initialize = function () {
        debugger;
        $scope.UserCredentialModel.Status = $scope.btnactive;
        Service.Post("TermMaster/GetUnitInfo", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.UnitList = result.data;
            //console.log(result.data);

        })
    }

    $scope.ShowHide = function (UnitID) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.IsVisible = true;
        var data = {

            UnitID: UnitID

        };

        Service.Post("TermMaster/GetSingleUnitInfo", JSON.stringify(data)).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;

            $scope.TermName = result.data.ResultData.TermName;
            $scope.TermID = result.data.ResultData.TermID;
            $scope.UnitName = result.data.ResultData.UnitName;
            $scope.UnitID = result.data.ResultData.UnitID;

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
        $scope.TermID = "";
        $scope.UnitName = "";

    }
    $scope.Add = function (UnitName, UnitID, TermID) {
        debugger
        var data = {
            UnitID: UnitID,
            TermID: TermID,
            UnitName: UnitName

        };
        if ($scope.form.$valid) {
            Service.Post("TermMaster/AddUnit", JSON.stringify(data)).then(function (response) {

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

    $scope.AddUpdate = function (UnitName, UnitID, TermID) {
        var data = {
            UnitID: UnitID,
            TermID: TermID,
            UnitName: UnitName

        };
        if ($scope.form.$valid) {
            Service.Post("TermMaster/UpdateUnit", JSON.stringify(data)).then(function (response) {

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


    $scope.Delete = function (UnitID) {
        debugger;
        var data = {

            UnitID: UnitID
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the Unit?");

        }
        else {
            var confirm = window.confirm("Do you want to active the Unit?");
        }
        if (confirm == true) {
            Service.Post("TermMaster/DeleteUnit", JSON.stringify(data)).then(function (response) {

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
    $scope.GetTerm = function () {
        debugger;
        $scope.UserCredentialModel.Status = $scope.btnactive;
        Service.Post("TermMaster/GetTermInfo", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.TermData = result.data;
            //console.log(result.data);

        })
    }

    //$scope.GetTerm() = function () {
    //    debugger;
    //    $scope.UserCredentialModel.Status = $scope.btnactive;
    //    Service.Post("TermMaster/GetTermInfo", $scope.UserCredentialModel).then(function (result) {
    //        debugger;
    //        $scope.ViewGetStudentInfoes = result.data;
    //        $scope.Term = result.data;
    //        //console.log(result.data);
    //    })
    //}
   
}
