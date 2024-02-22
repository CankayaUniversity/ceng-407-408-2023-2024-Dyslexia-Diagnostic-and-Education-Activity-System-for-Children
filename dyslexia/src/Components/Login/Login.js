import React, {useState} from 'react'
import './Login.css'
const Login = () => {
    const [email,setEmail]= useState('');
    const [password,setPassword]= useState('');
  return (
    <div className='container'>
     <div className='login-form'>
        <h1>LOGIN</h1>
                <div>
                    <input 
                        type='text' 
                        placeholder='email' 
                        id='email' 
                        value={email}
                        />
                </div>
                <div>
                    <input 
                        type='password' 
                        placeholder='Password' 
                        id='password' 
                        value={password}
                    /> 
                </div>
                <div>
                     <button type='submit' >LOGIN</button>
                </div> 
                <div>
                    <p>If you don't have an account , you can create one for free.</p>
                </div>
                <div>
                     <button type='submit' >Create Account</button>
                </div> 
                <div>
                     <button type='submit' >Forgot password</button>
                </div> 
                {/* 
                <div>
                onClick={check}
                    <Link to='/Register'>
                        Need an account?
                    </Link>
                </div>
                */}
     </div>            
    </div>
  )
}

export default Login
