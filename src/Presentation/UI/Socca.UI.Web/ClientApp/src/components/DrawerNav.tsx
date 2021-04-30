import React from 'react';
import { Link } from 'react-router-dom';
import { makeStyles, useTheme, Theme, createStyles } from '@material-ui/core/styles';
import Drawer from '@material-ui/core/Drawer';
import List from '@material-ui/core/List';
import Divider from '@material-ui/core/Divider';
import IconButton from '@material-ui/core/IconButton';
import ChevronLeftIcon from '@material-ui/icons/ChevronLeft';
import ChevronRightIcon from '@material-ui/icons/ChevronRight';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';

import HomeIcon from '@material-ui/icons/Home';
import GroupIcon from '@material-ui/icons/Group';
import PersonPinIcon from '@material-ui/icons/PersonPin';
import SportsSoccerIcon from '@material-ui/icons/SportsSoccer';

import PersonAddIcon from '@material-ui/icons/PersonAdd';
import LockOpenIcon from '@material-ui/icons/LockOpen';
import LockIcon from '@material-ui/icons/Lock';

import { useDrawerContext } from "../context/DrawerContext";
import Bar from './Bar';

const drawerWidth = 240;

export default function DrawerNav() {
  
  const { drawerOpen, handleDrawerClose } = useDrawerContext();


  const classes = useStyles();
  const theme = useTheme();

  const mainMenuIcons = [<HomeIcon/>, <GroupIcon/>, <PersonPinIcon/>, <SportsSoccerIcon/>];
  const securityMenuIcons = [<PersonAddIcon/>, <LockOpenIcon/>, <LockIcon/>];  

  return (
    <div>
      <Bar />
      <Drawer
        className={classes.drawer}
        variant="persistent"
        anchor="left"
        open={drawerOpen}
        classes={{
          paper: classes.drawerPaper,
        }}
      >
        <div className={classes.drawerHeader}>
          <IconButton onClick={handleDrawerClose}>
            {theme.direction === 'ltr' ? <ChevronLeftIcon /> : <ChevronRightIcon />}
          </IconButton>
        </div>
        <Divider />
        <List>
          {['Home', 'Players', 'Stadiums', 'Teams'].map((text, index) => (            
            <Link to={`${'/'.concat(text.toLowerCase())}`} key={text}>
                <ListItem button>
                    <ListItemIcon> {mainMenuIcons[index]} </ListItemIcon>
                    <ListItemText primary={text} />
                </ListItem>
            </Link>
          ))}
        </List>
        <Divider />
        <List>
          {['Register', 'Login', 'Sign Out'].map((text, index) => (
            <ListItem button key={text}>
              <ListItemIcon> {securityMenuIcons[index]} </ListItemIcon>
              <ListItemText primary={text} />
            </ListItem>
          ))}
        </List>
      </Drawer>

    </div>
  );
}

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    drawer: {
      width: drawerWidth,
      flexShrink: 0,
    },
    drawerPaper: {
      width: drawerWidth,
    },
    drawerHeader: {
      display: 'flex',
      alignItems: 'center',
      padding: theme.spacing(0, 1),
      // necessary for content to be below app bar
      ...theme.mixins.toolbar,
      justifyContent: 'flex-end',
    },
  }),
);
