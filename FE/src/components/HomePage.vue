<template>
  <v-container fluid>
    <div v-if="sortedDummyData.length > 1">
      <h3>Top 10 most popular products</h3>
      <div v-if="!$vuetify.breakpoint.xs">
        <product-carousel :data="sortedDummyData" />
      </div>
      <div v-else>
        <product-list :data="sortedDummyData" />
      </div>
    </div>
  </v-container>
</template>

<script>
import { mapGetters } from 'vuex';
import ProductCarousel from './Predefined-Layouts/productCarousel.vue';
import ProductList from './Predefined-Layouts/ProductList.vue';

export default {
  name: 'HomePage',
  components: {
    ProductCarousel,
    ProductList,
  },

  data: () => ({
    // This is test data
    sortedDummyData: [],
    dummyData: [],
    headersForDummyData: [
      {
        text: 'Product',
        value: 'ProductTitle',
      },
      {
        text: 'Description',
        value: 'ProductDescription',
      },
      {
        text: 'Price',
        value: 'ProductPrice',
      },
      {
        text: 'På lager',
        value: 'ProductStock',
      },
      {
        text: 'Tidligere købt',
        value: 'ProductBought',
      },
    ],
  }),
  computed: {
    ...mapGetters(['dummyShopItems']),
    averageSold() {
      return this.$util.calculateAverageSoldItems(this.dummyData);
    },
  },
  methods: {
    // This method will get only top 8 most bo ffught products, sorted by how many times product has been bought, and if that's equal to another then the stock of products will be compared.
    checkBoughtNumber() {
      let productCount = 0;
      this.dummyData.forEach((item) => {
        if (item.ProductBought > this.averageSold && productCount < 10) {
          this.sortedDummyData.push({ ...item });
          productCount++;
        }
      });
      this.sortedDummyData.sort((a, b) => (a.ProductBought < b.ProductBought ? 1 : a.ProductBought == b.ProductBought ? (a.ProductStock > b.ProductStock ? 1 : -1) : -1));
    },
  },
  created() {
    this.dummyData = this.dummyShopItems;
    // this.$store.dispatch('fetch_items');
    this.checkBoughtNumber();
  },
};
</script>
