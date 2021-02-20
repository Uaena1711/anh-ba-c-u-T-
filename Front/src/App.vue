<template>
  <div id="app">
    <v-main>
      
      <Header />
      
      <Content />
      <Navbar />
    </v-main>
  </div>
</template>

<script>
import Navbar from "@/components/layout/Navbar";
import Header from "@/components/layout/Header";
import Content from "@/components/layout/Content";

export default {
  name: "App",

  components: {
    Navbar,
    Header,
    Content,
  },

  data: () => ({
    //
  }),
};
</script>

<style lang='scss'>
@import "./styles/index.scss";


</style>
