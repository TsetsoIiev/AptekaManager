import React from 'react';

export default function Pharmacy({ data }) {
    return (
        <div>
            <p>Име: {data.pharmacyName}</p>
            <p>Адрес: {data.pharmacyAddress}</p>
            <p>Цена: {data.price}</p>
            <p>Наличност: {data.isInStock ? 'налично е' : 'не е налично'}</p>
        </div>
    )
}