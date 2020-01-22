<template>
        <div id="home" class="container">
            
            <h1>Mes restaurants</h1>
<div class="card text-white bg-success mb-3" style="max-width: 30%;display:inline-block; margin:1%;" v-for="item in restaurantList">
     <router-link :to="`/updateRestaurant/${item.restaurantId}`">
    <span class="badge badge-pill badge-primary" style="float: none;">Modifier</span>
    </router-link>
    <router-link :to="`/newreduction/${item.restaurantId}`">
    <span class="badge badge-pill badge-primary" style="float:none;">Reductions</span>
    </router-link>
   <button class="btn btn-primary btn-lg btn-block" type="submit">
  <div class="card-header">{{ item.name }} </div>
  <div class="card-body">
    <!--<h4 class="card-title">{{ item.photoLink }}</h4> -->
    <!-- <img src= {{ item.photoLink }} > -->

    <p class="card-text">{{ item.adresse }}</p>
    <p class="card-text"><img style="max-width:100%;" :src="item.photoLink"></p>
    <p class="card-text">Tel: 0{{ item.telephone }}</p>
  </div>
  </button>
</div>

<div class="card text-white bg-success mb-3" style="max-width: 30%;display:inline-block; margin:1%;">
  <div class="card-header">Ajouter un restaurant</div>
  <div class="card-body">
      <router-link :to="`/addRestaurant`"><button class="btn btn-secondary my-2 my-sm-0" style="margin-left: 29%;" type="submit"><i class="fas fa-plus-circle"></i></button></router-link>
  </div>
</div>
           
        </div>
</template>

<script>
 import { getRestaurantListAsync } from '../api/restaurantApi'
 import { requireAuth } from '../helpers/requireAuth'

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

            hasRestaurant(){
                if (restaurantList !== null){
                    return true;
                }else{
                    return false;
                }
            },
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