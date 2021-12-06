<template>
    <div class="col my-3">
        <div class="card text-center rounded-3">
            <span class="mt-4">
                <i :class="cardData.iconClass"></i>
            </span>
            <div class="card-body">
                <h5 class="card-title mb-3">{{ cardData.linkText }}</h5>
                <router-link class="link" :to="{ name: cardData.routeName }">View More...</router-link>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'Card',
        props: {
            cardData: {
                type: Object
            }
        }
    }
</script>

<style lang="css" scoped>
.card {
  border-radius: 2em;
  box-shadow: 0 5px 10px rgba(0, 0, 0, 0.2);
  background-color: #eff4ff;
}
.card:hover {
  box-shadow: 1px 8px 20px darkgrey;
}

.card-title {
  font-size: 1.5em;
  font-family: "Roboto", "Helvetica", "Arial", sans-serif;
  font-weight: 400;
  line-height: 1.04;
  letter-spacing: 0em;
}

.link {
    border-radius: 0.4em;
    padding: 0.5em 1.5em;
    background-color: transparent;
    border: 1px solid rgba(63, 81, 181, 0.5);
    color: #1b2b84;
    font-size: 0.875rem;
    font-weight: 500;
    line-height: 1.75;
    letter-spacing: 0.02857em;
    text-decoration: none;
  }
  
  .link:hover {
    background-color: #212529;
    color: #fff;
  }

  .fas{
    font-size: 40px;
  }
</style>