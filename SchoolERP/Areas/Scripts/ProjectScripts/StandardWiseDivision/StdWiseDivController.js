angular.module('ERP').controller('StdWiseDivisionController', StdWiseDivisionController);
function StdWiseDivisionController($scope, Service) {

    $scope.UserCredentialModel = {};
    $scope.ViewGetStudentInfoes = {};
    $scope.btnactive = 1;
    $scope.TempId = {};
    $scope.Status = 1;


    $scope.chkvalue = 0;
    //Hide Show Div
    $scope.ShowHideSave = function () {
        $scope.MainDiv = true;
        $scope.btnUpdate = false;
        $scope.btnSave = true;
    }
    //code for Display all data
    $scope.Initialize = function () {
        debugger;
        $scope.chkvalue = 0;

        $scope.UserCredentialModel.Status = $scope.btnactive;
        Service.Post("StdWiseDivision/GetAllStandard", $scope.UserCredentialModel).then(function (result) {

            $scope.ViewGetStudentInfoes = result.data.ResultData;
            $scope.StandardData = result.data.ResultData;


        })
        Service.Post("StdWiseDivision/GetAllBoard", $scope.UserCredentialModel).then(function (result) {

            $scope.ViewGetStudentInfoes = result.data.ResultData;
            $scope.BoardData = result.data.ResultData;


        })
        Service.Post("StdWiseDivision/GetAllDivision", $scope.UserCredentialModel).then(function (result) {

            $scope.ViewGetStudentInfoes = result.data.ResultData;
            $scope.DivisionData = result.data.ResultData;


        })
        Service.Post("StdWiseDivision/Display_StandardWiseDivision", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data.ResultData;
            $scope.StdWiseDivisionData = result.data.ResultData;


        })
    }



    //code for Add Section
    $scope.Add = function () {
        debugger;


        var lst = "";
        for (var i = 0; i < $scope.DivisionData.length; i++) {
            if ($scope.DivisionData[i].Selected) {
                var DivisionID = $scope.DivisionData[i].DivisionID;

                lst = lst + DivisionID + ",";
                //$scope.lst.push(DivisionID);
            }
        }
        var data = {

            BoardId: $scope.ddlBoard,
            StandardID: $scope.StandardID,
            DivisionID: lst


        };
        if ($scope.form.$valid) {
            Service.Post("StdWiseDivision/AddStdWiseDivision", JSON.stringify(data)).then(function (response) {
                $scope.MainDiv = false;
                $scope.btnUpdate = false;
                $scope.btnSave = true;
                if (response.data.IsSucess) {
                    $scope.Initialize();
                    alert(response.data.ResultData);
                }
                else {


                    alert(response.data.ResultData);
                }

            });
        }
    }

    //Get single Std Wise Div
    $scope.SingleValue = function (StandardID, DivisionID, BoardId, StdWiseDivisionId) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.MainDiv = true;
        var data = {

            StandardID: StandardID,
            DivisionId: DivisionID,
            BoardId: BoardId,
            StdWiseDivisionId: StdWiseDivisionId

        };

        Service.Post("StdWiseDivision/GetSingleValue", JSON.stringify(data)).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;



            //$scope.StandardId = result.data.ResultData.StandardID;
            //$scope.DivisionId = result.data.ResultData.DivisionID;
            //$scope.ddlBoard = result.data.ResultData.BoardID;
            //$scope.StandardName = result.data.ResultData.StandardName;
            $scope.StandardID = result.data.StandardID;
            $scope.DivisionId = result.data.DivisionID;
            $scope.ddlBoard = result.data.BoardID;
            $scope.StandardName = result.data.StandardName;
            $scope.BoardName = result.data.BoardName;
            $scope.StdWiseDivisionId = result.data.StdWiseDivisionId;

            $scope.chkvalue = 1;

        })
    }

    $scope.checkID = function (DivisionId) {
        debugger;

        if ($scope.chkvalue == 1) {
            var count = 0;

            if ($scope.DivisionId == DivisionId) {

                count = count + 1;
                $scope.TempId = DivisionId;
                $scope.chkvalue == 0;
                return true;
            }
            else {

            }



        }



    }

    //code for Update Section

    $scope.Update = function (StandardID, BoardID, StdWiseDivisionId) {
        debugger;
        var lst = "";
        for (var i = 0; i < $scope.DivisionData.length; i++) {
            if ($scope.DivisionData[i].Selected) {
                var DivisionID = $scope.DivisionData[i].DivisionID;

                lst = lst + DivisionID + ",";
                //$scope.lst.push(DivisionID);
            }
        }
        var data = {
            StandardID: StandardID,
            DivisionID: lst,
            BoardID: BoardID,
            StdWiseDivisionId: StdWiseDivisionId,
            Status: $scope.Status


        };
        if ($scope.form.$valid) {
            if (data.DivisionID == "") {
                data.DivisionID = $scope.TempId;
            }
            Service.Post("StdWiseDivision/UpdateStdDiv", JSON.stringify(data)).then(function (response) {
                $scope.btnUpdate = true;
                $scope.btnSave = false;
                $scope.MainDiv = false;
                if (response.data.IsSucess) {
                    debugger;




                    alert(response.data.ResultData);
                    $scope.StandardId = null;
                    $scope.DivisionID = null;
                    $scope.BoardID = null;
                    $scope.Initialize();

                }
                else {
                    debugger;

                    alert(response.data.Message);
                }

            });
        }
    }


    $scope.Delete = function (StdWiseDivisionId) {
        debugger;
        var data = {
            Status: $scope.btnactive,
            StdWiseDivisionId: StdWiseDivisionId
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the Section?");

        }
        else {
            var confirm = window.confirm("Do you want to active the Section?");
        }
        if (confirm == true) {
            Service.Post("StdWiseDivision/DeleteSingleStdDivision", JSON.stringify(data)).then(function (response) {

                debugger;
                if (response.data)
                    $scope.Initialize();
                alert(response.data.ResultData);
            });
        }

        $scope.IsVisible = false;
        $scope.Initialize();

    }
    $scope.Clear = function () {

        debugger;
        $scope.MainDiv = false;
        $scope.StandardId = null;
        $scope.DivisionID = null;
        $scope.BoardID = null;
        $scope.IsVisible = false;

    }
}