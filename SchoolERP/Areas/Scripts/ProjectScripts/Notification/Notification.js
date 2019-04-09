var app = angular.module('ERP').controller('NotificationController', NotificationController);

function NotificationController($scope, Service) {

    var form = $(".student-admission-wrapper");
    $scope.ViewGetStudentInfoes = {};
    $scope.UserCredentialModel = {};
    $scope.btnactive = 1;


    $scope.Initialize = function () {
        debugger;
        $scope.UserCredentialModel.Status = $scope.btnactive;
        Service.Post("Notification/GetNotificationTypeInfo", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.NotificationData = result.data;
            //console.log(result.data);

        })
    }

    $scope.ShowHide = function (NotificationTypeID) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.IsVisible = true;
        var data = {

            NotificationTypeID: NotificationTypeID

        };

        Service.Post("Notification/GetSingleNotificationTypeInfo", JSON.stringify(data)).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;

            $scope.Notification = result.data.ResultData.Notification;
            $scope.NotificationTypeID = result.data.ResultData.NotificationTypeID;
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

        $scope.Notification = null;
        $scope.NotificationTypeID = null;
        $scope.IsVisible = false;
        // $scope.Initialize();
    }
    $scope.Add = function (NotificationTypeID, Notification) {
        var data = {
            NotificationTypeID: NotificationTypeID,
            Notification: Notification

        };
        if ($scope.form.$valid) {
            Service.Post("Notification/AddNotificationType", JSON.stringify(data)).then(function (response) {

                if (response.data.IsSucess) {
                    debugger;
                    CustomizeApp.AddMessage();
                    $scope.Clear();
                    $scope.IsVisible = false;
                    $scope.Initialize();
                    //alert(response.data.ResultData);
                    // window.location = "./ParentGrievance"
                    //alert(result.data);

                }
                else {
                    debugger;
                    ShowMessage(0, response.data.Message);
                    //alert(response.data.Message);
                    //$scope.clear();
                    //window.location = "./PostGrievance"
                }

            });
        }
    }

    $scope.AddUpdate = function (NotificationTypeID, Notification) {
        var data = {
            NotificationTypeID: NotificationTypeID,
            Notification: Notification

        };
        if ($scope.form.$valid) {
            Service.Post("Notification/UpdateNotificationType", JSON.stringify(data)).then(function (response) {

                if (response.data.IsSucess) {
                    debugger;



                    CustomizeApp.UpdateMessage();
                    $scope.Clear();
                    $scope.IsVisible = false;
                    $scope.Initialize();
                    //alert(response.data.ResultData);
                    // window.location = "./ParentGrievance"
                    //alert(result.data);

                }
                else {
                    debugger;
                    ShowMessage(0, response.data.Message);
                    //alert(response.data.Message);
                    //$scope.clear();
                    //window.location = "./PostGrievance"
                }

            });
        }
    }


    $scope.Delete = function (NotificationTypeID) {
        debugger;
        var data = {

            NotificationTypeID: NotificationTypeID
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the Notification?");

        }
        else {
            var confirm = window.confirm("Do you want to active the Notification?");
        }
        if (confirm == true) {
            Service.Post("Notification/DeleteNotificationType", JSON.stringify(data)).then(function (response) {

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
