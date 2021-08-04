$(document).ready(function () {
    $('.form-image').click(function () { $('#customFile').trigger('click'); });
    $(function () {
        $('.selectpicker').selectpicker();
    });

    $('[data-toggle="tooltip"]').tooltip()
    

    //$('a[data-toggle="tab"]').on('show.bs.tab', function (e) {

    //    var $target = $(e.target);

    //    if ($target.parent().hasClass('disabled')) {
    //        return false;
    //    }
    //});
    //$(".next-step").click(function (e) {

    //    var $active = $('.wizard .nav-tabs li.active');
    //    $active.next().removeClass('disabled');
    //    nextTab($active);
    //});
    //$(".prev-step").click(function (e) {

    //    var $active = $('.wizard .nav-tabs li.active');
    //    prevTab($active);
    //});

    setTimeout(function () {
        $('body').addClass('loaded');
    }, 200);

   
    jQueryModalGet = (url, title) => {
        try {
            $.ajax({
                type: 'GET',
                url: url,
                contentType: false,
                processData: false,
                success: function (res) {
                    $('#form-modal .modal-body').html(res.html);
                    $('#form-modal .modal-title').html(title);
                    $('#form-modal').modal('show');
                    console.log(res);
                },
                error: function (err) {
                    console.log(err)
                }
            })
            //to prevent default form submit event
            return false;
        } catch (ex) {
            console.log(ex)
        }
    }

    jQueryModalGetHijo = (numero, url, title) => {
        try {
            $.ajax({
                type: 'GET',
                url: url,
                contentType: false,
                processData: false,
                success: function (res) {
                    $('#form-modal-hijo-'+numero+' .modal-body').html(res.html);
                    $('#form-modal-hijo-' + numero +' .modal-title').html(title);
                    $('#form-modal-hijo-' + numero +'').modal('show');
                    console.log(res);
                },
                error: function (err) {
                    console.log(err)
                }
            })
            //to prevent default form submit event
            return false;
        } catch (ex) {
            console.log(ex)
        }
    }


    jQueryModalGetHijo1 = (url, title) => {
        try {
            $.ajax({
                type: 'GET',
                url: url,
                contentType: false,
                processData: false,
                success: function (res) {
                    $('#form-modal-hijo-1 .modal-body').html(res.html);
                    $('#form-modal-hijo-1 .modal-title').html(title);
                    $('#form-modal-hijo-1').modal('show');
                    console.log(res);
                },
                error: function (err) {
                    console.log(err)
                }
            })
            //to prevent default form submit event
            return false;
        } catch (ex) {
            console.log(ex)
        }
    }

    jQueryModalPost = form => {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    if (res.isValid) {

                        if (res.solocerrar ?? false) {
                            $('#form-modal').modal('hide');
                            return;
                        }
                           
                        var opcion = res.opcion??0;
                        switch (opcion) {
                            case 1:
                                $(res.page).html(res.html);
                                break;
                            case 2:
                                $(res.page).html(res.html);
                                break;
                            case 99:
                                $(res.page).html(res.html);
                                break;
                            case 100:
                                $(res.page).html(res.html);
                                break;
                            case 101:
                                $(res.page).html(res.html);
                                break;
                            default:
                                $('#viewAll').html(res.html);
                                break;
                        }

                       
                        try {
                            if (opcion === 0) {
                                $('#viewAllD').html(res.html);
                            }
                        } catch (ex) { console.log(ex) }

                        var hijo = res.hijo ?? 0;
                        switch (hijo) {
                            case 1:
                                $('#form-modal-hijo').modal('hide');
                                break;
                            case 2:
                                $('#form-modal-hijo-1').modal('hide');
                                break;
                            default:
                                $('#form-modal').modal('hide');
                                break;
                        }
                        //if (hijo === 0) {
                        //    $('#form-modal').modal('hide');
                        //} else {
                        //    $('#form-modal-hijo').modal('hide');
                        //}
                    }
                },
                error: function (err) {
                    console.log(err)
                }
            })
            return false;
        } catch (ex) {
            console.log(ex)
        }
    }
    jQueryModalDelete = form => {
        if (confirm('¿Estás segura de eliminar este registro?')) {
            try {
                $.ajax({
                    type: 'POST',
                    url: form.action,
                    data: new FormData(form),
                    contentType: false,
                    processData: false,
                    success: function (res) {
                        if (res.isValid) {

                            var opcion = res.opcion ?? 0;
                            switch (opcion) {
                                case 1:
                                    $(res.page).html(res.html);
                                    break;
                                case 2:
                                    $(res.page).html(res.html);
                                    break;
                                case 99:
                                    $(res.page).html(res.html);
                                    break;
                                case 100:
                                    $(res.page).html(res.html);
                                    break;
                                case 101:
                                    $(res.page).html(res.html);
                                    break;
                                default:
                                    $('#viewAll').html(res.html);
                                    break;
                            }


                            try {
                                if (opcion === 0) {
                                    $('#viewAllD').html(res.html);
                                }
                            } catch (ex) { console.log(ex) }

                            //try {
                            //    $('#viewAllD').html(res.html);
                            //} catch (ex) { console.log(ex) }
                            //try {
                            //    $('#viewAllNacional').html(res.html);
                            //} catch (ex) { console.log(ex) }

                            //$('#viewAll').html(res.html)
                        }
                    },
                    error: function (err) {
                        console.log(err)
                    }
                })
            } catch (ex) {
                console.log(ex)
            }
        }

        //prevent default form submit event
        return false;
    }
});

//function nextTab(elem) {
//    $data = $(elem).next().find('a[data-toggle="tab"]').click();
//}
//function prevTab(elem) {
//    $(elem).prev().find('a[data-toggle="tab"]').click();
//}

    // Vigila la actividad del sistema.
    // --------------------------------
function VigilaActividad() {

    // Contador de tiempo en el que el usuario está inactivo.
    // ------------------------------------------------------
    var segundosDesdeUltimaActividad = 0;

    // Recuperamos del Controlador el valor timeOut definido en sessionState del Web.config
    // -----------------------------------------------------------------------------------
    var timeOut = 1;//'@Convert.ToInt32(((System.Web.Configuration.SessionStateSection)System.Configuration.ConfigurationManager.GetSection("system.web/sessionState")).Timeout.TotalMinutes)';

    var maximaInactividad = timeOut * 60;

    // A intervalos de 1 segundo (1000) revisa el estado del contador.
    // ---------------------------------------------------------------
    setInterval(function () {
        segundoDesdeUltimaActividad++;

        if (segundosDesdeUltimaActividad > maximaInactividad) {
            alert("aaa");
        location.href = '../Account/login';
        }
    }, 1000);

    // Esta funcion inicializa el contador de inactividad, sucede cuando se detecta que el usuario está trabajando...
    // -------------------------------------------------------------------------------------------------------------
    function reseteaActividad() {
        segundosDesdeUltimaActividad = 0;
    }

    // Vector con los eventos que vigila.
    // ----------------------------------
    var EventosActividad = [
        'keydown', 'keypress', 'scroll', 'mousedown', 'mousemove', 'touchstart', 'resize'
    ];

    // Creamos "Escuchadores" de eventos al documento...
    // -------------------------------------------------
    EventosActividad.forEach(function (eventName) {
        document.addEventListener(eventName, reseteaActividad, true);
    });
}