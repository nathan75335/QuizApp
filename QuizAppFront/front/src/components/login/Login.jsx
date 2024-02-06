import { useState } from 'react';
import '../login/Login.css'

function Login({handleActiveClick}){

  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')

  function handleChangeEmail(e){
    setEmail(e.target.value)
  }

  function handleChangePassword(e){
    setPassword(e.target.value)
  }

  function handleSubmit(){
    console.log(email, password)
  }
  return (     
    <>
            
      <input
         type="email"
         placeholder="Email"
         value={email}
         onChange={(e) => handleChangeEmail(e)}
       />

      <input
         type="password"
         placeholder="Password"
         value={password}
         onChange={(e) => handleChangePassword(e)}
       />
       <button onClick={handleSubmit}>Login</button>
        <p class="message">Not registered?
                    
        <a href="#" 
          onClick={handleActiveClick}
          >Create an Account</a></p>
     </>
            
  )
}

export default Login;
