import React from 'react'
import './Main.css'
import { ImStarFull } from "react-icons/im";

const MainPage = () => {
  return (
    <div className='main-container'>
      <div className='profile-icon'>
        <ImStarFull className="icon" />
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

