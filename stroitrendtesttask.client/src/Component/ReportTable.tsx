import axios from 'axios';
import React, { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
interface ReportData {
  total: number;
  records: { [key: string]: { [key: string]: number } };
}

interface TableProps {
  reportName: string;
}

const API_URL = `https://localhost:7150/api/table/`

const Table: React.FC<TableProps> = ({ reportName }) => {
  const [data, setData] = useState<ReportData | null>(null);
 
  React.useEffect(() => {
    const fetchData = async () => {
      try {
        const result = await axios.get<ReportData>(API_URL+reportName);
        setData(result.data);
      } catch (error) {
      
        const fallbackURL = `https://DockerPuth/${reportName}`
        if (fallbackURL) {
          const fallbackResult = await axios.get<ReportData>(fallbackURL);
          setData(fallbackResult.data);
        } else {
          console.error('Error making request:', error);
        }
      }
    };
  
    fetchData();
  }, [reportName, API_URL]);

  if (!data) {
    return <div>Loading...</div>;
  }

  const tableRows = Object.entries(data.records).map(([date, records]) => {
    return (
      <tr key={date}>
        <td>{date}</td>
        <td>{Object.values(records).reduce((total, value) => total + value, 0)}</td>
        {Object.entries(records).map(([name, value]) => (
          <td key={name}>{value}</td>
        ))}
      </tr>
    );
  });

  return (

    <div className='row'>
        <div className="col-12">
          <div className='card'>
            <div className="table-responsive">
                <table className='table table-striped table-dark'>
                  <thead className='bg-dark'>
                    <tr className='bg-dark'>
                      <th scope="col">Date</th>
                      <th scope="col">Total</th>
                        {Object.entries(data.records[Object.keys(data.records)[0]]).map(([name, _]) => (
                        <th scope="col" key={name}>{name}</th>
                      ))}
                    </tr>
                  </thead>
                  <tbody className="customtable">
                    {tableRows}
                  </tbody>
                </table>
          </div>
        </div>
      </div>
   </div>
  );
};
export default Table 