import React, {useState} from 'react'
import './RegisterAgreement.css'
import { useNavigate } from 'react-router-dom'

const RegisterAgreement = () => {
    const [agreement, setAgreement] = useState('');
    const [error, setError] = useState(false);
    const navigate = useNavigate();

    const handleSubmit = async (event) => {
        if (agreement) {
            navigate('/MainPage')
          } else {
            setError(true);
          }
        const userInfo = JSON.parse(localStorage.getItem('userInfo'));
       
    };
    const handleClose = () => {
        localStorage.removeItem('userInfo');
        navigate('/Register');
    };

  return (
    <div className='agreement-container'>
        <div>
            <div className="agreement-modal">
                <div className="agreement-modal-content">
                    <div>
                    <span className="close" onClick={handleClose}>&times;</span>
                    </div>
                    <div>
                        <h2>Sign Up for Free</h2>
                        <div className="reg-agreement-checkbox">
                            <input
                            type="checkbox"
                            id="agree"
                            checked={agreement}
                            onChange={(e) => {
                                setAgreement(e.target.checked);
                                setError(false);
                            }}
                            />
                            <label htmlFor="agreement" className={error ? 'text-error' : ''}>I Agree</label>
                        </div>
                    </div>
                    <div>
                    <button type="submit" className="reg_button" onClick={handleSubmit}>REGISTER</button>
                    </div>
                    
                </div>
            </div>
        </div>
    </div>
  )
}

export default RegisterAgreement
