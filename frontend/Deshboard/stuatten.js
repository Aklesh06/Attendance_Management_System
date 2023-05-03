let day;
let attendetail;
let userid=0 ;
function viewAttendence() {
    day = document.getElementById("day").value;
    userid = sessionStorage.getItem("Userid");
    var data ={
        "userID":parseInt(userid) ,
        "attandanceDate": day
      }
      console.log(data);

    $.ajax({
        type: 'POST',
        url: 'https://localhost:7184/api/Attendence/AttandanceDetails',
        data: JSON.stringify(data),        
        contentType: "application/json; charset=utf-8",
        success: function (response) {
        attendetail = response;
        myFunction();
        }
    });


}

function myFunction() {
    //console.log(studentdetails[0].userName);
    //console.log(select);
    var table = document.createElement('table');
    table.style.backgroundColor='rgb(189, 205, 234)';
    table.style.width='550px';
    table.style.borderBlockColor='rgb(166, 191, 238)';
    table.style.fontSize = '23px';
    table.style.height='220px';
    table.style.top = '30%';
    table.style.left = '30%';
    table.style.position = 'absolute';
    table.setAttribute("id", "table");
    for (var i = 0; i < attendetail.length; i++) {

        var tr = document.createElement('tr');
        var td1 = document.createElement('td');
        var td2 = document.createElement('td');

        td1.appendChild(document.createTextNode(attendetail[i].subject));
        td1.setAttribute("id", "t1d" + i);
        td2.appendChild(document.createTextNode(attendetail[i].attandance));

        tr.setAttribute("id", "tr" + i);
        tr.appendChild(td1);
        tr.appendChild(td2);
        //tr.appendChild(createSelect(i));
        table.appendChild(tr);
        table.setAttribute("border", "2");
    }
    document.body.appendChild(table);
}
