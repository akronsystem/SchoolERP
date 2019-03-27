var app = angular.module('ERP').controller('AssignWidgetController', AssignWidgetController);

function AssignWidgetController($scope, Service) {

    var form = $(".student-admission-wrapper");
   
    $scope.UserCredentialModel = {};
 
    $scope.Sequence = [];
   
    $scope.Initialize = function () {
      
        $scope.UserCredentialModel.Status = 1;
        Service.Post("AssignWidget/GetAssignWidget", $scope.UserCredentialModel).then(function (result) {
          
            $scope.AssignWidgetList = result.data;
          
            $scope.AssignWidgetID = "";
            for (var i = 0; i < $scope.WidgetList.length; i++) {
               
                    $scope.WidgetList[i].Selected = false;
                
            }

           

        })
    }


    $scope.GetRoleList = function () {
    
        Service.Post("AssignWidget/GetRole").then(function (result) {

            $scope.RoleList = result.data;

        })

    }

    $scope.GetWidgetList = function () {
       
        Service.Post("AssignWidget/GetWidgetList").then(function (result) {

            $scope.WidgetList = result.data;

           

        })

    }

   



    $scope.ShowHideSave = function () {
        
        $scope.btnUpdate = false;
        $scope.btnSave = true;
        $scope.IsVisible = true;
       
        $scope.GetRoleList();

       
    }
   

    $scope.Clear = function () {
      
        $scope.RoleID = "";
        $scope.Sequence = [];
      
        for (var i = 0; i < $scope.WidgetList.length; i++)
        {
            if ($scope.WidgetList[i].Selected)
            {
                $scope.WidgetList[i].Selected = false;
            }
        }
        $scope.AssignWidgetID = "";
        $scope.IsVisible = false;
       
    }

    
    $scope.Add = function (RoleID) {
        var WidgetIDs = "";
        var f = 0;
     
        if (RoleID == undefined || RoleID == "" || RoleID=="0") {
            alert('Please Select Role!');
            return false;
        }
        else
        {
            for (var i = 0; i < $scope.WidgetList.length; i++) {
                if ($scope.WidgetList[i].Selected)
                {
                    f = 1;
                    var WidgetID = $scope.WidgetList[i].WidgetID;
                    var WidgetName = $scope.WidgetList[i].WidgetName;
                    WidgetIDs += WidgetID + ",";
                }
            }
            if (f==0)
            {
                alert('Please Select Widgets!');
                return false;   
            }
            var SequenceIDs = "";
            var a = "";

            for (var i = 0; i < $scope.WidgetList.length; i++) {
                if ($scope.WidgetList[i].Selected == false)
                {

                    for (var j = 0; j < $scope.Sequence.length; j++)
                    {
                        $scope.Sequence[i] = ""; // Clear textbox value when Checkbox is Unchecked
                    }
                }
            }
            for (var j = 0; j < $scope.Sequence.length; j++)
            {
                a += $scope.Sequence[j] + ",";
            }



            for (var i = 0; i < $scope.WidgetList.length; i++)
            {
                if ($scope.WidgetList[i].Selected == false)
                {

                    $scope.Sequence[i] = "";

                    // Clear textbox value when Checkbox is Unchecked
                }
            }

            SequenceIDs = $scope.Sequence;
            if (a == "" || a == undefined)
            {
                alert('Please Enter Order!');
                return false;
            }
            var data = {
                RoleID: RoleID,
                WidgetIDs: WidgetIDs,
                SequenceIDs: a,
                AssignWidgetID: $scope.AssignWidgetID
            };


            if ($scope.form.$valid) {
                Service.Post("AssignWidget/SaveAssignWidget", JSON.stringify(data)).then(function (response) {

                    if (response.data.IsSucess) {

                        //CustomizeApp.UpdateMessage();
                        $scope.Clear();


                        $scope.IsVisible = false;
                        $scope.Initialize();
                        alert(response.data.ResultData);

                    }
                    else {

                        //ShowMessage(0, response.data.Message);
                        alert(response.data.Message);
                    }

                });
            }
        }//else complete
    };

    $scope.clearTextBox = function ()
    {
        for (var i = 0; i < $scope.WidgetList.length; i++)
        {
            if ($scope.WidgetList[i].Selected == false)
            {
                for (var j = 0; j < $scope.Sequence.length; j++)
                {
                    $scope.Sequence[i] = "";

                    // Clear textbox value when Checkbox is Unchecked
                }
            }
        }
    }
    $scope.GetRoleID = function (RoleID) {

        $scope.Sequence = [];
        $scope.AssignWidgetID ="";
        for (var i = 0; i < $scope.WidgetList.length; i++) {
            if ($scope.WidgetList[i].Selected) {
                $scope.WidgetList[i].Selected = false;
            }
        }
       
        var data = {
            RoleID: RoleID
        };
        Service.Post("AssignWidget/GetAssignWidgetRoleWise", JSON.stringify(data)).then(function (result) {
            
            $scope.GetAssignWidgetRoleWiseList = result.data;
            

            angular.forEach($scope.WidgetList, function (value1, key1) {
                angular.forEach($scope.GetAssignWidgetRoleWiseList, function (value2, key2) {
                    if (value1.WidgetID == value2.WidgetID) {

                      
                        $scope.WidgetList[value2.WidgetID - 1].Selected = true;

                        $scope.Sequence[value2.WidgetID - 1] = value2.Sequence;
                        $scope.AssignWidgetID =value2.AssignWidgetID;

                    }
                });
            });
        })

    };


    $scope.ChkOrderValue = function (Sequence)
    {
        debugger;
        var flag = 0,temp=0;
        
        for (var i = 0; i < $scope.Sequence.length; i++)
        {
           
            for (var count = 1; count < $scope.Sequence.length; count++)
            {

                if ($scope.Sequence[i] == $scope.Sequence[count + i])
                {
                    flag = 1;
                 //   $scope.Sequence[i] = "";
                    $scope.Sequence[count] = "";
                }
            }
        }
        if (flag==1)
        {
            alert('Order Number Is Already Exists!!');
        } 
    };

    $scope.formatDate = function (date) {
        var dateOut = new Date(date);
        return dateOut;
    };

  
   


}
