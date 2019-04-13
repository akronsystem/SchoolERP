var app = angular.module('ERP').controller('ShiftDetailsController', ShiftDetailsController);

function ShiftDetailsController($scope, Service, $timeout) {

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
        Service.Post("ShiftMaster/GetShiftDetailsInfo", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.ShiftDetailData = result.data;
            //console.log(result.data);

        })
    }

    $scope.ShowHide = function (ShiftDetailID) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.IsVisible = true;
        var data = {

            ShiftDetailID: ShiftDetailID

        };

        Service.Post("ShiftMaster/GetSingleShiftDetailsInfo", JSON.stringify(data)).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;

            $scope.ShiftName = result.data.ResultData.ShiftName;
            $scope.ShiftID = result.data.ResultData.ShiftID; 
            $scope.ShiftDetailID = result.data.ResultData.ShiftDetailID;
            $scope.InTime = result.data.ResultData.InTime;
            $scope.OutTime = result.data.ResultData.OutTime;
            $scope.LateMark = result.data.ResultData.LateMark;
            $scope.EarlyGoing = result.data.ResultData.EarlyGoing;
            $scope.HalfDayLate = result.data.ResultData.HalfDayLate;
            $scope.HalfDayEarly = result.data.ResultData.HalfDayEarly;
            
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

        $scope.ShiftName = null;
        $scope.ShiftID = null;
        $scope.IsVisible = false;
        // $scope.Initialize();
    }
    $scope.Add = function (ShiftDetailID, ShiftID) {
       
        debugger;
        var InTime = $('#m_timepicker_1').val();
        var OutTime = $('#m_timepicker_2').val();
        var LateMark = $('#m_timepicker_3').val();
        var EarlyGoing = $('#m_timepicker_4').val();
        var HalfDayLate = $('#m_timepicker_5').val();
        var HalfDayEarly = $('#m_timepicker_6').val();
        var data = {
            ShiftDetailID: ShiftDetailID,
            ShiftID: ShiftID,
            InTime: InTime,
            OutTime: OutTime,
            LateMark: LateMark,
            EarlyGoing: EarlyGoing,
            HalfDayLate: HalfDayLate,
            HalfDayEarly: HalfDayEarly
        };
        if ($scope.form.$valid) {
            $scope.btns = true;
            $scope.isCheck = false;
            $scope.btnValue = "SAVING.........";
            $timeout(function () {
                $scope.isCheck = true;
                $scope.btnSave = false;
                $scope.btnValue = "SAVE";
                Service.Post("ShiftMaster/AddShiftDetails", JSON.stringify(data)).then(function (response) {

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
            }, 3000);
        }
    }

    $scope.AddUpdate = function (ShiftDetailID, ShiftID) {
        debugger;
        var InTime = $('#m_timepicker_1').val();
        var OutTime = $('#m_timepicker_2').val();
        var LateMark = $('#m_timepicker_3').val();
        var EarlyGoing = $('#m_timepicker_4').val();
        var HalfDayLate = $('#m_timepicker_5').val();
        var HalfDayEarly = $('#m_timepicker_6').val();
       

        var data = {
            ShiftDetailID: ShiftDetailID,
            ShiftID: ShiftID,
            InTime: InTime,
            OutTime: OutTime,
            LateMark: LateMark,
            EarlyGoing: EarlyGoing,
            HalfDayLate: HalfDayLate,
            HalfDayEarly: HalfDayEarly
        };
        if ($scope.form.$valid) {
            $scope.btnu = true;
            $scope.isCheck = false;
            $scope.btnValue = "SAVING.........";
            $timeout(function () {
                $scope.isCheck = true;
                $scope.btnSave = false;
                $scope.btnValue = "SAVE";
                Service.Post("ShiftMaster/UpdateShiftDetails", JSON.stringify(data)).then(function (response) {

                    if (response.data.IsSucess) {
                        debugger;
                        CustomizeApp.UpdateMessage();
                        $scope.Clear();
                        $scope.IsVisible = false;
                        $scope.Initialize();
                        // alert(response.data.ResultData);
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
            }, 3000);
        }
    }


    $scope.Delete = function (ShiftDetailID) {
        debugger;
        var data = {

            ShiftDetailID: ShiftDetailID
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the Shift?");

        }
        else {
            var confirm = window.confirm("Do you want to active the Shift?");
        }
        if (confirm == true) {
            Service.Post("ShiftMaster/DeleteShiftDetails", JSON.stringify(data)).then(function (response) {

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
    $scope.GetName = function () {
        debugger;
        $scope.UserCredentialModel = {};
        Service.Post("ShiftMaster/GetShiftInfo", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.ShiftDetails = result.data;
            //console.log(result.data);

        })
    }
    //$scope.onFnBegChange = function (InTime) {
    //    $scope.InTime = InTime.toLocaleTimeString();
    //}

}
