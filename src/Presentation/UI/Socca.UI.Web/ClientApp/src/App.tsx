import './App.css';
import {  BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import Home from './pages/Home';
import Players from './pages/Players';
import Stadiums from './pages/Stadiums';
import Teams from './pages/Teams';

import NavBar from './components/NavBar';

function App() {
  return (
    <Router>
      <div>
        <NavBar />

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
      </div>
    </Router>
  );
}

export default App;
