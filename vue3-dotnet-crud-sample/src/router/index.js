import { createRouter, createWebHistory } from "vue-router";
import TodoLists from "../views/Todos/TodoLists.vue";
import EditTodoList from "../views/Todos/EditTodo.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/",
      name: "home",
      component: TodoLists,
    },
    {
      path: "/edit/:id",
      name: "editTodo",
      component: EditTodoList,
    },
  ],
});

export default router;
