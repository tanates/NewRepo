import React, { useState, useEffect } from 'react';
import EmployeeService from '../../Servisec/EmployeeServisec';
import { EmployeeAdd } from '../../Types/EmployeeTypes';

interface ListEmployeesProps {
  onClose: () => void;
}

const ListEmployeesComponent: React.FC<ListEmployeesProps> = ({ onClose }) => {
  const [employees, setEmployees] = useState<EmployeeAdd[]>([]);

  const [newEmployee, setNewEmployee] = useState<EmployeeAdd>({
    id: '',
    password: '',
    firstName: '',
    lastName: '',
    middleName: '',
    email: '',
  });

  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    setNewEmployee({ ...newEmployee, [name]: value });
  };

  const handleAddEmployee = async () => {
    await EmployeeService.addEmpployee(newEmployee);
    setNewEmployee({
      id: '',
      password: '',
      firstName: '',
      lastName: '',
      middleName: '',
      email: '',
    });
    const result = await EmployeeService.getAll();
    setEmployees(result.data);
    onClose(); // Закрываем модальное окно после добавления сотрудника
  };

  useEffect(() => {
    const fetchData = async () => {
      const result = await EmployeeService.getAll();
      setEmployees(result.data);
    };
    fetchData();
  }, []);

  return (
    <div className="container mt-5">
      <h2 className="text-primary">Add Employee</h2>
      <form>
        <div className="form-group row">
          <label htmlFor="password" className="mb-2 col-sm-2 col-form-label">Password:</label>
          <div className="col-sm-10">
            <input type="password" className="form-control" name="password" value={newEmployee.password} onChange={handleInputChange} />
          </div>
        </div>
        <div className="form-group row">
          <label htmlFor="firstName" className="col-sm-2 col-form-label">First Name:</label>
          <div className="col-sm-10">
            <input type="text" className="form-control" name="firstName" value={newEmployee.firstName} onChange={handleInputChange} />
          </div>
        </div>
        <div className="form-group row">
          <label htmlFor="lastName" className="col-sm-2 col-form-label">Last Name:</label>
          <div className="col-sm-10">
            <input type="text" className="form-control" name="lastName" value={newEmployee.lastName} onChange={handleInputChange} />
          </div>
        </div>
        <div className="form-group row">
          <label htmlFor="middleName" className="col-sm-2 col-form-label">Middle Name:</label>
          <div className="col-sm-10">
            <input type="text" className="form-control" name="middleName" value={newEmployee.middleName} onChange={handleInputChange} />
          </div>
        </div>
        <div className="form-group row">
          <label htmlFor="email" className="col-sm-2 col-form-label">Email:</label>
          <div className="col-sm-10">
            <input type="email" className="form-control" id="email" name="email" value={newEmployee.email} onChange={handleInputChange} />
          </div>
        </div>
        <div className="mt-2 d-flex justify-content-center">
          <button type="button" className="btn btn-primary" onClick={handleAddEmployee}>Add Employee</button>
        </div>
      </form>
    </div>
  );
  
};

export default ListEmployeesComponent;
