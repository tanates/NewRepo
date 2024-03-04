import React, { useState } from 'react';
import Table  from './Component/ReportTable';
import 'bootstrap/dist/css/bootstrap.min.css';

const App: React.FC = () => {
  const [reportName, setReportName] = useState<'Duration' | 'Ratings' | 'ResponseTime' | 'Tags' | 'TotalChats'>('Duration');

  return (
    
    <div className='d-flex row ' >
      <div className='d-flex justify-content-center '>
          <h1 >Reports</h1>
      </div>
      <div className='d-flex justify-content-center'>
            <div className='mt-1'>
            <button onClick={() => setReportName('Duration')}>Duration</button>
            <button onClick={() => setReportName('Ratings')}>Ratings</button>
            <button onClick={() => setReportName('ResponseTime')}>ResponseTime</button>
            <button onClick={() => setReportName('Tags')}>Tags</button>
            <button onClick={() => setReportName('TotalChats')}>TotalChats</button>
            </div>
        </div>
        <div className=' '>
            
             <Table reportName={reportName} />
        </div>
       
 
    </div>
  );
};

export default App;
