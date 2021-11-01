<template>
  <v-container fluid>
    <v-row>
      <v-col cols="12" sm="6" md="6" lg="4" xl="3" v-for="(item, index) in dummyData" :key="index" class="mb-8 px-4 text-center">
        <v-card class="d-flex flex-column" style="height: 100%">
          <v-card-title class="text-center d-block text-h5 text-xl-h4">
            {{ item.ProductTitle }}
          </v-card-title>
          <v-card-subtitle class="text-xl-h5">
            {{ item.ProductDescription }}
          </v-card-subtitle>
          <v-card-text class="text-xl-h5 text-lg-h6 text-md-subtitle-1 text-subtitle-1 black--text">
            <div class="d-flex justify-center">
              <h4>Price:&nbsp;</h4>
              <h4>${{ item.ProductPrice }}</h4>
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
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  name: 'productsComponent',
  data: () => ({
    dummyData: [
      {
        ProductId: 1,
        ProductTitle: 'Product 1',
        ProductDescription: 'This is a test description',
        ProductPrice: 250,
        ProductStock: 7,
        ProductBought: 251,
      },
      {
        ProductId: 2,
        ProductTitle: 'Product 2',
        ProductDescription: 'This is a test description',
        ProductPrice: 225,
        ProductStock: 2,
        ProductBought: 663,
      },
      {
        ProductId: 3,
        ProductTitle: 'Product 3',
        ProductDescription: 'This is a test description',
        ProductPrice: 5551,
        ProductStock: 3,
        ProductBought: 17,
      },
      {
        ProductId: 4,
        ProductTitle: 'Product 4',
        ProductDescription: 'This is a test description',
        ProductPrice: 1932,
        ProductStock: 543,
        ProductBought: 1543,
      },
    ],
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
};
</script>

<style></style>
