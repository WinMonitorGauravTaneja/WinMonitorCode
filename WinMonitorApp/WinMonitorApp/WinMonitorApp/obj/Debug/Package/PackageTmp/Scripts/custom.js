//master page tab panel button click page loads
    function masterPageDashBoardClicked() {
            $("#masterPageContentPlace").load("Admin/CompanyDashboard");
        }

    function masterPageComponentClicked() {
            $("#masterPageContentPlace").load("Admin/ComponentandStatus");
        }

    function masterPageMetricsClicked() {
            $("#masterPageContentPlace").load("Admin/PerformanceMetrics");
        }

    function masterPageAcivatePageClicked() {
            $("#masterPageContentPlace").load("Admin/ActivatePage");
        }

    function masterPageRegisteredAdminClicked() {
            $("#masterPageContentPlace").load("Admin/RegisteredAdmin");
        }

    function masterPageSettingsClicked() {
            $("#masterPageContentPlace").load("Admin/Settings");
    }


//Company Dashboard functions
    function addAccountCompanyDashboard() {
        $(function () {
            function reposition() {
                var modal = $(this),
                    dialog = modal.find('.modal-dialog');
                modal.css('display', 'block');

                // Dividing by two centers the modal exactly, but dividing by three 
                // or four works better for larger screens.
                dialog.css("margin-top", Math.max(0, ($(window).height() - dialog.height()) / 3));
            }
            // Reposition when a modal is shown
            $('.modal').on('show.bs.modal', reposition);
            // Reposition when the window is resized
            $(window).on('resize', function () {
                $('.modal:visible').each(reposition);
            });
        });
        $("#addCompanyAccountModal").modal('show');
    }


//Setting Page Functions
    function changePasswordSettings() {
        $(function () {
            function reposition() {
                var modal = $(this),
                    dialog = modal.find('.modal-dialog');
                modal.css('display', 'block');

                // Dividing by two centers the modal exactly, but dividing by three 
                // or four works better for larger screens.
                dialog.css("margin-top", Math.max(0, ($(window).height() - dialog.height()) / 3));
            }
            // Reposition when a modal is shown
            $('.modal').on('show.bs.modal', reposition);
            // Reposition when the window is resized
            $(window).on('resize', function () {
                $('.modal:visible').each(reposition);
            });
        });
        $("#changePasswordModal").modal('show');
    }


//Component Page Functions
    //function1
    function openAddMasterComponentModalFuntion() {                                                                                  //click event: Add Master Component Modal show
        $(function () {
            function reposition() {
                var modal = $(this),
                    dialog = modal.find('.modal-dialog');
                modal.css('display', 'block');

                // Dividing by two centers the modal exactly, but dividing by three 
                // or four works better for larger screens.
                dialog.css("margin-top", Math.max(0, ($(window).height() - dialog.height()) / 3));
            }
            // Reposition when a modal is shown
            $('.modal').on('show.bs.modal', reposition);
            // Reposition when the window is resized
            $(window).on('resize', function () {
                $('.modal:visible').each(reposition);
            });
        });
        $("#AddMasterComponentModal").modal('show');
    }

    //function2
    function openAddSpecificComponentModalFuntion() {                                                                                   //click event: Add Specific Component Modal show
        $(function () {
            function reposition() {
                var modal = $(this),
                    dialog = modal.find('.modal-dialog');
                modal.css('display', 'block');

                // Dividing by two centers the modal exactly, but dividing by three 
                // or four works better for larger screens.
                dialog.css("margin-top", Math.max(0, ($(window).height() - dialog.height()) / 3));
            }
            // Reposition when a modal is shown
            $('.modal').on('show.bs.modal', reposition);
            // Reposition when the window is resized
            $(window).on('resize', function () {
                $('.modal:visible').each(reposition);
            });
        });
        $("#AddSpecificComponentModal").modal('show');
    }

    //function3
    function openCreateIncidentModalFunction() {                                                                                               //click event: Create Incident Modal show
        $(function () {
            function reposition() {
                var modal = $(this),
                    dialog = modal.find('.modal-dialog');
                modal.css('display', 'block');

                // Dividing by two centers the modal exactly, but dividing by three 
                // or four works better for larger screens.
                dialog.css("margin-top", Math.max(0, ($(window).height() - dialog.height()) / 3));
            }
            // Reposition when a modal is shown
            $('.modal').on('show.bs.modal', reposition);
            // Reposition when the window is resized
            $(window).on('resize', function () {
                $('.modal:visible').each(reposition);
            });
        });
        $("#raiseIncidentModal").modal('show');
    }


//JQuery to check Company modal and add Company table row  
    $("#btnaddCompany").click(function () {

        if (($("#CompanyName").val()) && ($("#CompanyURL").val())) {
            /*
            1. set Company No. using guid or sequences
            2. set all the entered values in the database
            */
            var newrow = '<tr><td> <input type="radio" name="companyselect" />+dBval</td><td>+DB'+$("#CompanyName").val()+'</td><td>+DB'+$("#CompanyURL").val()+'</td></tr>';
            $("#companytable").append(newrow);
        }
        else {
            alert("Enter CompanyName and CompanyURL");
        }   
    });


//JQuery to check specific components modal and to add to the table
    $("#btnaddSpecificComponent").click(function () {

        if (($("#formComponentId").val()) && ($("#formComponentName").val())) {
            /*
            1. set all the entered values in the database
            */
            var newrow = '<tr><td><input type="checkbox" name="componentCheckBox">+dBval</td><td>+DB' + $("#formComponentId").val() + '</td><td>+DB' + $("#formComponentName").val() +
                '</td><td>+DBSpecific</td><td>+DBCompanyName</td><td>+DBIncidentName</td></tr>';
            $("#existingComponentTable").append(newrow);
        }
        else {
            alert("Enter ComponentID and ComponentName");
        }
    });


    //JQuery to check fields in minor and major event modal
    $("#btnaddIncident").click(function () {

        if (($("#formIncidentName").val()) && ($("#formIncidentDetails").val())) {
            /*
            1. set all the entered values in the database
            */   
        }
        else {
            alert("Enter IncidentName and IncidentDetails");
        }
    });


//JQuery for check password validation modal
    $("#btnChangePassword").click(function () {
            if ($("#NewPassword").val() == $("#ConfirmNewPassword").val()) {


            }
            else {

                alert("New Password and Confirm New Password Not Match!");
            }
    });


//Table break events for CompanyDashboard Table
    $("#companytable").ready(function(){
        $("#companytable").DataTable(
            {
                "lengthMenu": [[2, 5, 8], [2, 5, 8]]
            });
    });

//Table break events for Components and Status Table
    $("#existingComponentTable").ready(function(){
        $("#existingComponentTable").DataTable(
            {
                "lengthMenu": [[2, 5, 8], [2, 5, 8]]
            });
    });


//Table break events for Registered Administrators Table
    $("#RegisteredAdminTable").ready(function() {
        $("#RegisteredAdminTable").DataTable(
            {
                "lengthMenu": [[2, 5, 8], [2, 5, 8]]
            });
    });
