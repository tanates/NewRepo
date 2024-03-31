import React, { useEffect, useState } from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
import EmployeeServisec from '../../Servisec/EmployeeServisec';
import { Toast } from 'bootstrap';
import RemoveEmployeeSelect from './EmployeeDelete';
import { EmployeeRemove } from '../../Types/EmployeeRemove';
import EmployeeAdd from './EmployeeAdd';
import UpdateEmployeeForm from './EmployeeUpdate';
import { EmployeeUpdate } from '../../Types/EmployeeTypes';
import { error } from 'jquery';

const EmployeePage: React.FC = () => {
 const [showAddModal, setShowAddModal] = useState(false);
 const [showUpdateForm, setShowUpdateForm] = useState(false);
  const [employeeToRemove, setEmployeeToRemove] = useState<EmployeeRemove | null>(null);
  const [employeeToUpdate , setEmployeeToUpdate] = useState<EmployeeUpdate | null>(null);
  const [employees, setEmployees] = useState<EmployeeRemove[]>([]);
  const [showRemoveEmployeeModal, setShowRemoveEmployeeModal] = useState(false);
  const [toastMessage, setToastMessage] = useState('');
  const handleShowAddModal = () => setShowAddModal(true);

  const showToast = (message: string, type: 'success' | 'error') => {
    setToastMessage(message);
    const toastElement = document.getElementById('liveToast') as HTMLElement;
    const toastInstance = new Toast(toastElement);
    toastInstance.show();

    setTimeout(() => {
      toastInstance.hide();
    }, 3000);
  };

  const handleClose = () => {
    setShowRemoveEmployeeModal(false);
    setShowAddModal(false);
    setShowUpdateForm(false);
  };

  const handleShowRemoveEmployeeModal = () => setShowRemoveEmployeeModal(true);

  useEffect(() => {
    EmployeeServisec.getAll().then((response) => {
      console.log(response.data);
      setEmployees(response.data);
    });
  }, []);

  const handleUpdateButtonClick = () => {
    setShowUpdateForm(true);
  };
  const handleDeleteEmployee = async () => {
    if (employeeToRemove) {
      await EmployeeServisec.remove(employeeToRemove.id)
        .then((response) => {
          showToast(response.data, 'success');
          setEmployees(employees.filter((employee) => employee.id !== employeeToRemove.id));
        })
        .catch((error) => {
          showToast(error.message, 'error');
        });
      setShowRemoveEmployeeModal(false);
    }
  };
   const handleUpdateEmployee = async () =>{
   
    setShowUpdateForm(false)
   }

  return (
    <div className='container mt-5'>
       <div className='d-flex'>   
         <Button className="mx-2" variant="primary" onClick={handleShowAddModal}>
          Add employee
        </Button>


      <div>
        <Button className="mx-2" variant="danger" onClick={handleShowRemoveEmployeeModal}>
          Remove employee
        </Button>
      </div>

      <Modal show={showAddModal} onHide={handleClose}>
          <Modal.Header closeButton>
            <Modal.Title>Add Employee</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <EmployeeAdd onClose={handleClose} />
          </Modal.Body>
        </Modal>

      <Modal show={showRemoveEmployeeModal} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Remove Employee</Modal.Title>
        </Modal.Header>
        <Modal.Body>
        <RemoveEmployeeSelect
            employees={employees}
            onChange={(selectedEmployee) => setEmployeeToRemove(selectedEmployee)}
            onSubmit={handleDeleteEmployee}
            />

        </Modal.Body>
        
      </Modal>
      
  
      </div>
    
      <div>
        <button onClick={handleUpdateButtonClick}>Update Employee</button>
        {showUpdateForm && <UpdateEmployeeForm onUpdate={handleUpdateEmployee} />}
    </div>

      <div className="position-fixed bottom-0 end-0 p-3 toast-container">
        <div id="liveToast" className="toast hide" role="alert" aria-live="assertive" aria-atomic="true">
          <div className="toast-header">
            <strong className="me-auto">Bootstrap</strong>
            <small>just now</small>
            <button type="button" className="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
          </div>
          <div className="toast-body">
            {toastMessage}
          </div>
        </div>
      </div>
    </div>
  );
};

export default EmployeePage;
