<template>
    <div>
        <form @submit="onSubmit($event)">
            <div v-for="item in restaurantList">
            <div class="form-group">
                <label class="col-form-label" for="inputDefault">Nom{{item.name}}</label>
                <input type="text" class="form-control" required>
            </div>

            <div class="form-group">
                <label class="col-form-label" for="inputDefault">Adresse</label>
                <input type="text" class="form-control" required>
            </div>

            <div class="form-group">
                <label class="col-form-label" for="inputDefault">Lien Photo</label>
                <input type="text" class="form-control" required>
            </div>

            <div class="form-group">
                <label class="col-form-label" for="inputDefault">Numero Telephone</label>
                <input type="text" class="form-control" required>
            </div>
            </div>

            <button type="submit" class="btn btn-primary">Sauvegarder</button>
        </form>

    </div>
</template>

<script>
    import { getRestaurantByIdAsync,UpdateRestaurantAsync } from '../api/restaurantApi'

    export default {
        data () {
            return {
               
                restaurantList: [],

                
            }
        },

        async mounted() {
            
            await this.refreshList();
                
        },

        methods: {
            async onSubmit(event) {
                
            try {
                
                       console.log("envoi form update");
                       
                        await UpdateRestaurantAsync(this.item);
                        this.$router.replace('/restaurantList');
                    }
                    catch(e) {
                        console.error(e);
                    }
           
            
            },
            async refreshList() {
                try {
                    
                    this.id = this.$route.params.id;
                    this.restaurantList = await getRestaurantByIdAsync(this.id);
                    
                }
                catch(e) {
                    console.error(e);
                }
            },

        }
    }
</script>

<style lang="scss">

</style>