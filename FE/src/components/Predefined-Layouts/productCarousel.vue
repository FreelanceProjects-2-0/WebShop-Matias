<template>
  <v-container fluid>
    <h1 v-if="errorMessage">{{ errorMessage }}</h1>
    <v-slide-group show-arrows class="pa-0" draggable="false" v-else>
      <template v-slot:[`prev`]>
        <v-btn icon plain class="black--text" x-large>
          <v-icon>mdi-chevron-left</v-icon>
        </v-btn>
      </template>
      <template v-slot:[`next`]>
        <v-btn icon plain class="black--text" x-large>
          <v-icon>mdi-chevron-right</v-icon>
        </v-btn>
      </template>
      <v-slide-item v-for="(item, index) in productList" :key="index">
        <v-card class="d-flex flex-column mx-1 mx-sm-2 my-1" style="height: 95%; width: 275px" elevation="3" outlined tile>
          <v-card-title class="text-center d-block text-xl-h4 font-weight-medium">
            {{ item.ProductTitle }}
          </v-card-title>
          <v-card-subtitle class="text-xl-h5">
            {{ item.ProductDescription }}
          </v-card-subtitle>
          <v-card-text class="text-xl-h5 text-lg-h6 text-md-subtitle-1 text-subtitle-1 black--text">
            <div class="d-flex">
              <h4>Price:&nbsp;</h4>
              <h4 class="ml-auto">${{ $util.dicountCalculator(item.ProductPrice, item.ProductDiscount) }}</h4>
            </div>
            <div class="d-flex flex-row">
              <h4>Savings {{ item.ProductDiscount }}%&nbsp;</h4>
              <h4 class="text-decoration-line-through grey--text ml-auto">${{ item.ProductPrice }}</h4>
            </div>
            <div class="d-flex justify-end">
              <h4>Stock:&nbsp;</h4>
              <h4 :class="$util.stockNumberColor(item.ProductStock)">{{ item.ProductStock }}</h4>
            </div>
            <div class="d-flex justify-end">
              <h4>Items sold:&nbsp;</h4>
              <h4>{{ item.ProductBought }}</h4>
            </div>
          </v-card-text>
        </v-card>
      </v-slide-item>
    </v-slide-group>
  </v-container>
</template>

<script>
export default {
  data: () => ({
    productList: [],
    errorMessage: '',
  }),
  props: {
    data: Array,
  },
  created() {
    if (!this.data) {
      this.errorMessage = 'No products loaded...';
    } else {
      this.productList = this.data;
    }
  },
};
</script>

<style></style>
