import '../modalResultScreen/ModalResultScreen.css'
import { useNavigate } from 'react-router-dom'

function ModalResultScreen({result}){

    const navigate  = useNavigate()

    return(<div className="result-container">
            <p>Scrore : {result} </p>

            <div className='button-container'>
                <button onClick={() => navigate('/Home')} className='button_3'>Home</button>
            </div>
          
         </div>)
}

export default ModalResultScreen