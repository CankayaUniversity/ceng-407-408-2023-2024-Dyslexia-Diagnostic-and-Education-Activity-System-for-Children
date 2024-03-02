import React, { useState, useEffect } from 'react'
import './EducationalGamesList.css'
import { ImStarFull } from "react-icons/im";
import { useNavigate ,Link} from 'react-router-dom'
import { Card } from 'react-bootstrap';

const EducationalGamesList = () => {
  const navigate = useNavigate();

  const handleClose = () => {
    navigate(`/MainPage`);
};

  return (
    <div>
      <div className='educatioanlGameList-container'>
     
        <Link to={`/ProfileReadOnly`}>
          <div className='profile-icon'>
              <ImStarFull className="icon"/>
              <span className="text">PROFILE</span>
          </div>
        </Link>
        <div className="educatioanlGameList-modal">
        <span className="close" onClick={handleClose}>&times;</span>
          <Link to={`/MainPage`}>
            <Card title="Practice Game"  className='edu_card_Main'>
              {/* Diğer içerikler buraya eklenebilir */}
            </Card>
          </Link>
        </div>
      </div>
    </div>
  )
}

export default EducationalGamesList
