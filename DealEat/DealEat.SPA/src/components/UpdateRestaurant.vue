<template>
    <div>
        
            
    <div class="container">
        <h1>Modifier mon restaurant</h1>
        <form @submit="onSubmit($event)">
            <div class="form-group">
                <label class="col-form-label" for="inputDefault">Nom</label>
                <input type="text" class="form-control" v-model="item.name" style="max-width: 40%;" required>
            </div>

            <div class="form-group">
                <label class="col-form-label" for="inputDefault">Adresse</label>
                <input type="text" class="form-control" v-model="item.adresse" style="max-width: 40%;" required>
            </div>

          <div class="form-group">
                <label class="col-form-label" for="inputDefault">Lien Photo</label>
                <input type="text" class="form-control" v-model="item.photoLink" :placeholder="item.photoLink" style="max-width: 40%;font-family: revert;" required>
            </div>

            <div class="form-group">
                <label class="col-form-label" for="inputDefault">Numero Telephone</label>
                <input type="text" class="form-control" v-model="item.telephone" :placeholder="item.telephone" style="max-width: 40%;" required>
            </div>

            <button type="submit" class="btn btn-primary">Sauvegarder</button>
        </form>
    </div>
    </div>
</template>

<script>
    import { getRestaurantByIdWebAsync,UpdateRestaurantAsync } from '../api/restaurantApi'
    import { requireAuth } from '../helpers/requireAuth'

    export default {
        data () {
            return {
               
               item: {}
                
            }
        },

        async mounted() {
            
            await this.refreshList();
                
        },

        methods: {
            async onSubmit(event) {
                event.preventDefault();
                       
                        await UpdateRestaurantAsync(this.item.restaurantId,this.item);
                        this.$router.replace('/home');
           
            
            },
            async refreshList() {
                    this.id = this.$route.params.id;
                    this.item = await getRestaurantByIdWebAsync(this.id);
            },

        }
    }
</script>

<style lang="scss">

</style>