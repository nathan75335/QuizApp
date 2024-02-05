import '../login/Login.css'

function Login({handleActiveClick}){
  return (     
    <>
            
                    <input type="email" placeholder="Email"/>
                    <input type="password" placeholder="Password"/>
                    <button>Login</button>
                    <p class="message">Not registered?
                    
                     <a href="#" 
                        onClick={handleActiveClick}
                    >Create an Account</a></p>
           </>
            
        )
}

export default Login;
