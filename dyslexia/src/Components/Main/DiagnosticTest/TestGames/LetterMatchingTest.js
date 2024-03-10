import React ,{useState}from 'react'
import './LetterMatchingTest.css'
import { Card , Button } from 'react-bootstrap';

const LetterMatchingTest = () => {
  const [selectedCard, setSelectedCard] = useState(null);
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
        <Button 
          variant="primary" 
          className="continue-button"
          onClick={() => console.log('Devam butonuna basıldı!')}
          disabled={selectedCard === null}
        >
          Continue n/10
        </Button>
        </div>
    </div>
  )
}

export default LetterMatchingTest
