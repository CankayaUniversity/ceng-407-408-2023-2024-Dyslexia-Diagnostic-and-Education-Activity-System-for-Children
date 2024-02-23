import React, {useState} from 'react'
import './ForgotPassword.css'
import { useNavigate } from 'react-router-dom'

const ForgotPassword = () => {
  const navigate = useNavigate();
  const [email,setEmail]= useState('');

  const handleSubmit = () => {
    localStorage.removeItem('userInfo');
    navigate('/');
  };
  const handleClose = () => {
    navigate('/');
  };
  return (
    <div className='forgotpassword-container'>
      <div className='forgotpassword-modal'>
        <div className='forgotpassword-modal-content'>
          <span className="close" onClick={handleClose}>&times;</span>
          <h2>Forgot Password</h2>
          <div>
            <input 
              type='text' 
              placeholder='Email'
              value={email}
              onChange={(e)=>setEmail(e.target.value)}/>
          </div>
          <div>
            <button type='submit' onClick={handleSubmit}>Send Mail</button>
          </div> 

        </div>
      </div>
    </div>
  )
}

export default ForgotPassword
