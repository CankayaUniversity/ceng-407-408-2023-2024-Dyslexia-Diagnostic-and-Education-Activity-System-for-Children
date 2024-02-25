import React, { useState, useEffect } from 'react'
import './EducationalGamesList.css'
import { ImStarFull } from "react-icons/im";
import { useNavigate ,Link} from 'react-router-dom'

const EducationalGamesList = () => {
  return (
    <div>
      <div className='educatioanlGameList-container'>
      <Link to={`/MainPage`}>
        <div className='profile-icon'>
            <ImStarFull className="icon"/>
            <span className="text">PROFILE</span>
        </div>
     </Link>
      <div className="educatioanlGameList-modal">
            <h1>Educational Games</h1>
        </div>
      </div>
    </div>
  )
}

export default EducationalGamesList
