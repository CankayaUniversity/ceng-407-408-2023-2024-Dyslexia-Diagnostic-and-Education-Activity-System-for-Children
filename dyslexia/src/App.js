import {
  BrowserRouter as Router,
  Routes,
  Route,
  Navigate 
} from "react-router-dom";
import Login from "./Components/Login/Login";
import Register from "./Components/Login/Register";
import ForgotPassword from "./Components/Login/ForgotPassword";
import MainPage from "./Components/Main/MainPage";
import RegisterAgreement from "./Components/Login/RegisterAgreement";
import Profile from "./Components/Main/Profile/Profile";
function App() {
  return (
    <div className="App">
      <Router>
        <Routes>
          <Route path="/" element={<Login/>}/>
          <Route path='/Register' element={<Register/>}/>
          <Route path="/RegisterAgreement" element={<RegisterAgreement/>}/>
          <Route path="/ForgotPassword" element={<ForgotPassword/>}/>
          <Route path='/MainPage'element={<MainPage/>}/>
          <Route path="/Profile" element={<Profile/>}/>
        
        </Routes>
      </Router>
    </div>
  );
}

export default App;
