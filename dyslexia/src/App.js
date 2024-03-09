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
import DiagnosticTestAgreement from "./Components/Main/DiagnosticTest/DiagnosticTestAgreement";
import EducationalGamesList from "./Components/Main/EducationalGame/EducationalGamesList";
//import MatchDinoParts from "./Games/MatchDinoParts";
import ProfileReadOnly from "./Components/Main/Profile/ProfileReadOnly";
import TestsInformation from "./Components/Main/DiagnosticTest/TestsInformation";
import LetterMatchingTest from "./Components/Main/DiagnosticTest/TestGames/LetterMatchingTest";
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
          <Route path="/ProfileReadOnly" element={<ProfileReadOnly/>}/>
          <Route path="/DiagnosisAgreement" element={<DiagnosticTestAgreement/>}/>
          <Route path="/TestsInformation" element={<TestsInformation/>}/>
          <Route path="/EducationalGamesList" element={<EducationalGamesList/>}/>
          <Route path="/LetterMatchingTest" element={<LetterMatchingTest/>}/>

        </Routes>
      </Router>
    </div>
  );
}

export default App;
/*<Route path="/MatchDino" element={<MatchDinoParts/>}/> */