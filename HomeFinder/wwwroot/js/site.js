﻿//Visa inloggningsruta
$(".login-modal").click(function () {
    $('#login-prompt-modal').modal('show');
    return false;
});

//Byt klass på favorit-ikon
$(".fa-star").click(function () {
    let test = document.getElementsByClassName("login-modal");

    if (test.length === 0) {
        if (this.classList.contains("fa-solid")) {
            this.classList.remove("fa-solid");
            this.classList.add("fa-regular");
        }
        else {
            this.classList.remove("fa-regular");
            this.classList.add("fa-solid");
        }
    }
});






