let div=document.getElementById("savebutton");
let button = document.createElement("button");
div.appendChild(button);
button.style.border = "none";
button.value = "کالای شما";
let count = document.getElementById("count");
if (count >= 1) {
    button.className="btn btn-success"
}
else {
    button.className = "btn btn-danger"
}