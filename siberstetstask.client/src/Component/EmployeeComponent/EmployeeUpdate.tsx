import React, { useState, useEffect, ChangeEvent } from 'react';
import Modal from 'react-modal';
import { EmployeeUpdate } from '../../Types/EmployeeTypes';
import EmployeeServisec from '../../Servisec/EmployeeServisec';
import 'bootstrap/dist/css/bootstrap.min.css';

interface Props {
  onUpdate: (employee: EmployeeUpdate) => void;
}

const EmployeeUpdateForm: React.FC<Props> = ({ onUpdate }) => {
  const [employees, setEmployees] = useState<EmployeeUpdate[]>([]);
  const [selectedEmployee, setSelectedEmployee] = useState<EmployeeUpdate >();
  const [modalIsOpen, setModalIsOpen] = useState(false);

  useEffect(() => {
    const fetchEmployees = async () => {
      const response = await EmployeeServisec.getAll();
      const allEmployees: EmployeeUpdate[] = response.data;
      setEmployees(allEmployees);
    };
    fetchEmployees();
  }, []);

  const handleEmployeeSelect = (event: React.ChangeEvent<HTMLSelectElement>) => {
    const selectedId = event.target.value;
    const selected = employees.find((employee) => employee.id === selectedId);
    setSelectedEmployee(selected); // Удалите || null
    setModalIsOpen(true);
  };
  const handleInputChange = (event: ChangeEvent<HTMLInputElement>) => {
    if (selectedEmployee) {
      setSelectedEmployee({
        ...selectedEmployee,
        [event.target.name]: event.target.value,
      });
    }
  };

  const handleFormSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    if (selectedEmployee) {
      onUpdate(selectedEmployee);
      setModalIsOpen(false);
    }
  };

  return (
    <div className="container mt-5">
          <div className="container mb-5">
      <div className="form-group">
        <label htmlFor="employeeSelect">Выберите сотрудника</label>
        <select className="form-control" id="employeeSelect" onChange={handleEmployeeSelect}>
          <option value="">Выберите сотрудника</option>
          {employees.map((employee) => (
            <option key={employee.id} value={employee.id}>
              {employee.email}
            </option>
          ))}
        </select>
      </div>
      <Modal className="update" isOpen={modalIsOpen} onRequestClose={() => setModalIsOpen(false)}>
        {selectedEmployee && (
          <form onSubmit={handleFormSubmit}>
            <div className="modal-content">
              <div className="modal-header">
                <h5 className="modal-title">Обновить информацию о сотруднике</h5>
                <button type="button" className="close" onClick={() => setModalIsOpen(false)}>
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div className="modal-body">
                <div className="form-group">
                  <label htmlFor="employeeSelect">Выберите сотрудника</label>
                  <select className="form-control" id="employeeSelect" value={selectedEmployee.id} onChange={handleEmployeeSelect}>
                    <option value="">Выберите сотрудника</option>
                    {employees.map((employee) => (
                      <option key={employee.id} value={employee.id}>
                        {employee.email}
                      </option>
                    ))}
                  </select>
                </div>
                <div className="form-group">
                  <label htmlFor="firstName">Имя</label>
                  <input type="text" className="form-control" id="firstName" name="firstName" value={selectedEmployee.firstName} onChange={handleInputChange} />
                </div>
                <div className="form-group">
                  <label htmlFor="lastName">Фамилия</label>
                  <input type="text" className="form-control" id="lastName" name="lastName" value={selectedEmployee.lastName} onChange={handleInputChange} />
                </div>
                <div className="form-group">
                  <label htmlFor="middleName">Отчество</label>
                  <input type="text" className="form-control" id="middleName" name="middleName" value={selectedEmployee.middleName} onChange={handleInputChange} />
                </div>
              </div>
              <div className="modal-footer">
                <button type="submit" className="btn btn-primary">Обновить сотрудника</button>
                <button type="button" className="btn btn-secondary" onClick={() => setModalIsOpen(false)}>Закрыть</button>
              </div>
            </div>
          </form>
        )}
      </Modal>
    
    </div>
   </div> 
  );
};

export default EmployeeUpdateForm;
