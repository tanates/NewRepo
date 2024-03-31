import React, { useState } from 'react';
import { AddProjectType } from '../../Types/ProjectTypes';
import ProjectService from '../../Servisec/ProjectServisec'
import { v4 as uuidv4 } from 'uuid';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
import { Toast } from 'bootstrap';



const AddProjectForm: React.FC = () => {
  const [project, setProject] = useState<AddProjectType>({
    Id: '',
    NameProject: '',
    CustomerCompany: '',
    ExecutingCompany: '',
    emailEmployee: '',
    StartDateProject: new Date(),
    EndDateProject: new Date(),
    PriorityProject: 0
  });
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
  

  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    setProject({ ...project, [name]: value });
  };

  const handleDateChange = (name: string, date: Date) => {
    setProject({ ...project, [name]: date });
  };

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    try {
      const response = await ProjectService.addProject(project);
      console.log(response);
      // сбросить форму после отправки
      setProject({
        Id: uuidv4() ,
        NameProject: '',
        CustomerCompany: '',
        ExecutingCompany: '',
        emailEmployee: '',
        StartDateProject: new Date(),
        EndDateProject: new Date(),
        PriorityProject: 0
      });
      showToast(response , 'success')
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <form className='form-row'onSubmit={handleSubmit}>
        <h2 className="text-primary">Add Project</h2>
    <div className="form-row">
      <div className="form-group col-md-6">
        <label htmlFor="NameProject">Name Project:</label>
        <input type="text" className="form-control" name="NameProject" value={project.NameProject} onChange={handleInputChange} />
      </div>
      <div className="form-group col-md-6">
        <label htmlFor="CustomerCompany">Customer Company:</label>
        <input type="text" className="form-control" name="CustomerCompany" value={project.CustomerCompany} onChange={handleInputChange} />
      </div>
    </div>
    <div className="form-row">
      <div className="form-group col-md-6">
        <label htmlFor="ExecutingCompany">Executing Company:</label>
        <input type="text" className="form-control" name="ExecutingCompany" value={project.ExecutingCompany} onChange={handleInputChange} />
      </div>
      <div className="form-group col-md-6">
        <label htmlFor="emailEmployee">Email Employee:</label>
        <input type="text" className="form-control" name="emailEmployee" value={project.emailEmployee} onChange={handleInputChange} />
      </div>
    </div>
    <div className="form-row">
      <div className="form-group col-md-6">
        <label htmlFor="StartDateProject">Start Date Project:</label>
        <input type="date"  name="StartDateProject" value={project.StartDateProject.toISOString().split('T')[0]} onChange={(e) => handleDateChange('StartDateProject', new Date(e.target.value))} />
      </div>
      <div className="form-group col-md-6">
        <label htmlFor="EndDateProject">End Date Project:</label>
        <input type="date" name="EndDateProject" value={project.EndDateProject.toISOString().split('T')[0]} onChange={(e) => handleDateChange('EndDateProject', new Date(e.target.value))} />
      </div>
    </div>
    <div className="form-row">
      <div className="form-group col-md-6">
        <label htmlFor="PriorityProject">Priority Project:</label>
        <input type="number" className="form-control" name="PriorityProject" value={project.PriorityProject} onChange={handleInputChange} />
      </div>
    </div>
    <div className="mt-2 d-flex justify-content-center">
      <button type="submit" className="btn btn-primary">Add Project</button>
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
    </form>
    
  );
};

export default AddProjectForm;


