import React, { useState, useEffect } from 'react'
import './DiagnosticTestAgreement.css'
import { ImStarFull } from "react-icons/im";
import { useNavigate ,Link} from 'react-router-dom'
import { IoIosCloudy } from "react-icons/io";


const DiagnosticTestAgreement = () => {
    const navigate = useNavigate();
    const [agree, setAgree] = useState(false);
    const [error, setError] = useState(false);

    const handleSave = () => {
        if (agree) {
            navigate('/TestsInformation');
          } else {
            setError(true);
          }
    };
    const handleClose = () => {
        navigate('/MainPage');
    };

  return (
    <div className='diagnosisAgreement-container'>
      <Link to={`/ProfileReadOnly`}>
        <div className='profile-icon'>
            <ImStarFull className="icon"/>
            <span className="text">PROFILE</span>
        </div>
     </Link>
      <div className="diagnosisAgreement-modal">
        <div className="diagnosisAgreement-modal-content">
            <span className="close" onClick={handleClose}>&times;</span>
            <h1>Privacy and Licanse Agreement</h1>
            <div className="agreement-checkbox">
                <input
                type="checkbox"
                id="agree"
                checked={agree}
                onChange={(e) => {
                    setAgree(e.target.checked);
                    setError(false); // Reset error state when checkbox changes
                }}
                />
                <label htmlFor="agree" className={error ? 'text-error' : ''}>I Agree</label>
            </div>
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
