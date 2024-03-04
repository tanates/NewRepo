interface Record {
    [key: string]: number;
  }
  
  interface ReportData {
    records: {
      [key: string]: Record;
    };
  }
  
  interface TableProps {
    reportData: ReportData;
    reportName:string;
  }
  
  const TagsTable: React.FC<TableProps> = ({ reportData  , reportName }) => {
    const { records } = reportData;
    const dates = Object.keys(records);

  return (
    <div className="content">
        <div className="table-responsive">
        <h2>Name Table : {reportName}</h2>
          <table className='table table-striped table-bordered custom-table-dark table-dark'>
                <thead >
                    <tr>
                    <th>Дата</th>
                    <th>Значения</th>
                    </tr>
                </thead>
                <tbody >
                    {dates.map((date) => (
                    <tr key={date}>
                        <td>{date}</td>
                        <td >
                        {Object.entries(records[date]).map(([key, value]) => (
                            <div  className="d-flex" key={`${date}-${key}` }>
                               
                               {key} - {value}
                            </div>
                        ))}
                       </td>
                    </tr>
                    ))}
                </tbody>
            </table>
       </div>    
    </div>
  );
};
export default TagsTable