<template>
  <v-container fluid>
    <div>
      <product-list :data="products" />
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
    ...mapGetters(['shopItems']),
  },
  data: () => ({
    products: [],
  }),
  created() {
    this.$store.dispatch('fetch_items');
    this.products = this.shopItems;
  },
};
</script>

<style></style>
