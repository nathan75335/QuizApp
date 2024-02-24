import { useEffect, useState } from 'react';
import '../quizzesByCategory/QuizzesByCategory.css'
import { useParams } from "react-router-dom";

function QuizzesByCategory(){

    const [quizzesByCategory, setQuizzesByCategory] = useState([])
    const { id } = useParams()

  async function getQuizzesByCategory (){

    const  response = await fetch(`http://quizmaster.api/api/categories/${id}`, {
        method: 'GET',
        headers: {
          "Content-Type": "application/json",
          "Authorization": ' Bearer ' +  JSON.parse(localStorage.getItem('token')).token, 
        },
    });
    const quizzesByCategory = await response.json();

    setQuizzesByCategory([...quizzesByCategory])
  } 


  useEffect( () => {
    getQuizzesByCategory()
  },[] )


    return(
    <div className='categoryQuizzes-container'> 
        
        {quizzesByCategory.map( category => (
            <>
                <h2 className='categorie-title'>{category.name}</h2>
              
                <div className='quizz-container'>
                    {category.quizzes.map(quizz => (
                        <a href={`/Game/${quizz.id}`} className='quizz'>
                            <h3>{quizz.title}</h3>
                            <p>
                                Questions : 3/13
                            </p>
                            <p className='time'>
                                Time : 5min
                            </p>
                        </a> 
                    ) )}

                </div>   
              
            </>
        ))}
        
    </div>
    
    )
            
}

export default QuizzesByCategory