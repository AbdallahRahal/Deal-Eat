<template>
        <div id="listReduction" class="container">
            
                        <a href="javascript:history.back()">
                            <button class="btn btn-secondary my-2 my-sm-0" type="submit"><i class="fas fa-arrow-circle-left"></i></button>
                        </a>
            <h1>Liste des réductions</h1>
<div class="card text-white bg-success mb-3" style="max-width: 30%;display:inline-block; margin:1%;" v-for="item in reductionList">
  <div class="card-header">{{ item.name }}</div>
  <div class="card-body">
   <!-- <h4 class="card-title">{{ item.photoLink }}</h4> -->
    <p class="card-text">-{{ item.reduction }}€ de réduction sur 1 jour</p>
    <!-- <p class="card-text">{{ item.bracketId }}</p> -->
  </div>
</div>
           
        </div>
</template>

<script>
 import { getReductionListAsync } from '../api/reductionApi'

    export default {
        data() {
            return {
                reductionList: []
            }
        },

        async mounted() {
            await this.refreshList();
            
        },

        methods: {
            async refreshList() {
                try {
                    this.reductionList = await getReductionListAsync();
                    
                }
                catch(e) {
                    console.error(e);
                }
            },

        }
    }
</script>
