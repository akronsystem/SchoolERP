var app = angular.module('ERP').controller('BoardController', BoardController);

function BoardController($scope, Service, $timeout) {

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
        //window.location.reload();
        $scope.UserCredentialModel.Status = $scope.btnactive;
        Service.Post("Board/GetBoardInfo", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.Board = result.data;
            //console.log(result.data);

        })
    }

    $scope.ShowHide = function (BoardID) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.IsVisible = true;
        var data = {

            BoardID: BoardID

        };

        Service.Post("Board/GetSingleBoardInfo", JSON.stringify(data)).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;

            $scope.BoardName = result.data.ResultData.BoardName;
            $scope.BoardID = result.data.ResultData.BoardID;
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
    $scope.Add = function (BoardID, BoardName) {
      
        var data = {
            BoardID: BoardID,
            BoardName: BoardName

        };
        if ($scope.form.$valid) {
            $scope.btns = true;
            $scope.isCheck = false;
            $scope.btnValue = "SAVING.........";
            $timeout(function () {
                $scope.isCheck = true;
                $scope.btnSave = false;
                $scope.btnValue = "SAVE";
            Service.Post("Board/AddBoard", JSON.stringify(data)).then(function (response) {

                if (response.data.IsSucess) {
                    debugger;
                    CustomizeApp.AddMessage();
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

    $scope.AddUpdate = function (BoardID, BoardName) {
      
        var data = {
            BoardID: BoardID,
            BoardName: BoardName
           
        };
        if ($scope.form.$valid) {
            $scope.btnu = true;
            $scope.isCheck = false;
            $scope.btnValue = "SAVING.........";
            $timeout(function () {
                $scope.isCheck = true;
                $scope.btnUpdate = false;
               
                $scope.btnValue = "SAVE";
                Service.Post("Board/UpdateBoard", JSON.stringify(data)).then(function (response) {

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
            }, 3000);
        }
    }


    $scope.Delete = function (BoardID) {
        debugger;
        var data = {

            BoardID: BoardID
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the board?");

        }
        else {
            var confirm = window.confirm("Do you want to active the board?");
        }
        if (confirm == true) {
            Service.Post("Board/DeleteBoard", JSON.stringify(data)).then(function (response) {

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
