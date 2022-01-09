<template>
  <v-container fluid>
    <div v-if="sortedProducts.length >= 1">
      <h3>Top 10 most popular products</h3>
      <div v-if="!$vuetify.breakpoint.xs">
        <product-carousel :data="sortedProducts" />
      </div>
      <div v-else>
        <product-list :data="sortedProducts" />
      </div>
    </div>
  </v-container>
</template>

<script>
import ProductCarousel from './Predefined-Layouts/productCarousel.vue';
import ProductList from './Predefined-Layouts/ProductList.vue';
import apiService from '@/services/apiService.js';

export default {
  name: 'HomePage',
  components: {
    ProductCarousel,
    ProductList,
  },

  data: () => ({
    // This is test data
    sortedProducts: [],
    products: [],
    headersForProducts: [
      {
        text: 'Product',
        value: 'title',
      },
      {
        text: 'Description',
        value: 'description',
      },
      {
        text: 'Price',
        value: 'price',
      },
      {
        text: 'På lager',
        value: 'stock',
      },
      {
        text: 'Tidligere købt',
        value: 'bought',
      },
    ],
  }),
  computed: {
    averageSold() {
      return this.$util.calculateAverageSoldItems(this.products);
    },
  },
  methods: {
    async getProducts() {
      this.products = await apiService.getProducts();
      this.checkBoughtNumber(this.products);
    },
    
    // This method will get only top 8 most bo bought products, sorted by how many times product has been bought, and if that's equal to another then the stock of products will be compared.
    checkBoughtNumber(items) {
      let productCount = 0;

      items.forEach(element => {
        if (element.bought > this.averageSold && productCount < 10)
        {
          this.sortedProducts.push({ ...element });
          productCount++;
        }
      });
      this.sortedProducts.sort((a, b) => (a.bought < b.bought ? 1 : a.bought == b.bought ? (a.stock > b.stock ? 1 : -1) : -1));
    },
  },
  created() {
    this.getProducts();
  },
};
</script>
