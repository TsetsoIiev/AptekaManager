import React, { useState } from 'react';
import PharmacyGrid from './PharmacyGrid';
import SearchBox from './SearchBox';

const axios = require('axios');

export function Home() {

  const [searchData, setSearchData] = useState('');
  const [pharmacyData, setPharmacyData] = useState([]);

  const handleSearchClick = () => {
    axios.get(`https://localhost:44306/api/Pharmacy/GetMedicines/${searchData}`, {
      headers: {
        'Access-Control-Allow-Origin': '*'
      }
    }).then((res) => {
        console.log(res);
        setPharmacyData(res.data);
      })
  }

  return (
    <div>
      <SearchBox searchData={searchData} setSearchData={setSearchData} handleSearchClick={handleSearchClick} />
      <PharmacyGrid data={pharmacyData} />
    </div>
  );
}
