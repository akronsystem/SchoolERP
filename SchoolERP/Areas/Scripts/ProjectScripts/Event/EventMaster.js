var app = angular.module('ERP').controller('EventController', EventController);

function EventController($scope, Service) {

    var form = $(".student-admission-wrapper");
    $scope.ViewGetStudentInfoes = {};
    $scope.UserCredentialModel = {};
    $scope.btnactive = 1;


    $scope.Initialize = function () {
        debugger;
        $scope.UserCredentialModel.Status = $scope.btnactive;
        Service.Post("EventMaster/GetEventInfo", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.EventData = result.data;
            //console.log(result.data);

        })
    }

    $scope.ShowHide = function (EventID) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.IsVisible = true;
        var data = {

            EventID: EventID

        };

        Service.Post("EventMaster/GetSingleEventInfo", JSON.stringify(data)).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;

            $scope.EventType = result.data.ResultData.EventType;
            $scope.EventTypeID = result.data.ResultData.EventTypeID; 
            $scope.EventID = result.data.ResultData.EventID;
            $scope.EventName = result.data.ResultData.EventName;
            $scope.StartDate = result.data.ResultData.StartDate;
            $scope.EndDate = result.data.ResultData.EndDate;
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
        $scope.EventID = null;
        $scope.EventName = null;
        $scope.EventTypeID = null;
        $scope.StartDate = null;
        $scope.EndDate = null;
        $scope.IsVisible = false;
        // $scope.Initialize();
    }
    $scope.Add = function (EventID, EventTypeID, EventName) {
        var StartDate = $('#m_datepicker_1').val();
        var EndDate = $('#m_datepicker_2').val();
        var data = {
            EventID: EventID,
            EventTypeID: EventTypeID,
            EventName: EventName,
            StartDate: StartDate,
            EndDate: EndDate

        };
        if ($scope.form.$valid) {
            Service.Post("EventMaster/AddEvent", JSON.stringify(data)).then(function (response) {

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

    $scope.AddUpdate = function (EventID, EventTypeID, EventName) {
        debugger;
        var StartDate = $('#m_datepicker_1').val();
        var EndDate = $('#m_datepicker_2').val();
        var data = {
            EventID: EventID,
            EventTypeID: EventTypeID,
            EventName: EventName,
            StartDate: StartDate,
            EndDate: EndDate

        };
        if ($scope.form.$valid) {
            Service.Post("EventMaster/UpdateEvent", JSON.stringify(data)).then(function (response) {

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
                    ShowMessage(0, response.data.Message);
                    //alert(response.data.Message);
                    //$scope.clear();
                    //window.location = "./PostGrievance"
                }

            });
        }
    }


    $scope.Delete = function (EventID) {
        debugger;
        var data = {

            EventID: EventID
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the EventType?");

        }
        else {
            var confirm = window.confirm("Do you want to active the EventType?");
        }
        if (confirm == true) {
            Service.Post("EventMaster/DeleteEvent", JSON.stringify(data)).then(function (response) {

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
    $scope.GetEvent = function () {
        debugger;
        $scope.UserCredentialModel = {};
        Service.Post("EventMaster/GetEventTypeInfo", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.EventTypeData = result.data;
            //console.log(result.data);

        })
    }

}
