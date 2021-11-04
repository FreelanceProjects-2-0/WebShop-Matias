<template>
  <v-container fluid>
    <div>
      <product-list :data="dummyData" />
    </div>
  </v-container>
</template>

<script>
import { mapGetters } from 'vuex';
import ProductList from './Predefined-Layouts/ProductList.vue';

export default {
  name: 'productsComponent',
  components: {
    ProductList,
  },
  computed: {
    ...mapGetters(['dummyShopItems']),
  },
  data: () => ({
    dummyData: [],
  }),
  created() {
    this.dummyData = this.dummyShopItems;
  },
};
</script>

<style></style>
