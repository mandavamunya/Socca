import React from "react";
import clsx from 'clsx';
import { createStyles, makeStyles, Theme, useTheme } from "@material-ui/core/styles";
import Typography from "@material-ui/core/Typography";
import { useDrawerContext } from "../context/DrawerContext";

const drawerWidth = 240;

export default function Players() {
  const { drawerOpen } = useDrawerContext();
  const classes = useStyles();
      
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
           
    </main>        
  );
}

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
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
