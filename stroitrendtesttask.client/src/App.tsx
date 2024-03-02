import React, { useState } from 'react';
import Table  from './Component/ReportTable';
import 'bootstrap/dist/css/bootstrap.min.css';

const App: React.FC = () => {
  const [reportName, setReportName] = useState<'Duration' | 'Ratings' | 'ResponseTime' | 'Tags' | 'TotalChats'>('Duration');

  return (
    <div className='container' >
            <button onClick={() => setReportName('Duration')}>Duration</button>
            <button onClick={() => setReportName('Ratings')}>Ratings</button>
            <button onClick={() => setReportName('ResponseTime')}>ResponseTime</button>
            <button onClick={() => setReportName('Tags')}>Tags</button>
            <button onClick={() => setReportName('TotalChats')}>TotalChats</button>
            <br />
            <br />
         <div className='d-flex justify-content-center'>
            <h1>Reports</h1>
        </div>
      <Table reportName={reportName} />
    </div>
  );
};

export default App;
