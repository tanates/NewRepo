import './App.css';
import { Routes, Route, BrowserRouter } from "react-router-dom";
import Project from './Component/ProjectComponent/Project';
import EmployeePage from './Component/EmployeeComponent/EmployeePage';
import Navigation from './Navigation';

const App: React.FC = () => {
  return (
    <BrowserRouter>
    <Navigation />
      <div className='text-center mt-5'>
        <Routes>
          <Route path="/Project" element={<Project />} />
          <Route path="/Employee" element={<EmployeePage />} />
          <Route path="/Task" element={<div>Task page</div>} /> {/* Добавьте компонент Task позже */}
        </Routes>
      </div>
    </BrowserRouter>
  );
};

export default App;
