import React, { useEffect, useState } from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import AddProjectForm from './ProjectAdd';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
import EmployeeProjectSelect from './ProjectAddEmployee';
import ProjectService from '../../Servisec/ProjectServisec';
import EmployeeServisec from '../../Servisec/EmployeeServisec';
import { EmployeeProjectSelection, Project } from '../../Types/EmployeeTypes';
import { Employee } from "../../Types/EmployeeTypes";
import RemoveProjectSelect from './RemoveProject';
import { RemoveProject } from '../../Types/ProjectTypes';
import { Toast } from 'bootstrap';
import ProjectRemoveEmployee from './ProjectRemoveEmployee';



const ProjectPage: React.FC = () => {
  const [projectsDelete ,setDelete] = useState<RemoveProject|null>(null);
  const [projectsEmployeeDelete ,setEmplyeeDelete] = useState<EmployeeProjectSelection|null>(null);
  const [projects, setProjects] = useState<Project[]>([]);
  const [employees, setEmployees] = useState<Employee[]>([]);
  const [selectedOption, setSelectedOption] = useState<EmployeeProjectSelection | null>(null);
  const [showProjectModal, setShowProjectModal] = useState(false);
  const [showEmployeeModal, setShowEmployeeModal] = useState(false);
  const [showRemoveModal, setShowRemoveModal] = useState(false);
  const [showRemoveEmplyeeModal, setShowRemoveEmployeeModal] = useState(false);
  const [toastMessage, setToastMessage] = useState('');
  
  
  
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
    setShowProjectModal(false);
    setShowEmployeeModal(false);
    setShowRemoveModal(false);
    setShowRemoveEmployeeModal(false)
  };
  const handleShowProjectModal = () => setShowProjectModal(true);
  const handleShowEmployeeModal = () => setShowEmployeeModal(true);
  const handleShowRemoveModel = () => setShowRemoveModal(true);
  const handleShowEmployeeRemoveModel = ()=> setShowRemoveEmployeeModal(true);
  useEffect(() => {
  
    ProjectService.getAll().then((response) => {
      setProjects(response.data);
    });

    EmployeeServisec.getAll().then((response) => {
      setEmployees(response.data);
    });
  }, []);
  const handleSubmit = async () => {
    if (selectedOption) {
      const data: EmployeeProjectSelection = {
        projectId: selectedOption.projectId,
        employeeId: selectedOption.employeeId,
      };

      await EmployeeServisec.addEmployeeInProject(data)
        .then((response) => {
          showToast(response.data, 'success')
          // Сбросить или обновить состояние при необходимости
        })
        .catch((error) => {
          console.error('Error:', error);
          showToast(error.message, 'error')
        });
    }

    if(projectsEmployeeDelete){
      const data  : EmployeeProjectSelection = {
        projectId: projectsEmployeeDelete.projectId,
        employeeId: projectsEmployeeDelete.employeeId,
           
      }
      await ProjectService.deleteEmployeeInProject(data).then((response=>{
        showToast(response.data, 'success')
      })
      ) .catch((error)=>{
        showToast(error.message, 'success')
      })
    }
    
  };

  const hundleDeleteSubmit = async () => {
       if(projectsDelete){
          const data  : RemoveProject = {
             id :projectsDelete.id,
              name : projectsDelete.name
          }

          await ProjectService.deleteProject(data)
          .then((response) => {
            
            showToast(response.data, 'success')
            // Сбросить или обновить состояние при необходимости
          })
          .catch((error)=>{
            showToast(error.message, 'success')
          })
       }
    
  };
  return (
    <div className='d-flex'>
      <div>
        <Button className="mx-2" variant="primary" onClick={handleShowProjectModal}>
            Add project
        </Button>
      </div>
      
      <div>
        <Button className="mx-2" variant="primary" onClick={handleShowEmployeeModal}>
        Add employee 
       </Button>
      </div>
      <div>
        <Button className="mx-2" variant="danger" onClick={handleShowRemoveModel}>
           Remove project
        </Button>
      </div>
      <div>
        <Button className="mx-2" variant="danger" onClick={handleShowEmployeeRemoveModel}>
           Remove employee
        </Button>
      </div>
      
      <Modal show={showProjectModal} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Add New Project</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <AddProjectForm />
        </Modal.Body>
      </Modal>

      <Modal show={showEmployeeModal} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Add New Employee in Project</Modal.Title>
        </Modal.Header>
        <Modal.Body>
           <EmployeeProjectSelect projects={projects} employees={employees} onChange={setSelectedOption} onSubmit={handleSubmit}/>
        </Modal.Body>
      </Modal>
      <Modal show={showRemoveModal} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Remove Project</Modal.Title>
        </Modal.Header>
        <Modal.Body>
           <RemoveProjectSelect projects={projects}  onChange={setDelete} onSubmit={hundleDeleteSubmit}/>
        </Modal.Body>
      </Modal>
      <Modal show={showRemoveEmplyeeModal} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Remove Project</Modal.Title>
        </Modal.Header>
        <Modal.Body>
           <ProjectRemoveEmployee projects={projects} employees={employees}   onChange={setEmplyeeDelete} onSubmit={handleSubmit}/>
        </Modal.Body>
      </Modal>

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

export default ProjectPage;
