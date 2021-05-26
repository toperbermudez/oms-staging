function LoadModal(url,title, callback) {
    var $genericModal = $('#genericModal');
    $.get(url, function (data) {
        var $data = $('<div></div>');
        $data.html($(data).html());
        $genericModal.find('.modal-title').text(title);
        $genericModal.find('.modal-body').html($data.find('.modalBody').html());
        $genericModal.find('.modal-footer').html($data.find('.modalFooter').html());
        $genericModal.modal('show');
        callback();
    });
}