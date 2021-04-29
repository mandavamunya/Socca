import { createStyles, makeStyles, Theme, useTheme } from "@material-ui/core/styles";
import React from "react";
import clsx from 'clsx';
import Typography from "@material-ui/core/Typography";

const drawerWidth = 240;

export default function Stadiums() {

    const classes = useStyles();
    const theme = useTheme();
    const [open, setOpen] = React.useState(true);
        
    return (
        <main
        className={clsx(classes.content, {
            [classes.contentShift]: open,
        })}
        >
            <div className={classes.drawerHeader} />

            <Typography variant="h4">
                Stadiums
            </Typography>       

            <Typography paragraph>
            
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