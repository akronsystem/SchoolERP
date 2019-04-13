var app = angular.module('ERP').controller('TermCommencementController', TermCommencementController);

function TermCommencementController($scope, Service, $timeout) {
    
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
        Service.Post("TermMaster/GetTermCommencementInfo", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.DataList = result.data;
            //console.log(result.data);

        })
    }

    $scope.ShowHide = function (TermCommID) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.IsVisible = true;
        var data = {

            TermCommID: TermCommID

        };

        Service.Post("TermMaster/GetSingleTermCommencementInfo", JSON.stringify(data)).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;

            $scope.TermName = result.data.ResultData.TermName;
            $scope.TermID = result.data.ResultData.TermID;
            $scope.TermCommID = result.data.ResultData.TermCommID;
            $scope.StartDate = result.data.ResultData.StartDate;
            $scope.EndDate = result.data.ResultData.EndDate;
            //$scope.UnitID = result.data.ResultData.UnitID;

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
        $scope.TermCommID = "";
        $scope.TermName = "";
        $scope.TermID = "";
        $scope.StartDate = "";
        $scope.EndDate = "";

    }
    $scope.Add = function (TermID) {
        debugger
        var StartDate = $('#m_datepicker_1').val();
        var EndDate = $('#m_datepicker_2').val();
        var data = {
            TermID: TermID,
             StartDate: StartDate,
            EndDate: EndDate

        };
        if ($scope.form.$valid) {
            $scope.btns = true;
            $scope.isCheck = false;
            $scope.btnValue = "SAVING.........";
            $timeout(function () {
                $scope.isCheck = true;
                $scope.btnSave = false;
                $scope.btnValue = "SAVE";
                Service.Post("TermMaster/AddTermCommencement", JSON.stringify(data)).then(function (response) {

                    if (response.data.IsSucess) {
                        CustomizeApp.AddMessage();
                        $scope.Clear();
                        $scope.IsVisible = false;
                        $scope.Initialize();

                    }
                    else {
                        ShowMessage(0, response.data.Message);

                    }

                });
            }, 3000);
        }
    }

    $scope.AddUpdate = function (TermID, TermCommID) {
        var StartDate = $('#m_datepicker_1').val();
        var EndDate = $('#m_datepicker_2').val();
        var data = {
            TermID: TermID,
            TermCommID: TermCommID,
            StartDate: StartDate,
            EndDate: EndDate

        };
        if ($scope.form.$valid) {
            $scope.btnu = true;
            $scope.isCheck = false;
            $scope.btnValue = "SAVING.........";
            $timeout(function () {
                $scope.isCheck = true;
                $scope.btnUpdate = false;

                $scope.btnValue = "SAVE";
                Service.Post("TermMaster/UpdateTermCommencement", JSON.stringify(data)).then(function (response) {

                    if (response.data.IsSucess) {
                        CustomizeApp.UpdateMessage();
                        $scope.Clear();
                        $scope.IsVisible = false;
                        $scope.Initialize();

                    }
                    else {
                        ShowMessage(0, response.data.Message);

                    }

                });
            }, 3000);
        }
    }


    $scope.Delete = function (TermCommID) {
        debugger;
        var data = {

            TermCommID: TermCommID
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the Term?");

        }
        else {
            var confirm = window.confirm("Do you want to active the Term?");
        }
        if (confirm == true) {
            Service.Post("TermMaster/DeleteTermCommencement", JSON.stringify(data)).then(function (response) {

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
