$(function () {
    l.AddEventBtnLogin();
});



 //let btnLogin = document.getElementsByName("btn-l");
//btnLogin.addEventListener("click", function () {
//    alert("Hello World!");
//});
const l = {
    AddEventBtnLogin: function () {
        $('#btnlogin').click(function () {
            $('#btnlogin').prop('disabled', true);
            $('#btnlogin').empty();
            $('#btnlogin').html('<i class="fa-solid fa-sync fa-spin"></i>Sign up');
            let formLogin = $('.formlogin');
            if (!formLogin.valid()) {
                return;
            } else {
                let dataPerson = formLogin.serializeArray();

                $.post("/Login/Create", dataPerson, function (data) {
                    if (data.token!="") {
                        Swal.fire({
                            type: 'success',
                            title: '',
                            text: "Login correcto",
                            footer: ''
                        }).then((result) => {
                            window.location.href = "/home/index";

                        })
                    } else {
                        $.notify("Error algo salio mal", "error"); 
                        $('#btnlogin').prop('disabled', false);
                        $('#btnlogin').empty();
                        $('#btnlogin').html('Accesar');
                     }
                });
            }
        }); 
    }
}

 