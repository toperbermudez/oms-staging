$(function () {
    var element = {
        $employeeList: $('#employeeList'),
        $txtEmployeeSearch: $('#txtEmployeeSearch'),
        $activeDrpSearch: $('#activeDrpSearch'),
    };

    var dom = {
        employeeDt : null
    };

    var methods = {
        initEmployeeDT: function () {
            element.$employeeList.DataTable().clear().destroy();
            dom.employeeDt = element.$employeeList.DataTable({
                "processing": true,
                "serverSide": true,
                "ajax": {
                    "url": "/Employee/ListEmployee",
                    "type": "post",
                    "data": function (d) {
                        d.search = element.$txtEmployeeSearch.val();
                        d.filterType = element.$activeDrpSearch.val();
                    }
                },
                "lengthChange": false,
                "filter": false,
                "columnDefs": [
                    {
                        "render": function (data, type, row) {
                            var a = $('<a></a>');
                            a.addClass('btn btn-danger').text('Delete');
                            return '<a class="btn btn-danger btnDeactivate">Deactivate</a>';
                        },
                        "targets": 9
                    },
                    {
                        "render": function (data, type, row) {
                            var createdDate = new Date(data);
                            return createdDate.getMonth() + 1 + "/" + createdDate.getDay() + "/" + createdDate.getFullYear();
                        },
                        "targets": 7
                    },
                    {
                        "render": function (data, type, row) {
                            return data === "True" ? "Yes" : "No";
                        },
                        "targets": 6
                    },
                    { "visible": false, "targets": [0] }
                ]
            });
        },
        init: function () {
            methods.initEmployeeDT();
        },
        loadEmployeeModal: function (url) {
            Loader.show('Loading');
            LoadModal(url,'Add New Employee', function () {
                Loader.hide();
                $employeefrm = $('#employeefrm');
                $employeefrm.validate({
                    rules: {
                        Password: {
                            required: true,
                            equalTo: "#ConfirmPassword"
                        },
                        ConfirmPassword: {
                            required: true,
                            equalTo: "#Password"
                        }
                    },
                    messages: {
                        Password: {
                            equalTo: 'Password mismatch.'
                        },
                        ConfirmPassword: {
                            equalTo: 'Password mismatch.'
                        }
                    }
                });
                methods.loadRoles();
                $('.btnSaveEmployee').on('click', function (e) {
                    if ($employeefrm.valid()) {
                        e.preventDefault();
                        Loader.show('Saving Product Please Wait');
                        $.ajax({
                            type: 'POST',
                            url: $employeefrm.attr('action'),
                            data: $employeefrm.serialize(),
                            success: function (data) {
                                Loader.hide();
                                if (data.Success) {
                                    $('#genericModal').modal('hide');
                                    methods.initEmployeeDT();
                                } else {
                                    common.displayAlert($employeefrm, 'Error', data.ErrorMessage);
                                }
                            }
                        });
                    }
                });
            });
        },
        loadRoles: function () {
            employeeController.GetRoles(function (data) {
                common.populateDropdowns($('#RoleId'),data);
            });
        }
    };

    methods.init();

    $('.btnAddEmployee').on('click', function () {
        var $this = $(this);
        methods.loadEmployeeModal($this.data('modal-url'));
    });

    element.$txtEmployeeSearch.on('keyup', function () {
        dom.employeeDt.search($(this).val()).draw();
    });

    element.$activeDrpSearch.on('change', function () {
        dom.employeeDt.search($(this).val()).draw();
    });
});