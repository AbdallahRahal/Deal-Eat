<template>
    <div>
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
    </div>
</template>

<script>
    import { getRestaurantByIdAsync,UdpateRestaurantAsync } from '../api/restaurantApi'

    export default {
        data () {
            return {
                item: {},
               
                id: null,
                
            }
        },

        async mounted() {
            
            this.id = this.$route.params.id;
            
            if(this.mode == 'edit') {
                try {
                    const item = await getRestaurantByIdAsync(this.id);

                    this.item = item;
                }
                catch(e) {
                    console.error(e);
                    this.$router.replace('/home');
                }
            }
        },

        methods: {
            async onSubmit(event) {
                
                event.preventDefault();
                var errors = [];
                this.errors = errors;

                if(errors.length == 0) {
                    try {
                       
                        await UdpateRestaurantAsync(this.item);
                        this.$router.replace('/restaurantList');
                    }
                    catch(e) {
                        console.error(e);
                    }
                }
            }
        }
    }
</script>

<style lang="scss">

</style>