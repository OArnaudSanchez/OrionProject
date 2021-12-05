import React from 'react';
import { useFetch } from '../hooks/useFetch';

export const ClientsView = () => {

    const ENDPOINT = 'clients';
    const result = useFetch(ENDPOINT);
    const { data, loading } = !!result && result;
    console.log(data, loading);

    return (
        <div className="row mt-5">
            <div className="col">
                <h1 className='text-center'>Clients</h1>
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
                                    <th>Name</th>
                                    <th>Last Name</th>
                                    <th>Birth Date</th>
                                    <th>Addresses</th>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    data?.map( client => (
                                        <tr key = { client.id }>
                                            <td>{ client.id }</td>
                                            <td>{ client.name }</td>
                                            <td>{ client.lastName }</td>
                                            <td>{ client.birthDate }</td>
                                            {
                                                client?.addresses?.map( (address, index) => (
                                                    <td className='d-block' key = { address.id }>
                                                        { index + 1 }. 
                                                        { `${ address.city }, ${ address.streetName }, ${ address.streetNumber }, Postal Code: ${ address.postalCode }` }
                                                    </td>
                                                ))
                                            }
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
