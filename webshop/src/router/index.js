import Vue from 'vue';
import VueRouter from 'vue-router';
import Home from '../views/Home.vue';

Vue.use(VueRouter);

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home,
  },
  {
    path: '/about',
    name: 'About',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/About.vue'),
  },
];

const router = new VueRouter({
  mode: 'history',
  routes,
});

// Check if page needs admin rights, if not try to get cached login.
router.beforeEach(async (to, from, next) => {
  let success;
  if (to.matched.some((record) => record.meta.requireAdmin)) {
    // success = await store.dispatch('ENSURE_ADMIN');
  } else {
    success = true;
  }

  // If user dosn't have admin rights redirect to front-page
  if (!success) return next({ name: 'Home' });
  next();
});

router.afterEach(async (to) => {
  Vue.nextTick(() => {
    document.title = to.meta.title ? to.meta.title : `Webshop`;
  });
});

export default router;
