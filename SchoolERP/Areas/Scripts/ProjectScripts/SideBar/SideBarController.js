
var app = angular.module('ERP').controller('SideBarController', SideBarController);

function SideBarController($scope, Service, $window) {

    var form = $(".m-form m-form--fit m-form--label-align-right");
    $scope.ViewGetStudentInfoes = {};
    $scope.UserCredentialModel = {};
    //alert('HEHELOOO');
    $scope.SiteMenu = [];
    $scope.Initialize = function () {
        
        Service.Post("SideBar/GetSiteMenu").then(function (result) {
           debugger;
           $scope.SiteMenu = result.data;

       })

    }
    $scope.Click = function (path) {
        debugger;
        //var data ="../SchoolAdmin/"
        if (path == null)
        {

        }
        else
        {
           
            var name = $window.location.origin + "/SchoolAdmin/" + path;
            $window.location = name;
            

        }

    }
}