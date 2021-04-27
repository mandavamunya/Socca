import React from "react";
import {
    Link
  } from "react-router-dom";

export default function NavBar() {
    return (
        <nav>
          <ul>
            <li>
              <Link to="/">Home</Link>
            </li>
            <li>
              <Link to="/players">Players</Link>
            </li>
            <li>
              <Link to="/stadiums">Stadiums</Link>
            </li>
            <li>
              <Link to="/teams">Teams</Link>
            </li>            
          </ul>
        </nav>
    );
}