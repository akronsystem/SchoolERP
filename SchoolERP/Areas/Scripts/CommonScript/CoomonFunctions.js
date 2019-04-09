var oldItem = null;

function IntializeTable($filter, NgTableParams, data) {   
    debugger;
    angular.forEach(data, function (value, key) {            
        angular.forEach(value, function (a, b) {
            if (b.endsWith('Date')) {                
                if (b === "CreatedDate" || b === "ModifiedDate") value[b] = $filter('formatedDate')(a, fullDateFormat);
                else value[b] = $filter('formatedDate')(a, shortDateFormat);
            }
        });
    });
    return new NgTableParams({ count: 25 }, {
        counts: [25, 50, 100],       
        dataset: data
    });
}

function ActiveRow(item) {
    if (oldItem) {
        oldItem.Selected = false;
    }
    if (oldItem === item) {
        item.Selected = false;
        oldItem = null;
    } else {
        item.Selected = true;
        oldItem = item;
    }
    item.Selected = true;
}

function ShowMessage(result, errorList, callback) {
    debugger;
    var title = "Message";
    if (result === 0) title = "Error";
    else if (result === -1) title = "Record not found";

    var error = "";
   
    if (errorList !== null) {
        if (typeof (errorList) === "object") {
            if (errorList.length > 1) {
                error = "<ul>";
                for (var i = 0; i < errorList.length; i++) {
                    error = error + "<li>" + errorList[i] + "</li>";
                }
                error = error + "</ul>";
            } else {
                error = "";
                angular.forEach(errorList, function (value, key) {
                    error = error + value;
                });
            }
        } else {
            error = errorList;
        }
    }
    bootbox.dialog({
        message: error,
        title: title, buttons: { main: { label: "OK", className: "blue", callback: callback } }
    });

    
}