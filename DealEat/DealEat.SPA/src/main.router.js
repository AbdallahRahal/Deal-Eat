// Vue router setup
import Vue from 'vue';
import VueRouter from 'vue-router';
Vue.use(VueRouter);

import requireAuth from './helpers/requireAuth';

// Components
import Home from './components/Home.vue'
import LoginMerchant from './components/LoginMerchant.vue'
import Logout from './components/Logout.vue'
import ReductionList from './components/ReductionList.vue'
import RestaurantInfo from './components/RestaurantInfo.vue'
import UpdateRestaurant from './components/UpdateRestaurant.vue'
import NewRestaurant from './components/NewRestaurant.vue'
import NewReduction from './components/NewReduction.vue'

//import User from './components/User.vue'

const routes = [
    { path: '/home', component: Home , beforeEnter: requireAuth},
    { path: '', component: Home, beforeEnter: requireAuth },
    { path: '/login', component: LoginMerchant },
    { path: '/updateRestaurant/:id', component: UpdateRestaurant, beforeEnter: requireAuth },
    { path: '/reductionList', component: ReductionList, beforeEnter: requireAuth  },
    { path: '/newreduction/:id', component: NewReduction, beforeEnter: requireAuth  },
    { path: '/restaurantInfo', component: RestaurantInfo, beforeEnter: requireAuth  },
    { path: '/addRestaurant', component: NewRestaurant, beforeEnter: requireAuth  },
    /*{ path: '/', component: Home },
    //{ path: '/logout', component: Logout, beforeEnter: requireAuth },

    //{ path: '/user', component: User },

    /*{ path: '/teachers', component: TeacherList, beforeEnter: requireAuth },
    { path: '/teachers/:mode([create|edit]+)/:id?', component: TeacherEdit, beforeEnter: requireAuth },
    { path: '/teachers/assign/:id', component: TeacherAssign, beforeEnter: requireAuth },
    { path: '/teachers/presentEdit/:id', component: TeacherPresentEdit, beforeEnter: requireAuth },

    { path: '/github/following', component: FollowingList, beforeEnter: requireAuth, meta: { requiredProviders: ['GitHub'] } }*/
];

export default new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
});