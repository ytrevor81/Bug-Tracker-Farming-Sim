import { createRouter, createWebHistory } from 'vue-router'
import BugListView from '../views/BugListView.vue'
import BugFormView from '../views/BugFormView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: BugListView,
    },
    {
      path: '/create',
      name: 'create',
      component: BugFormView,
    },
  ],
})

export default router
