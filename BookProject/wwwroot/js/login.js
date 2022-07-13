const regis = document.querySelector(".regis");
const login_form = document.querySelector(".login_form");
const regis_form = document.querySelector(".regis_form");
const loginn = document.querySelector(".loginn");
const web_title = document.querySelector(".web_title");

regis.onclick = function () {
    login_form.classList.add("active");
    regis_form.classList.add("active");
    web_title.classList.add("active");
};
loginn.onclick = function () {
    login_form.classList.remove("active");
    regis_form.classList.remove("active");
    web_title.classList.remove("active");
};
