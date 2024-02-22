import {
  BrowserRouter as Router,
  Routes,
  Route,
  Navigate 
} from "react-router-dom";
 import Login from "./Components/Login/Login";
function App() {
  return (
    <div className="App">
      <Router>
        <Routes>
          <Route path="/" element={<Login/>}/>
        </Routes>
      </Router>
    </div>
  );
}

export default App;
