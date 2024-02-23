import React, {useState} from 'react'
import './Login.css'
import {Link,useNavigate} from "react-router-dom";
const Login = () => {
    const [email,setEmail]= useState('');
    const [password,setPassword]= useState('');
    const navigate = useNavigate();
    const check = (event) => {
        event.preventDefault();
    
        if (!validateForm({ email, password })) {
            alert('Please make sure all fields are filled out correctly.');
            return;
        }
        navigate('/MainPage');
        //loginMutation.mutate({email,password})
    };

    function validateForm({ email, password }) {
        return password.length > 0 || email.length > 0;
    }
    const register=()=> {
        navigate('/Register');
    }
    const forgotPassword=()=> {
        navigate('/ForgotPassword');
    }

  return (
    <div className='login-container'>
     <div className='login-form'>
        <h1>LOGIN</h1>
                <div>
                    <input 
                        type='text' 
                        placeholder='Email'
                        value={email}
                        onChange={(e)=>setEmail(e.target.value)}/>
                </div>
                <div>
                    <input 
                        type='password' 
                        placeholder='Password' 
                        value={password}
                        onChange={(e)=>setPassword(e.target.value)}/> 
                </div>
                <div>
                     <button type='submit' onClick={check}>LOGIN</button>
                     <p>If you don't have an account , you can create one for free.</p>
                    <button onClick={register}>Create Account</button>
                    <button onClick={forgotPassword} >Forgot Password</button>
                </div> 
     </div>            
    </div>
  )
}

export default Login
