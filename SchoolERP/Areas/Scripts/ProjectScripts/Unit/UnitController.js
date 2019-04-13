var app = angular.module('ERP').controller('UnitController', UnitController);

function UnitController($scope, Service, $timeout) {

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
            $scope.btns = true;
            $scope.isCheck = false;
            $scope.btnValue = "SAVING.........";
            $timeout(function () {
                $scope.isCheck = true;
                $scope.btnSave = false;
                $scope.btnValue = "SAVE";
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
            }, 3000);
        }
    }

    $scope.AddUpdate = function (UnitName, UnitID, TermID) {
        var data = {
            UnitID: UnitID,
            TermID: TermID,
            UnitName: UnitName

        };
        if ($scope.form.$valid) {
            $scope.btnu = true;
            $scope.isCheck = false;
            $scope.btnValue = "SAVING.........";
            $timeout(function () {
                $scope.isCheck = true;
                $scope.btnUpdate = false;

                $scope.btnValue = "SAVE";
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
            }, 3000);
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
