<script setup>
import { onMounted, reactive, ref } from "vue";
import axios from "axios";
import { useRouter } from "vue-router";
import ConfirmDeleteAlert from "../../components/ConfirmDeleteAlert.vue";

// Get all to do list
const todoListCollection = ref([]);
const deleteTodoId = ref(0);
let delModalInstance;

onMounted(() => {
  delModalInstance = new window.bootstrap.Modal(document.getElementById("deleteAlert"));
  axios.get("https://localhost:7154/api/TodoList").then((response) => {
    todoListCollection.value = response.data;
  });
});

const openDeleteModal = (id) => {
  deleteTodoId.value = id;
  delModalInstance.show();
};
const confirmDelete = () => {
  axios.delete(`https://localhost:7154/api/TodoList/${deleteTodoId.value}`).then(() => {
    todoListCollection.value = todoListCollection.value.filter((_) => _.id !== deleteTodoId.value);
  });
  delModalInstance.hide();
};

// Post to do
let newTodo = reactive({
  name: "",
});

const router = useRouter();
const addTodo = () => {
  axios.post("https://localhost:7154/api/TodoList", newTodo).then(() => {
    router.push(window.location.reload());
  });
};
</script>
<template>
  <form @submit.prevent="addTodo">
    <div class="container">
      <div class="input-group mb-3 mt-4">
        <input v-model="newTodo.name" type="text" class="form-control" id="txtTodoName" placeholder="Add To do" aria-label="Add To do" aria-describedby="button-addon2" />
        <button class="btn btn-outline-secondary" type="submit" id="button-addon2">Add</button>
      </div>
    </div>
  </form>

  <div class="container">
    <table class="table table-striped">
      <thead>
        <tr>
          <th>No</th>
          <th>To do Name</th>
          <th>Action</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(item, index) in todoListCollection" :key="item.id">
          <th>{{ index + 1 }}</th>
          <th>{{ item.name }}</th>
          <th>
            <RouterLink class="btn btn-primary" :to="`/edit/${item.id}`">Edit</RouterLink>
            <button type="button" class="btn btn-danger" @click="($event) => openDeleteModal(item.id)">Delete</button>
          </th>
        </tr>
      </tbody>
    </table>
    <ConfirmDeleteAlert @confirm-delete-click="confirmDelete"></ConfirmDeleteAlert>
  </div>
</template>
