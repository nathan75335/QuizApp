import './App.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import {Register, Home, Game, QuizzesByCategory} from './components/index'
import PrivateRoutes from "./utils/PrivateRoute"

function App() {
  return (
   <>
      <BrowserRouter>
         <Routes>
          
          <Route element={<PrivateRoutes />}>
            <Route path="/Home" exact element={<Home/>} />
            <Route path="/QuizzesByCategory/:id" exact element={<QuizzesByCategory/>} />
            <Route path="/Game/:id" exact element={<Game/>} />
          </Route>

          <Route path="/" exact element={<Register/>} />
      </Routes>
     </BrowserRouter>
   </>
  );
}

export default App;
