var app = angular.module('ERP').controller('BoardController', BoardController);

function BoardController($scope, Service, $timeout) {

    var form = $(".student-admission-wrapper");
    $scope.myText = "/Content/Loader.gif";
    $scope.isCheck = true;
    $scope.btnValue = "SAVE";
    $scope.ViewGetStudentInfoes = {};
    $scope.UserCredentialModel = {};
    $scope.btnactive = 1;

    $scope.Initialize = function () {
        debugger;
        $scope.UserCredentialModel.Status = $scope.btnactive;
        Service.Post("SchoolMaster/GetBoardInfo", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.Board = result.data;
            //console.log(result.data);

        })
    }

    $scope.ShowHide = function (BoardId) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.IsVisible = true;
        var data = {

            BoardId: BoardId

        };

        Service.Post("SchoolMaster/GetSingleBoardInfo", JSON.stringify(data)).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;

            $scope.BoardName = result.data.ResultData.BoardName;
            $scope.BoardId = result.data.ResultData.BoardId;
            // $scope.Students = result.data.ResultData;

            $scope.Initialize();
        })
    }


    $scope.ShowHideSave = function () {
        debugger;
        $scope.btnUpdate = false;
        $scope.btnSave = true;
        $scope.IsVisible = true;
        $scope.isCheck = true;
    }


    $scope.Clear = function () {

        $scope.BoardName = null;
        $scope.ModuleId = null;
        $scope.IsVisible = false;
        // $scope.Initialize();
    }
    $scope.Add = function (BoardId, BoardName) {
        var data = {
            BoardId: BoardId,
            BoardName: BoardName

        };
        if ($scope.form.$valid) {
            $scope.isCheck = false;
            $scope.btnValue = "SAVING.........";
            $timeout(function () {
                $scope.isCheck = true;
                $scope.btnSave = false;
                $scope.btnValue = "SAVE";
                Service.Post("SchoolMaster/AddBoard", JSON.stringify(data)).then(function (response) {

                    if (response.data.IsSucess) {
                        debugger;


                        CustomizeApp.AddMessage();
                        window.location.reload();
                       
                       
                    }
                    else {
                        debugger;
                        ShowMessage(0, response.data.Message);
                       
                    }

                });
            }, 3000);
        }
    }

    $scope.AddUpdate = function (BoardId, BoardName) {
        var data = {
            BoardId: BoardId,
            BoardName: BoardName
           
        };
        if ($scope.form.$valid) {
            Service.Post("SchoolMaster/UpdateBoard", JSON.stringify(data)).then(function (response) {

                if (response.data.IsSucess) {
                    debugger;
                    CustomizeApp.UpdateMessage();
                    window.location.reload();
                   

                }
                else {
                    debugger;
                    ShowMessage(0, response.data.Message);
                   
                }

            });
        }
    }


    $scope.Delete = function (BoardId) {
        debugger;
        var data = {

            BoardId: BoardId
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the board?");

        }
        else {
            var confirm = window.confirm("Do you want to active the board?");
        }
        if (confirm == true) {
            Service.Post("SchoolMaster/DeleteBoard", JSON.stringify(data)).then(function (response) {

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
