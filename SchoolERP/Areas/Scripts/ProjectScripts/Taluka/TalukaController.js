var app = angular.module('ERP').controller('TalukaController', TalukaController);

function TalukaController($scope, Service, $timeout) {

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
        Service.Post("StateMaster/GetTalukaInfo", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.TalukaList = result.data;
            //console.log(result.data);

        })
    }

    $scope.ShowHide = function (TalukaID) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.IsVisible = true;
        var data = {

            TalukaID: TalukaID

        };

        Service.Post("StateMaster/GetSingleTalukaInfo", JSON.stringify(data)).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;

            $scope.Taluka = result.data.ResultData.Taluka;
            $scope.TalukaID = result.data.ResultData.TalukaID;
            $scope.DistrictID = result.data.ResultData.DistrictID;
            $scope.StateID = result.data.ResultData.StateID;
            $scope.District = result.data.ResultData.District;
            $scope.GetDistrict(result.data.ResultData.StateID);
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
        $scope.Taluka = "";
        $scope.DistrictID = "";
        $scope.StateID = "";
        $scope.Initialize();
       
    }
    $scope.Add = function (Taluka,TalukaID,DistrictID, District, StateID) {
        var data = {
            Taluka: Taluka,
            DistrictID: DistrictID,
            District: District,
            StateID: StateID,
            TalukaID: TalukaID

        };
        if ($scope.form.$valid) {
            $scope.btns = true;
            $scope.isCheck = false;
            $scope.btnValue = "SAVING.........";
            $timeout(function () {
                $scope.isCheck = true;
                $scope.btnSave = false;
                $scope.btnValue = "SAVE";
                Service.Post("StateMaster/AddTaluka", JSON.stringify(data)).then(function (response) {

                    if (response.data.IsSucess) {
                        debugger;
                        CustomizeApp.AddMessage();
                        $scope.Clear();
                        $scope.IsVisible = false;
                        $scope.Initialize();

                    }
                    else {
                        debugger;
                        ShowMessage(0, response.data.Message);

                    }

                });
            }, 3000);
        }
    }

    $scope.AddUpdate = function (Taluka, TalukaID, DistrictID, District, StateID) {
        var data = {
            Taluka: Taluka,
            DistrictID: DistrictID,
            District: District,
            StateID: StateID,
            TalukaID: TalukaID

        };
        if ($scope.form.$valid) {
            $scope.btnu = true;
            $scope.isCheck = false;
            $scope.btnValue = "SAVING.........";
            $timeout(function () {
                $scope.isCheck = true;
                $scope.btnUpdate = false;

                $scope.btnValue = "SAVE";
                Service.Post("StateMaster/UpdateTaluka", JSON.stringify(data)).then(function (response) {

                    if (response.data.IsSucess) {
                        debugger;
                        CustomizeApp.UpdateMessage();
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


    $scope.Delete = function (TalukaID) {
        debugger;
        var data = {

            TalukaID: TalukaID
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the Taluka?");

        }
        else {
            var confirm = window.confirm("Do you want to active the Taluka?");
        }
        if (confirm == true) {
            Service.Post("StateMaster/DeleteTaluka", JSON.stringify(data)).then(function (response) {

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
    $scope.GetDistrict = function (StateID) {
        debugger;
        var Data = {
            StateID: StateID
        };
        Service.Post("StateMaster/GetStateUnderTaluka", JSON.stringify(Data)).then(function (result) {
            $scope.ParentDistrict = result.data;
            console.log(result.data);

        })
    }

}
