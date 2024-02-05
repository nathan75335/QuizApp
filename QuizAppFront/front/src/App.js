import './App.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import {Register, Home, Game} from './components/index'

function App() {
  return (
   <>
      <BrowserRouter>
         <Routes>
          <Route path="/" exact element={<Register/>} />
          <Route path="/Home" exact element={<Home/>} />
          <Route path="/Game" exact element={<Game/>} />
      </Routes>
     </BrowserRouter>
   </>
  );
}

export default App;
