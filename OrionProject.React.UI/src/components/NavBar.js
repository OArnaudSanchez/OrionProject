import React from 'react';
import { Link, NavLink } from 'react-router-dom';

export const NavBar = () => {
    return (
        <nav className="navbar navbar-expand-sm navbar-dark bg-dark ps-5">
        <Link className="navbar-brand" to="/">
          OrionProject
        </Link>
  
        <div className="navbar-collapse">
          <div className="navbar-nav">
            <NavLink className="nav-item nav-link" to='/clients'>
                Clients
            </NavLink>
            <NavLink className="nav-item nav-link" to='/addresses'>
                Addresses
            </NavLink>
          </div>
        </div>
      </nav>
    )
}
