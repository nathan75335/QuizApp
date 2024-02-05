import '../register/Register.css'
import pic from "../../assets/QUIZ.jpg"
import Login from '../login/Login';
import { useState } from 'react';

function Register(){
  const [active , setActive] = useState(true)

   function handleActiveClick(){
      setActive(true)
  }

  return (

            <div className="register-page">
              
                <div className="form">
                {
                 active ?
                          <div className="register-form fade-In-register">
                              <input type="text" placeholder="Name"/>
                              <input type="password" placeholder="Password"/>
                              <input type="password" placeholder="Confirm Password"/>
                              <button>Create</button>
                              <p className="message">Already registered? <a href="#"
                               onClick={ ()=> setActive(false) }
                              
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
