var app = angular.module('ERP').controller('AcademicController', AcademicController);

function AcademicController($scope, Service) {

    var form = $(".m-form m-form--fit m-form--label-align-right");
    $scope.ViewGetStudentInfoes = {};
    $scope.UserCredentialModel = {};
    $scope.btnactive = 1;


    $scope.Initialize = function () {
        debugger;
        $scope.UserCredentialModel.Status = $scope.btnactive;
        Service.Post("AcademicYear/GetAcademicYearInfo", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.AcademicList = result.data;
            //console.log(result.data);

        })
    }

    $scope.ShowHide = function (AcademicID) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.IsVisible = true;
        var data = {

            AcademicID: AcademicID

        };

        Service.Post("AcademicYear/GetSingleAcademicInfo", JSON.stringify(data)).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;
            $scope.AcademicID = result.data.ResultData.AcademicID;
            $scope.Type = result.data.ResultData.Type;
            $scope.StartDate = result.data.ResultData.StartDate;
            $scope.EndDate = result.data.ResultData.EndDate;

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
        $scope.Type = "";
        $scope.StartDate = "";
        $scope.EndDate = "";
        
    }
    $scope.Add = function (Type, StartDate, EndDate) {
        debugger;
        var StartDate = $('#m_datepicker_1').val();
        var EndDate = $('#m_datepicker_2').val();
        var data = {           
            Type: Type,
            StartDate: StartDate,
            EndDate: EndDate

        };
        if ($scope.form.$valid) {
            Service.Post("AcademicYear/AddAcademic", JSON.stringify(data)).then(function (response) {

                if (response.data.IsSucess) {
                    debugger;



                    //CustomizeApp.UpdateMessage();
                    $scope.Clear();
                    $scope.IsVisible = false;
                    $scope.Initialize();
                    alert(response.data.ResultData);
                    // window.location = "./ParentGrievance"

                    //alert(result.data);

                }
                else {
                    debugger;
                    //ShowMessage(0, response.data.Message);
                    alert(response.data.Message);
                    //$scope.clear();
                    //window.location = "./PostGrievance"
                }

            });
        }
    }

    $scope.AddUpdate = function (AcademicID, Type, StartDate, EndDate) {
        debugger;
        var StartDate = $('#m_datepicker_1').val();
        var EndDate = $('#m_datepicker_2').val();
        var data = {
            AcademicID: AcademicID,
            Type: Type,
            StartDate: StartDate,
            EndDate: EndDate

        };
        if ($scope.form.$valid) {
            Service.Post("AcademicYear/UpdateAcademic", JSON.stringify(data)).then(function (response) {

                if (response.data.IsSucess) {
                    debugger;



                    //CustomizeApp.UpdateMessage();
                    $scope.Clear();
                    $scope.IsVisible = false;
                    $scope.Initialize();
                    alert(response.data.ResultData);
                    // window.location = "./ParentGrievance"

                    //alert(result.data);

                }
                else {
                    debugger;
                    //ShowMessage(0, response.data.Message);
                    alert(response.data.Message);
                    //$scope.clear();
                    //window.location = "./PostGrievance"
                }

            });
        }
    }


    $scope.Delete = function (AcademicID) {
        debugger;
        var data = {

            AcademicID: AcademicID
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the State?");

        }
        else {
            var confirm = window.confirm("Do you want to active the State?");
        }
        if (confirm == true) {
            Service.Post("AcademicYear/DeleteAcademic", JSON.stringify(data)).then(function (response) {

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
