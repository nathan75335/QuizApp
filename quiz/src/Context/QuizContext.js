import React, { createContext, useContext, useState } from "react";

const QuizContext = createContext();

function Provider({ children }) {
  const [currentQuestion, setCurrentQuestion] = useState(0);

  const questions = {
    A1: [
      {
        id: 1,
        question: "What does 'happy' mean?",
        answers: [
          { answer: "Sad", trueAnswer: false },
           { answer: "Annoyed", trueAnswer: false },
           { answer: "Happy", trueAnswer: true },
           { answer: "Boring", trueAnswer: false },
        ],
      },
      {
        id: 2,
        question: "What does 'book' mean?",
        answers: [
          { answer: "Telefon", trueAnswer: false },
          { answer: "Anahtar", trueAnswer: false },
          { answer: "Kitap", trueAnswer: true },
          { answer: "Kalem", trueAnswer: false },
        ],
      },
      {
        id: 3,
        question: "What does 'hot' mean?",
        answers: [
            { answer: "Cold", trueAnswer: false },
            { answer: "Hot", trueAnswer: true },
            { answer: "Moist", trueAnswer: false },
            { answer: "Dry", trueAnswer: false },
        ],
      },
      {
        id: 4,
        question: "What does 'red' mean?",
        answers: [
            { answer: "Red", trueAnswer: true },
            { answer: "Green", trueAnswer: false },
            { answer: "Blue", trueAnswer: false },
            { answer: "Yellow", trueAnswer: false },
        ],
      },
      {
        id: 5,
        question: "What does 'cold' mean?",
        answers: [
            { answer: "Hot", trueAnswer: false },
            { answer: "Moist", trueAnswer: false },
            { answer: "Dry", trueAnswer: false },
            { answer: "Cold", trueAnswer: true },
        ],
      },
      {
        id: 6,
        question: "What does 'small' mean?",
        answers: [
            { answer: "Big", trueAnswer: false },
            { answer: "Small", trueAnswer: true },
            { answer: "High", trueAnswer: false },
            { answer: "Heavy", trueAnswer: false },
        ],
      },
      {
        id: 7,
        question: "What does 'fast' mean?",
        answers: [
            { answer: "Slow", trueAnswer: false },
            { answer: "Fast", trueAnswer: true },
            { answer: "Long", trueAnswer: false },
            { answer: "Short", trueAnswer: false },
        ],
      },
      {
        id: 8,
        question: "What does 'big' mean?",
        answers: [
            { answer: "Small", trueAnswer: false },
            { answer: "Low", trueAnswer: false },
            { answer: "Big", trueAnswer: true },
            { answer: "High", trueAnswer: false },
        ],
      },
      {
        id: 9,
        question: "What does 'long' mean?",
        answers: [
            { answer: "Short", trueAnswer: false },
            { answer: "Fast", trueAnswer: false },
            { answer: "Slow", trueAnswer: false },
            { answer: "Long", trueAnswer: true },
        ],
      },
      {
        id: 10,
        question: "What does 'old' mean?",
        answers: [
            { answer: "Young", trueAnswer: false },
            { answer: "Nice", trueAnswer: false },
            { answer: "Old", trueAnswer: true },
            { answer: "Ugly", trueAnswer: false },
        ],
      },
      {
        id: 11,
        question: "What does 'new' mean?",
        answers: [
            { answer: "New", trueAnswer: true },
            { answer: "Old", trueAnswer: false },
            { answer: "Dirty", trueAnswer: false },
            { answer: "Clean", trueAnswer: false },
        ],
      },
      {
        id: 12,
        question: "What does 'fast food' mean?",
        answers: [
            { answer: "Healthy food", trueAnswer: false },
            { answer: "Delicious food", trueAnswer: false },
            { answer: "Expensive food", trueAnswer: false },
            { answer: "Fast food", trueAnswer: true },
        ],
      },
      {
        id: 13,
        question: "What does 'quiet' mean?",
        answers: [
            { answer: "Noisy", trueAnswer: false },
            { answer: "Quiet", trueAnswer: true },
            { answer: "Live", trueAnswer: false },
            { answer: "Calm", trueAnswer: false },
        ],
      },
      {
        id: 14,
        question: "What does 'fat' mean?",
        answers: [
            { answer: "Weak", trueAnswer: false },
            { answer: "Fat", trueAnswer: true },
            { answer: "Long", trueAnswer: false },
            { answer: "Short", trueAnswer: false },
        ],
      },
      {
        id: 15,
        question: "What does 'expensive' mean?",
        answers: [
            { answer: "Cheap", trueAnswer: false },
            { answer: "Nice", trueAnswer: false },
            { answer: "Expensive", trueAnswer: true },
            { answer: "Bad", trueAnswer: false },
        ],
      },
      {
        id: 16,
        question: "What does 'cheap' mean?",
        answers: [
            { answer: "Cheap", trueAnswer: true },
            { answer: "Expensive", trueAnswer: false },
            { answer: "Bad", trueAnswer: false },
            { answer: "Nice", trueAnswer: false },
        ],
      },
      {
        id: 17,
        question: "What does 'worried' mean?",
        answers: [
            { answer: "Sad", trueAnswer: false },
            { answer: "Happy", trueAnswer: false },
            { answer: "Troublesome", trueAnswer: false },
            { answer: "Anxious", trueAnswer: true },
        ],
      },
      {
        id: 18,
        question: "What does 'sad' mean?",
        answers: [
          {answer: "Happy", trueAnswer: false },
          { answer: "Nice", trueAnswer: false },
          { answer: "Bad", trueAnswer: false },
          { answer: "Sad", trueAnswer: true },
        ],
      },
      {
        id: 19,
        question: "What does 'watch' mean?",
        answers: [
            { answer: "Looking", trueAnswer: false },
            { answer: "To be afraid", trueAnswer: false },
            { answer: "Watching", trueAnswer: true },
            { answer: "Sleeping", trueAnswer: false },
        ],
      },
      {
        id: 20,
        question: "What does 'sleep' mean?",
        answers: [
            { answer: "Escape", trueAnswer: false },
            { answer: "Sleeping", trueAnswer: true },
            { answer: "Running", trueAnswer: false },
            { answer: "Sitting", trueAnswer: false },
        ],
      },
    ],
    A2: [
      {
        id: 1,
        question: "What does 'ability' mean?",
        answers: [
            { answer: "Capability", trueAnswer: true },
            { answer: "Short", trueAnswer: false },
            { answer: "Tired", trueAnswer: false },
            { answer: "Smart", trueAnswer: false },
        ],
      },
      {
        id: 2,
        question: "What does 'accept' mean?",
        answers: [
            { answer: "Reject", trueAnswer: false },
            { answer: "Combine", trueAnswer: false },
            { answer: "Accept", trueAnswer: true },
            { answer: "Leaving", trueAnswer: false },
        ],
      },
      {
        id: 3,
        question: "What does 'achieve' mean?",
        answers: [
            { answer: "Lose", trueAnswer: false },
            { answer: "Succeed", trueAnswer: true },
            { answer: "To fight", trueAnswer: false },
            { answer: "Rest", trueAnswer: false },
        ],
      },
      {
        id: 4,
        question: "What does 'add' mean?",
        answers: [
            { answer: "Add", trueAnswer: true },
            { answer: "Remove", trueAnswer: false },
            { answer: "Mix", trueAnswer: false },
            { answer: "Break", trueAnswer: false },
        ],
      },
      {
        id: 5,
        question: "What does 'advantage' mean?",
        answers: [
            { answer: "Disadvantage", trueAnswer: false },
            { answer: "Problem", trueAnswer: false },
            { answer: "Success", trueAnswer: false },
            { answer: "Advantage", trueAnswer: true },
        ],
      },
      {
        id: 6,
        question: "What does 'apologize' mean?",
        answers: [
            { answer: "Praise", trueAnswer: false },
            { answer: "To encourage", trueAnswer: false },
            { answer: "Giving a gift", trueAnswer: false },
            { answer: "Apologizing", trueAnswer: true },
        ],
      },
      {
        id: 7,
        question: "What does 'attract' mean?",
        answers: [
            { answer: "Recover", trueAnswer: false },
            { answer: "Helping", trueAnswer: false },
            { answer: "To pull", trueAnswer: true },
            { answer: "To love", trueAnswer: false },
        ],
      },
      {
        id: 8,
        question: "What does 'begin' mean?",
        answers: [
            { answer: "To finish", trueAnswer: false },
            { answer: "Getting started", trueAnswer: true },
            { answer: "Speaking", trueAnswer: false },
            { answer: "Thinking", trueAnswer: false },
        ],
      },
      {
        id: 9,
        question: "What does 'believe' mean?",
        answers: [
            { answer: "Reject", trueAnswer: false },
            { answer: "Attacking", trueAnswer: false },
            { answer: "Believe", trueAnswer: true },
            { answer: "See", trueAnswer: false },
        ],
      },
      {
        id: 10,
        question: "What does 'build' mean?",
        answers: [
            { answer: "To build", trueAnswer: true },
            { answer: "To destroy", trueAnswer: false },
            { answer: "To fight", trueAnswer: false },
            { answer: "Raise", trueAnswer: false },
        ],
      },
      {
        id: 11,
        question: "What does 'call' mean?",
        answers: [
            { answer: "See", trueAnswer: false },
            { answer: "Available", trueAnswer: false },
            { answer: "To arrest", trueAnswer: false },
            { answer: "Seeking", trueAnswer: true },
        ],
      },
      {
        id: 12,
        question: "What does 'care' mean?",
        answers: [
            { answer: "Giving", trueAnswer: false },
             { answer: "Waiting", trueAnswer: false }, 
             { answer: "Caring", trueAnswer: true }, 
             { answer: "Seeing", trueAnswer: false },
        ],
      },
      {
        id: 13,
        question: "What does 'catch' mean?",
        answers: [
            { answer: "Leaving", trueAnswer: false },
            { answer: "Understanding", trueAnswer: false },
            { answer: "Catching", trueAnswer: true },
            { answer: "To do", trueAnswer: false },
        ],
      },
      {
        id: 14,
        question: "What does 'choose' mean?",
        answers: [
            { answer: "Accept", trueAnswer: false },
            { answer: "To choose", trueAnswer: true },
            { answer: "Responding", trueAnswer: false },
            { answer: "Reject", trueAnswer: false },
        ],
      },
      {
        id: 15,
        question: "What does 'clean' mean?",
        answers: [
            { answer: "To pollute", trueAnswer: false },
            { answer: "Looking", trueAnswer: false },
            { answer: "Break", trueAnswer: false },
            { answer: "Cleaning", trueAnswer: true },
        ],
      },
      {
        id: 16,
        question: "What does 'close' mean?",
        answers: [
            { answer: "Shutdown", trueAnswer: true },
            { answer: "To open", trueAnswer: false },
            { answer: "Monitoring", trueAnswer: false },
            { answer: "Combine", trueAnswer: false },
        ],
      },
      {
        id: 17,
        question: "What does 'cook' mean?",
        answers: [
          { answer: "Boşaltmak", trueAnswer: false },
          { answer: "Pişirmek", trueAnswer: true },
          { answer: "Sıkışmak", trueAnswer: false },
          { answer: "Görmek", trueAnswer: false },
        ],
      },
      {
        id: 18,
        question: "What does 'count' mean?",
        answers: [
          { answer: "Bulmak", trueAnswer: false },
          { answer: "Vurmak", trueAnswer: false },
          { answer: "Yenmek", trueAnswer: false },
          { answer: "Saymak", trueAnswer: true },
        ],
      },
      {
        id: 19,
        question: "What does 'cry' mean?",
        answers: [
          { answer: "Gülümsemek", trueAnswer: false },
          { answer: "Kızgın olmak", trueAnswer: false },
          { answer: "Ağlamak", trueAnswer: true },
          { answer: "Korkmak", trueAnswer: false },
        ],
      },
      {
        id: 20,
        question: "What does 'cut' mean?",
        answers: [
          { answer: "Kesmek", trueAnswer: true },
          { answer: "Yapıştırmak", trueAnswer: false },
          { answer: "Bozmak", trueAnswer: false },
          { answer: "Satmak", trueAnswer: false },
        ],
      },
    ],
    B1: [
      {
        id: 1,
        question: "What does 'accommodation' mean?",
        answers: [
          { answer: "Food", trueAnswer: false },
          { answer: "Clothes", trueAnswer: false },
          { answer: "Accommodation", trueAnswer: true },
          { answer: "Work", trueAnswer: false },
        ],
      },
      {
        id: 2,
        question: "What does 'adventure' mean?",
        answers: [
          { answer: "Friendship", trueAnswer: false },
          { answer: "Adventure", trueAnswer: true },
          { answer: "Love", trueAnswer: false },
          { answer: "Success", trueAnswer: false },
        ],
      },
      {
        id: 3,
        question: "What does 'anxious' mean?",
        answers: [
          { answer: "Anxious", trueAnswer: true },
          { answer: "Happy", trueAnswer: false },
          { answer: "Quiet", trueAnswer: false },
          { answer: "Fearful", trueAnswer: false },
        ],
      },
      {
        id: 4,
        question: "What does 'career' mean?",
        answers: [
          { answer: "Read", trueAnswer: false },
          { answer: "Family", trueAnswer: false },
          { answer: "Health", trueAnswer: false },
          { answer: "Career", trueAnswer: true },
        ],
      },
      {
        id: 5,
        question: "What does 'comfortable' mean?",
        answers: [
          { answer: "Difficult", trueAnswer: false },
          { answer: "Comfortable", trueAnswer: true },
          { answer: "Hot", trueAnswer: false },
          { answer: "Painful", trueAnswer: false },
        ],
      },
      {
        id: 6,
        question: "What does 'culture' mean?",
        answers: [
          { answer: "Sports", trueAnswer: false },
          { answer: "Culture", trueAnswer: true },
          { answer: "Food", trueAnswer: false },
          { answer: "Nature", trueAnswer: false },
        ],
      },
      {
        id: 7,
        question: "What does 'deduction' mean?",
        answers: [
          { answer: "Guess", trueAnswer: false },
          { answer: "Observation", trueAnswer: false },
          { answer: "Exit", trueAnswer: true },
          { answer: "Sorry", trueAnswer: false },
        ],
      },
      {
        id: 8,
        question: "What does 'empathy' mean?",
        answers: [
          { answer: "Empathy", trueAnswer: true },
          { answer: "Tolerance", trueAnswer: false },
          { answer: "Yes", trueAnswer: false },
          { answer: "Question", trueAnswer: false },
        ],
      },
      {
        id: 9,
        question: "What does 'frustration' mean?",
        answers: [
          { answer: "Success", trueAnswer: false },
          { answer: "Excitement", trueAnswer: false },
          { answer: "Disappointment", trueAnswer: true },
          { answer: "Energy", trueAnswer: false },
        ],
      },
      {
        id: 10,
        question: "What does 'globalization' mean?",
        answers: [
          { answer: "Localization", trueAnswer: false },
          { answer: "Nationalization", trueAnswer: false },
          { answer: "Don't go away", trueAnswer: false },
          { answer: "Globalization", trueAnswer: true },
        ],
      },
      {
        id: 11,
         question: "What does 'hypothesis' mean?",
         answers: [
           { answer: "Proof", trueAnswer: false },
           { answer: "Result", trueAnswer: false },
           { answer: "Hypothesis", trueAnswer: true },
           { answer: "Art", trueAnswer: false },
         ],
       },
       {
         id: 12,
         question: "What does 'inevitable' mean?",
         answers: [
           { answer: "Inevitable", trueAnswer: true },
           { answer: "Required", trueAnswer: false },
           { answer: "Normal", trueAnswer: false },
           { answer: "Misleading", trueAnswer: false },
         ],
       },
       {
         id: 13,
         question: "What does 'justify' mean?",
         answers: [
           { answer: "Reject", trueAnswer: false },
           { answer: "Understand", trueAnswer: false },
           { answer: "Change", trueAnswer: false },
           { answer: "Verify", trueAnswer: true },
         ],
       },
       {
         id: 14,
         question: "What does 'knowledge' mean?",
         answers: [
           { answer: "Info", trueAnswer: true },
           { answer: "Faith", trueAnswer: false },
           { answer: "I think", trueAnswer: false },
           { answer: "Experience", trueAnswer: false },
         ],
       },
       {
         id: 15,
         question: "What does 'independent' mean?",
         answers: [
           { answer: "Happy", trueAnswer: false },
           { answer: "Independent", trueAnswer: true },
           { answer: "Weak", trueAnswer: false },
           { answer: "Peaceful", trueAnswer: false },
         ],
       },
       {
         id: 16,
         question: "What does 'opportunity' mean?",
         answers: [
           { answer: "Violence", trueAnswer: false },
           { answer: "Opportunity", trueAnswer: true },
           { answer: "Target", trueAnswer: false },
           { answer: "Good", trueAnswer: false },
         ],
       },
       {
         id: 17,
         question: "What does 'responsible' mean?",
         answers: [
           { answer: "Jealous", trueAnswer: false },
           { answer: "Full of love", trueAnswer: false },
           { answer: "Responsible", trueAnswer: true },
           { answer: "Brave", trueAnswer: false },
         ],
       },
       {
         id: 18,
         question: "What does 'sufficient' mean?",
         answers: [
           { answer: "Difficult", trueAnswer: false },
           { answer: "Bad", trueAnswer: false },
           { answer: "Rich", trueAnswer: false },
           { answer: "Enough", trueAnswer: true },
         ],
       },
       {
         id: 19,
         question: "What does 'tradition' mean?",
         answers: [
           { answer: "Dance", trueAnswer: false },
           { answer: "Tradition", trueAnswer: true },
           { answer: "Good", trueAnswer: false },
           { answer: "Music", trueAnswer: false },
         ],
       },
       {
         id: 20,
         question: "What does 'vocabulary' mean?",
         answers: [
           { answer: "Image", trueAnswer: false },
           { answer: "Vocabulary", trueAnswer: true },
           { answer: "Book", trueAnswer: false },
           { answer: "Recipe", trueAnswer: false },
         ],
       },
     ],
    B2: [
      {
        id: 1,
        question: "What does 'acquaintance' mean?",
        answers: [
          { answer: "Dating", trueAnswer: true },
          { answer: "Company", trueAnswer: false },
          { answer: "Privacy", trueAnswer: false },
          { answer: "Exit", trueAnswer: false },
        ],
      },
      {
        id: 2,
        question: "Which one is the meaning of 'consequence'?",
        answers: [
          { answer: "Logic", trueAnswer: false },
          { answer: "Result", trueAnswer: true },
          { answer: "Survey", trueAnswer: false },
          { answer: "Treatment", trueAnswer: false },
        ],
      },
      {
        id: 3,
        question: "What is the meaning of 'nervous'?",
        answers: [
          { answer: "Lazy", trueAnswer: false },
          { answer: "Ambitious", trueAnswer: false },
          { answer: "Limited", trueAnswer: true },
          { answer: "Working", trueAnswer: false },
        ],
      },
      {
        id: 4,
        question: "Which one is the meaning of 'Complicated'?",
        answers: [
          { answer: "Complex", trueAnswer: true },
          { answer: "Simple", trueAnswer: false },
          { answer: "Detailed", trueAnswer: false },
          { answer: "Fast", trueAnswer: false },
        ],
      },
      {
        id: 5,
        question: "What does 'fluctuate' mean?",
        answers: [
          { answer: "Show variation", trueAnswer: true },
          { answer: "Search", trueAnswer: false },
          { answer: "Claim", trueAnswer: false },
          { answer: "Spend", trueAnswer: false },
        ],
      },
      {
        id: 6,
        question: "Which one is the meaning of 'humble'?",
        answers: [
          { answer: "Humble", trueAnswer: true },
          { answer: "True", trueAnswer: false },
          { answer: "Arrogant", trueAnswer: false },
          { answer: "Smart", trueAnswer: false },
        ],
      },
      {
        id: 7,
        question: "What is the meaning of 'incorporate'?",
        answers: [
          { answer: "Separate", trueAnswer: false },
          { answer: "Shrink", trueAnswer: false },
          { answer: "Drink", trueAnswer: true },
          { answer: "Agreement", trueAnswer: false },
        ],
      },
      {
        id: 8,
        question: "Which one is the meaning of 'justifiable'?",
        answers: [
          { answer: "Questionable", trueAnswer: false },
          { answer: "Acceptable", trueAnswer: true },
          { answer: "Invincible", trueAnswer: false },
          { answer: "OK", trueAnswer: false },
        ],
      },
      {
        id: 9,
        question: "What does 'legacy' mean?",
        answers: [
          { answer: "Inheritance", trueAnswer: false },
          { answer: "Date", trueAnswer: false },
          { answer: "Inheritance", trueAnswer: false },
          { answer: "Key", trueAnswer: true },
        ],
      },
      {
        id: 10,
        question: "Which one is the meaning of 'manifest'?",
        answers: [
          { answer: "Secret", trueAnswer: false },
          { answer: "Open", trueAnswer: true },
          { answer: "Unsolicited", trueAnswer: false },
          { answer: "Apologize", trueAnswer: false },
        ],
      },
      {
        id: 11,
        question: "What is the meaning of 'notorious'?",
        answers: [
          { answer: "Famous", trueAnswer: false },
          { answer: "Mysterious", trueAnswer: false },
          { answer: "Notorious", trueAnswer: true },
          { answer: "Full of love", trueAnswer: false },
        ],
      },
      {
        id: 12,
        question: "Which one is the meaning of 'obstruct'?",
        answers: [
          { answer: "Block", trueAnswer: true },
          { answer: "Confirm", trueAnswer: false },
          { answer: "Increase", trueAnswer: false },
          { answer: "Attack", trueAnswer: false },
        ],
      },
      {
        id: 13,
        question: "What does 'profound' mean?",
        answers: [
          { answer: "Irrational", trueAnswer: false },
          { answer: "Deep", trueAnswer: true },
          { answer: "Galiz", trueAnswer: false },
          { answer: "Kaba", trueAnswer: false },
        ],
      },
      {
        id: 14,
        question: "Which one is the meaning of 'rational'?",
        answers: [
          { answer: "Makes sense", trueAnswer: true },
          { answer: "Persuasive", trueAnswer: false },
          { answer: "Dark", trueAnswer: false },
          { answer: "Reduced", trueAnswer: false },
        ],
      },
      {
        id: 15,
        question: "What is the meaning of 'speculate'?",
        answers: [
          { answer: "Sacrifice", trueAnswer: false },
          { answer: "Display", trueAnswer: false },
          { answer: "Guess", trueAnswer: true },
          { answer: "Promise", trueAnswer: false },
        ],
      },
      {
        id: 16,
        question: "Which one is the meaning of 'trivial'?",
        answers: [
          { answer: "Forced", trueAnswer: false },
          { answer: "Value", trueAnswer: false },
          { answer: "Shy", trueAnswer: false },
          { answer: "Unimportant", trueAnswer: true },
        ],
      },
      {
        id: 17,
        question: "What does 'ultimate' mean?",
        answers: [
          { answer: "Final", trueAnswer: true },
          { answer: "Late", trueAnswer: false },
          { answer: "Amazing", trueAnswer: false },
          { answer: "Don't care", trueAnswer: false },
        ],
      },
      {
        id: 18,
        question: "Which one is the meaning of 'vague'?",
        answers: [
          { answer: "Kaba", trueAnswer: false },
          { answer: "Unclear", trueAnswer: true },
          { answer: "Old", trueAnswer: false },
          { answer: "Fair", trueAnswer: false },
        ],
      },
      {
        id: 19,
        question: "What is the meaning of 'widespread'?",
        answers: [
          { answer: "Limited", trueAnswer: false },
          { answer: "Common", trueAnswer: true },
          { answer: "Different", trueAnswer: false },
          { answer: "Decreased", trueAnswer: false },
        ],
      },
      {
        id: 20,
        question: "Which one is the meaning of 'vivid'?",
        answers: [
          { answer: "Live", trueAnswer: true },
          { answer: "Enchanting", trueAnswer: false },
          { answer: "Mixed", trueAnswer: false },
          { answer: "Negative", trueAnswer: false },
        ],
      },
    ],
    C1: [
      {
        id: 1,
        question: "What is the meaning of the word 'conjecture'?",
        answers: [
          { answer: "true", trueAnswer: false },
          { answer: "guess", trueAnswer: true },
          { answer: "false", trueAnswer: false },
          { answer: "decision", trueAnswer: false },
        ],
      },
      {
        id: 2,
        question: "What does the word 'diligent' mean?",
        answers: [
          { answer: "lazy", trueAnswer: false },
          { answer: "active", trueAnswer: true },
          { answer: "slow", trueAnswer: false },
          { answer: "sorry", trueAnswer: false },
        ],
      },
      {
        id: 3,
        question: "What is the meaning of the word 'elaborate'?",
        answers: [
          { answer: "simple", trueAnswer: false },
          { answer: "complex", trueAnswer: true },
          { answer: "boring", trueAnswer: false },
          { answer: "fit", trueAnswer: false },
        ],
      },
      {
        id: 4,
        question: "What does the word 'feasible' mean?",
        answers: [
          { answer: "logical", trueAnswer: true },
          { answer: "meaningless", trueAnswer: false },
          { answer: "dangerous", trueAnswer: false },
          { answer: "bad", trueAnswer: false },
        ],
      },
      {
        id: 5,
        question: "What is the meaning of the word 'gregarious'?",
        answers: [
          { answer: "traitor", trueAnswer: false },
          { answer: "sincere", trueAnswer: false },
          { answer: "reliable", trueAnswer: false },
          { answer: "social", trueAnswer: true },
        ],
      },
      {
        id: 6,
        question: "What does the word 'hackneyed' mean?",
        answers: [
          { answer: "original", trueAnswer: false },
          { answer: "boring", trueAnswer: true },
          { answer: "strong", trueAnswer: false },
          { answer: "harmless", trueAnswer: false },
        ],
        trueAnswer: "boring"
      },
      {
        id: 7,
         question: "What is the meaning of the word 'imminent'?",
         answers: [
           { answer: "secret", trueAnswer: false },
           { answer: "nearly", trueAnswer: true },
           { answer: "on", trueAnswer: false },
           { answer: "successful", trueAnswer: false },
         ],
       },
       {
         id: 8,
         question: "What does the word 'inquisitive' mean?",
         answers: [
           { answer: "curious", trueAnswer: true },
           { answer: "coward", trueAnswer: false },
           { answer: "extreme", trueAnswer: false },
           { answer: "confident", trueAnswer: false },
         ],
       },
       {
         id: 9,
         question: "What is the meaning of the word 'juxtapose'?",
         answers: [
           { answer: "merge", trueAnswer: false },
           { answer: "separate", trueAnswer: false },
           { answer: "juxtapose", trueAnswer: true },
           { answer: "making enemies", trueAnswer: false },
         ],
       },
       {
         id: 10,
         question: "What does the word 'keen' mean?",
         answers: [
           { answer: "meaningless", trueAnswer: false },
           { answer: "stable", trueAnswer: false },
           { answer: "sharp", trueAnswer: true },
           { answer: "restless", trueAnswer: false },
         ],
       },
       {
         id: 11,
         question: "What is the meaning of the word 'lucid'?",
         answers: [
           { answer: "unknown", trueAnswer: false },
           { answer: "dark", trueAnswer: false },
           { answer: "understood", trueAnswer: true },
           { answer: "many", trueAnswer: false },
         ],
       },
       {
         id: 12,
         question: "What does the word 'malleable' mean?",
         answers: [
           { answer: "incompatible", trueAnswer: false },
           { answer: "flexible", trueAnswer: true },
           { answer: "irregular", trueAnswer: false },
           { answer: "friendly", trueAnswer: false },
         ],
       },
       {
         id: 13,
         question: "What is the meaning of the word 'nostalgia'?",
         answers: [
           { answer: "myself", trueAnswer: true },
           { answer: "kin", trueAnswer: false },
           { answer: "excitement", trueAnswer: false },
           { answer: "minimum", trueAnswer: false },
         ],
       },
       {
         id: 14,
         question: "What does the word 'obscure' mean?",
         answers: [
           { answer: "on", trueAnswer: false },
           { answer: "unknown", trueAnswer: true },
           { answer: "understood", trueAnswer: false },
           { answer: "honed", trueAnswer: false },
         ],
       },
       {
        id: 15,
        question: "What is the meaning of the word 'pensive'?",
        answers: [
          { answer: "understandable", trueAnswer: true },
          { answer: "coward", trueAnswer: false },
          { answer: "happy", trueAnswer: false },
          { answer: "doubtful", trueAnswer: false },
        ],
      },
      {
        id: 16,
        question: "What does the word 'quaint' mean?",
        answers: [
          { answer: "shown", trueAnswer: false },
          { answer: "foreign", trueAnswer: false },
          { answer: "strange", trueAnswer: true },
          { answer: "high", trueAnswer: false },
        ],
      },
      {
        id: 17,
        question: "What is the meaning of the word 'applaud'?",
        answers: [
          { answer: "optimist", trueAnswer: false },
          { answer: "durable", trueAnswer: false },
          { answer: "Applause", trueAnswer: true },
          { answer: "stupid", trueAnswer: false },
        ],
      },
      {
        id: 18,
        question: "What does the word 'superfluous' mean?",
        answers: [
          { answer: "required", trueAnswer: false },
          { answer: "unnecessary", trueAnswer: true },
          { answer: "successful", trueAnswer: false },
          { answer: "unfortunate", trueAnswer: false },
        ],
      },
      {
        id: 19,
        question: "What is the meaning of the word 'tedious'?",
        answers: [
          { answer: "excited", trueAnswer: false },
          { answer: "boring", trueAnswer: true },
          { answer: "meaningless", trueAnswer: false },
          { answer: "problem", trueAnswer: false },
        ],
      },
      {
        id: 20,
        question: "What does the word 'diminish' mean?",
        answers: [
          { answer: "rare", trueAnswer: false },
          { answer: "Reduce", trueAnswer: true },
          { answer: "malicious", trueAnswer: false },
          { answer: "famous", trueAnswer: false },
        ],
      },
    ],
    C2: [
        {
          id: 1,
          question: "What is the meaning of the word 'abundant'?",
          answers: [
            { answer: "not enough", trueAnswerr: false },
            { answer: "restricted", trueAnswerr: false },
            { answer: "dar", trueAnswerr: false },
            { answer: "be", trueAnswerr: true },
          ],
        },
        {
          id: 2,
          question: "What does the word 'exquisite' mean?",
          answers: [
            { answer: "disgusting", trueAnswerr: false },
            { answer: "soft", trueAnswerr: false },
            { answer: "elegant", trueAnswerr: true },
            { answer: "sharp", trueAnswerr: false },
          ],
        },
        {
          id: 3,
          question: "What is the definition of 'conundrum'?",
          answers: [
            { answer: "puzzle", trueAnswerr: true },
            { answer: "simple problem", trueAnswerr: false },
            { answer: "multiple choice", trueAnswerr: false },
            { answer: "correct answer", trueAnswerr: false },
          ],
        },
        {
          id: 4,
          question: "What is the meaning of the word 'elated'?",
          answers: [
            { answer: "hopeful", trueAnswerr: false },
            { answer: "sorry", trueAnswerr: false },
            { answer: "enthusiastic", trueAnswerr: true },
            { answer: "limited", trueAnswerr: false },
          ],
        },
        {
          id: 5,
          question: "What does the word 'affluent' mean?",
          answers: [
            { answer: "poor", trueAnswerr: false },
            { answer: "rich", trueAnswerr: true },
            { answer: "tired", trueAnswerr: false },
            { answer: "healthy", trueAnswerr: false },
          ],
        },
        {
          id: 6,
          question: "What is the definition of 'exasperate'?",
          answers: [
            { answer: "surprise", trueAnswerr: false },
            { answer: "intimidate", trueAnswerr: false },
            { answer: "get angry", trueAnswerr: true },
            { answer: "relax", trueAnswerr: false },
          ],
        },
        {
          id: 7,
          question: "What is the meaning of the word 'resilient'?",
          answers: [
            { answer: "broken", trueAnswerr: false },
            { answer: "compatible", trueAnswerr: false },
            { answer: "weak", trueAnswerr: false },
            { answer: "durable", trueAnswerr: true },
          ],
        },
        {
          id: 8,
          question: "What does the word 'ominous' mean?",
          answers: [
            { answer: "weird", trueAnswerr: false },
            { answer: "optimist", trueAnswerr: false },
            { answer: "dangerous", trueAnswerr: true },
            { answer: "destructive", trueAnswerr: false },
          ],
        },
        {
            id: 9,
            question: "What is the definition of 'scrutinize'?",
            answers: [
              { answer: "monitor", trueAnswerr: false },
              { answer: "exclude", trueAnswerr: false },
              { answer: "review", trueAnswerr: true },
              { answer: "accelerate", trueAnswerr: false },
            ],
          },
          {
            id: 10,
            question: "What is the meaning of the word 'prolific'?",
            answers: [
              { answer: "productive", trueAnswerr: true },
              { answer: "careless", trueAnswerr: false },
              { answer: "weak", trueAnswerr: false },
              { answer: "unimportant", trueAnswerr: false },
            ],
          },
          {
            id: 11,
            question: "What does the word 'impeccable' mean?",
            answers: [
              { answer: "bad", trueAnswerr: false },
              { answer: "no error", trueAnswerr: true },
              { answer: "concern", trueAnswerr: false },
              { answer: "full of love", trueAnswerr: false },
            ],
          },
          {
            id: 12,
            question: "What is the definition of 'perplexed'?",
            answers: [
              { answer: "confused", trueAnswerr: true },
              { answer: "compressed", trueAnswerr: false },
              { answer: "scared", trueAnswerr: false },
              { answer: "confident", trueAnswerr: false },
            ],
          },
          {
            id: 13,
            question: "What is the meaning of the word 'mundane'?",
            answers: [
              { answer: "meaningless", trueAnswerr: false },
              { answer: "fun", trueAnswerr: false },
              { answer: "original", trueAnswerr: false },
              { answer: "regular", trueAnswerr: true },
            ],
          },
          {
            id: 14,
            question: "What does the word 'quintessential' mean?",
            answers: [
              { answer: "basic", trueAnswerr: true },
              { answer: "complex", trueAnswerr: false },
              { answer: "kaba", trueAnswerr: false },
              { answer: "air", trueAnswerr: false },
            ],
          },
          {
            id: 15,
            question: "What is the definition of the word 'ephemeral'?",
            answers: [
              { answer: "temporary", trueAnswerr: true },
              { answer: "permanent", trueAnswerr: false },
              { answer: "bad", trueAnswerr: false },
              { answer: "fit", trueAnswerr: false },
            ],
          },
          {
            id: 16,
            question: "What is the meaning of the word 'verbose'?",
            answers: [
              { answer: "understood", trueAnswerr: false },
              { answer: "cut", trueAnswerr: false },
              { answer: "on", trueAnswerr: false },
              { answer: "exaggerated", trueAnswerr: true },
            ],
          },
          {
            id: 17,
            question: "What does the word 'quell' mean?",
            answers: [
              { answer: "injury", trueAnswerr: false },
              { answer: "paste", trueAnswerr: false },
              { answer: "appease", trueAnswerr: true },
              { answer: "upgrade", trueAnswerr: false },
            ],
          },
          {
            id: 18,
            question: "What is the meaning of the word 'ennui'?",
            answers: [
              { answer: "excitement", trueAnswerr: false },
              { answer: "boredom", trueAnswerr: true },
              { answer: "happiness", trueAnswerr: false },
              { answer: "concern", trueAnswerr: false },
            ],
          },
          {
            id: 19,
            question: "What does the word 'idiosyncrasy' mean?",
            answers: [
              { answer: "experience", trueAnswerr: false },
              { answer: "habit", trueAnswerr: false },
              { answer: "weird", trueAnswerr: true },
              { answer: "intelligence", trueAnswerr: false },
            ],
          },
          {
            id: 20,
            question: "What is the meaning of the word 'ubiquitous'?",
            answers: [
              { answer: "moment", trueAnswerr: false },
              { answer: "universal", trueAnswerr: true },
              { answer: "limited", trueAnswerr: false },
              { answer: "clear", trueAnswerr: false },
            ],
          },
        ],
      };

  const sharedValuesAndMethods = {
    questions,
    currentQuestion,
    setCurrentQuestion,
  };

  return (
    <QuizContext.Provider value={sharedValuesAndMethods}>
      {children}
    </QuizContext.Provider>
  );
}

const useQuizContext = () => useContext(QuizContext);
export { Provider, useQuizContext };

export default QuizContext