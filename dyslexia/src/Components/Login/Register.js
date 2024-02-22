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

    const handleChange = (e) => {
        const { name, value } = e.target;
        if (name === 'name') setName(value);
        else if (name === 'surname') setSurname(value);
        else if (name === 'age') setAge(value);
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
        navigate('/')
    };

    function validateForm({ email, name,surname,gender,age, password, confirmPassword }) {
        return (
            password === confirmPassword &&
            password.length > 0 &&
            name.length > 0 &&
            surname.length > 0 &&
            age.length > 0 &&
            email.length > 0 &&
            confirmPassword.length > 0
        );
    }

  return (
    <div className='container'>
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
                <input 
                    type='text' 
                    placeholder='Age' 
                    name='age' 
                    value={age}
                    onChange={handleChange}
                />
            </div>
            <div>
                <input 
                    type='text' 
                    placeholder='Gender' 
                    name='gender' 
                    value={gender}
                    onChange={handleChange}
                />
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
