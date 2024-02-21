import '../TimeOut/TimeOut.css'
import { useNavigate } from 'react-router-dom'

function TimeOut({message}){

    const navigate  = useNavigate()


    return(<div className="result-container">

            <p>{message}</p>

            <div className='button-container'>
                <button onClick={() => navigate('/Home')} className='button_3'>Home</button>
            </div>
          
         </div>)
}

export default TimeOut