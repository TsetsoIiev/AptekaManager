import React from 'react';
import { makeStyles } from '@material-ui/styles'
import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
import Pharmacy from './Pharmacy'

const useStyles = makeStyles((theme) => ({
    grid: {
        zIndex: 10,
        position: 'absolute',
        justifyContent: 'center',
        bottom: 0
    }
}));

export default function PharmacyGrid({ data }) {
    const classes = useStyles();

    return (
        <div>
            <Grid className={classes.grid} container spacing={3}>
                {data.map((el) => {
                    return (
                        <Paper>
                            <Pharmacy data={el} key={el.pharmacyName} />
                        </Paper>);
                })}
            </Grid>
        </div>
    )
}