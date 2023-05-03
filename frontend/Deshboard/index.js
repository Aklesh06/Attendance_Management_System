let UserDetails;
let useridele;
let passwordele;

function varify(){
    useridele=document.getElementById("uname").value;
    passwordele=document.getElementById("password").value;
    $.ajax({
        type: 'get',
        url: 'https://localhost:7184/api/User/api/'+useridele,
        success: function (response) {
            UserDetails = response;            
           varifyUserDetails();
            }
        });  
    
    }


function varifyUserDetails()
{
    //console.log(UserDetails);
   if(UserDetails)
    {
       if(UserDetails[0].userPassword ===  passwordele)
        {
           if(UserDetails[0].rolesId==1)
            {              
               sessionStorage.setItem("Userid",UserDetails[0].userId );
               window.location.replace("http://127.0.0.1:5500/Deshboard/student_dashboard.html");
            }
            else
            {
               window.location.replace("http://127.0.0.1:5500/Deshboard/teacher_dashboard.html");
            }
    }
    else{
       mess.textContent="User/Password not exist";
        mess.style.color="red";
        mess.style.padding='30px';
    }

    }
}
    

