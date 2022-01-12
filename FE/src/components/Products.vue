<template>
  <v-container fluid>
    <v-row no-gutters>
      <v-btn v-if="isAdmin" plain @click="createNewProduct"><v-icon left>mdi-plus-box-multiple</v-icon>Add product</v-btn>
    </v-row>
    <div v-if="!detailsView && products.length >= 1">
      <strong class="px-4">Products</strong>
      <product-list :data="products" :key="reRenderKey" />
      <create-edit-product ref="CreateEditproductRef" @product-updated="getProducts" />
    </div>
    <div v-else>HAI</div>
  </v-container>
</template>

<script>
import { mapGetters } from 'vuex';
import CreateEditProduct from './Dialogs/CreateEditProduct.vue';
import ProductList from './Predefined-Layouts/ProductList.vue';
import apiService from '@/services/apiService.js';

export default {
  name: 'productsComponent',
  components: {
    ProductList,
    CreateEditProduct,
  },
  data: () => ({
    detailsView: false,
    products: [],
    reRenderKey: 0,
  }),
  computed: {
    ...mapGetters(['isAdmin']),
  },
  methods: {
    async getProducts() {
      this.products = await apiService.getProducts();
      this.reRenderKey++;
    },
    createNewProduct() {
      this.$refs.CreateEditproductRef.createProduct();
    },
  },
  created() {
    this.getProducts();
  },
};
</script>

<style></style>
