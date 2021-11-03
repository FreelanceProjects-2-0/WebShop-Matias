<template>
  <v-container fluid>
    <div v-if="sortedDummyData.length > 1">
      <h3>Top 10 most popular products</h3>

      <v-slide-group show-arrows class="pa-4">
        <template v-slot:[`prev`]>
          <v-btn icon>
            <v-icon :class="hover ? (size = '30px') : (size = '10px')">mdi-chevron-left</v-icon>
          </v-btn>
        </template>
        <template v-slot:[`next`]>
          <v-btn icon>
            <v-icon :class="hover ? (size = '30px') : (size = '10px')">mdi-chevron-right</v-icon>
          </v-btn>
        </template>
        <v-slide-item v-for="(item, index) in sortedDummyData" :key="index" class="mb-8 px-4">
          <v-card class="d-flex flex-column mx-1 my-1 pa-0" style="height: 100%" elevation="2" tile>
            <v-card-title class="text-center d-block text-h5 text-xl-h4">
              {{ item.ProductTitle }}
            </v-card-title>
            <v-card-subtitle class="text-xl-h5">
              {{ item.ProductDescription }}
            </v-card-subtitle>
            <v-card-text class="text-xl-h5 text-lg-h6 text-md-subtitle-1 text-subtitle-1 black--text">
              <div class="d-flex justify-center">
                <h4>Price:&nbsp;</h4>
                <h4>${{ $util.dicountCalculator(item.ProductPrice, item.ProductDiscount) }}</h4>
              </div>
              <div>
                <h4>Discount: {{ item.ProductDiscount }}</h4>
              </div>
              <div class="d-flex justify-center">
                <h4>Stock:&nbsp;</h4>
                <h4 :class="$util.stockNumberColor(item.ProductStock)">{{ item.ProductStock }}</h4>
              </div>
              <div class="d-flex justify-center">
                <h4>Items sold:&nbsp;</h4>
                <h4>{{ item.ProductBought }}</h4>
              </div>
            </v-card-text>
          </v-card>
        </v-slide-item>
      </v-slide-group>
    </div>
  </v-container>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
  name: 'HomePage',

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
    // This method will get only top 8 most bought products, sorted by how many times product has been bought, and if that's equal to another then the stock of products will be compared.
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
