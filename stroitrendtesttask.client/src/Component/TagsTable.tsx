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
  }
  
  const TagsTable: React.FC<TableProps> = ({ reportData }) => {
    const { records } = reportData;
    const dates = Object.keys(records);
    const values = Object.values(records)[0];
    const keys = Object.keys(values);

  return (
    <div className="content">
      <div className='container'>
        <div className="table-responsive">
          <table className='table table-striped table-bordered custom-table'>
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
</div>
  );
};
export default TagsTable