<template>
  <div class="delete-teacher-confirmation">
    <p>Delete {{ firstName }} {{ lastName }}?</p>
    <button @click="onOkClicked">Ok</button><button @click="onCancelClicked">Cancel</button>
  </div>
</template>

<script>
import { getById, deleteTeacher } from '../services/TeacherService'

export default {
  data() {
    return {
      firstName: '',
      lastName: '',
      teacherId: this.$route.params.teacherId
    }
  },

  async created() {
    let teacher = await getById(this.teacherId);
    this.firstName = teacher.firstName;
    this.lastName = teacher.lastName;
  },

  methods: {
    async onOkClicked() {
      await deleteTeacher(this.teacherId);
      this.$router.push({ name: 'teachers' });
    },

    onCancelClicked() {
      this.$router.go(-1);
    }
  }
}
</script>