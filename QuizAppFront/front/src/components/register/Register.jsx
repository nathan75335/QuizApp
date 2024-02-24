import '../register/Register.css'
import pic from "../../assets/QUIZ.jpg"
import Login from '../login/Login';
import { useState } from 'react';

function Register(){
  
  const [active , setActive] = useState(true)

  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const [confirmPassWord , setConfirmPassword] = useState('')
  const [name , setName] = useState('')
  const [isRegistred, setIsregistred ] = useState(false)

   function handleActiveClick(){
      setActive(true)
  }


  async function  registerUser(){
    let  response = await fetch(`http://40.71.42.59:8080/api/auth/registration`, {
      method: 'POST',
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify( {name: name, email: email, password: password, confirmPassWord: confirmPassWord} )
    });

    if(response.status === 200){
      setIsregistred(true)
    }else{
      console.log(response)
    }

     return await response.json();
  }

   

 async function handleSubmit() {
  await registerUser()
 }
  
  return (

            <div className="register-page">
              {isRegistred && <div>user successfully registred</div>}
              
                <div className="form">
                {
                 active ?
                          <div className="register-form fade-In-register">

                              <input
                                 value={name}
                                  onChange={(e) =>  setName(e.target.value)}
                                  type="name"
                                  placeholder="name"
                              />

                              <input
                                 value={email}
                                  onChange={(e) =>  setEmail(e.target.value)}
                                  type="email"
                                  placeholder="email"
                              />

                              <input
                                 value={password}
                                  onChange={(e)=>  setPassword(e.target.value)}
                                  type="password"
                                  placeholder="Password"
                              />

                              <input
                                value={confirmPassWord}
                                onChange={ (e) =>  setConfirmPassword(e.target.value)}
                                type="password" placeholder="Confirm Password"
                              />

                              <button onClick={async() => await handleSubmit()}>Create</button>
                              
                              <p className="message">Already registered? <a href="#"
                               onClick={ ()=> setActive(false)
                              
                              }
                              
                             > Sign In</a></p>
                          </div>

                : 
                   <div className='fade-In-login'>

                     <Login handleActiveClick={handleActiveClick} />

                    </div>
                    
                }
                 </div>

                 <div className="image-container">
                    <img src={pic} />
                 </div>

             </div>
      )
}
export default Register;
