import axios from "axios";
import { AddProjectType, RemoveProject } from "../Types/ProjectTypes";
import { EmployeeProjectSelection } from "../Types/EmployeeTypes";

const API_URL = "https://localhost:7280/api/Projects";

class ProjectService {

  static async getAll() {
    return axios.get(API_URL +`/all`);
  }
  static async getAllEmployee(projectId:string) {
    const response = await axios.get(`${API_URL}/project/${projectId}`);
    return response.data;
}

 static async addProject(data: AddProjectType) {
    const response = await axios.post(API_URL + "/add", data);
    return response.data;
  }
  
  
  static async deleteProject(data: RemoveProject) {
    return await axios.delete(`${API_URL}/delete/${data.id}`);
  }
    
  static async deleteEmployeeInProject(data: EmployeeProjectSelection) {
    return await axios.put(`${API_URL}/delete/employee`, data);
  }
}

export default ProjectService
