import apiService from './apiService';

const ENDPOINT = 'addresses';
class AddressService{

    async getAll(){
        return await apiService.get(`${ ENDPOINT }`);
    }

    async createAddress(address){
        const headers = { 'Content-type': 'application/json' };
        return await apiService.post(`${ ENDPOINT }`, address, { headers: headers } );
    }
}

export default new AddressService();