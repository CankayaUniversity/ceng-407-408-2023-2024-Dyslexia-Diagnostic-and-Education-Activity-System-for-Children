import React, { useState, useEffect } from 'react'
import './DiagnosticTestAgreement.css'
import { ImStarFull } from "react-icons/im";
import { useNavigate ,Link} from 'react-router-dom'
import { IoIosCloudy } from "react-icons/io";


const DiagnosticTestAgreement = () => {
    const navigate = useNavigate();

    const handleSave = () => {
         navigate('/MainPage');
      };

  return (
    <div className='diagnosisAgreement-container'>
      <Link to={`/MainPage`}>
        <div className='profile-icon'>
            <ImStarFull className="icon"/>
            <span className="text">PROFILE</span>
        </div>
     </Link>
      <div className="diagnosisAgreement-modal">
        <div className="diagnosisAgreement-modal-content">
            <h1>Privacy and Licanse Agreement</h1>
            <div className="save-button" onClick={handleSave}>
                <IoIosCloudy className="icon-save" />
                <span>OK</span>
            </div>
        </div>
      </div>

    </div>
  )
}

export default DiagnosticTestAgreement
