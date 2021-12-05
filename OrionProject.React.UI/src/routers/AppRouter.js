import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import { NavBar } from '../components/NavBar';
import { AddressesView } from '../views/AddressesView';
import { ClientsView } from '../views/ClientsView';
import { HomeView } from '../views/HomeView';

export const AppRouter = () => {
    return (
        <BrowserRouter>
            <NavBar />
            <div className="container">
                <Routes>
                    <Route path = '/' element = { <HomeView /> } />
                    <Route path = '/clients' element = { <ClientsView /> } />
                    <Route path = '/addresses' element = { <AddressesView /> } />
                </Routes>
            </div>
        </BrowserRouter>
    )
}
