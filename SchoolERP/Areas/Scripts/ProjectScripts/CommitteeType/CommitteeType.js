var app = angular.module('ERP').controller('CommitteeTypeController', CommitteeTypeController);

function CommitteeTypeController($scope, Service, $timeout) {

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
        Service.Post("CommiteeMaster/GetCommitteTypeInfo", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.CommitteTypeData = result.data;
            //console.log(result.data);

        })
    }

    $scope.ShowHide = function (CommitteeTypeId) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.IsVisible = true;
        var data = {

            CommitteeTypeId: CommitteeTypeId

        };

        Service.Post("CommiteeMaster/GetSingleCommitteTypeInfo", JSON.stringify(data)).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;

            $scope.CommitteeType = result.data.ResultData.CommitteeType;
            $scope.CommitteeTypeId = result.data.ResultData.CommitteeTypeId;
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

        $scope.CommitteeType = null;
        $scope.CommitteeTypeId = null;
        window.location.reload();
        //$scope.IsVisible = false;
        // $scope.Initialize();
    }
    $scope.Add = function (CommitteeTypeId, CommitteeType) {
      
        var data = {
            CommitteeTypeId: CommitteeTypeId,
            CommitteeType: CommitteeType

        };
        if ($scope.form.$valid) {
            $scope.btns = true;
            $scope.isCheck = false;
            $scope.btnValue = "SAVING.........";
            $timeout(function () {
                $scope.isCheck = true;
                $scope.btnSave = false;
                $scope.btnValue = "SAVE";
                Service.Post("CommiteeMaster/AddCommitteeType", JSON.stringify(data)).then(function (response) {

                    if (response.data.IsSucess) {
                        CustomizeApp.AddMessage();
                        $scope.IsVisible = false;
                        //$scope.Initialize();
                        $scope.Clear();
                      
                    }
                    else {
                        debugger;
                        ShowMessage(0, response.data.Message);
                        
                    }

                });
            }, 3000);
        }
    }

    $scope.AddUpdate = function (CommitteeTypeId, CommitteeType) {
       
        var data = {
            CommitteeTypeId: CommitteeTypeId,
            CommitteeType: CommitteeType

        };
        if ($scope.form.$valid) {
            $scope.btnu = true;
            $scope.isCheck = false;
            $scope.btnValue = "SAVING.........";
            $timeout(function () {
                $scope.isCheck = true;
                $scope.btnUpdate = false;

                $scope.btnValue = "SAVE";
                Service.Post("CommiteeMaster/UpdateCommitteType", JSON.stringify(data)).then(function (response) {

                    if (response.data.IsSucess) {
                        CustomizeApp.UpdateMessage();                     
                        //$scope.IsVisible = false;
                        //$scope.Initialize();
                        $scope.Clear();
                      
                    }
                    else {
                        debugger;
                        ShowMessage(0, response.data.Message);
                       
                    }

                });

            }, 3000);
        }
    }


    $scope.Delete = function (CommitteeTypeId) {
        debugger;
        var data = {

            CommitteeTypeId: CommitteeTypeId
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the CommiteeType?");

        }
        else {
            var confirm = window.confirm("Do you want to active the CommiteeType?");
        }
        if (confirm == true) {
            Service.Post("CommiteeMaster/DeleteCommitteType", JSON.stringify(data)).then(function (response) {

                debugger;
                if (response.data.IsSucess) {
                    $scope.Initialize();
                    alert(response.data.ResultData);
                }
            });
        }
        $scope.Clear();
        $scope.IsVisible = false;
        $scope.Initialize();

    }

}
