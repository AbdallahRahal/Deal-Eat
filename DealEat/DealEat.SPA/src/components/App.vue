<template>
    <div id="app">
        <header>
            <nav class="navbar navbar-expand-lg navbar-dark bg-primary" style="margin:2%;">
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
        </header>
    <div>
                
    </div>
        <main role="main" class="p-3 p-md-4 p-lg-5">
            <router-view class="child"></router-view>
        </main>
        
    </div>
</template>

<script >


</script>

<style lang="css">
@import "../styles/bootstrap.css";
</style>
