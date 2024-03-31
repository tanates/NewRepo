import axios from "axios";
import { EmployeeAdd, EmployeeProjectSelection, EmployeeUpdate } from "../Types/EmployeeTypes";

const API_URL ="https://localhost:7280/api/";
class EmployeeServisec {
    static async update(data : EmployeeUpdate []) {
        const response= await axios.put(API_URL +`Employee` , data)

        return response.data;
        
    }
   static async getAll() {
        return axios.get(API_URL+`Employee`);
    }
   
   static async addEmployeeInProject(data: EmployeeProjectSelection) {
        return axios.put(API_URL +`Projects/add/employee`, data);
      }

  static async  addEmpployee( data: EmployeeAdd ){
        return axios.post(API_URL+`Employee` , data);
    }

    static remove(employeeId: string) {
        return axios.delete(`${API_URL}/${employeeId}`);
      }
}

export default EmployeeServisec