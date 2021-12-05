import React from 'react'
import { Card } from '../components/Card'

export const HomeView = () => {

    const data = [
        {
            iconClass: 'fas fa-users', 
            linkText: 'Clients', 
            linkPath: '/clients'
        },
        {
            iconClass: 'fas fa-map-marker-alt', 
            linkText: 'Addresses', 
            linkPath: '/addresses'
        },
    ]

    return (
        <div className="row mt-5">
            <div className="col-12">
                <h1 className="text-center">Orion Project</h1>
            </div>
            <div className="col">
                <div className="row row-cols-1 row-cols-md-2">
                    {
                        data.map( card => (
                            <Card 
                                key = { card.linkPath }
                                iconClass = { card.iconClass } 
                                linkText = { card.linkText } 
                                linkPath = { card.linkPath } />
                        ))
                    }
                </div>
            </div>
        </div>
    )
}
