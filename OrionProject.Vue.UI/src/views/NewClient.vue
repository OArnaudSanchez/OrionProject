<template>
  <div class="row mt-5">
    <div class="col">
      <h1 class="text-center">New Client</h1>
    </div>
    <div class="col-12">
      <form class="row g-3">
        <div class="col-md-6">
          <label class="form-label">Name</label>
          <input type="text" class="form-control" v-model="client.name" required />
        </div>
        <div class="col-md-6">
          <label class="form-label">Last Name</label>
          <input type="text" class="form-control" v-model="client.lastName" required />
        </div>
        <div class="col-md-6">
          <label class="form-label">Birth Date</label>
          <input type="date" class="form-control" v-model="client.birthDate" required />
        </div>
        <div class="col-md-6">
          <label class="form-label">Email</label>
          <input type="email" class="form-control" v-model="client.email" required />
        </div>
        <div class="col-12">
          <button class="btn btn-primary" @click.prevent="AddClient">Add Client</button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import clientService from '@/services/clientService.js';
export default {
  name: "NewClient",
  data(){
      return{
          client: {
              name: '',
              lastName: '',
              birthDate: '',
              email: ''
          }
      }
  },
  methods:{
      async AddClient(){
        try{
            const { status } = await clientService.createClient(this.client);
            if(status === 201){
                alert('The client was created');
                this.$router.push({ name: 'Clients' });
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