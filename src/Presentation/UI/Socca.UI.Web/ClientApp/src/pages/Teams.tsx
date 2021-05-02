import clsx from 'clsx';
import Typography from "@material-ui/core/Typography";
import { createStyles, makeStyles, Theme } from "@material-ui/core/styles";
import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
import TeamCard from '../components/TeamCard';
import { useDrawerContext } from "../context/DrawerContext";

const drawerWidth = 240;

export default function Teams() {
  const { drawerOpen } = useDrawerContext();
  const classes = useStyles();
      
  const teams =  [
    { 
      description: "Chelsea Football Club is an English professional football club. Founded in 1905, the club competes in the Premier League, the top division of English football.", 
      title: "Chelsea Football Club", 
      image: "https://upload.wikimedia.org/wikipedia/en/c/cc/Chelsea_FC.svg" 
    },
    { 
      description: "Manchester United Football Club is a professional football club. Founded in 1878, the club competes in the Premier League, the top flight of English football.", 
      title: "Manchester United Football Club", 
      image: "https://upload.wikimedia.org/wikipedia/en/7/7a/Manchester_United_FC_crest.svg" 
    },
    { 
      description: "Manchester City Football Club is an English football club. Founded in 1880, the club competes in the Premier League, the top flight of English football.", 
      title: "Manchester City Football Club", 
      image: "https://upload.wikimedia.org/wikipedia/en/e/eb/Manchester_City_FC_badge.svg" },
    { 
      description: "Liverpool Football Club is a professional football club. Founded in 1892, the club competes in the Premier League, the top tier of English football.", 
      title: "Liverpool Football Club", 
      image: "https://upload.wikimedia.org/wikipedia/en/0/0c/Liverpool_FC.svg" 
    },
  ];

  return (
    <main
    className={clsx(classes.content, {
        [classes.contentShift]: drawerOpen,
    })}
    >
      <div className={classes.drawerHeader} />

      <Typography variant="h4">
          Teams
      </Typography>

      <div className={classes.gridRoot}>
      <Grid container spacing={3}>
      {
        teams.map((team, index) => (
          <Grid item xs={12} sm={6} md={3} key={index}>
            <Paper className={classes.paper}>
              <TeamCard title={team.title} description = {team.description} image = {team.image}/>
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