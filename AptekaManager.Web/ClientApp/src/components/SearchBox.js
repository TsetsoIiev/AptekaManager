import React, { useState } from 'react';
import { fade, withStyles, makeStyles, createMuiTheme } from '@material-ui/core/styles';
import { green } from '@material-ui/core/colors';
import InputBase from '@material-ui/core/InputBase';
import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
import SearchIcon from '@material-ui/icons/Search';
import IconButton from '@material-ui/core/IconButton';

const BootstrapInput = withStyles((theme) => ({
    root: {
        'label + &': {
            marginTop: theme.spacing(3),
        },
    },
    input: {
        borderRadius: 4,
        position: 'relative',
        backgroundColor: theme.palette.common.white,
        border: '1px solid #ced4da',
        fontSize: 16,
        width: '300px',
        padding: '10px 12px',
        transition: theme.transitions.create(['border-color', 'box-shadow']),
        fontFamily: [
            '-apple-system',
            'BlinkMacSystemFont',
            '"Segoe UI"',
            'Roboto',
            '"Helvetica Neue"',
            'Arial',
            'sans-serif',
            '"Apple Color Emoji"',
            '"Segoe UI Emoji"',
            '"Segoe UI Symbol"',
        ].join(','),
        '&:focus': {
            boxShadow: `${fade(theme.palette.primary.main, 0.25)} 0 0 0 0.2rem`,
            borderColor: theme.palette.primary.main,
        },
    },
}))(InputBase);

const useStyles = makeStyles((theme) => ({
    root: {
        display: 'flex',
        flexWrap: 'wrap',
        flexGrow: 1
    },
    margin: {
        margin: theme.spacing(1),
    },
    paper: {
        padding: theme.spacing(2),
        textAlign: 'center',
        color: theme.palette.text.secondary,
    },
    image: {
        outline: '300px solid rgba(48, 55, 76, 0.6) !important',
        outlineOffset: -300,
        position: 'absolute',
        width: '100%',
        height: '80%'
    },
    searchBox: {
        position: 'absolute',
        top: '40%',
        left: '38%'
    },
    txt: {
        position: 'absolute',
        top: '50%',
        left: '35%',
        fontSize: 40,
        fontWeight: 'bold',
        color: 'white',
        textShadow: '-1px 0 black, 0 1px black, 1px 0 black, 0 -1px black'
    },
    iconButton: {
      padding: 10,
      backgroundColor: 'rgba(48,55,76,1) !important',
      borderRadius: 0
    },
}));

const theme = createMuiTheme({
    palette: {
        primary: green,
    },
});

export default function SearchBox() {
    const classes = useStyles();

    const [search, setSearch] = useState('');

    const handleSearchChange = (e) => {
        setSearch(e.target.value);
    }

    return (
        <div>
            <Grid container>
                <img src={require('./pharmacy-1.jpg')} className={classes.image} />
                <Paper className={classes.searchBox} >
                    <BootstrapInput defaultValue={search} id="searchBoxId" onChange={handleSearchChange} />
                    <IconButton type="submit" className={classes.iconButton} aria-label="search">
                        <SearchIcon />
                    </IconButton>
                </Paper>
                <div className={classes.txt}>
                    Намери лекарството си
                </div>
            </Grid>
        </div>
    )
}