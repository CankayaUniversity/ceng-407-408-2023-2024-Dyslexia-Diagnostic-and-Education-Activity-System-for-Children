import React, { useState, useEffect } from 'react';
import './TestsInformation.css';
import { ImStarFull } from "react-icons/im";
import { useNavigate, useLocation, Link } from 'react-router-dom';
import { IoIosCloudy } from "react-icons/io";

const TestsInformation = () => {
  const navigate = useNavigate();
  const location = useLocation(); 
  const [currentTest, setCurrentTest] = useState('LetterMatching');
  const [testInfo, setTestInfo] = useState({ title: '', description: '' });

  useEffect(() => {
    let stateTest = location.state?.currentTest;
    if (stateTest) {
      setCurrentTest(stateTest);
    }
  }, [location]);

  useEffect(() => {
    let info = {};
    if (currentTest === 'LetterMatching') {
      info = {
        title: 'Letter Matching Test',
        description: 'Match the letters with the correct pictures.'
      };
    } else if (currentTest === 'NavigationSkill') {
      info = {
        title: 'Navigation Skill Test',
        description: 'Navigate through the maze to find the treasure.'
      };
    } else if (currentTest === 'Symmetry') {
      info = {
        title: 'Symmetry Test',
        description: 'Test your ability to identify symmetrical shapes.'
      };
    }
    setTestInfo(info);
  }, [currentTest]);

  const handleStart = () => {
    if (currentTest === 'LetterMatching') {
      navigate('/LetterMatchingTest');
    } else if (currentTest === 'NavigationSkill') {
      navigate('/NavigationSkillTest');
    } else if (currentTest === 'Symmetry') {
      navigate('/SymmetryTest');
    }
  };

  const handleClose = () => {
    navigate('/MainPage');
  };

  return (
    <div className='testInfo-container'>
      <Link to={`/ProfileReadOnly`}>
        <div className='profile-icon'>
          <ImStarFull className="icon"/>
          <span className="text">PROFILE</span>
        </div>
      </Link>
      <div className="testInfo-modal">
        <div className="testInfo-modal-content">
          <span className="close" onClick={handleClose}>&times;</span>
          <h2>{testInfo.description}</h2>
          <div className="start-button" onClick={handleStart}>
            <IoIosCloudy className="start-icon-save" />
            <span>Start Test</span>
          </div>
          <h1 className="testInfo-title">{testInfo.title}</h1>
        </div>
      </div>
    </div>
  );
};

export default TestsInformation;
