<template>
  <div class="row mt-5">
    <div class="col-12">
      <h1 class="text-center">Orion Project</h1>
    </div>
    <div class="col">
      <div class="row row-cols-1 row-cols-md-2">
          <Card  v-for="(cardData, index) of appData" :key="index" :cardData="cardData" />
      </div>
    </div>
  </div>
</template>

<script>
import Card from '@/components/Card.vue';
export default {
  name: 'Home',
  components: {
    Card,
  },
    data(){
    return{
      appData: [
        {
            iconClass: 'fas fa-users', 
            linkText: 'Clients', 
            routeName: 'Clients'
        },
        {
            iconClass: 'fas fa-map-marker-alt', 
            linkText: 'Addresses', 
            routeName: 'Addresses'
        },
      ]
    }
  }
}
</script>
