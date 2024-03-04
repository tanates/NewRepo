import axios from 'axios';
import React, { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import './ReportStyle.css'
import TagsTable from './TagsTable';
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

  const tableHeaders = Object.entries(data.records[Object.keys(data.records)[0]]).map(([name, _]) => name);
  const tableHeadersTags = Object.entries(data.records[Object.keys(data.records)[0]]).map(([name, _]) => name);
  const tableRows = Object.entries(data.records).map(([date, records]) => {
    const rowData = [date, Object.values(records).reduce((total, value) => total + value, 0), ...Object.values(records)];

    return (
      <tr key={date}>
        {rowData.map((value, index) => (
          <td key={`${date}-${index}`}>{value}</td>
        ))}
      </tr>
    );
  });

  if(reportName!=="Tags"){
  return (
    <div className="content">
      <div className='container'>
        <div className="table-responsive">
          <table className='table table-striped table-bordered custom-table'>
            <thead>
              {reportName!=="Tags"&&(
              <tr>
                <th scope="col">Data</th>
                <th scope="col">Total</th>
                {tableHeaders.map((name) =>(
                    
                     <th scope="col" key={name}>{name}</th>
                ))}
              </tr>
              )}
              {reportName==="Tags"&&(
                  tableHeadersTags
              )}
            </thead>
            <tbody>
              { reportName === "Tags" && (
                 tableRows
              )} 
              {reportName!=="Tags"&&(
                tableRows
              )}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
              }
    else{
      return (
        <TagsTable reportData={data}/>
      )
    }
};

export default Table;
