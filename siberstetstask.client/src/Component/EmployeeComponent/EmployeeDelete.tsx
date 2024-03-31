import React from 'react';
import Select from 'react-select';
import { EmployeeRemove } from "../../Types/EmployeeRemove";

interface RemoveEmployeeSelectProps {
  employees: EmployeeRemove[];
  onChange: (selectedOption: EmployeeRemove | null) => void;
  onSubmit: () => void;
}

const RemoveEmployeeSelect: React.FC<RemoveEmployeeSelectProps> = ({ employees, onChange, onSubmit }) => {
    const employeeOptions = employees.map((employee) => ({
        value: employee.id,
        label: employee.email, // измените эту строку
      }));

  const handleInputChange = (selectedOption: any) => {
    const employee = employees.find((employee) => employee.id === selectedOption.value);
    onChange(employee || null);
  };
  

  return (
    <>
      <Select
        options={employeeOptions}
        onChange={handleInputChange}
        placeholder="Select an employee to remove"
      />
      <button onClick={onSubmit}>Remove Employee</button>
    </>
  );
};

export default RemoveEmployeeSelect;
