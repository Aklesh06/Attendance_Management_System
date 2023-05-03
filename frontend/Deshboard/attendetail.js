let studentdetails = [];
let attancdanceDetails;
let subid;

$.ajax({
    type: 'get',
    url: 'https://localhost:7184/api/User/api/Student',
    success: function (response) {
        // console.log(response.length);
        studentdetails = response;
    }
});



function createSelect(i) {
    var select = document.createElement("select");
    select.style.width = '200px';
    select.style.backgroundColor = 'rgb(166, 191, 238)';
    select.setAttribute("id", "select" + i);
    var option = document.createElement("option");
    option.value = "true";
    option.text = "Present";
    select.add(option);

    var option2 = document.createElement("option");
    option2.value = "";
    option2.text = "Absent";
    select.add(option2);
    return select;
}

function myFunction() {
    //console.log(studentdetails[0].userName);
    //console.log(select);
    subid = document.getElementById('sub').value;
    var table = document.createElement('table');
    table.style.backgroundColor='rgb(189, 205, 234)';
    table.style.width='400px';
    table.style.borderBlockColor='rgb(166, 191, 238)';
    table.style.fontSize = '23px';
    table.style.top = '20%';
    table.style.left = '34%';
    table.style.position = 'absolute';
    table.setAttribute("id", "table");
    for (var i = 0; i < studentdetails.length; i++) {

        var tr = document.createElement('tr');
        var td1 = document.createElement('td');
        var td2 = document.createElement('td');

        td1.appendChild(document.createTextNode(studentdetails[i].userId));
        td1.setAttribute("id", "t1d" + i);
        td2.appendChild(document.createTextNode(studentdetails[i].userName));

        tr.setAttribute("id", "tr" + i);
        tr.appendChild(td1);
        tr.appendChild(td2);
        tr.appendChild(createSelect(i));
        table.appendChild(tr);
        table.setAttribute("border", "2");
    }
    document.body.appendChild(table);
}
function verifySave() {
    var tbl = document.getElementById("table");
    var Row = document.getElementById("tr0");
    // var Cells = Row.getElementsByTagName("td");
    // var details =Cells[0].innerText;
    var Cells = Row.getElementsByTagName("td")[0].innerText;

    var trdata = document.getElementsByTagName("tr");
    var atdata = document.getElementsByTagName("select");
    let attancdancedata = [];    
    for (var i = 0; i < trdata.length; i++) {
        var userId = document.getElementsByTagName("td")[2 * i].innerText;
        attancdancedata.push(userId);        
    }
    for (var i = 0; i < atdata.length; i++) {
        var atvalue = Boolean(document.getElementById("select"+i).value);
        
        var param = {
            "attendenceId": 0,
            "subjectId": subid,
            "userId": attancdancedata[i],
            "attendenceDate": new Date(),
            "isPresent": atvalue,
            "createdBy": 8,
            "createdDate": "2022-11-25T20:03:16.353Z",
            "updatedDate": "2022-11-25T20:03:16.353Z"
        }
        
    var atparam = JSON.stringify(param);
    $.ajax({
        type: 'POST',
        url: 'https://localhost:7184/api/Attendence',
        data: atparam,
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var res = response;
            varify();
        }
    });
    }
}
function varify()
{
    mess.textContent="Upload Successfully....!";
    mess.style.color="white";
    mess.style.padding='30px';
}


