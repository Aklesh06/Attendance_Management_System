var pass;
var copass;
function checkPass(){

    
pass=document.getElementById("password");
copass=document.getElementById("confim-password");

    var p=(pass.value);
    var c=(copass.value);
    var data =sessionStorage.getItem("Email");
            
    console.log(data);
  
$.ajax({
    type: 'get',
    url: 'https://localhost:7184/api/User/api/Student',
    success: function (response) {
        // console.log(response.length);
        emaildetails = response;
        varifypass();
    }
});
    }

function varifypass()
  {
  
    if(emaildetails)
    for(var i=0;i<emaildetails.length;i++)
    {
        if(emaildetails[i].email ===  data)
        {
            password = emaildetails[i].userPassword ;
        }
    }
   
    if(p != 0)
    {
    if (p === c)
    {
        //need password go to database
        $.ajax({
            type: 'POST',
            url: 'https://localhost:7184/api/User/api/UserId',
            data: JSON.stringify(data1),        
            contentType: "application/json; charset=utf-8",  
            success: function (response) {
                var res = response;
            }
        });
        window.location.replace("http://127.0.0.1:5500/Loginforgot/Goback.html");
    }
    else 
    {
        mess.textContent="Password Not Matched";
        mess.style.color="red";
    }
    }

}

