<template>
        <form @submit="onSubmit($event)">

            <div class="form-group">
                <label >Nom</label>
                <input type="text" v-model="item.Name" class="form-control" required>
            </div>

            <div class="form-group">
                <label >Adresse</label>
                <input type="text" v-model="item.Adresse" class="form-control" required>
            </div>

            <div class="form-group">
                <label >Lien Photo</label>
                <input type="text" v-model="item.Photolink" class="form-control" required>
            </div>

            <div class="form-group">
                <label >Numero Telephone</label>
                <input type="text" v-model="item.Telephone" class="form-control">
            </div>

            <button type="submit" class="btn btn-primary">Sauvegarder</button>
        </form>


</template>

<script>
import { getRestaurantByIdAsync } from '../api/restaurantApi'
import { newReductionByIdAsync } from '../api/reductionApi'
    export default {
        data () {
            return {
                item: {},
                id: null,
                
            }
        },

        async mounted() {
            
            this.id = this.$route.params.id;
            
            const item = await getRestaurantByIdAsync(this.id);
            this.item = item;
               
            
        },

        methods: {
            async onSubmit(event) {
                       
                await newReductionAsync(this.id,this.item);
                this.$router.replace('/restaurantList');
                
            }
        }
    }

</script>
