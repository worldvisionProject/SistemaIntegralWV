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
                        $('#viewAll').html(res.html)
                        $('#form-modal').modal('hide');
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
        if (confirm('Are you sure to delete this record ?')) {
            try {
                $.ajax({
                    type: 'POST',
                    url: form.action,
                    data: new FormData(form),
                    contentType: false,
                    processData: false,
                    success: function (res) {
                        if (res.isValid) {
                            $('#viewAll').html(res.html)
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