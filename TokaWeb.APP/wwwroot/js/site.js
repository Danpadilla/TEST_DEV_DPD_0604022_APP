$(function () {
    pp.AddEventBtnNewPerson();
    $('#FechaNacimiento').datepicker({
        format: 'yyyy-mm-dd'
    });
    pp.AddEventBtnUpdatePerson();
    pp.AddEventBtnOpenModal();
    $('#nuevaPersona').on('hidden.bs.modal', function (e) {
        $('.newPerson')[0].reset();
    })
});
const pp = {
    getPerson: function (e) {
        $('.btn-new-person').hide();
        $('.btn-update-person').show();
        let person = $(e).parent();
        let personId = person.data("person"); 
        $.get('/Personas/Details', { personId: personId }, function (data) {
            if (data.idPersonaFisica) {
                $('#nuevaPersona').modal('show');
                $('#Nombre').val(data.nombre);
                $('#ApellidoPaterno').val(data.apellidoPaterno);
                $('#ApellidoMaterno').val(data.apellidoMaterno);
                const d = new Date(data.fechaNacimiento); 
                $('#FechaNacimiento').val(pp.formatDate(d)); 
                $('.btn-update-person').attr("data-person", data.idPersonaFisica);

                $('#Rfc').val(data.rfc);
                if (data.activo) {
                    $('#CheckActivo').prop('checked', true);
                } else {
                    $('#CheckActivo').prop('checked', false);
                } 
            } else {
                $.notify("Error algo salio mal", "error");
            }
        });
    },
    AddEventBtnNewPerson: function () {
        $('.btn-new-person').click(function () {
            pp.NewPerson(1);
            
        });
    },
    AddEventBtnOpenModal: function () {
        $('.btn-open-modal').click(function () { 
            $('.btn-update-person').hide();
            $('.btn-new-person').show();
            $('#nuevaPersona').modal("show");

        });
    },
    AddEventBtnUpdatePerson: function () {
        $('.btn-update-person').click(function () { 
            pp.NewPerson(2);

        });
    },
    DeletePerson: function (e) {
        let person = $(e).parent();
        let personId = person.data("person");
        console.log('DeletePerson', person);
        $.post('/Personas/Delete', { personId: personId}, function (data) {
            if (data.status) {
                Swal.fire({
                    type: 'success',
                    title: '',
                    text: "Eliminado correctamente",
                    footer: '' 
                }).then((result) => {
                    window.location.href = data.pathredirect;

                })
                 

            } else {
                $.notify("Error algo salio mal", "error");
            }
        });
    },
    NewPerson: function (p) {
        
        var form = $(".newPerson");
        if (!form.valid()) {
            return;
        } else {
            let dataPerson = form.serializeArray();
            let pathRequest = "";
            switch (p) {
                case 1:
                    pathRequest = "/Personas/Create";
                    break;
                case 2: 
                    dataPerson.push({ name: 'IdPersonaFisica', value: $('.btn-update-person').data('person') });
                    pathRequest = "/Personas/Edit";
                    break;
            } 
            if ($('#CheckActivo').val() == "on") {
                dataPerson.push({ name: 'Activo', value: true });
            } else {
                dataPerson.push({ name: 'Activo', value: false });
            }

            $.post(pathRequest, dataPerson, function (data) {
                if (data.status) {
                    Swal.fire({
                        type: 'success',
                        title: '',
                        text: "Guardado correctamente",
                        footer: ''
                    }).then((result) => {
                        window.location.href = data.pathredirect;

                    })

                } else {
                    $.notify("Error algo salio mal", "error");
                }
            });
        }
    },
    formatDate: function (date) {
        var d = new Date(date),
            month = '' + (d.getMonth() + 1),
            day = '' + d.getDate(),
            year = d.getFullYear();

        if (month.length < 2)
            month = '0' + month;
        if (day.length < 2)
            day = '0' + day;

        return [year, month, day].join('-');
    }
}