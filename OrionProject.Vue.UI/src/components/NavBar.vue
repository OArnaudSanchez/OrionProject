<template>
    <nav class="navbar navbar-expand-sm navbar-dark bg-dark ps-5">
        <router-link class="navbar-brand" :to="{ name: 'Home' }">
            OrionProject
        </router-link>
  
        <div class="navbar-collapse">
          <div class="navbar-nav">
            <router-link class="nav-item nav-link" :to="{ name: 'Clients' }">
                Clients
            </router-link>
            <router-link class="nav-item nav-link" :to="{ name: 'Addresses' }">
                Addresses
            </router-link>
          </div>
        </div>
      </nav>
</template>

<script>
    export default {
        name: 'NavBar'
    }
</script>