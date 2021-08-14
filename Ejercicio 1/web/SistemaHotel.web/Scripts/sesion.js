$(document).ready(function () {
    $("#login").on("click", "#btnlogin", function () {
        let usuario = $("#usuario").val();
        let password = $("#password").val();
        let correcto = false;
        if (usuario.replace(" ", "").length === 0) {
            $("label[data-error='usuario']").text("El usuario es requerido");
        } else {
            $("label[data-error='usuario']").text("");
            correcto = true;
        }
        if (password.replace(" ", "").length === 0) {
            $("label[data-error='password']").text("El password es requerido");
        } else {
            $("label[data-error='password']").text("");
            correcto = true;
        }
        if (correcto) {
            login(usuario, password);
        }
    });
});

function login(usuario, password) {
    $.get(UrlLogin, { Usuario: usuario, Password: password }, function (data) {
        if (data.Id === 0) {
            alert("El usuario y/o contraseña son incorrectos");
        } else {
            location.href = Home;
        }
    });
};