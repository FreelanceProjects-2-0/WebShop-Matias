<template>
  <v-container fluid>
    <h4>{{ text }}</h4>
  </v-container>
</template>

<script>
export default {
  name: 'HomePage',

  data: () => ({
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
  }),
};
</script>
