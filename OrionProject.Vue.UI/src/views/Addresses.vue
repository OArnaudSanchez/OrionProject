<template>
     <div class="row mt-5">
        <div class="col">
            <h1 class="text-center">Addresses</h1>
        </div>
        <div class="col-12">
            <template v-if="loading">
                <h1 class="text-center">Loading....</h1>
            </template>
            <template v-else>
                <router-link :to="{ name: 'NewAddress' }" class="btn btn-primary">New Address</router-link>
                <div class="table-responsive">
                    <table class="table table-striped">
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
                            <tr v-for="( address, index) of addresses" :key="address.id">
                                <td>{{ address.id }}</td>
                                <td>{{ address.city }}</td>
                                <td>{{ address.streetName }}</td>
                                <td>{{ address.streetNumber }}</td>
                                <td>
                                    {{ getAddressClient[index] }}
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
import addressService from '@/services/addressService.js';
    export default {
        name: 'Addresses',
        data(){
            return{
                loading: true,
                addresses: [],
            }
        },
        async created(){
            this.fetchAddresses();
        },
        methods: {
            async fetchAddresses(){
                try{
                    this.loading = true;
                    const { data } = await addressService.getAll();
                    this.addresses = data;
                }catch(error){
                    console.log(error);
                }finally{
                    this.loading = false;
                }
            },
            // getFilteredAddress(address, index){
            //     return `${ index + 1 }. ${ address.city }, ${ address.streetName }, ${ address.streetNumber }, Postal Code: ${ address.postalCode }`;
            // }
        },
        computed: {
            getAddressClient(){
               return this.addresses.map( address => `${ address.client.name } ${ address.client.lastName }`);
            }
        }
    }
</script>

<style lang="scss" scoped>

</style>