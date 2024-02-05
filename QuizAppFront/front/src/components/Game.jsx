import { MdAccessibility } from "react-icons/md";
import '../components/Game.css'

function Game() {
  return (
    <div className="app_container">
        <div className="game-header">
            <h3><span className="icon"><MdAccessibility /></span>Accessibilty</h3>
            <p className="time">5:00</p>
        </div>
      

        <div className="game_container">
            <div className="app_header">
                <p className="quiz_number">Question 6 of 10</p>
               <div className="quiz_section">What is the square root of 144 ? </div>
           </div>
        
            <section className="answers_section">
               
                <div className="">
                    <p className="answer"><span className="icon_2">A</span> 12 <span className="check"> <input type='checkbox'/></span></p>
                    <p className="answer"> <span className="icon_2">B</span> 5 <span className="check"> <input type='checkbox'/></span></p>
                    <p className="answer"> <span className="icon_2">C</span>456 <span className="check"> <input type='checkbox'/></span></p>
                    <p className="answer"> <span className="icon_2">D</span> 25 <span className="check"> <input type='checkbox'/></span></p>
                </div>
               
                    <button className="button_3">Submit answer</button>

            </section>

        </div>
     
    </div>
  );
}

export default Game;
