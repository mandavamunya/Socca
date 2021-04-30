import React from 'react';
import {  BrowserRouter as Router, Switch, Route } from 'react-router-dom';

import CssBaseline from '@material-ui/core/CssBaseline';
import { createStyles, makeStyles, Theme } from '@material-ui/core/styles';

import Home from './pages/Home';
import Players from './pages/Players';
import Stadiums from './pages/Stadiums';
import Teams from './pages/Teams';

import DrawerNav from './components/DrawerNav';


import './App.css';
import logo from './assets/images/logo.svg';
import { DrawerContextProvider } from './context/DrawerContext';


function App() {
  const classes = useStyles();

  return (
    <Router>
      <div className={classes.root}>
        <DrawerContextProvider>
          <CssBaseline />
          <DrawerNav />

          {/* A <Switch> looks through its children <Route>s and
              renders the first one that matches the current URL. */}
          <Switch>
            <Route path="/players">
              <Players />
            </Route>
            <Route path="/stadiums">
              <Stadiums />
            </Route>
            <Route path="/teams">
              <Teams />
            </Route>          
            <Route path="/">
              <Home />
            </Route>
          </Switch>
        </DrawerContextProvider>
      </div>
    </Router>
  );
}

export default App;


const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      display: 'flex',
    }
  }),
);
