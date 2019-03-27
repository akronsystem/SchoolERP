var app = angular.module('ERP').controller('WidgetController', WidgetController);

function WidgetController($scope, Service) {

    var form = $(".student-admission-wrapper");
    $scope.ViewGetStudentInfoes = {};
    $scope.UserCredentialModel = {};
    $scope.btnactive = 1;


    $scope.Initialize = function () {
        debugger;
        $scope.UserCredentialModel.Status = $scope.btnactive;
        Service.Post("Widget/GetWidgetInfo", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.WidgetData = result.data;
            //console.log(result.data);

        })
    }

    $scope.ShowHide = function (WidgetID) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.IsVisible = true;
        var data = {

            WidgetID: WidgetID

        };

        Service.Post("Widget/GetSingleWidgetInfo", JSON.stringify(data)).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;

            $scope.WidgetName = result.data.ResultData.WidgetName;
            $scope.ActionName = result.data.ResultData.ActionName;
            $scope.WidgetID = result.data.ResultData.WidgetID;
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

        $scope.WidgetName = null;
        $scope.WidgetID = null;
        $scope.ActionName = null;
        $scope.IsVisible = false;
        // $scope.Initialize();
    }
    $scope.Add = function (WidgetID, WidgetName, ActionName) {
        debugger;
        var data = {
            WidgetID: WidgetID,
            WidgetName: WidgetName,
            ActionName:ActionName
        };
        if ($scope.form.$valid) {
            Service.Post("Widget/AddWidget", JSON.stringify(data)).then(function (response) {

                if (response.data.IsSucess) {
                    debugger;



                    //CustomizeApp.UpdateMessage();
                    $scope.Clear();
                    $scope.IsVisible = false;
                    $scope.Initialize();
                    alert(response.data.ResultData);
                    // window.location = "./ParentGrievance"

                    //alert(result.data);

                }
                else {
                    debugger;
                    //ShowMessage(0, response.data.Message);
                    alert(response.data.Message);
                    //$scope.clear();
                    //window.location = "./PostGrievance"
                }

            });
        }
    }

    $scope.AddUpdate = function (WidgetID, WidgetName, ActionName) {
        var data = {
            WidgetID: WidgetID,
            WidgetName: WidgetName,
            ActionName: ActionName
        };
        if ($scope.form.$valid) {
            Service.Post("Widget/UpdateWidget", JSON.stringify(data)).then(function (response) {

                if (response.data.IsSucess) {
                    debugger;



                    //CustomizeApp.UpdateMessage();
                    $scope.Clear();
                    $scope.IsVisible = false;
                    $scope.Initialize();
                    alert(response.data.ResultData);
                    // window.location = "./ParentGrievance"

                    //alert(result.data);

                }
                else {
                    debugger;
                    //ShowMessage(0, response.data.Message);
                    alert(response.data.Message);
                    //$scope.clear();
                    //window.location = "./PostGrievance"
                }

            });
        }
    }


    $scope.Delete = function (WidgetID) {
        debugger;
        var data = {

            WidgetID: WidgetID
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the Widget?");

        }
        else {
            var confirm = window.confirm("Do you want to active the Widget?");
        }
        if (confirm == true) {
            Service.Post("Widget/DeleteWidget", JSON.stringify(data)).then(function (response) {

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
