const regis = document.querySelector(".regis");
const login_form = document.querySelector(".login_form");
const forget_form = document.querySelector(".forget_form");
const regis_form = document.querySelector(".regis_form");
const loginn = document.querySelector(".loginn");
const web_title = document.querySelector(".web_title");
const forget = document.querySelector(".forget");

regis.onclick = function () {
    login_form.classList.add("active");
    forget_form.classList.remove("active");
    regis_form.classList.add("active");
    web_title.classList.add("active");
};
forget.onclick = function () {
    login_form.classList.add("active");
    regis_form.classList.remove("active");
    forget_form.classList.add("active");
    web_title.classList.add("active");
};
loginn.onclick = function () {
    login_form.classList.remove("active");
    forget_form.classList.remove("active");
    regis_form.classList.remove("active");
    web_title.classList.remove("active");
};
