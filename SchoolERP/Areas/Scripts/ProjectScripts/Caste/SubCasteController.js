var app = angular.module('ERP').controller('SubCasteController', SubCasteController);

function SubCasteController($scope, Service) {

    var form = $(".student-admission-wrapper");
    $scope.ViewGetStudentInfoes = {};
    $scope.UserCredentialModel = {};
    $scope.btnactive = 1;


    $scope.Initialize = function () {
        debugger;
        $scope.UserCredentialModel.Status = $scope.btnactive;
        Service.Post("Caste/GetSubCasteMaster", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.SubCastes = result.data.ResultData;
            $scope.GetSubCaste();
            //console.log(result.data);
        })
    }

    $scope.GetSubCaste = function () {

        Service.Post("Caste/GetCaste").then(function (result) {
            debugger;
            $scope.Castes = result.data.ResultData;
            console.log(result.data);
        })
    }

    $scope.ShowHide = function (SubCasteID) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.IsVisible = true;
        var data = {
            SubCasteID: SubCasteID
        };

        Service.Post("Caste/GetSingleSubCasteInfo", JSON.stringify(data), $scope.UserCredentialModel).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;

            $scope.SubCasteName = result.data.SubCasteName;
            $scope.CasteID = result.data.CasteID;
            $scope.SubCasteID = result.data.SubCasteID;
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

        $scope.SubCasteName = null;
        $scope.CasteID = null;
        $scope.SubCasteID = null;
        $scope.IsVisible = false;
        //$scope.Initialize();
    }

    $scope.AddUpdate = function (SubCasteID, CasteID, SubCasteName, BtnStatus) {
        var data = {
            SubCasteID: SubCasteID,
            CasteID: CasteID,
            SubCasteName: SubCasteName,
            BtnStatus: BtnStatus
        };
        if ($scope.form.$valid) {
            Service.Post("Caste/SaveSubCaste", JSON.stringify(data)).then(function (response) {

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
        }
    }


    $scope.Delete = function (SubCasteID) {
        debugger;
        var data = {

            SubCasteID: SubCasteID
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the sub caste?");

        }
        else {
            var confirm = window.confirm("Do you want to active the sub caste?");
        }
        if (confirm == true) {
            Service.Post("Caste/DeleteSubCaste", JSON.stringify(data)).then(function (response) {

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
