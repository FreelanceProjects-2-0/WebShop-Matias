<template>
  <v-container fluid>
    <v-row no-gutters class="px-2">
      <v-btn tile @click="isDataTable = !isDataTable"> {{ isDataTable ? 'Show card-list': 'Show datatable'}}</v-btn>
    </v-row>
    <h1 v-if="errorMessage">{{ errorMessage }}</h1>
    <v-row no-gutters v-else-if="!isDataTable">
      <v-col cols="6" v-for="(item, index) in products" :key="index" class="py-2 px-2 text-left">
        <!--   -->
        <v-card v-if="isMobile" class="" style="height: 100%">
          <v-row no-gutters>
            <v-col>
              <v-card-title>
                {{ item.title }}
              </v-card-title>
              <v-card-subtitle>
                <v-row no-gutters>
                  <v-col cols="9">
                    {{ item.description }}
                    <div class="d-flex justify-end mt-0">
                      <v-img width="250px" src="@/assets/placeholder.jpg"></v-img>
                    </div>
                  </v-col>
                </v-row>
              </v-card-subtitle>
            </v-col>
            <v-card-text class="text-xl-h5 text-lg-h6 text-subtitle-1 black--text">
              <div class="d-flex">
                <h4>Price&nbsp;${{ $util.dicountCalculator(item.price, item.discount) }}</h4>
                <h4 class="ml-auto text-decoration-line-through grey--text">${{ item.ProductPrice }}</h4>
              </div>
              <div class="d-flex" v-if="item.ProductStock <= 50">
                <h4>Items in stock&nbsp;</h4>
                <h4 :class="$util.stock(item.ProductStock)" class="ml-auto">{{ item.ProductStock }}</h4>
              </div>
              <div class="d-flex">
                <h4>Items sold</h4>
                <h4 class="ml-auto">{{ item.ProductBought }}</h4>
              </div>
            </v-card-text>
          </v-row>
        </v-card>
        <!--  -->
        <v-card v-else class="d-flex flex-column" style="height: 100%">
          <v-row no-gutters>
            <v-col>
              <v-card-title class="text-xl-h4">
                {{ item.title }}
              </v-card-title>
              <v-card-subtitle class="text-xl-h5">
                <v-row no-gutters>
                  <v-col cols="9">
                    {{ item.description }}
                  </v-col>
                  <v-col cols="3">
                    <div class="d-flex justify-end mt-0">
                      <v-img width="250px" src="@/assets/placeholder.jpg"></v-img>
                    </div>
                  </v-col>
                </v-row>
              </v-card-subtitle>
            </v-col>
            <v-card-text class="text-xl-h5 text-lg-h6 text-subtitle-1 black--text">
              <v-row no-gutters>
                <v-col class="">
                  <h4>Price&nbsp;${{ $util.dicountCalculator(item.price, item.discount) }}</h4>
                  <h4 class="text-decoration-line-through grey--text">${{ item.price }}</h4>
                </v-col>
                <v-col class="justify-end" cols="6">
                  <div class="d-flex justify-end" v-if="item.stock <= 50">
                    <h4 :class="$util.stockNumberColor(item.stock)">{{ item.stock }}</h4>
                    <h4>&nbsp;Items in stock</h4>
                  </div>
                  <div class="d-flex justify-end">
                    <h4>{{ item.bought }}</h4>
                    <h4>&nbsp;Items sold</h4>
                  </div>
                </v-col>
              </v-row>
            </v-card-text>
          </v-row>
        </v-card>
      </v-col>
    </v-row>
      <v-data-table v-else :items="products" :headers="productDataTableHeaders">
        <template v-slot:[`item.discountPrice`]="product">
          {{ $util.dicountCalculator(product.item.price, product.item.discount) }}
        </template>
      </v-data-table>
  </v-container>
</template>

<script>
export default {
  data: () => ({
    isDataTable: false,
    products: [],
    errorMessage: '',

    productDataTableHeaders: [
      {
        text: 'Title',
        value: 'title',
      },
      {
        text: 'Description',
        value:'description',
      },
      {
        text: 'Before discount',
        value:'price',
      },
      {
        text: 'Price',
        value:'discountPrice',
      },
      {
        text: 'Discount',
        value:'discount',
      },
      {
        text: 'Stock',
        value:'stock',
      },
      {
        text: 'Bought',
        value:'bought',
      }
    ],
  }),
  computed: {
    isMobile() {
      if (window.innerWidth < 350) {
        return true;
      }
      return false;
    },
  },
  methods: {},
  props: {
    data: Array,
  },
  created() {
    if (!this.data) {
      this.errorMessage = 'No products loaded...';
    } else {
      this.products = this.data;
    }
  },
};
</script>

<style></style>
