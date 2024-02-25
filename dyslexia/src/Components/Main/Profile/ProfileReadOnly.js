import React, { useState, useEffect } from 'react'
import './Profile.css'
import { ImStarFull } from "react-icons/im";
import { useNavigate ,Link, useLocation} from 'react-router-dom'
import { IoIosCloudy } from "react-icons/io";

const ProfileReadOnly = () => {
    const navigate = useNavigate();
    const location = useLocation();
    const currentYear = new Date().getFullYear();
    const startYear = currentYear - 15;
    const endYear = currentYear - 4;

    const ageOptions = [];
    for (let year = endYear; year >= startYear; year--) {
        ageOptions.push(<option key={year} value={year}>{year}</option>);
    }
    
    const [profile, setProfile] = useState({
        name: '',
        surname: '',
        email: '',
        gender: '',
        age: 0,
      });
    
      useEffect(() => {
        const storedProfile = JSON.parse(localStorage.getItem('userInfo'));
        if (storedProfile) {
          setProfile({
            name: storedProfile.name || '',
            surname: storedProfile.surname || '',
            email: storedProfile.email || '',
            gender: storedProfile.gender || '',
            age: storedProfile.age || '',
            testScore: storedProfile.testScore || 'N/A', 
          });
        }
      }, []);
    
      const OK = () => {
        navigate(-1);
      };
  return (
    <div className='profile-container'>
      <Link to={`/MainPage`}>
        <div className='profile-icon'>
            <ImStarFull className="icon"/>
            <span className="text">PROFILE</span>
        </div>
     </Link>
      <div className="profile-modal">
        <div className="profile-modal-content">
            <h1>MY PROFILE</h1>
          <input 
            type='text' 
            name='name' 
            value={profile.name}
            readOnly
          />
          <input 
            type='text' 
            name='surname' 
            value={profile.surname}
            readOnly
          />
          <input
            type='text'
            name='gender'
            value={profile.gender}
            readOnly
          />
          <input
            type='text'
            name='age'
            value={profile.age}
            readOnly
          />
          <input 
            type='text' 
            placeholder='Email'
            name='email'
            value={profile.email}
            readOnly
          />
          <input 
            type='text' 
            value={`Diagnostic test score: ${profile.testScore}`}
            readOnly
            className='readonly-input'
          />
          <div className="save-button" onClick={OK}>
            <IoIosCloudy className="icon-save" />
            <span>OK</span>
          </div>
        </div>

      </div>

    </div>
  )
}

export default ProfileReadOnly
