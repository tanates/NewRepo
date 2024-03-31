import React, { useState } from 'react';
import Select from 'react-select';
import { Project, EmployeeProjectSelection } from '../../Types/EmployeeTypes';
import { Employee } from "../../Types/EmployeeRemove";
import Button from 'react-bootstrap/esm/Button';
interface EmployeeProjectSelectProps {
    projects: Project[];
    employees: Employee[];
    onChange: (selectedOption: EmployeeProjectSelection | null) => void;
    onSubmit: () => void;
  }
  
const EmployeeProjectSelect: React.FC<EmployeeProjectSelectProps> = ({ projects, employees, onChange , onSubmit}) => {
  const [selectedOption, setSelectedOption] = useState<EmployeeProjectSelection | null>(null);

  const projectOptions = projects.map((project) => ({
    value: project.id,
    label: project.name,
  }));

  const employeeOptions = employees.map((employee) => ({
    value: employee.id,
    label: employee.email,
  }));

  const handleInputChange = (newSelectedOption: EmployeeProjectSelection | null) => {
    setSelectedOption(newSelectedOption);
    onChange(newSelectedOption);
  };
 

  return (
    <>
      <Select
        value={projectOptions.find((option) => option.value === selectedOption?.projectId)}
        onChange={(option) => handleInputChange({ projectId: option?.value || '', employeeId: '' })}
        options={projectOptions}
        placeholder="Выберите проект..."
        isClearable
      />
      <Select className='mt-2'
        value={employeeOptions.find((option) => option.value === selectedOption?.employeeId)}
        onChange={(option) => handleInputChange({ projectId: selectedOption?.projectId || '', employeeId: option?.value || '' })}
        options={employeeOptions}
        placeholder="Выберите сотрудника..."
        isClearable
        isDisabled={!selectedOption?.projectId}
        
      />
    <Button className='mt-2' type="button" onClick={onSubmit}>Delete</Button>
    </>
  );
};

export default EmployeeProjectSelect;
