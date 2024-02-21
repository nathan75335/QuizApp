import '../home/Home.css'
import { FaHtml5 } from "react-icons/fa6";
import { useEffect, useState } from 'react';


function Home() {

  const [categories, setCategories] = useState([])


  async function getCategories (){

    //console.log(JSON.parse(localStorage.getItem('token')))
    const  response = await fetch('https://localhost:7005/api/categories', {
      
      method: 'GET',
        headers: {
          "Content-Type": "application/json",
          "Authorization": ' Bearer ' +  JSON.parse(localStorage.getItem('token')).token, 
        },
    });

    const categories = await response.json();
    setCategories([...categories])
  } 


  useEffect( () => {
    getCategories()
   //let rep = JSON.parse(localStorage.getItem('token'))

  },[] )


  

  return (
    <section className='container'>

        <div>
            <p className='welcome'>Welcome to the </p>
            <h1 >Frontend Quizz!</h1>
            <p  className='chose_subject'>pick a subject to get started.</p>
        </div>
        <div className="answers_section">

        {categories.map( categorie  => (
                <a  href={`/QuizzesByCategory/${categorie.categoryId}`} className="categorie link" key={categorie.categoriyId} >
                  <span  className='icon '> <FaHtml5 /></span>{categorie.name}</a> 
        ))
      }
       </div>
       
    </section>
  );
}

export default Home;

