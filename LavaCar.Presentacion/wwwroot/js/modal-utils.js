function mostrarModal(url, reloadOnSuccess = true) {
    $('#modalContenido').load(url, function () {
        $('#modalMantenimiento').modal('show');
        $('form', '#modalContenido').on('submit', function (e) {
            e.preventDefault();
            const form = $(this);

            $.ajax({
                url: form.attr('action'),
                method: form.attr('method'),
                data: form.serialize(),
                success: function (response) {
                    if (response.success) {
                        $('#modalMantenimiento').modal('hide');
                        Swal.fire({
                            icon: 'success',
                            title: 'Éxito',
                            text: response.message,
                            timer: 3000,
                            showConfirmButton: false
                        }).then(() => {
                            if (reloadOnSuccess) {
                                location.reload();
                            }
                        });
                    } else {
                        $('.text-danger', form).html('');
                        if (response.errors) {
                            $.each(response.errors, function (key, messages) {
                                const input = $('[name="' + key + '"]', form);
                                const errorSpan = input.next('.text-danger');
                                if (errorSpan.length) {
                                    errorSpan.html(messages.join('<br>'));
                                } else {
                                    input.after('<span class="text-danger">' + messages.join('<br>') + '</span>');
                                }
                            });
                        } else if (response.message) {
                            Swal.fire({
                                icon: 'error',
                                title: 'Error',
                                text: response.message,
                                timer: 3500,
                                showConfirmButton: false
                            });
                        }
                    }
                },
                error: function () {
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'Error al procesar la solicitud',
                        timer: 3500,
                        showConfirmButton: false
                    });
                }
            });
        });
    });
}
function eliminarEntidad(id, formId, inputId, opciones = {}) {
    const {
        titulo = '¿Estás seguro?',
        texto = "Esta acción no se puede deshacer",
        icono = 'warning',
        mensajeExito = 'Eliminado correctamente',
        mensajeError = 'Ocurrió un error al eliminar',
        urlRedireccion = window.location.href
    } = opciones;

    Swal.fire({
        title: titulo,
        text: texto,
        icon: icono,
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#6c757d',
        confirmButtonText: 'Sí, eliminar',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {
            const form = document.getElementById(formId);
            const input = document.getElementById(inputId);
            input.value = id;

            fetch(form.action, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded'
                },
                body: new URLSearchParams(new FormData(form))
            })
                .then(response => {
                    if (response.ok) {
                        Swal.fire({
                            icon: 'success',
                            title: 'Éxito',
                            text: mensajeExito,
                            timer: 2500,
                            showConfirmButton: false
                        }).then(() => {
                            window.location.href = urlRedireccion;
                        });
                    } else {
                        throw new Error();
                    }
                })
                .catch(() => {
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: mensajeError,
                        timer: 3000,
                        showConfirmButton: false
                    });
                });
        }
    });
}
