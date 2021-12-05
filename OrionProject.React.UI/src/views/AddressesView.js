import React from 'react';
import { useFetch } from '../hooks/useFetch';

export const AddressesView = () => {

    const ENDPOINT = 'addresses';
    const result = useFetch(ENDPOINT);
    const { data, loading } = !!result && result;
    
    return (
        <div className="row mt-5">
            <div className="col">
                <h1 className='text-center'>Addresses</h1>
            </div>
            <div className="col-12">
                {
                    loading 
                    ? <h1 className='text-center'>Loading.....</h1>
                    :
                        <div className="table-responsive">
                        <table className="table table-striped">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>City</th>
                                    <th>Street Name</th>
                                    <th>Street Number</th>
                                    <th>Client</th>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    data?.map( address => (
                                        <tr key = { address.id }>
                                            <td>{ address.id }</td>
                                            <td>{ address.city }</td>
                                            <td>{ address.streetName }</td>
                                            <td>{ address.streetNumber }</td>
                                            <td>
                                                { `${ address.client.name } ${ address.client.lastName }` } 
                                            </td>
                                        </tr>
                                    ))
                                }
                            </tbody>
                        </table>
                    </div>
                }
                
            </div>
        </div>
    )
}
