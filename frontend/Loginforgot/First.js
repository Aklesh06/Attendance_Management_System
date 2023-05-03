let emailaddress;
let getemail;
function checkEmail()
{
    emailaddress = document.getElementById("em").value;
    $.ajax({
        type: 'get',
        url: 'https://localhost:7184/api/User/api/Student',
        success: function (response) {
            UserDetails = response;
            
            varifyemail();

            }
        });
    
    }

    function varifyemail()
    {
        if(UserDetails)
        for(var i=0;i<UserDetails.length;i++)
        {
            if(UserDetails[i].email ===  emailaddress)
            {
                getemail = UserDetails[i].email ;
            }
        }
            if(getemail ===  emailaddress)
            {
                sessionStorage.setItem("Email",getemail);
                window.location.replace("http://127.0.0.1:5500/Loginforgot/Step2.html");
            }
            else{
            mess.textContent="Email not exist";
            mess.style.color="red";
            }

    }