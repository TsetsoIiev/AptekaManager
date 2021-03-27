import React from 'react';

export default function PharmacyGrid(props) {
    const [pharmacies, setPharmacies] = useState(props.pharmacies);

    return (
        pharmacies == [] 
        ? (<div>
            
        </div>
        ) : (
            <div>
                <Grid container spacing={3}>
                    pharmacies.map((el) => {
                        <Grid item xs={12}>
                            <Paper className={classes.paper}>
                                <Pharmacy data={el} />
                            </Paper>
                        </Grid>
                        }));
                </Grid>
            </div>
        )
    )
}