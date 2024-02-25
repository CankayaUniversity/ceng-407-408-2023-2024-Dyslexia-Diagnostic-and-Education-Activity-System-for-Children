import React from 'react'
import './Main.css'
import { ImStarFull } from "react-icons/im";
import { useNavigate,Link } from 'react-router-dom'
import { Card } from 'react-bootstrap';

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
        <Card title="Diagnosis Tests">
          {/* Diğer içerikler buraya eklenebilir */}
        </Card>
        <Card title="Educational Games">
          {/* Diğer içerikler buraya eklenebilir */}
        </Card>
      </div>
    </div>
  )
}

export default MainPage

