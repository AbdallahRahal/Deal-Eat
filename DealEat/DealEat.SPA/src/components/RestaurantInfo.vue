<template>
        <div id="listRestaurant" class="container">
            
                        <router-link :to="`/`">
                            <button class="btn btn-secondary my-2 my-sm-0" type="submit"><i class="fas fa-arrow-circle-left"></i></button>
                        </router-link>
            <h1>Modifier un restaurant</h1>
<div class="card text-white bg-success mb-3" style="max-width: 30%;display:inline-block; margin:1%;" v-for="item in restaurantList"><button class="btn btn-primary btn-lg btn-block" type="submit">
  
  <div class="card-header"><input type="text" class="form-control" :value="item.name"></div>
  <div class="card-body">
    <!--<h4 class="card-title">{{ item.photoLink }}</h4> -->
    <!-- <img src= {{ item.photoLink }} > -->

    <p class="card-text">{{ item.adresse }}</p>
    <p class="card-text">Tel: 0{{ item.telephone }}</p>
  </div>
  </button>
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
