import React from 'react';
import { Link } from 'react-router-dom';

export const Card = ({ iconClass, linkText, linkPath }) => {
    return (
        <div className='col my-3'>
            <div className="card text-center rounded-3">
                <span className='mt-4'>
                <i className={ iconClass }></i>
                </span>
                <div className="card-body">
                    <h5 className="card-title mb-3">{ linkText }</h5>
                    <Link className='link' to = { linkPath }>View More...</Link>
                </div>
            </div>
        </div>
    )
}
