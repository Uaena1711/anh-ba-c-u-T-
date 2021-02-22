import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import Antd from 'ant-design-vue';
global.jQuery = require('jquery');
var $ = global.jQuery;
window.$ = $;

Vue.config.productionTip = false

new Vue({
  router,
  store,
  render: h => h(App),
}).$mount('#app')


Vue.use(Antd);
$(window).on("load resize ", function() {
  var scrollWidth = $('.tbl-content ').width() - $('.tbl-content table').width();
  $('.tbl-header').css({'padding-right':scrollWidth});
}).resize();

