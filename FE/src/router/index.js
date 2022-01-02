import Vue from 'vue';
import VueRouter from 'vue-router';
import HomeView from '@/views/Home.vue';
import HomeComponent from '@/components/HomePage.vue';
import productComponent from '@/components/Products.vue';

Vue.use(VueRouter);

const routes = [
  {
    path: '/',
    component: HomeView,
    children: [
      {
        path: '/',
        name: 'home',
        component: HomeComponent,
      },
      {
        path: '/products',
        name: 'products',
        component: productComponent,
      },
    ],
  },
];

const router = new VueRouter({
  mode: 'history',
  routes,
});

router.afterEach(async (to) => {
  Vue.nextTick(() => {
    document.title = to.meta.title ? to.meta.title : `Webshop`;
  });
});

export default router;
