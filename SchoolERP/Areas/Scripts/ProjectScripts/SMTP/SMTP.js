var app = angular.module('ERP').controller('SMTPController', SMTPController);

function SMTPController($scope, Service) {

    var form = $(".student-admission-wrapper");
    $scope.ViewGetStudentInfoes = {};
    $scope.UserCredentialModel = {};
    $scope.ispassword = true;
    $scope.btnactive = 1;


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
        $scope.IsVisible = false;
        // $scope.Initialize();
    }
    $scope.Add = function (ConfigurationID, Port, Secure, Host, UserName, Password) {
        var data = {
            ConfigurationID: ConfigurationID,
            Port: Port,
            Secure: Secure,
            Host: Host,
            UserName: UserName,
            Password: Password

        };
        if ($scope.form.$valid) {
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
        }
    }

    $scope.AddUpdate = function (ConfigurationID, Port, Secure, Host, UserName) {
        var data = {
            ConfigurationID: ConfigurationID,
            Port: Port,
            Secure: Secure,
            Host: Host,
            UserName: UserName
           
        };
       
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
