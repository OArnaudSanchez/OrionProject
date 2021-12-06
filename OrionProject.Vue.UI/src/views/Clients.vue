<template>
    <div class="row mt-5">
        <div class="col">
            <h1 class="text-center">Clients</h1>
        </div>
        <div class="col-12">
            <template v-if="loading">
                <h1 class="text-center">Loading....</h1>
            </template>
            <template v-else>
                <router-link :to="{ name: 'NewClient' }" class="btn btn-primary">New Client</router-link>
                <div class="table-responsive">
                    <table class="table table-striped">
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
                            <tr v-for="( client, index ) of clients" :key="index">
                                <td>{{ client.id }}</td>
                                <td>{{ client.name }}</td>
                                <td>{{ client.lastName }}</td>
                                <td>{{ client.birthDate }}</td>
                                <td class="d-block" v-for="( address, index ) of client.addresses" :key="index">
                                    {{ getFilteredAddress(address) }}
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </template>
        </div>
    </div>
</template>

<script>
import clientService from '@/services/clientService.js';
    export default {
        name: 'Clients',
        data(){
            return{
                loading: true,
                clients: [],
            }
        },
        async created(){
            this.fetchClients();
        },
        methods: {
            async fetchClients(){
                try{
                    this.loading = true;
                    const { data } = await clientService.getAll();
                    this.clients = data;
                }catch(error){
                    console.log(error);
                }finally{
                    this.loading = false;
                }
            },
            getFilteredAddress(address){
                return `${ address.city }, ${ address.streetName }, ${ address.streetNumber }, Postal Code: ${ address.postalCode }`;
            }
        },
    }
</script>
