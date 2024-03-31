export type EmployeeAdd = {
  id: string,
  password: string,
  firstName: string, 
  lastName: string, 
  middleName: string, 
  email: string
}
export type EmployeeUpdate = {
  id: string,
  firstName: string, 
  lastName: string, 
  middleName: string, 
  email: string
}
export type RemoveEmployee = {
  id:string; 
  name :string
}
export type Employee = {
  id: string;
  email: string;
};

  export type Project = {
    id: string;
    name: string;
    // Добавьте другие необходимые свойства проекта
  };
  export type EmployeeProjectSelection = {
    projectId: string;
    employeeId: string;
  };
