import Vue from 'vue';
import VueRouter from 'vue-router';
import HomeView from '@/views/Home.vue';
import HomeComponent from '@/components/HomePage.vue';
import productComponent from '@/components/Products.vue';
import store from '@/store/index';

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

router.beforeEach(async (to,from,next) =>{
  const requiresAuth = to.matched.some((record) => record.meta.requiresAdmin || record.meta.requiresManager || record.meta.requiresAuth);
  const authReq = store.dispatch('ENSURE_AUTH');

  if (requiresAuth){
    let success = await authReq
    if (to.matched.some((record) => record.meta.requiresAdmin)){
      success = store.getters.isAdmin;
    }
    else if (to.matched.some((record) => record.meta.requiresManager)){
      success = store.getters.isManager;
    }

    if (!success) {
      next({path: '/'});
    }
    else{
      next();
    }
  }
  next();
});

router.afterEach(async (to) => {
  Vue.nextTick(() => {
    document.title = to.meta.title ? to.meta.title : `Webshop`;
  });
});

export default router;
