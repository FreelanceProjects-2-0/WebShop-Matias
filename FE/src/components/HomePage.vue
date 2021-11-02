<template>
  <v-container fluid>
    <div v-if="sortedDummyData.length > 1">
      <!-- <h4>{{ text }}</h4> -->
      <!-- <br /> -->
      <!-- <h3>Most popular items:</h3> -->
      <v-row>
        <v-col cols="12" sm="6" md="6" lg="4" xl="3" v-for="(item, index) in sortedDummyData" :key="index" class="mb-8 px-4 text-center">
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
        </v-col>
      </v-row>
    </div>
  </v-container>
</template>

<script>
export default {
  name: 'HomePage',

  data: () => ({
    // This is test data
    text:
      'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse rhoncus nisi ligula, ac ultricies erat aliquam finibus. Ut rutrum eu felis vel finibus. ' +
      'Aenean dictum sodales pellentesque. Nunc viverra tellus eu ante fringilla pulvinar. Vestibulum sed mollis diam. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.' +
      'Integer vitae metus tempus, blandit tortor nec, semper diam. Curabitur nec cursus urna. Suspendisse laoreet, leo a luctus malesuada, ipsum orci tristique felis, vel iaculis diam elit vel enim. In finibus dignissim est in elementum.' +
      'Fusce dictum pharetra porttitor. Ut hendrerit ultrices tellus id fermentum. Praesent a mauris augue. Donec velit ex, laoreet ac convallis nec, laoreet sed risus. ' +
      'Ut nulla dolor, ornare sed velit eget, condimentum tincidunt ipsum. Nulla vel velit non diam ultricies suscipit. Curabitur molestie semper est ut euismod. Morbi et risus lorem. Vestibulum interdum nulla nec pretium elementum. ' +
      'Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Quisque blandit sodales quam. Fusce interdum mauris non dapibus elementum. Phasellus in blandit elit, sed mollis nibh. ' +
      'Etiam vitae nisl a est blandit lacinia suscipit nec nulla. Morbi volutpat porta nunc quis congue. Fusce dictum molestie est et faucibus. Nulla facilisi. Vestibulum blandit gravida elit eget consequat. ' +
      'Quisque eget justo eu ex pulvinar consectetur ut ac quam. Maecenas pharetra, odio nec laoreet aliquam, ex enim feugiat massa, a pharetra dui nisi efficitur leo. Praesent odio dolor, feugiat eu neque eu, commodo finibus est. ' +
      'Duis quis nisl tempus, sagittis nisi quis, sagittis justo. Vestibulum elementum ut erat a aliquam.',
    sortedDummyData: [],
    dummyData: [
      {
        ProductId: 1,
        ProductTitle: 'Product 1',
        ProductDescription: 'This is a test description',
        ProductPrice: 250,
        ProductStock: 7,
        ProductBought: 251,
        ProductDiscount: 5,
      },
      {
        ProductId: 2,
        ProductTitle: 'Product 2',
        ProductDescription: 'This is a test description',
        ProductPrice: 225,
        ProductStock: 2,
        ProductBought: 663,
        ProductDiscount: 7.5,
      },
      {
        ProductId: 3,
        ProductTitle: 'Product 3',
        ProductDescription: 'This is a test description',
        ProductPrice: 5551,
        ProductStock: 3,
        ProductBought: 17,
        ProductDiscount: 10,
      },
      {
        ProductId: 4,
        ProductTitle: 'Product 4',
        ProductDescription: 'This is a test description',
        ProductPrice: 1932,
        ProductStock: 543,
        ProductBought: 1543,
        ProductDiscount: 15,
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

  computed: {
    averageSold() {
      return this.$util.calculateAverageSoldItems(this.dummyData);
    },
  },
  methods: {
    checkBoughtNumber() {
      let productCount = 0;
      this.dummyData.forEach((item) => {
        if (item.ProductBought > this.averageSold && productCount < 10) {
          this.sortedDummyData.push({ ...item });
          productCount++;
        }
      });
    },
  },
  created() {
    this.checkBoughtNumber();
  },
};
</script>
