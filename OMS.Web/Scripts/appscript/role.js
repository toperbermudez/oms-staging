$(function () {
    var init = function () {
        var elements = {
            $roleModal: $('#genericModal'),
            $roleList: $('#genericModal').find('#roleList'),
            $roleForm: $('#genericModal').find('#roleForm')
        };

        var dom = {
            roleValidator: null,
            roleDt: null
        };
        var methods = {
            initializeDt: function () {
                elements.$roleList.DataTable().clear().destroy();
                dom.roleDt = elements.$roleList.DataTable({
                    "processing": true,
                    "serverSide": true,
                    "ajax": "/role/ListRole",
                    "lengthChange": false,
                    "filter": false,
                    "columnDefs": [
                        {
                            "render": function (data, type, row) {
                                var a = $('<a></a>');
                                a.addClass('btn btn-danger').text('Delete');
                                return '<a class="btn btn-danger btnDeleteProduct">Delete</a>';
                            },
                            "targets": 3
                        },
                        { "visible": false, "targets": [0] }
                    ]
                });
            },
            init: function () {
                methods.initializeDt();
                elements.$roleForm.validate();
                dom.roleValidator = elements.$roleForm.data('validator');
            }
        };

        $('#rolebtn').on('click', function () {
            methods.init();
        });

        elements.$roleList.find('tbody')
            .on('click', 'tr', function () {
                var data = dom.roleDt.row(this).data();
                Loader.show('Retrieving Role Details. Please Wait');
                roleController.GetRole(data[0], function (data) {
                    Loader.hide();
                    $('#Name', elements.$roleForm).val(data.Name);
                    $('#Description', elements.$roleForm).val(data.Description);
                    $('#ID', elements.$roleForm).val(data.ID);
                    $('.btnNew', elements.$roleModal).show();
                });
            })
            .on('click', '.btnDeleteRole', function (e) {
                e.stopPropagation();
                if (confirm("Are you sure you want to delete this record?")) {
                    var data = dom.RoleDt.row($(this).closest('tr')).data();
                    Loader.show('Deleting Role. Please Wait');
                    roleController.DeleteRole(data[0], function (data) {
                        Loader.hide();
                        if (data.Success) {
                            methods.initializeDt();
                        } else {
                            common.displayAlert(element.$roleForm, 'Error', data.ErrorMessage);
                        }
                    });
                }
            });

        $('.btnSave').on('click', function (e) {
            if (elements.$roleForm.valid()) {
                e.preventDefault();
                Loader.show('Saving Role Please wait');
                $.ajax({
                    type: 'POST',
                    url: elements.$roleForm.attr('action'),
                    data: elements.$roleForm.serialize(),
                    success: function (data) {
                        Loader.hide();
                        if (data.Success) {
                            methods.initializeDt();
                        } else {
                            common.displayAlert(elements.$roleForm, 'Error', data.ErrorMessage);
                        }
                    }
                });
            }
        });

        $('.btnNew').on('click', function () {
            elements.$roleForm.find('input').val('');
            $(this).hide();
        });

        methods.init();
    };


    $('#rolebtn').on('click', function () {
        var $this = $(this);
        Loader.show('Loading');
        LoadModal($this.data('modal-url'), 'Create Role', function () {
            Loader.hide();
            init();
        });
    });
});