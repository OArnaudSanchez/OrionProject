<template>
  <div class="row">
    <div class="col">
      <h1 class="text-center">New Address</h1>
    </div>
    <div class="col-12">
      <form class="row g-3">
        <div class="col-md-6">
          <label class="form-label">City</label>
          <input
            type="text"
            class="form-control"
            v-model="address.city"
            required
          />
        </div>
        <div class="col-md-6">
          <label class="form-label">Street Name</label>
          <input
            type="text"
            class="form-control"
            v-model="address.streetName"
            required
          />
        </div>
        <div class="col-md-4">
          <label class="form-label">Street Number</label>
          <input
            type="text"
            class="form-control"
            v-model="address.streetNumber"
            required
          />
        </div>
        <div class="col-md-4">
          <label class="form-label">Postal Code</label>
          <input
            type="text"
            class="form-control"
            v-model="address.postalCode"
            required
          />
        </div>
        <div class="col-md-4">
          <label class="form-label">Client</label>
          <select class="form-control" v-model="address.idClient">
              <option value="" selected>Select Client</option>
              <option :value="client.id" v-for="(client) of clients" :key="client.id">
                  {{ `${ client.name } ${ client.lastName }` }}
              </option>
          </select>
        </div>
        <div class="col-12">
          <button class="btn btn-primary" @click.prevent="AddAddress">
            Add Address
          </button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import clientService from '@/services/clientService.js';
import addressService from '@/services/addressService.js';
export default {
  name: "NewAddress",
  data(){
      return{
          address: {
              city: '',
              streetName: '',
              streetNumber: '',
              postalCode: '',
              idClient: ''
          },
          clients: []
      }
  },
  async created(){
      const { data } = await clientService.getAll();
      this.clients = data;
  },
  methods: {
      async AddAddress(){
          try{
            const { status } = await addressService.createAddress(this.address);
            if(status === 201){
                alert('The Address was created');
                this.$router.push({ name: 'Addresses' });
            }
        }catch(error){
            console.log(error);
        }
      }
  }
};
</script>

<style lang="scss" scoped>
</style>