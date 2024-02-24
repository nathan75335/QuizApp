import { MdSports } from "react-icons/md";
import '../game/Game.css';
import { useParams } from "react-router-dom";
import { useState, useEffect, useCallback } from "react";
import quizQuestions from "./quizQuestions";
import ModelResultScreen from '../modalResultScreen/ModalResultScreen'



function Game() {

    const { id } = useParams()

    let [questions, setQuestions] = useState([{}]);
    let [questionIndex , setQuestionIndex] = useState(0);
    let [isTimeOut, setIsTimeout] = useState(false)
    let [isResult , SetIsresult] = useState(false)
    let [currentlyChecked, setCurrentlyChecked] = useState(0);

    let alphabet=['A', 'B', 'C', 'D'];
   
    const [seconds, setSeconds] = useState(10)
    const [minutes, setMinutes] = useState(2)
    let [score, setScore] = useState(0); 

    let timer

//get score for the selected questions after the time is finished 
 async function  getScore(){

    let  response = await fetch(`https://localhost:7005/api/userquizzes/calculate`, {
        method: 'POST',
        headers: {
          "Content-Type": "application/json",
          "Authorization": ' Bearer ' +  JSON.parse(localStorage.getItem('token')).token, 
        },
        body: JSON.stringify({quizId: id,
          quizQuestions: quizQuestions})
      });

       return await response.json();
    
 }
 
  useEffect( () => { 

    const receiveScore = async () => {
    const result = await  getScore()
    setScore(result)
   }

   if(isTimeOut){
    receiveScore()
  }
   
    },[isTimeOut])

useEffect(()=> {
    timer = setInterval(()=>{

      if(minutes === 0 && seconds === 0 ){
          clearInterval(timer)
          setIsTimeout(true)
          return 
        
    }
      setSeconds(seconds - 1)
      if(seconds === 0){
        setMinutes(minutes - 1)
        setSeconds(59)
      }
    }, 1000)

    return () => clearInterval(timer)
  },[minutes, seconds])

  async function getQuestionsByQuiz (){

    let  response = await fetch(`http://quizmaster.api/api/questions/${id}`, {

       method: 'GET',
        headers: {
          "Content-Type": "application/json",
          "Authorization": ' Bearer ' +  JSON.parse(localStorage.getItem('token')).token, 
        }, 
    });
    let questions = await response.json();

    return questions
  
  } 

   useEffect(() => {
    
    const questionsReceivedFunction  = async() => {
      const response = await getQuestionsByQuiz();
     setQuestions(response);
    }

    questionsReceivedFunction();
       
  }, [questionIndex])

  async function handleNextQuestion(){



      if(questionIndex + 1 < questions.length){

        setQuestionIndex(questionIndex + 1);
        return 
     }

       //send user answers to the backend to calculate score
       let  response = await fetch(`http://quizmaster.api/api/userquizzes/calculate`, {
        method: 'POST',
        headers: {
          "Content-Type": "application/json",
          "Authorization": ' Bearer ' +  JSON.parse(localStorage.getItem('token')).token, 
        },
        body: JSON.stringify({quizId: id,
          quizQuestions: quizQuestions})
      });

      let result = await response.json();
      console.log(result)
      setScore(result)
      SetIsresult(true)
      clearInterval(timer)
  
      
  }
  console.log('ggfgfg')

  const handleActiveOption = (id)=> {
    setCurrentlyChecked(id);
  }

  //select all user answer and corresponding questions from the front 
 function getUserAnswer(questionId, userOptionId){
  quizQuestions.push({
    questionId : questionId,
    answerId : userOptionId});
    
  }
   
  return (
    <div className="app_container">
        {isResult && <ModelResultScreen result={score}/>}
        {isTimeOut && <ModelResultScreen result={score}/>}
      
     
        <div className="game-header">
            <h2><span className="icon-quizz"><MdSports/></span>{questions[questionIndex].quizTitle}</h2>
            {/*<p className="time">{minutes}:{seconds}</p>*/}
        </div>
      

        <div className={isResult || isTimeOut ? "hide_game-container" : "game_container" }>
            <div className="app_header">
                <p className="quiz_number">question {questionIndex + 1} of {questions.length}</p>
               <div className="quiz_section">{questions[questionIndex].questionTitle} ?</div>
           </div>
        
            <section className="answers_section">
               
                <div className="">
                {
                  questions[questionIndex] ?  questions[questionIndex].answerOptions ? questions[questionIndex].answerOptions.map( (answerOption, index) => (
                    <p className="answer" key={answerOption.optionId}>
                      <span className="icon_2">{alphabet[index]}</span> {answerOption.optionText} 
                      <span className="check"> <input checked = {currentlyChecked === answerOption.optionId ? true: false} onClick={() => handleActiveOption(answerOption.optionId)} onChange={()=> getUserAnswer( questions[questionIndex].questionId ,answerOption.optionId)} type='checkbox'/></span></p>
                  ))  :  "Loading..." : "Loading..."
                }
                </div>
               
                    <button onClick={ async () => await handleNextQuestion()} className="button_3">{ questionIndex + 1 === questions.length ? "Submit"  : "Next"}</button>

            </section>

        </div>
     
    </div>
  );
}

export default Game;
