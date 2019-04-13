var app = angular.module('ERP').controller('SMTPController', SMTPController);

function SMTPController($scope, Service, $timeout) {

    var form = $(".m-form--label-align-right");
    $scope.ViewGetStudentInfoes = {};
    $scope.UserCredentialModel = {};
    $scope.ispassword = true;
    $scope.btnactive = 1;
    $scope.myText = "/Content/Loader4.gif";
    $scope.isCheck = true;
    $scope.btnu = false;
    $scope.btns = false;
    $scope.btnValue = "SAVE";

    $scope.Initialize = function () {
        debugger;
        $scope.UserCredentialModel.Status = $scope.btnactive;
        Service.Post("SMTP/GetSMTPInfo", $scope.UserCredentialModel).then(function (result) {
            debugger;
            $scope.ViewGetStudentInfoes = result.data;
            $scope.SMTPData = result.data;
            //console.log(result.data);

        })
    }

    $scope.ShowHide = function (ConfigurationID) {
        debugger;
        $scope.btnUpdate = true;
        $scope.btnSave = false;
        $scope.IsVisible = true;
        $scope.ispassword = false;
        var data = {

            ConfigurationID: ConfigurationID

        };

        Service.Post("SMTP/GetSingleSMTPInfo", JSON.stringify(data)).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;

            $scope.ConfigurationID = result.data.ResultData.ConfigurationID;
            $scope.Port = result.data.ResultData.Port;
            $scope.Host = result.data.ResultData.Host;
            $scope.Secure = result.data.ResultData.Secure; 
            $scope.UserName = result.data.ResultData.UserName;
            $scope.Password = result.data.ResultData.Password;
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

        $scope.ConfigurationID = null;
        $scope.Port = null;
        $scope.Secure = null;
        $scope.Host = null;
        $scope.UserName = null;
        $scope.Password = null;
        //$scope.IsVisible = false;
         window.location.reload();
        // $scope.Initialize();
    }
    $scope.Add = function () {       

        var data = {
            ConfigurationID: $scope.ConfigurationID,
            Port: $scope.Port,
            Secure: $scope.Secure,
            Host: $scope.Host,
            UserName: $scope.UserName,
            Password: $scope.Password

        };
        if ($scope.form.$valid) {
            $scope.btns = true;
            $scope.isCheck = false;
            $scope.btnValue = "SAVING.........";
            $timeout(function () {
                $scope.isCheck = true;
                $scope.btnSave = false;
                $scope.btnValue = "SAVE";
                Service.Post("SMTP/AddSMTP", JSON.stringify(data)).then(function (response) {

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
                        //alert(response.data.Message);
                        //$scope.clear();
                        //window.location = "./PostGrievance"
                    }

                });
            }, 3000);
        }
      
    }

    $scope.AddUpdate = function () {
        
        var data = {
            ConfigurationID: $scope.ConfigurationID,
            Port: $scope.Port,
            Secure: $scope.Secure,
            Host: $scope.Host,
            UserName: $scope.UserName
           
        };
        if ($scope.form.$valid) {
            $scope.btnu = true;

            $scope.isCheck = false;
            $scope.btnValue = "SAVING.........";
            $timeout(function () {
                $scope.isCheck = true;
                $scope.btnUpdate = false;

                $scope.btnValue = "SAVE";
                Service.Post("SMTP/UpdateSMTP", JSON.stringify(data)).then(function (response) {

                    if (response.data.IsSucess) {
                        debugger;
                        CustomizeApp.UpdateMessage();
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


    $scope.Delete = function (ConfigurationID) {
        debugger;
        var data = {

            ConfigurationID: ConfigurationID
        };

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the SMTP?");

        }
        else {
            var confirm = window.confirm("Do you want to active the SMTP?");
        }
        if (confirm == true) {
            Service.Post("SMTP/DeleteSMTP", JSON.stringify(data)).then(function (response) {

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
