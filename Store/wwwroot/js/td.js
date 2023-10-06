document.getElementById('MyButton').addEventListener('click', function AppendItem() {
    console.log("add item func");
    let table = document.getElementById("myTable");
    let body = table.getElementsByTagName("tbody")[0];
    let tr = document.createElement("tr");
    let td1 = document.createElement("td");
    let td2 = document.createElement("td");
    let td3 = document.createElement("td");
    let td4 = document.createElement("td");
    let myInput1 = document.createElement("input");
    let myInput2 = document.createElement("input");
    let myInput3 = document.createElement("input");
    let myInput4 = document.createElement("input");
    myInput1.setAttribute("type", "text");
    myInput2.setAttribute("type", "text");
    myInput3.setAttribute("type", "text");
    myInput4.setAttribute("type", "text");
    td1.appendChild(myInput1);
    td2.appendChild(myInput2);
    td3.appendChild(myInput3);
    td4.appendChild(myInput4);
    tr.appendChild(td1);
    tr.appendChild(td2);
    tr.appendChild(td3);
    tr.appendChild(td4);
    body.appendChild(tr);
});

