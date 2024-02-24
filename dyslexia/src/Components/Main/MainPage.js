import React from 'react'
import './Main.css'
import { ImStarFull } from "react-icons/im";
import { useNavigate } from 'react-router-dom'

const MainPage = () => {
  const navigate = useNavigate();

  const ProfileInfo =()=>{
    navigate('/Profile');
  }
  return (
    <div className='main-container'>
      <div className='profile-icon'>
        <ImStarFull className="icon" onClick={ProfileInfo} />
        <span className="text">PROFILE</span>
      </div>
       <div className="card-container">
        <div className="card">
          Diagnosis Tests
          {/* You can add more content here */}
        </div>
        <div className="card">
          Educational Games
          {/* You can add more content here */}
        </div>
      </div>
    </div>
  )
}

export default MainPage

