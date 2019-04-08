var app = angular.module('ERP').controller('SchoolAchievementDetailsController', SchoolAchievementDetailsController);

function SchoolAchievementDetailsController($scope, Service) {

    var form = $(".student-admission-wrapper");
    $scope.AchievementTypeList = {};
    $scope.UserCredentialModel = {};
    $scope.GetAllSchoolAchievementDet = {};
    $scope.btnactive = 1;


    $scope.Initialize = function () {
        debugger;
        $scope.UserCredentialModel.Status = $scope.btnactive;
        Service.Post("SchoolAchievementDetails/GetAllSchoolAchievementDetails", $scope.UserCredentialModel).then(function (result) {
          
            $scope.GetAllSchoolAchievementDet = result.data;
           
        })
    }


    $scope.GetAchievementType = function () {
        debugger;
        Service.Get("SchoolAchievementDetails/GetAllAchievementTypeMaster").then(function (result) {
           
            $scope.AchievementTypeList = result.data.ResultData;
            
        })

    }

  

    $scope.ShowHide = function (AchievementDID) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.IsVisible = true;
        $scope.GetAchievementType();
        var data = {

            AchievementDID: AchievementDID

        };

        Service.Post("SchoolAchievementDetails/GetSingleAchievementDetails", JSON.stringify(data), $scope.UserCredentialModel).then(function (result) {

            debugger;
            var Date = $('#m_datepicker_1').val();
            $scope.GetAllSchoolAchievementDet = result.data;
            $scope.Achievement = result.data.Achievement;
            $scope.AchievementDID = result.data.AchievementDID;
            $scope.AchievementTypeID = result.data.AchievementTypeID;
            $scope.Date = result.data.Date;
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
        $scope.Date = null;
        $scope.Achievement = null;
        $scope.AchievementDID = null;
        $scope.AchievementTypeID = null;
        $scope.IsVisible = false;
        $scope.AchievementTypeList = null;
    }
   
    $scope.Add = function (AchievementTypeID, Achievement, Date) {
        debugger;
        var Date = $('#m_datepicker_1').val();
        var data = {
            AchievementTypeID: AchievementTypeID,
            Achievement: Achievement,
            Date: Date
        };
        if ($scope.form.$valid) {
            Service.Post("SchoolAchievementDetails/SaveAchievementDetails", JSON.stringify(data)).then(function (response) {
                debugger;
                if (response.data.IsSucess) {
                CustomizeApp.AddMessage();
                    $scope.Clear();
                   
                    $scope.GetAchievementType();
                 
                    $scope.IsVisible = false;
                    $scope.Initialize();
                    //alert(response.data.ResultData);
                    
                }
                else {
                    debugger;
                    ShowMessage(0, response.data.Message);
                    //alert(response.data.Message);
                      }

            });
        }
    };

    $scope.Update = function (AchievementDID, AchievementTypeID, Achievement, Date) {
        debugger;
        var Date = $('#m_datepicker_1').val();
        var data = {
            AchievementDID: AchievementDID,
            AchievementTypeID: AchievementTypeID,
            Achievement: Achievement,
            Date: Date
        };
        if ($scope.form.$valid) {
            Service.Post("SchoolAchievementDetails/UpdateAchievementDetails", JSON.stringify(data)).then(function (response) {
                debugger;
                if (response.data.IsSucess) {
                    CustomizeApp.UpdateMessage();
                    $scope.Clear();

                    $scope.GetAchievementType();

                    $scope.IsVisible = false;
                    $scope.Initialize();
                   

                }
                else {
                    debugger;
                    ShowMessage(0, response.data.Message);
                    //alert(response.data.Message);
                }

            });
        }
    };


    $scope.Delete = function (AchievementDID) {
        debugger;
        var data = {

            AchievementDID: AchievementDID
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the Achievement Details?");

        }
        else {
            var confirm = window.confirm("Do you want to active the Achievement Details?");
        }
        if (confirm == true) {
            Service.Post("SchoolAchievementDetails/DeleteAchievementDetails", JSON.stringify(data)).then(function (response) {

                debugger;
                if (response.data)
                    $scope.Initialize();
                alert(response.data.ResultData);
            });
        }
        $scope.Clear();
        $scope.IsVisible = false;
        $scope.Initialize();

    };





}
