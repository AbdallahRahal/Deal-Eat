<template>
        <div id="home" class="container" style="max-width: 100%;">
           
            <div class="container" style="margin-top: 10%;">
                <router-link :to="`restaurantInfo`"><button type="submit" class="btn btn-primary btn-lg btn-block">Modifier un restaurant</button></router-link>
                <router-link :to="`restaurantList`"><button type="submit" class="btn btn-primary btn-lg btn-block" style="margin-top: 3%;">Afficher les restaurant</button></router-link>
                <router-link :to="`reductionList`"><button type="submit" class="btn btn-primary btn-lg btn-block" style="margin-top: 3%;">Afficher les promotions</button></router-link>
            </div>
        </div>  
        
</template>

<script>

</script>
