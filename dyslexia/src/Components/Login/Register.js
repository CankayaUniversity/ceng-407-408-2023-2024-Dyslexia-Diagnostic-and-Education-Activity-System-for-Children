import React, {useState} from 'react'
import './Register.css'
import { useNavigate } from 'react-router-dom'

const Register = () => {
    const [email, setEmail] = useState('')
    const [name, setName] = useState('')
    const [surname, setSurname] = useState('')
    const [gender, setGender] = useState('')
    const [age, setAge] = useState('')
    const [password, setPassword] = useState('')
    const [confirmPassword, setConfirmPassword] = useState('')
    const navigate = useNavigate();
    const currentYear = new Date().getFullYear();
    const startYear = currentYear - 20; // 20 yıl önce
    const endYear = currentYear - 4; // 4 yıl önce

    // ageOptions dizisi, sadece belirli yaş aralığındaki yılları içerecek şekilde güncelleniyor.
    const ageOptions = [];
    for (let year = endYear; year >= startYear; year--) {
        ageOptions.push(<option key={year} value={year}>{year}</option>);
    }
    
    const handleChange = (e) => {
        const { name, value } = e.target;
        if (name === 'name') setName(value);
        else if (name === 'surname') setSurname(value);
        else if (name === 'age') setAge(parseInt(value));
        else if (name === 'gender') setGender(value);
        else if (name === 'email') setEmail(value);
        else if (name === 'password') setPassword(value);
        else if (name === 'confirmPassword') setConfirmPassword(value);

    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        const userInfoToSave = { email, name,surname,gender,age, password, confirmPassword };

        if (!validateForm(userInfoToSave)) {
            alert('Please make sure all fields are filled out correctly and passwords match.');
            return;
        }
        console.log(userInfoToSave);
        localStorage.setItem('userInfo', JSON.stringify(userInfoToSave));
        navigate('/RegisterAgreement')
    };

    function validateForm({ email, name,surname,gender,age, password, confirmPassword }) {
        return (
            password === confirmPassword &&
            password.length > 0 &&
            name.length > 0 &&
            surname.length > 0 &&
            age.toString().length > 0 &&
            email.length > 0 &&
            confirmPassword.length > 0
        );
    }

  return (
    <div className='register-container'>
        <div className='register-form'>
            <h1>Sign Up for Free</h1>
            <div>
                <input 
                    type='text' 
                    placeholder='Name' 
                    name='name' 
                    value={name}
                    onChange={handleChange}
                />
            </div>
            <div>
                <input 
                    type='text' 
                    placeholder='Surname' 
                    name='surname' 
                    value={surname}
                    onChange={handleChange}
                />
            </div>
            <div>
                <select
                    name='age'
                    value={age}
                    onChange={handleChange}
                    required
                >
                    <option value=''>Select Year of Birth</option>
                    {ageOptions}
                </select>
            </div>
            <div>
                <select
                    name='gender'
                    value={gender} // Bu seçilen değeri belirlemek için kullanılır.
                    onChange={handleChange}
                >
                    <option value='' disabled hidden>Select Gender</option>
                    <option value='female'>Female</option>
                    <option value='male'>Male</option>
                </select>
            </div>
            <div>
                <input 
                    type='text' 
                    placeholder='Email'
                    name='email'
                    value={email}
                    onChange={handleChange}
                />
            </div>
            <div>
                <input 
                    type='password' 
                    placeholder='Password' 
                    name='password' 
                    value={password}
                    onChange={handleChange}
                />   
            </div>
            <div>
                <input 
                    type='password' 
                    placeholder='Confirm Password' 
                    name='confirmPassword' 
                    value={confirmPassword}
                    onChange={handleChange}
                />   
            </div>
            <div>
                <button onClick={handleSubmit} type="submit">Create your account</button>
            </div>
        </div>
    </div>
  )
}

export default Register
