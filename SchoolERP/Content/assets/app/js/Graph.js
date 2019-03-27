angular.module('ERP').controller('Dashboard', Dashboard);

function Dashboard($scope, Service) {
   
     
          
    var canvas = document.getElementById("Doughnutcanvas");
       var ClosePopup = document.getElementById("popupCloseButton");
    var myNewChart =new Chart(document.getElementById("Doughnutcanvas"), {
    type: 'pie',
    data: {
        labels: ["Pending", "Collected"],
        datasets: [{
            label: "Population (millions)",
            backgroundColor: ["#FA8072", "#20B2AA"],
            data: [40, 60],
            
        }]
    },
    options: {
        title: {
            display: true,
            text: 'Fee Collection Details'
        }
    }
    });


     //popup
        var myNewChart1 =new Chart(document.getElementById("Doughnutcanvas1"), {
    type: 'pie',
    data: {
        labels: ["I", "II","III","IV","V"],
        datasets: [{
            label: "Population (millions)",
            backgroundColor: ["#3e95cd", "#8e5ea2","#BC8F8F","#FFDAB9","#FAFAD2"],
            data: [20, 20,10,40,10],
            
        }]
    },
    options: {
        title: {
            display: true,
            text: ' Standard Wise Fee Collection Details'
        }
    }
    });
   
    canvas.onclick = function (evt) {
        debugger;
        var activePoints = myNewChart.getElementsAtEvent(evt);
        var modal = document.getElementById('myModal');

        if (activePoints[0]) {
            var chartData = activePoints[0]['_chart'].config.data;
            var idx = activePoints[0]['_index'];

            $scope.name = chartData.labels[idx];
            var value = chartData.datasets[0].data[idx];
            var color = chartData.datasets[0].backgroundColor[idx]; //Or any other data you wish to take from the clicked slice
         $('.hover_bkgr_fricc').show();
          
          
            //alert(label + ' ' + value + ' ' + color); //Or any other function you want to execute. I sent the data to the server, and used the response i got from the server to create a new chart in a Bootstrap modal.
        }
      
    };

   ClosePopup.onclick=function()
         {
        

      $('.hover_bkgr_fricc').hide();
          
};
   
  
  };
 