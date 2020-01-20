<template>

        <div id="updateRestaurant" class="container">
            TEST
        </div>
</template>

<script>
 import { requireAuth } from '../helpers/requireAuth'

    export default {
        data() {
            return {
            }
        },

        async mounted() {
            await this.refreshList();
            
        },

        methods: {
            async refreshList() {
                try {
                    
                }
                catch(e) {
                    console.error(e);
                }
            },

        }
    }
</script>
