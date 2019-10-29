<template>
  <div class="teachers">
    <h1>Teachers ({{ teacherCount }})</h1>
    <table>
      <tr>
        <td>Id</td>
        <td>First name</td>
        <td>Last name</td>
      </tr>
      <tr v-for="teacher in teachers" :key="teacher.teacherId">
        <td><router-link :to="{ name: 'teacher', params: { teacherId: teacher.teacherId } }">{{ teacher.teacherId }}</router-link></td>
        <td><router-link :to="{ name: 'teacher', params: { teacherId: teacher.teacherId } }">{{ teacher.firstName }}</router-link></td>
        <td><router-link :to="{ name: 'teacher', params: { teacherId: teacher.teacherId } }">{{ teacher.lastName }}</router-link></td>
      </tr>
    </table>
  </div>
</template>

<script>
import { getAll } from '../services/TeacherService'

export default {
  data() {
    return {
      teachers: null
    };
  },

  async created() {
    this.teachers = await getAll();
  },

  computed: {
    teacherCount() {
      return this.teachers != null ? this.teachers.length : 0;
    }
  }
}
</script>