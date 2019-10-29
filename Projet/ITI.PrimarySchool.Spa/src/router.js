import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'
import Counter from './views/Counter.vue'
import TeacherList from './components/TeacherList.vue'
import TeacherDetails from './components/TeacherDetails.vue'
import DeleteTeacherConfirmation from './components/DeleteTeacherConfirmation.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/counter',
      name: 'counter',
      component: Counter
    },
    {
      path: '/teachers',
      name: 'teachers',
      component: TeacherList
    },
    {
      path: '/teachers/:teacherId',
      name: 'teacher',
      component: TeacherDetails
    },
    {
      path: '/teachers/delete/:teacherId',
      name: 'deleteTeacher',
      component: DeleteTeacherConfirmation
    }
  ]
})
