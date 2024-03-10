import React ,{useState}from 'react'
import './LetterMatchingTest.css'
import { Card , Button } from 'react-bootstrap';
import { useNavigate ,Link} from 'react-router-dom'

const LetterMatchingTest = () => {
  const navigate =useNavigate();
  const [questions, setQuestions] = useState([]);
  const [currentQuestionIndex, setCurrentQuestionIndex] = useState(0);
 // const [selectedCard, setSelectedCard] = useState(null);
  const [clickCount, setClickCount] = useState(0);

  const handleClick = () => {
    if (clickCount < 9) {
      setClickCount(prevCount => prevCount + 1);
    } else {
      console.log("Navigated...");
      navigate('/TestsInformation', { state: { nextTest: 'NavigationSkill' } });
    }
  };
  return (
    <div className='LetterMatching-container'>
        <div className='question_container '> 
          <Card className='card_LetterGame'>
          </Card>
          <Card className='card_LetterGame'> 
          </Card>
          <Card className='card_LetterGame'> 
          </Card>
          <Card className='card_LetterGame'>  
          </Card>
        </div>
        <div>
        <button
          className="continue-button"
          onClick={handleClick}
          disabled={clickCount === 10}
        >
          Continue {clickCount + 1}/10
        </button>
        </div>
    </div>
  )
}

export default LetterMatchingTest
