import React, { useState, useEffect } from 'react'
import './TestsInformation.css'
import { ImStarFull } from "react-icons/im";
import { useNavigate ,Link} from 'react-router-dom'
import { IoIosCloudy } from "react-icons/io";

const TestsInformation = () => {
  const navigate = useNavigate();

  const handleStart= () => {
    navigate('/MainPage');
  };

  const handleClose = () => {
    navigate('/MainPage');
  };
  return (
    <div className='testInfo-container'>
      <Link to={`/ProfileReadOnly`}>
        <div className='profile-icon'>
            <ImStarFull className="icon"/>
            <span className="text">PROFILE</span>
        </div>
     </Link>
      <div className="testInfo-modal">
        <div className="testInfo-modal-content">
            <span className="close" onClick={handleClose}>&times;</span>
            <h2>How to play the Test</h2>
            <div className="start-button" onClick={handleStart}>
                <IoIosCloudy className="start-icon-save" />
                <span>Start Test </span>
            </div>
            <h1 className="testInfo-title">Test Name</h1>
        </div>
      </div>

    </div>
  )
}

export default TestsInformation
