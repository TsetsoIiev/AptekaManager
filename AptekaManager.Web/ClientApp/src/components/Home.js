import React, { useState } from 'react';
import PharmacyGrid from './PharmacyGrid';
import SearchBox from './SearchBox';

const axios = require('axios');

export function Home() {

  const [searchData, setSearchData] = useState('');
  const [pharmacyData, setPharmacyData] = useState([]);

  const handleSearchClick = () => {
    try {
      axios.get(`https://localhost:44306/api/Pharmacy/GetMedicines/${searchData}`, {
        headers: {
          'Access-Control-Allow-Origin': '*'
        }
      }).then((res) => {
        if (res.status === 200) {
          setPharmacyData(res.data);
        }
      })
    } catch {
      alert('Търсеното лекарство не бе намерено в нашата мрежа');
    }
}

  return (
    <div>
      <div>
        <SearchBox searchData={searchData} setSearchData={setSearchData} handleSearchClick={handleSearchClick} />
      </div>
      <div>
        <PharmacyGrid data={pharmacyData} />
      </div>
    </div>
  );
}
