const search = document.querySelector(".search");
const mysearch = document.querySelector(".mysearch");
const list = document.querySelector(".list");
const outlist = document.querySelector(".outlist");
const nav_left = document.querySelector(".nav_left");
const main = document.querySelector(".main");
const nav_head = document.querySelector(".nav_head");
const aboutme = document.querySelector(".aboutme");
const donate = document.querySelector(".donate");
const bookmarks = document.querySelector(".bookmarks");
const bookmarks_nav = document.querySelector(".bookmarks_nav");
const contact = document.querySelector(".contact");
const contact_nav = document.querySelector(".contact_nav");
const folder = document.querySelector(".folder");
const folder_nav = document.querySelector(".folder_nav");
const loged = document.querySelector(".loged");
const loged_nav = document.querySelector(".loged_nav");
const left_control = document.querySelector(".left_control");

left_control.onclick = function () {
  nav_left.classList.toggle("active2");
  nav_head.classList.toggle("active2");
};
nav_left.onclick = function () {
  mysearch.classList.remove("active");
  loged_nav.classList.remove("active");
};
main.onclick = function () {
  mysearch.classList.remove("active");
  loged_nav.classList.remove("active");
};
loged.onclick = function () {
  loged_nav.classList.toggle("active");
  mysearch.classList.remove("active");
};
search.onclick = function () {
  mysearch.classList.toggle("active");
  loged_nav.classList.remove("active");
};
list.onclick = function () {
  nav_left.classList.toggle("active");
  main.classList.toggle("active");
  nav_head.classList.toggle("active");
  mysearch.classList.remove("active");
  loged_nav.classList.remove("active");
  $.ajax({
    url: "/Sen's Page/NavLeft",
    type: "get",
    success: function (data) {
      var link = document.getElementById("link");
      link.innerHTML += data;
    },
    error: function (xhr) {},
  });
};
bookmarks.onclick = function () {
  bookmarks_nav.classList.toggle("active");
  contact_nav.classList.remove("active");
  folder_nav.classList.remove("active");
};
contact.onclick = function () {
  contact_nav.classList.toggle("active");
  bookmarks_nav.classList.remove("active");
  folder_nav.classList.remove("active");
};
folder.onclick = function () {
  folder_nav.classList.toggle("active");
  contact_nav.classList.remove("active");
  bookmarks_nav.classList.remove("active");
};
