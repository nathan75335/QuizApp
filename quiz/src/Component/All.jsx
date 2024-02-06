import React from 'react';
import Home from './Home';
import Quiz from './Quiz';
import Result from './Result';
import Error from './Error';
import '../assets/CSS/style.css';

import { Routes, Route } from "react-router-dom";

function All() {
  return (
    <div className="app-container">
      <div className="quiz-box">
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/quiz/:level" element={<Quiz />} />
          <Route path="/result" element={<Result />} />
          <Route path="*" element={<Error />} />
        </Routes>
      </div>
    </div>
  )
}

export default All