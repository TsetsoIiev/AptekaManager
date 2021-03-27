import React from 'react';
import { NavMenu } from './NavMenu';

export function Layout({ children }) {
    return (
      <div>
        <NavMenu />
        {children}
      </div>
    );
}
