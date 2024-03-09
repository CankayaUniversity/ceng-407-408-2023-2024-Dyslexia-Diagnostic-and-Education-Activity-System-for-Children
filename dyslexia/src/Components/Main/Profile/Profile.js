import React, { useState, useEffect } from 'react'
import './Profile.css'
import { ImStarFull } from "react-icons/im";
import { useNavigate ,Link} from 'react-router-dom'
import { IoIosCloudy } from "react-icons/io";

const Profile = () => {
    //const navigate = useNavigate();
    const currentYear = new Date().getFullYear();
    const startYear = currentYear - 15;
    const endYear = currentYear - 4;
    const [saveSuccess, setSaveSuccess] = useState(false);
    const [showSuccessMessage, setShowSuccessMessage] = useState(false);

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
    
      const handleChange = (event) => {
        const { name, value } = event.target;
        setProfile(prevProfile => ({
          ...prevProfile,
          [name]: value
        }));
      };
    
      const handleSave = () => {
        localStorage.setItem('userInfo', JSON.stringify(profile));
        setSaveSuccess(true); // İşlem başarılı olduğunda durum güncelleniyor
        setShowSuccessMessage(true); // Mesajı göstermek için

        setTimeout(() => {
          setShowSuccessMessage(false); // Mesajı bir süre sonra gizle
        }, 5000); // 3 saniye sonra mesajı gizle
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
          <h1 className='profile-header'>MY PROFILE</h1>
          <input 
            type='text' 
            name='name' 
            value={profile.name}
            onChange={handleChange}
          />
          <input 
            type='text' 
            name='surname' 
            value={profile.surname}
            onChange={handleChange}
          />
          <select
            name='gender'
            value={profile.gender}
            onChange={handleChange}
          >
            <option value='' disabled hidden>Select Gender</option>
            <option value='female'>Female</option>
            <option value='male'>Male</option>
          </select>
          <select
                    name='age'
                    value={profile.age}
                    onChange={handleChange}
                    required
                >
                    <option value=''>Select Year of Birth</option>
                    {ageOptions}
                </select>
          <input 
            type='text' 
            placeholder='Email'
            name='email'
            value={profile.email}
            onChange={handleChange}
          />
          <input 
            type='text' 
            value={`Diagnostic test score: ${profile.testScore}`}
            readOnly
            className='readonly-input'
          />
          <div>
            {showSuccessMessage && (
              <div className="success-message">
                Profile updated successfully!
              </div>
            )}
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

export default Profile
