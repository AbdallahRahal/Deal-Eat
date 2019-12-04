// Vue router setup
import Vue from 'vue';
import VueRouter from 'vue-router';
Vue.use(VueRouter);

//import requireAuth from './helpers/requireAuth';

// Components
import Home from './components/Home.vue'
import Login from './components/Login.vue'
import Logout from './components/Logout.vue'
import RestaurantList from './components/RestaurantList.vue'
import ReductionList from './components/ReductionList.vue'

//import User from './components/User.vue'

const routes = [
    { path: '/home', component: Home },
    { path: '', component: Home },
    { path: '/login', component: Login },
    { path: '/restaurantList', component: RestaurantList },
    { path: '/reductionList', component: ReductionList },
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