﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const searchWrapper = document.querySelector(".search-input");
const inputBox = searchWrapper.querySelector("input");
const suggBox = searchWrapper.querySelector(".autocom-box");

inputBox.onkeyup = (e) => {
    let userData = e.target.value;
    let emptyArray = [];
    if (userData) {
        $.ajax({
            type: "GET",
            url: 'https://localhost:7164/api/Manga/GetSuggestionList/',
            data: '{title: ' + userData + "}",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response.hasSuccess) {
                    console.log(response.data);
                    emptyArray = response.data.filter((data) => {
                        return data.toLocaleLowerCase().includes(userData.toLocaleLowerCase());
                    });
                    emptyArray = emptyArray.map((data) => {
                        return data = '<li>' + data + '</li>';
                    });
                    console.log(emptyArray);
                    searchWrapper.classList.add("active");
                    showSuggestions(emptyArray);
                }
                },
                error: function () {
                    alert("Erro ao buscar mangas");
                }
            });
    }
    else {
        searchWrapper.classList.remove("active");
    }
}


function showSuggestions(list) {
    let listData;
    if (!list.length) {
        userValue = inputBox.value;
        listData = '<li>' + userValue + '</li>';
    } else if (list.length >= 5) {
        let maxLength = 5;
        let newArray = [];
        for (var i = 0; i < maxLength; i++) {
            newArray.push(list[i]);
        }
        listData = newArray.join('');
    }
    else {
        listData = list.join('');
    }
    suggBox.innerHTML = listData;
}