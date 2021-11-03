<template>
  <v-container fluid>
    <v-row>
      <v-col cols="12" v-for="(item, index) in dummyData" :key="index" class="mb-8 px-4 text-left">
        <v-card class="d-flex flex-column" style="height: 100%">
          <v-row no-gutters>
            <v-col>
              <v-card-title class="text-left text-h5 text-xl-h4">
                {{ item.ProductTitle }}
              </v-card-title>
              <v-card-subtitle class="text-xl-h5">
                {{ item.ProductDescription }}
              </v-card-subtitle>
              <v-card-text class="text-xl-h5 text-lg-h6 text-subtitle-1 black--text">
                <v-row no-gutters>
                  <v-col>
                    <h4>Price&nbsp;</h4>
                    <h4>${{ $util.dicountCalculator(item.ProductPrice, item.ProductDiscount) }}</h4>
                    <h4 class="text-decoration-line-through grey--text">${{ item.ProductPrice }}</h4>
                  </v-col>
                  <v-col class="justify-end" cols="3">
                    <div class="d-flex justify-end">
                      <v-img width="250px" src="@/assets/placeholder.jpg"></v-img>
                    </div>
                    <div class="d-flex justify-end" v-if="item.ProductStock <= 50">
                      <h4 :class="$util.stockNumberColor(item.ProductStock)">{{ item.ProductStock }}</h4>
                      <h4>&nbsp;Items in stock</h4>
                    </div>
                    <div class="d-flex justify-end">
                      <h4>{{ item.ProductBought }}</h4>
                      <h4>&nbsp;Items sold</h4>
                    </div>
                  </v-col>
                </v-row>
              </v-card-text>
            </v-col>
          </v-row>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
  name: 'productsComponent',
  computed: {
    ...mapGetters(['dummyShopItems']),
  },
  data: () => ({
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
  created() {
    this.dummyData = this.dummyShopItems;
  },
};
</script>

<style></style>
