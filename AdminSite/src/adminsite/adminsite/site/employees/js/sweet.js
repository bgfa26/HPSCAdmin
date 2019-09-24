function sweetAlert(msg, type, relocation) {
    swal({
        title: msg,
        timer: 2000,
        buttons: false,
        className: 'heightswal',
        icon: type
    })
    .then(() => {
        window.location.href = relocation;
    });
}

function sweetAlertNoRedirect(msg, type) {
    swal({
        title: msg,
        timer: 2000,
        buttons: false,
        className: 'heightswal',
        icon: type
    })
}

function errorSweetAlert(msg, type) {
    swal({
        title: msg,
        timer: 2000,
        buttons: false,
        className: 'heightswal',
        icon: type
    });
}