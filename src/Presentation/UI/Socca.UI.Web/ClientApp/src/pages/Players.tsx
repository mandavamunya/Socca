import { useEffect } from 'react';

import clsx from 'clsx';
import Typography from "@material-ui/core/Typography";
import { createStyles, makeStyles, Theme } from "@material-ui/core/styles";
import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
import PlayerCard from '../components/PlayerCard';
import { useDrawerContext } from "../context/DrawerContext";

import { useDispatch, useSelector } from 'react-redux';

import { onPageLoadGetPlayers, ApplicationState } from '../redux';

const drawerWidth = 240;

export default function Players() {
  const { players, playersError } = useSelector((state: ApplicationState) => state.playersReducer);  

  const dispatch = useDispatch();

  const { drawerOpen } = useDrawerContext();
  const classes = useStyles();

  useEffect(() => {
      dispatch(onPageLoadGetPlayers()); 
  });

  return (
    <main
    className={clsx(classes.content, {
      [classes.contentShift]: drawerOpen,
    })}
    >
      <div className={classes.drawerHeader} />

      <Typography variant="h4">
          Players
      </Typography>

      <div className={classes.gridRoot}>
        <Grid container spacing={3}>
        {
          players.map((player, index) => (
            <Grid item xs={12} sm={6} md={3} key={index}>
              <Paper className={classes.paper}>
                <PlayerCard title={`${player.firstName} ${player.lastName}`} description = {player.position} image = {player.image}/>
              </Paper>
            </Grid>
          ))
        }   
        </Grid> 
      </div>
           
    </main>        
  );
}


const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    gridRoot: {
      flexGrow: 1,
    },  
    paper: {
      padding: theme.spacing(2),
      textAlign: 'center',
      color: theme.palette.text.secondary,
    },  
    content: {
        flexGrow: 1,
        padding: theme.spacing(3),
        transition: theme.transitions.create('margin', {
          easing: theme.transitions.easing.sharp,
          duration: theme.transitions.duration.leavingScreen,
        }),
        marginLeft: -drawerWidth,
      },
      drawerHeader: {
        display: 'flex',
        alignItems: 'center',
        padding: theme.spacing(0, 1),
        // necessary for content to be below app bar
        ...theme.mixins.toolbar,
        justifyContent: 'flex-end',
      },
      contentShift: {
        transition: theme.transitions.create('margin', {
          easing: theme.transitions.easing.easeOut,
          duration: theme.transitions.duration.enteringScreen,
        }),
        marginLeft: 0,
      },           
  }),
);
