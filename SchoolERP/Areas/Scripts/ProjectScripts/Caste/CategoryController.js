var app = angular.module('ERP').controller('CategoryController', CategoryController);

function CategoryController($scope, Service, $timeout) {

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
        Service.Post("Caste/GetCategoryMaster", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.Categorys = result.data.ResultData;
            //console.log(result.data);
        })
    }

    $scope.ShowHide = function (CategoryID) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.IsVisible = true;
        var data = {
            CategoryID: CategoryID
        };

        Service.Post("Caste/GetSingleCategoryInfo", JSON.stringify(data), $scope.UserCredentialModel).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;

            $scope.CategoryName = result.data.CategoryName;
            $scope.CategoryID = result.data.CategoryID;
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

        $scope.CategoryName = null;
        $scope.CategoryID = null;
        $scope.IsVisible = false;
        // $scope.Initialize();
    }

    $scope.AddUpdate = function (CategoryID, CategoryName, BtnStatus) {
        var data = {
            CategoryID: CategoryID,
            CategoryName: CategoryName,
            BtnStatus: BtnStatus
        };
        if ($scope.form.$valid) {
            $scope.btns = true;
            $scope.btnu = true;
            $scope.isCheck = false;
            $scope.btnValue = "SAVING.........";
            $timeout(function () {
                $scope.isCheck = true;
                $scope.btnSave = false;
                $scope.btnValue = "SAVE";
                Service.Post("Caste/SaveCategory", JSON.stringify(data)).then(function (response) {

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
            }, 3000);
        }
    }


    $scope.Delete = function (CategoryID) {
        debugger;
        var data = {

            CategoryID: CategoryID
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the category?");

        }
        else {
            var confirm = window.confirm("Do you want to active the category?");
        }
        if (confirm == true) {
            Service.Post("Caste/DeleteCategory", JSON.stringify(data)).then(function (response) {

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
