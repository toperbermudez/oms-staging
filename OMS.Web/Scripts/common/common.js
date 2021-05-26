var serviceCaller = {
    get: function (url, callBack) {
        $.get(url, function (data) {
            if (callBack != undefined)
                callBack(data);
        }).fail(function (xhr, status, error) {

        });
    },
    post: function (url, data, callBack) {
        $.post(url, data, function (data) {
            if (callBack != undefined)
                callBack(data);
        }).fail(function (xhr, status, error) {

        });
    }
}

var common = {
    displayAlert: function ($parent,title,message) {
        var err = $('.errorAlert', $parent);
        err.show();
        err.find('#errTitle').text(title);
        err.find('#errMsg').text(message);
    },
    populateDropdowns: function ($dropdown, data, callBack) {
        var value = $dropdown.data('value');
        $dropdown.find('option[value!=""]').remove();
        $.each(data, function (index, item) {
            var $option = $('<option/>')
                .attr({ value: item.Value })
                .text(item.Text);
            if (callBack != undefined) {
                $option = callBack($option, item);
            }
            $dropdown.append($option);
        });
        $dropdown.val(value);
    }
}

var productController = {
    GetCategory: function (callback) {
        serviceCaller.get('/product/GetCategory', callback);
    },
    GetProduct: function (id, callback) {
        serviceCaller.get('/product/GetProduct/' + id, callback);
    },
    RemoveProduct: function (id, callback) {
        serviceCaller.get('/product/RemoveProduct/' + id, callback);
    }
};

var categoryController = {
    GetCategory: function (id, callback) {
        serviceCaller.get('/admin/GetCategory/' + id, callback);
    },
    DeleteCategory: function (id, callback) {
        serviceCaller.get('/admin/DeleteCategory/' + id, callback);
    }
};

var employeeController = {
    GetRoles: function (callback) {
        serviceCaller.get('/employee/GetRoles', callback);
    }
};

var Loader = {

  show: function(message) {
    if (message === undefined) {
      message = "Your file is being processed.<br/>Depending on the size of the file, this make take several minutes to complete.";
    }
    var $loader = $("<div id='loader'><p>" + message + "</p></div>").appendTo($("body"));

    // center
    var $loaderP = $('#loader p');
    var height = $loaderP.outerHeight();
    var width = $loaderP.outerWidth();
    $loaderP.css({ 'margin-top': (-height / 2) });
    $loaderP.css({ 'margin-left': (-width / 2) });
    $loader.fadeIn(2000);
  },
  hide: function() {
      $('#loader').remove();
  },
};