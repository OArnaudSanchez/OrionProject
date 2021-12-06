import apiService from './apiService';

const ENDPOINT = 'clients';
class ClientService{

    async getAll(){
        return await apiService.get(`${ ENDPOINT }`);
    }

    async createClient(client){
        const headers = { 'Content-type': 'application/json' };
        return await apiService.post(`${ ENDPOINT }`, client, { headers: headers } );
    }

}

export default new ClientService();