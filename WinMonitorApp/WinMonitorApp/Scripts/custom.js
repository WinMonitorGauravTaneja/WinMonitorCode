//master page tab panel button click page loads
    //pageload function when dashboard tab clicked
    function masterPageDashBoardClicked() {
            $("#masterPageContentPlace").load("CompanyDashboard");
        }

    //pageload function when component tab clicked
    function masterPageComponentClicked() {
            $("#masterPageContentPlace").load("ComponentandStatus");
        }

    //pageload function when Metrics tab clicked
    function masterPageMetricsClicked() {
            $("#masterPageContentPlace").load("PerformanceMetrics");
        }

    //pageload function when activate page tab clicked
    function masterPageAcivatePageClicked() {
            $("#masterPageContentPlace").load("ActivatePage");
        }

    //pageload function when regitered admin tab clicked
    function masterPageRegisteredAdminClicked() {
            $("#masterPageContentPlace").load("RegisteredAdmin");
        }

    //pageload function when settings tab clicked
    function masterPageSettingsClicked() {
            $("#masterPageContentPlace").load("Settings");
    }


//Company Dashboard functions
    //function to open add company account modal
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
    //function to open change password modal
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
    //function to toggle state of checkboxes when state of master checkbox is changed in component page
    function checkUnCheck(source, name) {
        checkboxes = document.getElementsByName(name);
        for (var i in checkboxes)
            checkboxes[i].checked = source.checked;
    }



    //function to open add master component modal
    function openAddMasterComponentModalFuntion() {

        $.ajax({                                                                    //to add master components from database to the modal
            url: 'getMasterComponentDataFromDataBase',
            type: 'get',
            async:false,
            datatype: 'json',
            success: function(data)
            {
                var newRow, i, eachRow, rowCountHtmlPage;
                rowCountHtmlPage = document.getElementById("addMasterComponentModalTable").rows.length;
                if (rowCountHtmlPage <= data.length)
                {
                    for (i = 0; i < data.length; i++) {
                        eachRow = data[i];
                        newRow = '<tr><td><input type="checkBox" name="masterComponentListfromDBCheckBoxes"></td><td>' + eachRow[1] + '</td><tr>';
                        $("#addMasterComponentModalTableBody").append(newRow);
                    }
                }
            },
            error: function () {
                alert("error");
            }
        });

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


    //function to add selected master component to database and on component page
    function addMasterComponentToDBAndPage() {
        var data = ($('input[name="masterComponentListfromDBCheckBoxes"]:checked').serialize());
        $.ajax({
            url: "addMasterComponentToDB",
            type: 'post',
            async: false,
            datatype: 'json',
            data: { pMasterComponentListFromPage: data },
            success: function (data) {
                var i
                for (i = 0; i < data.length; i++) {
                    newRow = '<tr><td><input type="checkbox" name="componentCheckBox" value="' + data[i].PageComponentId + '"></td><td>' + data[i].PageComponentId + '</td><td>' + data[i].PageComponentName +
                '</td><td>' + data[i].PageComponentType + '</td><td>' + data[i].PageCompanyName + '</td><td>' + data[i].PageIncidentName + '</td></tr>';
                    $("#existingComponentTable").append(newRow);
                }
            },
            error: function () { alert("error"); }
        });

    }

    //function to open add specific component modal
    function openAddSpecificComponentModalFuntion() {
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

    //function to open create incident modal
    function openCreateIncidentModalFunction() {                                                                                              
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

    //function to load existing components from database to web page
    function loadComponentsFromDB() {
        $.ajax({
            url: "ComponentandStatusFromDB",
            type: 'get',
            data: { companyIdFromPage: companyId },
            datatype: 'json',
            success: function (data) {
                var i, j, company, component;
                for (i = 0; i < data.length; i++) {//company in data){
                    for (j = 0; j < data[i].length; j++) {
                        row = data[i];
                        newRow = '<tr><td><input type="checkbox" name="componentCheckBox" value="' + row[j].PageComponentId + '"></td><td>' + row[j].PageComponentId + '</td><td>' + row[j].PageComponentName +
                        '</td><td>' + row[j].PageComponentType + '</td><td>' + data[i].PageCompanyName + '</td><td>' + row[j].PageIncidentName + '</td></tr>';
                        $("#existingComponentTableBody").append(newRow);
                    }
                }
            },
            error: function () { alert("error") }

        });
    }

//JQuery to check Company modal and to add company account(new row) in company table on dashboard page
    $("#btnaddCompany").click(function () {

        if (($("#CompanyName").val()) && ($("#CompanyURL").val())) {

            var jsonCompany = {"jsonCompanyName": $("#CompanyName").val(), "jsonCompanyURL": $("#CompanyURL").val()};

            $.ajax({
                type: "POST",
                url: "/Admin/jsonCompanyRetrieve",
                // The key needs to match your method's input parameter (case-sensitive).
                data: JSON.stringify({ jsonCompanyServers: jsonCompany }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data)
                {
                    alert(data);
                },
                failure: function (errMsg)
                {
                    alert(errMsg);
                }
            });
            $('#addCompanyAccountModal').modal('hide');
            alert("Company Sucessfully Added");
            $("#masterPageContentPlace").load("CompanyDashboard");
        }
        else {
            alert("Enter CompanyName and CompanyURL");
        }   
    });

//Company Select button using radio selection
    $('#btnSelectCompany').click(function () {
        if ($('input:radio[name="radioCompanySelect"]').is(":checked")) {
            var tempCompany = $('input:radio[name="radioCompanySelect"]:checked').closest("tr");
            var giveCompanyName = tempCompany.find("#RazorCompanyName").text();

            //global company id passed
             globalCompanyId = tempCompany.find("#RazorCompanyId").text();

            alert("Selected Company: " + giveCompanyName);
        }
        else {
            alert("No Company Selected");
        }
    });



//JQuery to check specific components modal and to  add specific component(new row) in existing component table on component page  
    $("#btnaddSpecificComponent").click(function () {

        if (($("#formComponentName").val())) {

            var jsonSpecificComponents = { "jsonSpecificComponentName": $("#formComponentName").val(), "jsonSpecificComponentStatus": "Operational", "jsonSpecificComponentCompanyId": globalCompanyId};

            $.ajax({
                type: "POST",
                url: "/Admin/jsonSpecificComponentRetrieve",
                // The key needs to match your method's input parameter (case-sensitive).
                data: JSON.stringify({ jsonSpecificComponentServers: jsonSpecificComponents }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    alert(data);
                },
                failure: function (errMsg) {
                    alert(errMsg);
                }
            });
            $('#AddSpecificComponentModal').modal('hide');
            alert("Specific Component Sucessfully Added");
            $("#masterPageContentPlace").load("ComponentandStatus");

        }
        else {
            alert("Enter Specific ComponentName");
        }
    });


//JQuery to add and check new incident in the incident table and JQuery to check fields in minor and major event modal
    $("#btnaddIncident").click(function () {

        if (($("#formIncidentName").val()) && ($("#formIncidentDetails").val())) {
           
            
            var jsonIncidents = { "jsonIncidentName": $("#formIncidentName").val(), "jsonIncidentDetails": $("#formIncidentDetails").val()};

            $.ajax({
                type: "POST",
                url: "/Admin/jsonIncidentRetreive",
                // The key needs to match your method's input parameter (case-sensitive).
                data: JSON.stringify({ jsonIncidentServers: jsonIncidents }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    alert(data);
                },
                failure: function (errMsg) {
                    alert(errMsg);
                }
            });
            $('#raiseIncidentModal').modal('hide');
            alert("Incident added sucessfully");
            $("#masterPageContentPlace").load("ComponentandStatus");

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
                "lengthMenu": [[5, 10, 20], [5, 10, 20]]
            });
    });




//Table break events for Components and Status Table
    $("#existingComponentTable").ready(function(){
        $("#existingComponentTable").DataTable(
            {
                "lengthMenu": [[5, 10, 20], [5, 10, 20]]
            });
    });


//Table break events for Registered Administrators Table
    $("#RegisteredAdminTable").ready(function() {
        $("#RegisteredAdminTable").DataTable(
            {
                "lengthMenu": [[5, 10, 20], [5, 10, 20]]
            });
    });


//global company variable
    $("radioCompanySelect").click(function () {
        {
            $("tr").css("background-color", "green");
        }
    });