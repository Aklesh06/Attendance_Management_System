// JavaScript source code
    //$.ajax({
    //    headers: {
    //        "Accept": "application/json",//depends on your api
    //        "Content-type": "application/json"//depends on your api
    //    }, url: "https://localhost:7184/api/User",
    //    success: function (response) {
    //        var r = JSON.parse(response);
    //        $("#main").html(r.base);
    //    }
    //});
function saveFormDetails() {

    var name = document.getElementById('name').value;
    var password = document.getElementById('password').value;
    var profession = document.getElementById('role').value;
    var date = document.getElementById('date').value;
    var email = document.getElementById('Email').value;
    var phone = document.getElementById('phone').value;
    var gender = document.getElementById('gen').value;
    var currentAddress = document.getElementById('currentAddress').value;
    var parmanentAddress = document.getElementById('parmanentAddress').value;
    var pin = document.getElementById('pin').value;
    var city = document.getElementById('city').value;
    var nationality = document.getElementById('nationality').value;
    //this.userDetails =new {
    //    userId: 0,
    //    rolesId: 1,
    //    userName: "Test1",
    //    userPassword: "Test1",
    //    dateOfBirth: date,
    //    gender: "Male",
    //    currentAddress: "garposh",
    //    permanentAddress: "garposh",
    //    city: "garposh",
    //    nationality: "Indian",
    //    pinCode: 500084,
    //    email: "Test2@gmail.com",
    //    createDate: new date(),
    //    updatedDate: new date()
    //}
    var data2 = {
        "userId": 0,
        "rolesId": profession,
        "userName": name,
        "userPassword": password,
        "dateOfBirth": date,
        "phoneno" : phone,
        "gender": gender,
        "currentAddress": currentAddress,
        "permanentAddress": parmanentAddress,
        "city": city,
        "nationality": nationality,
        "pinCode": pin,
        "email": email,
        "createDate":  "2022-11-14T20:10:25.332Z",
        "updatedDate": "2022-11-14T20:10:25.332Z"
    }
    var data1 = JSON.stringify(data2);
    $.ajax({
        type: 'POST',
        url: 'https://localhost:7184/api/User',
        data: data1,
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var res = response;
            takeBack();
        }
    });
    //  $.ajax({
    //      type: 'get',
    //      url: 'https://localhost:7184/api/User',
    //      xhrFields: {
    //          withCredentials: true
    //      },
    //      success: function (response) {
    //          var res = response;
    //      }
    //  });    
    
}
function takeBack()
{
    window.location.replace("http://127.0.0.1:5500/Deshboard/teacher_dashboard.html");
}