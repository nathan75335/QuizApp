import '../register/Register.css'
import pic from "../../assets/QUIZ.jpg"
import Login from '../login/Login';
import { useState } from 'react';

function Register(){
  const [active , setActive] = useState(true)

  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const [confirmPassWord , setConfirmPassword] = useState('')

  const [token, setToken] = useState('') 

   function handleActiveClick(){
      setActive(true)
  }

  function handleChangeEmail(e){
    setEmail(e.target.value)
  }

  function handleChangeconfirmPassword(e){
    setConfirmPassword(e.target.value)
  }

  function handleChangePassword(e){
    setPassword(e.target.value)
  }

  function handleSubmit(){
    console.log(email, password, confirmPassWord)
  }
  
  return (

            <div className="register-page">
              
                <div className="form">
                {
                 active ?
                          <div className="register-form fade-In-register">
                              <input
                                 value={email}
                                  onChange={(e) => handleChangeEmail(e)}
                                  type="email"
                                  placeholder="email"
                              />

                              <input
                                 value={password}
                                  onChange={(e)=> handleChangePassword(e)}
                                  type="password"
                                  placeholder="Password"
                              />

                              <input
                                value={confirmPassWord}
                                onChange={ (e) => handleChangeconfirmPassword(e)}
                                type="password" placeholder="Confirm Password"
                              />

                              <button onClick={handleSubmit}>Create</button>
                              
                              <p className="message">Already registered? <a href="#"
                               onClick={ ()=> setActive(false)
                              
                              }
                              
                             > Sign In</a></p>
                          </div>

                : 
                   <div className='fade-In-login'>
                     <Login handleActiveClick={handleActiveClick}/>
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
