import { useState } from 'react';
import '../login/Login.css'
import { useNavigate } from 'react-router-dom';

function Login({handleActiveClick}){

  const navigate = useNavigate()

const [email, setEmail] = useState('')
const [password, setPassword] = useState('')


  async function  login(){

    const response = await fetch(`http://40.71.42.59:8080/api/auth/login`, {
        method: 'POST',
        headers: {
          "Content-Type": "application/json"
        },
        body: JSON.stringify({ email: email, password: password})
      });
      
     // setToken(await response.json())
      let rep =  await response.json()
      localStorage.setItem('token', JSON.stringify(rep))

      setEmail('')
      setPassword('')
      navigate('/Home')
      
 }

 async function handleUserLogin() {
  await login()
 }

 
  return (     
    <>
            
      <input
         type="email"
         placeholder="Email"
         value={email}
         onChange={(e) => setEmail(e.target.value)}
       />

      <input
         type="password"
         placeholder="Password"
         value={password}
         onChange={(e) =>  setPassword(e.target.value)}
       />
       <button onClick={async() => await handleUserLogin()}>Login</button>
        <p class="message">Not registered?
                    
        <a href="#" onClick={handleActiveClick}
          >Create an Account</a></p>
     </>
            
  )
  }

export default Login;
