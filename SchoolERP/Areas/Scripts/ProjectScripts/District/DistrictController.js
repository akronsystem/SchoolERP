var app = angular.module('ERP').controller('DistrictController', DistrictController);

function DistrictController($scope, Service, $timeout) {

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
        Service.Post("StateMaster/GetDistrictInfo", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.DistrictList = result.data;
            //console.log(result.data);

        })
    }

    $scope.ShowHide = function (DistrictID) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.IsVisible = true;
        var data = {

            DistrictID: DistrictID

        };

        Service.Post("StateMaster/GetSingleDistrictInfo", JSON.stringify(data)).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;

            $scope.District = result.data.ResultData.District;
            $scope.DistrictID = result.data.ResultData.DistrictID;
            $scope.StateID = result.data.ResultData.StateID;

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
        $scope.District = "";
        $scope.StateID = "";


    }
    $scope.Add = function (DistrictID, District, StateID) {
     
        var data = {
            DistrictID: DistrictID,
            District: District,
            StateID: StateID

        };
        if ($scope.form.$valid) {
            $scope.btns = true;
            $scope.isCheck = false;
            $scope.btnValue = "SAVING.........";
            $timeout(function () {
                $scope.isCheck = true;
                $scope.btnSave = false;
                $scope.btnValue = "SAVE";
                Service.Post("StateMaster/AddDistrict", JSON.stringify(data)).then(function (response) {

                    if (response.data.IsSucess) {
                        debugger;
                        CustomizeApp.AddMessage();
                        $scope.Clear();
                        //$scope.IsVisible = false;
                        $scope.Initialize();
                        window.location.reload();
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

    $scope.AddUpdate = function (DistrictID, District, StateID) {
    
        var data = {
            DistrictID: DistrictID,
            District: District,
            StateID: StateID

        };
        if ($scope.form.$valid) {
            $scope.btnu = true;
            $scope.isCheck = false;
            $scope.btnValue = "SAVING.........";
            $timeout(function () {
                $scope.isCheck = true;
                $scope.btnUpdate = false;

                $scope.btnValue = "SAVE";
                Service.Post("StateMaster/UpdateDistrict", JSON.stringify(data)).then(function (response) {

                    if (response.data.IsSucess) {
                        debugger;
                    CustomizeApp.UpdateMessage();
                    $scope.Clear();
                        
                        //$scope.IsVisible = false;
                    $scope.Initialize();
                    window.location.reload();
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


    $scope.Delete = function (DistrictID) {
        debugger;
        var data = {

            DistrictID: DistrictID
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the State?");

        }
        else {
            var confirm = window.confirm("Do you want to active the State?");
        }
        if (confirm == true) {
            Service.Post("StateMaster/DeleteDistrict", JSON.stringify(data)).then(function (response) {

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
    $scope.GetState = function () {
        debugger;
        $scope.UserCredentialModel = {};
        Service.Post("StateMaster/GetState", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.StateList = result.data;
            //console.log(result.data);

        })
    }

}
