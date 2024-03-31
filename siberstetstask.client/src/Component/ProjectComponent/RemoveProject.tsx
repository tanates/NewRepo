import React, { useState } from 'react';
import Select from 'react-select';
import {  RemoveProject} from '../../Types/ProjectTypes';
import Button from 'react-bootstrap/esm/Button';

interface RemoveProjectSelectProps {
    projects: RemoveProject[];
    onChange: (selectedOption: RemoveProject | null) => void;
    onSubmit: () => void;
  }
  
const RemoveProjectSelect: React.FC<RemoveProjectSelectProps> = ({ projects,  onChange , onSubmit}) => {
  const [selectedOption, setSelectedOption] = useState<RemoveProject | null>(null);

  const projectOptions = projects.map((project) => ({
    value: project.id,
    label: project.name,
  }));



  const handleInputChange = (newSelectedOption: RemoveProject | null) => {
    setSelectedOption(newSelectedOption);
    onChange(newSelectedOption);
  };
 

  return (
    <div className='container'>
    <Select
        value={projectOptions.find((option) => option.value === selectedOption?.id)}
        onChange={(option) => {
        const selectedProject = projects.find((project) => project.id === option?.value);
        handleInputChange(selectedProject || null);
        }}
        options={projectOptions}
        placeholder="Выберите проект..."
        isClearable
    />
    <div className=''>
    <Button className='' type="button" onClick={onSubmit}>Deleted</Button>
    </div>

    </div>
  );
};

export default RemoveProjectSelect;
