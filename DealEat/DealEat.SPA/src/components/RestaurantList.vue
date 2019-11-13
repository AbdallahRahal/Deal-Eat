<template>
        <div id="listRestaurant" class="container">
            <h1>Liste des restaurant</h1>
            <table class="table table-hover">
  <thead>
    <tr>
      <th scope="col">User Id</th>
      <th scope="col">User Pseudo</th>
      <th scope="col">Restaurant Id</th>
      <th scope="col">Name</th>
      <th scope="col">Adresse</th>
      <th scope="col">Photolink</th>
      <th scope="col">Telephone</th>
    </tr>
  </thead>
  <tbody>
      <tr v-if="teacherList.length == 0">
                    <td colspan="4" class="text-center">Il n'y a actuellement aucun professeur.</td>
                </tr>

    <tr class="table-dark" v-for="i of restaurantList">
      <th scope="row">{{ i.UserId }}</th>
      <td>{{ i.UserId }}</td>
      <td>{{ i.UserId }}</td>
      <td>{{ i.UserId }}</td>
      <td>{{ i.UserId }}</td>
      <td>{{ i.UserId }}</td>
      <td>{{ i.UserId }}</td>
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
                restaurantList: []
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

UserId, r.UserPseudo, r.RestaurantId, r.Name, r.Adresse, r.Photolink, r.Telephone
