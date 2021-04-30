import clsx from 'clsx';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import MenuIcon from '@material-ui/icons/Menu';
import IconButton from '@material-ui/core/IconButton';
import { useDrawerContext } from '../context/DrawerContext';
import { createStyles, Theme } from '@material-ui/core/styles';
import { makeStyles } from '@material-ui/core/styles';

const drawerWidth = 240;

export default function Bar() {

    const { drawerOpen, handleDrawerOpen } = useDrawerContext();
    const classes = useStyles();
    
    return (
        <AppBar
        position="fixed"
        className={clsx(classes.appBar, {
            [classes.appBarShift]: drawerOpen,
        })}
        >
            <Toolbar>
                <IconButton
                color="inherit"
                aria-label="open drawer"
                onClick={handleDrawerOpen}
                edge="start"
                className={clsx(classes.menuButton, drawerOpen && classes.hide)}
                >
                <MenuIcon />
                </IconButton>
                <Typography variant="h6" noWrap>
                SOCCA 
                </Typography>
            </Toolbar>
        </AppBar>
    );
}

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    appBar: {
      transition: theme.transitions.create(['margin', 'width'], {
        easing: theme.transitions.easing.sharp,
        duration: theme.transitions.duration.leavingScreen,
      }),
    },
    appBarShift: {
      width: `calc(100% - ${drawerWidth}px)`,
      marginLeft: drawerWidth,
      transition: theme.transitions.create(['margin', 'width'], {
        easing: theme.transitions.easing.easeOut,
        duration: theme.transitions.duration.enteringScreen,
      }),
    },
    menuButton: {
      marginRight: theme.spacing(2),
    },
    hide: {
      display: 'none',
    },
  }),
);
