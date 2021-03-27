import React from 'react';
import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
import Pharmacy from './Pharmacy'

export default function PharmacyGrid({ data }) {

    return (
        data == [] 
        ? (<div>
            
        </div>
        ) : (
            <div>
                <Grid container spacing={3}>
                    data.map((el) => 
                        <Grid item xs={12}>
                            <Paper>
                                <Pharmacy />
                            </Paper>
                        </Grid>
                    );
                </Grid>
            </div>
        )
    )
}