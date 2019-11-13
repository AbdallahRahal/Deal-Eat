<template>
        <div id="home" class="container" style="max-width: 100%;">
            <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
                    <a class="navbar-brand" href="#" style="width: 4%;"><img src="../../Logo Deal'eat V1.png" style="width: 200%;"></a>
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarColor01" aria-controls="navbarColor01" aria-expanded="false" aria-label="Toggle navigation">
                      <span class="navbar-toggler-icon"></span>
                    </button>
                  
                    <div class="collapse navbar-collapse" id="navbarColor01">
                      <ul class="navbar-nav mr-auto">
                        <h1 class="test-font" style="margin-left: 50%;">
                          Deal'Eat
                        </h1>
                      </ul>
                      <form class="form-inline my-2 my-lg-0">
                        <input class="form-control mr-sm-2" type="text" placeholder="Chercher...">
                        <button class="btn btn-secondary my-2 my-sm-0" type="submit"><i class="fas fa-search"></i></button>
                      </form>
                    </div>
                  </nav>
            <div class="container" style="margin-top: 10%;">
                <!--<router-link :to="`restaurant`"><button type="submit" class="btn btn-primary btn-lg btn-block">Ajouter un restaurant</button></router-link>-->
                <router-link :to="`restaurantList`"><button type="submit" class="btn btn-primary btn-lg btn-block" style="margin-top: 3%;">Afficher les restaurant</button></router-link>
                <!-- <button type="submit" class="btn btn-primary btn-lg btn-block" style="margin-top: 3%;">Ajouter une promotion</button>-->
            </div>
        </div>  
        
</template>

<script>

</script>
