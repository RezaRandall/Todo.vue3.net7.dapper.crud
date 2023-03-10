<script setup>
import axios from "axios";
import { onMounted, reactive, ref } from "vue";
import { useRoute, useRouter } from "vue-router";

const router = useRouter();
const route = useRoute();

let updateTodos = reactive({
  id: 0,
  name: "",
});

onMounted(async () => {
  const response = await axios.get(`https://localhost:7154/api/TodoList/id?id=${route.params.id}`);
  updateTodos.id = response.data.id;
  updateTodos.name = response.data.name;
});

const todoUpdate = async () => {
  await axios.put(`https://localhost:7154/api/TodoList/${route.params.id}`, updateTodos).then(() => {
    router.push("/");
  });
};
</script>

<template>
  <div class="contain">
    <form @submit.prevent="todoUpdate">
      <legend>Update To do</legend>
      <div class="container">
        <div class="input-group mb-3 mt-4">
          <input type="text" class="form-control" id="txtUpdateTodoName" placeholder="Add To do" v-model="updateTodos.name" />
          <button class="btn btn-outline-secondary" type="submit" id="button-addon2">Update</button>
        </div>
      </div>
    </form>
  </div>
</template>
