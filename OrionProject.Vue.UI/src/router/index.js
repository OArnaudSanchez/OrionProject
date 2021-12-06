import Vue from 'vue';
import VueRouter from 'vue-router';

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: () => import('@/views/Home.vue')
  },
  {
    path: '/clients',
    name: 'Clients',
    component: () => import('@/views/Clients.vue')
  },
  {
    path: '/newClient',
    name: 'NewClient',
    component: () => import('@/views/NewClient.vue')
  },
  {
    path: '/addresses',
    name: 'Addresses',
    component: () => import('@/views/Addresses.vue')
  },
  {
    path: '/newAddress',
    name: 'NewAddress',
    component: () => import('@/views/NewAddress.vue')
  }
]

const router = new VueRouter({
  routes
})

export default router
