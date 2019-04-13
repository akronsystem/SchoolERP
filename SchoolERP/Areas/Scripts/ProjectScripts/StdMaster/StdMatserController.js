angular.module('ERP').controller('StandardController', StandardController);
function StandardController($scope, Service, $timeout) {

   

    var form = $(".student-admission-wrapper");
    $scope.ViewGetStudentInfoes = {};
    $scope.UserCredentialModel = {};
    $scope.btnactive = 1;
    $scope.myText = "/Content/Loader4.gif";
    $scope.isCheck = true;
    $scope.btnu = false;
    $scope.btns = false;
    $scope.btnValue = "SAVE";


    //code for Display all data
    $scope.Initialize = function () {
        debugger;
        $scope.UserCredentialModel.Status = $scope.btnactive;
        Service.Post("Standard/DisplayStandard", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStandardInfoes = result.data;
            $scope.Standard = result.data;
           

        })
    }

    //code for Hide Show Div
    $scope.ShowHideSave = function ()
    {
        $scope.AddDiv = true;
        $scope.btnUpdate = false;
        $scope.btnSave = true;
    }


    //code for Add Stanadard
    $scope.Add = function (StandardName) {
        debugger;
        var data = {
          
            StandardName: StandardName

        };
        if ($scope.form.$valid) {
            $scope.btns = true;
            $scope.isCheck = false;
            $scope.btnValue = "SAVING.........";
            $timeout(function () {
                $scope.isCheck = true;
                $scope.btnSave = false;
                $scope.btnValue = "SAVE";
                Service.Post("Standard/SaveStandard", JSON.stringify(data)).then(function (response) {
                    $scope.AddDiv = false;
                    $scope.btnUpdate = false;
                    $scope.btnSave = true;
                    if (response.data.IsSucess) {
                        $scope.Initialize();
                        CustomizeApp.AddMessage();
                    }
                    else {


                        ShowMessage(0, response.data.Message);
                    }

                });
            }, 3000);
        }
    }
    //code for get single standard
    $scope.SingleValue = function (StandardId,StandardName) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.AddDiv = true;
        var data = {

            StandardId: StandardId,
            StandardName: StandardName

        };

        Service.Post("Standard/GetSingleStandard", JSON.stringify(data)).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;

            $scope.StandardName = result.data.ResultData.StandardName;
            $scope.StandardId = result.data.ResultData.StandardId;
         

            $scope.Initialize();
        })
    }
    //code for Update Standard

    $scope.Update = function (StandardId,StandardName) {
        debugger;
        var data = {
            StandardId: StandardId,
            StandardName: StandardName

        };
        if ($scope.form.$valid) {
            $scope.btnu = true;
            $scope.isCheck = false;
            $scope.btnValue = "SAVING.........";
            $timeout(function () {
                $scope.isCheck = true;
                $scope.btnUpdate = false;

                $scope.btnValue = "SAVE";
                Service.Post("Standard/UpdateStandard", JSON.stringify(data)).then(function (response) {
                    $scope.btnUpdate = true;
                    $scope.btnSave = false;
                    $scope.AddDiv = false;
                    if (response.data.IsSucess) {
                        debugger;


                        $scope.Initialize();
                        CustomizeApp.UpdateMessage();
                    }
                    else {
                        debugger;
                        ShowMessage(0, response.data.Message);
                    }
                });
            }, 3000);
        }
    }
    //Code For Delete
    $scope.Delete = function (StandardId) {
        debugger;
        var data = {
            Status : $scope.btnactive,
            StandardId: StandardId
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the Standard?");

        }
        else {
            var confirm = window.confirm("Do you want to active the Standard?");
        }
        if (confirm == true) {
            Service.Post("Standard/DeleteStandard", JSON.stringify(data)).then(function (response) {

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
