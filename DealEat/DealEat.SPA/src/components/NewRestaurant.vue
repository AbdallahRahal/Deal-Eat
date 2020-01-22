<template>
    <div>
    <div class="container">
        <h1>Ajouter un restaurant</h1>
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
                <input type="text" class="form-control" v-model="item.photoLink" style="max-width: 40%;font-family: revert;" required>
            </div>

            <div class="form-group">
                <label class="col-form-label" for="inputDefault">Numero Telephone</label>
                <input type="text" class="form-control" v-model="item.telephone" style="max-width: 40%;" required>
            </div>

            <button type="submit" class="btn btn-primary">Ajouter</button>
        </form>
    </div>
    </div>
</template>

<script>
    import { CreateRestaurantAsync } from '../api/restaurantApi'
    import { requireAuth } from '../helpers/requireAuth'
import AuthService from '../services/AuthService'

    export default {
        data () {
            return {
               
               item: {}
                
            }
        },

        async mounted() {
                
        },

        methods: {
            async onSubmit(event) {
                event.preventDefault();
                       
                        await CreateRestaurantAsync(AuthService.email ,this.item);
                        this.$router.replace('/home');
           
            
            }

        }
    }
</script>

<style lang="scss">

</style>