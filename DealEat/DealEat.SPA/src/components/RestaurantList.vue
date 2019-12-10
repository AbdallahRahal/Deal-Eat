<template>
        <div id="listRestaurant" class="container">
            
                        <router-link :to="`/`">
                            <button class="btn btn-secondary my-2 my-sm-0" type="submit"><i class="fas fa-arrow-circle-left"></i></button>
                        </router-link>
            <h1>Liste des restaurants</h1>
<div class="card text-white bg-success mb-3" style="max-width: 30%;display:inline-block; margin:1%;" v-for="item in restaurantList">
  <div class="card-header">{{ item.name }}</div>
  <div class="card-body">
    <h4 class="card-title">{{ item.photoLink }}</h4>
    <p class="card-text">{{ item.adresse }}</p>
    <p class="card-text">{{ item.telephone }}</p>
  </div>
</div>
           
        </div>
</template>

<script>
 import { getRestaurantListAsync } from '../api/restaurantApi'

    export default {
        data() {
            return {
                restaurantList: [],
            }
        },

        async mounted() {
            await this.refreshList();
            
        },

        methods: {
            async refreshList() {
                try {
                    this.restaurantList = await getRestaurantListAsync();
                    
                }
                catch(e) {
                    console.error(e);
                }
            },

        }
    }
</script>
