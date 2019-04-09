var app = angular.module('ERP').controller('FeeTypeController', FeeTypeController);

function FeeTypeController($scope, Service) {

    var form = $(".student-admission-wrapper");
    $scope.ViewGetStudentInfoes = {};
    $scope.UserCredentialModel = {};
    $scope.btnactive = 1;


    $scope.Initialize = function () {
        debugger;
        $scope.UserCredentialModel.Status = $scope.btnactive;
        Service.Post("FeeType/GetFeeTypeInfo", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.FeetTypeData = result.data;
            //console.log(result.data);

        })
    }

    $scope.ShowHide = function (FeeTypeID) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.IsVisible = true;
        var data = {

            FeeTypeID: FeeTypeID

        };

        Service.Post("FeeType/GetSingleFeeTypeInfo", JSON.stringify(data)).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;

            $scope.FeetType = result.data.ResultData.FeetType;
            $scope.FeeTypeID = result.data.ResultData.FeeTypeID;
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

        $scope.FeetType = null;
        $scope.FeeTypeID = null;
        $scope.IsVisible = false;
        // $scope.Initialize();
    }
    $scope.Add = function (FeeTypeID, FeetType) {
        var data = {
            FeeTypeID: FeeTypeID,
            FeetType: FeetType

        };
        if ($scope.form.$valid) {
            Service.Post("FeeType/AddFeeType", JSON.stringify(data)).then(function (response) {

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

    $scope.AddUpdate = function (FeeTypeID, FeetType) {
        var data = {
            FeeTypeID: FeeTypeID,
            FeetType: FeetType

        };
        if ($scope.form.$valid) {
            Service.Post("FeeType/UpdateFeeType", JSON.stringify(data)).then(function (response) {

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


    $scope.Delete = function (FeeTypeID) {
        debugger;
        var data = {

            FeeTypeID: FeeTypeID
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the FeeType?");

        }
        else {
            var confirm = window.confirm("Do you want to active the FeeType?");
        }
        if (confirm == true) {
            Service.Post("FeeType/DeleteFeeType", JSON.stringify(data)).then(function (response) {

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
