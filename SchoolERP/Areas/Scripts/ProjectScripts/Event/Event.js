var app = angular.module('ERP').controller('EventTypeController', EventTypeController);

function EventTypeController($scope, Service) {

    var form = $(".student-admission-wrapper");
    $scope.ViewGetStudentInfoes = {};
    $scope.UserCredentialModel = {};
    $scope.btnactive = 1;


    $scope.Initialize = function () {
        debugger;
        $scope.UserCredentialModel.Status = $scope.btnactive;
        Service.Post("EventMaster/GetEventTypeInfo", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.EventTypeData = result.data;
            //console.log(result.data);

        })
    }

    $scope.ShowHide = function (EventTypeID) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.IsVisible = true;
        var data = {

            EventTypeID: EventTypeID

        };

        Service.Post("EventMaster/GetSingleEventTypeInfo", JSON.stringify(data)).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;

            $scope.EventType = result.data.ResultData.EventType;
            $scope.EventTypeID = result.data.ResultData.EventTypeID;
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

        $scope.EventType = null;
        $scope.EventTypeID = null;
        $scope.IsVisible = false;
        // $scope.Initialize();
    }
    $scope.Add = function (EventTypeID, EventType) {
        var data = {
            EventTypeID: EventTypeID,
            EventType: EventType

        };
        if ($scope.form.$valid) {
            Service.Post("EventMaster/AddEventType", JSON.stringify(data)).then(function (response) {

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

    $scope.AddUpdate = function (EventTypeID, EventType) {
        var data = {
            EventTypeID: EventTypeID,
            EventType: EventType

        };
        if ($scope.form.$valid) {
            Service.Post("EventMaster/UpdateEventType", JSON.stringify(data)).then(function (response) {

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


    $scope.Delete = function (EventTypeID) {
        debugger;
        var data = {

            EventTypeID: EventTypeID
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the EventType?");

        }
        else {
            var confirm = window.confirm("Do you want to active the EventType?");
        }
        if (confirm == true) {
            Service.Post("EventMaster/DeleteEventType", JSON.stringify(data)).then(function (response) {

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
