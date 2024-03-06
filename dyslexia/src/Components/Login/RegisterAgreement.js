import React, {useState} from 'react'
import './RegisterAgreement.css'
import { useNavigate } from 'react-router-dom'

const RegisterAgreement = () => {
    const [agreement, setAgreement] = useState('')
    const navigate = useNavigate();

    const handleSubmit = async (event) => {
        const agreeCheckbox = document.querySelector('input[name="agree"]');
        if (!agreeCheckbox.checked) {
            alert('Please agree to the Privacy and License Agreement.');
            return;
        }
    
        // Kullanıcı checkbox'ı işaretlediyse, local storage'da saklanan kullanıcı bilgilerini al
        const userInfo = JSON.parse(localStorage.getItem('userInfo'));
        
        navigate('/MainPage')
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
                        <form>
                            <label>
                            <input type="checkbox" name="agree"/> I agree to the Privacy and License Agreement
                            </label>
                        </form>
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
