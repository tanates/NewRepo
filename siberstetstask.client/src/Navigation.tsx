import React from 'react';
import { NavLink } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
const Navigation: React.FC = () => {
  return (
    <header className='text-center mt-1'>
      <NavLink to="/Project" className='mx-2 btn btn-dark'>Project</NavLink>
      <NavLink to="/Employee" className='mx-2 btn btn-dark'>Employee</NavLink>
      <NavLink to="/Task" className='mx-2 btn btn-dark'>Task</NavLink>
    </header>
  );
};

export default Navigation;
