import '../home/Home.css'
import { IconName } from "react-icons/fa";
import { FaHtml5 , FaCss3Alt } from "react-icons/fa6";
import { MdAccessibility } from "react-icons/md";
import { IoLogoJavascript } from "react-icons/io5";



function Home() {
  return (
    <section className='container'>

        <div>
            <p className='welcome'>Welcome to the </p>
            <h1 >Frontend Quizz!</h1>
            <p  className='chose_subject'>pick a subject to get started.</p>
        </div>

        <div className="answers_section">
            <a href="#" className="categorie link"><span  className='icon '> <FaHtml5 /></span> HTML</a>
            <a  href="#"className="categorie link"> <span  className='icon '><FaCss3Alt /></span> CSS </a>
            <a  href="#"className="categorie link"><span  className='icon '> <IoLogoJavascript /></span>  Javascript </a>
            <a href="#" className="categorie link"><span  className='icon '> <MdAccessibility /></span>  Accessibility</a>     
        </div>
    </section>
  );
}

export default Home;
