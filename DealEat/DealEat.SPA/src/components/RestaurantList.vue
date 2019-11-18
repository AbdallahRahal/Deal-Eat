<template>
        <div id="listRestaurant" class="container">
            <h1>Liste des restaurants</h1>
            <table class="table table-hover">
  <thead>
    <tr>
      <th scope="col">User Id</th>
      <th scope="col">Restaurant Id</th>
      <th scope="col">Name</th>
      <th scope="col">Adresse</th>
      <th scope="col">Photolink</th>
      <th scope="col">Telephone</th>
    </tr>
  </thead>
  <tbody>

    <tr class="table-dark" v-for="i of restaurantList">
      <th scope="row">{{ i.userId }}</th>
      <td>{{ i.restaurantId }}</td>
      <td>{{ i.name }}</td>
      <td>{{ i.adresse }}</td>
      <td>{{ i.photoLink }}</td>
      <td>{{ i.telephone }}</td>

    </tr>
  </tbody>
</table> 
           
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
