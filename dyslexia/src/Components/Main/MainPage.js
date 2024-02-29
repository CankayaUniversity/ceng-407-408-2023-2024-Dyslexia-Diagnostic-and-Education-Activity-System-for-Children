import React from 'react'
import './Main.css'
import { ImStarFull } from "react-icons/im";
import { useNavigate,Link } from 'react-router-dom'
import { Card } from 'react-bootstrap';

const MainPage = () => {
  const navigate = useNavigate();
  return (
    <div className='main-container'>
      <Link to={`/Profile`}>
        <div className='profile-icon'>
            <ImStarFull className="icon"/>
            <span className="text">PROFILE</span>
        </div>
     </Link>
      <div className="card-container">
        <Link to={`/DiagnosisAgreement`}>
          <Card title="Diagnosis Tests" className='card'>
            {/* Diğer içerikler buraya eklenebilir */}
          </Card>
        </Link>
        <Link to={`/EducationalGamesList`}>
          <Card title="Educational Games" className='card'>
            {/* Diğer içerikler buraya eklenebilir */}
          </Card>
        </Link>
      </div>
    </div>
  )
}

export default MainPage

