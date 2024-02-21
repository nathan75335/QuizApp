import './App.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import {Register, Home, Game, QuizzesByCategory} from './components/index'

function App() {
  return (
   <>
      <BrowserRouter>
         <Routes>
          <Route path="/" exact element={<Register/>} />
          <Route path="/Home" exact element={<Home/>} />
          <Route path="/QuizzesByCategory/:id" exact element={<QuizzesByCategory/>} />
          <Route path="/Game/:id" exact element={<Game/>} />
      </Routes>
     </BrowserRouter>
   </>
  );
}

export default App;
