var recordAdded = "Record added successfully.";
var recordUpdated = "Record updated successfully.";
var recordDeleted = "Record deleted successfully.";
var recordConfirmDelete = "Are you sure you want to delete record?";
var recordExist = "Record(s) with the same value already exists.";

var CustomizeApp = function () {  

    var handleCustomizePortletTools = function () { 
        //debugger;
        $('body').on('click', '.hide-portlet', function (e) {
          //  debugger; 
            e.preventDefault();
            var el = $(".portlet-hide-show").closest(".portlet").children(".portlet-body");
            if ($(".portlet-hide-show").hasClass("collapse")) {
                $(".portlet-hide-show").removeClass("collapse").addClass("expand");
                el.slideUp(200);
            }
            $('#frmCRUD').validate().resetForm();
            $('#frmCRUD .form-group').removeClass('has-error');
            $('#frmCRUD .form-group').removeClass('has-success');
            $('.alert-danger', $('#frmCRUD')).hide();
        });        

        $('body').on('click', '.show-portlet', function (e) {
            e.preventDefault();
            var el = $(".portlet-hide-show").closest(".portlet").children(".portlet-body");
            if ($(".portlet-hide-show").hasClass("expand")) {
                $(".portlet-hide-show").removeClass("expand").addClass("collapse");
                el.slideDown(200);
            }
        });
    };

    var handleValidation = function () {
 
        $("#frmCRUD .form-body").prepend("<div class='alert alert-danger display-hide'><button class= 'close' data-close='alert' ></button >You have some form errors. Please check below.</div >");
        var form = $('#frmCRUD');
        var error = $('.alert-danger', form);
        form.validate({
            errorElement: 'span',
            errorClass: 'help-block help-block-error',
            focusInvalid: false,
            ignore: "",
            invalidHandler: function (event, validator) {
                error.show(); 
                //App.scrollTo(error, -200); 
            },
            highlight: function (element) {
                $(element).closest('#frmCRUD .form-group').removeClass("has-success").addClass('has-error');                
            },
            success: function (label, element) {
                $(element).closest('#frmCRUD .form-group').removeClass('has-error').addClass('has-success');
            },
            submitHandler: function (form) {
                error.hide();
            }
        });
    };

    var handleToastr = function () {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "positionClass": "toast-bottom-center",
            "onclick": null,
            "showDuration": "1000",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
    };

    var handleDatePicker = function () {
        $('.date-picker').datepicker({
            autoclose: true,
            format: 'dd/mm/yyyy',
            todayHighlight: true
        });
    };

    return {
        init: function () {
            handleCustomizePortletTools();
            handleValidation();
            handleToastr();
            handleDatePicker();
        },

        AddMessage: function () {
            toastr["success"](recordAdded, "Message");
        },
        UpdateMessage: function () {
            toastr["success"](recordUpdated, "Message");
        },
        DeleteMessage: function () {
            toastr["success"](recordDeleted, "Message");
        }
    };
}();

jQuery(document).ready(function () {
    CustomizeApp.init();
});

$("#btnLogout").click(function () {
    bootbox.confirm("Are you sure you want to logout?", function (result) {
        if (result) {
            $.getJSON(baseURL + 'Login/Logout', function (data) {
                if (data) location.href = baseURL;
            });
        }
    });
});

