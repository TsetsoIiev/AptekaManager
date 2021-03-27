import React, { useState } from 'react';
import { ReactComponent as LogoSvg } from './logo1.svg';
import { makeStyles } from '@material-ui/core/styles'
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

const useStyles = makeStyles((theme) => ({
  image: {
    width: 192,
    height: 48
  },
  navbar: {
    backgroundColor: 'rgba(48,55,76,1) !important'
  },
  txt: {
    color: 'white !important',
    fontWeight: 'bold'
  }
}));

export function NavMenu() {
  const classes = useStyles();

  const [isCollapsed, setIsCollapsed] = useState(true);

  const toggleNavbar = function () {
    setIsCollapsed(!isCollapsed);
  }

  return (
    <header className={classes.navbar}>
      <Navbar className='navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3'light>
        <LogoSvg className={classes.image} />
        <Container>
          <NavbarToggler onClick={toggleNavbar} className="mr-2" />
          <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={isCollapsed} navbar>
            <ul className="navbar-nav flex-grow">
              <NavItem>
                <NavLink tag={Link} to="/" className={classes.txt}>Home</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} to="/contacts" className={classes.txt}>Contacts</NavLink>
              </NavItem>
            </ul>
          </Collapse>
        </Container>
      </Navbar>
    </header>
  );
}
