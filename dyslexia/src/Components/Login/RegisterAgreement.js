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
            <div className="modal">
                <div className="modal-content">
                    <span className="close" onClick={handleClose}>&times;</span>
                    <h2>Sign Up for Free</h2>
                    <form>
                    <label>
                     <input type="checkbox" name="agree"/> I agree to the Privacy and License Agreement
                    </label>
                    <button type="submit" onClick={handleSubmit}>REGISTER</button>
                    </form>
                </div>
            </div>
        </div>
    </div>
  )
}

export default RegisterAgreement
