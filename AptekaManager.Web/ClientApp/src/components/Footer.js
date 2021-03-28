import React from 'react';
import { makeStyles } from '@material-ui/styles';
import { Container, Navbar, NavItem } from 'reactstrap';
import logo1 from './logo1.png';
import logo2 from './logo2.png';
import logo3 from './logo3.png';

const useStyles = makeStyles((theme) => ({
    footer: {
        backgroundColor: 'rgba(48,55,76,1) !important',
        bottom: 0,
        position: 'absolute',
        width: '100%',
        height: 100
    },
    image: {
        height: 100,
        width: 50
    }
}));

export function Footer() {
    const classes = useStyles();

    return (
        <footer className={classes.footer}>
            <Navbar className='navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3' light>
                <Container>
                    <NavItem>
                        <img src={logo1} />
                    </NavItem>
                    <NavItem>
                        <img src={logo2} />
                    </NavItem>
                    <NavItem>
                        <img src={logo3} />
                    </NavItem>
                </Container>
            </Navbar>
        </footer>
    )
}