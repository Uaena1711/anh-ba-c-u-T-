<template>
  <!-- <div >
    <nav class="main-nav">
      <div class="logo">my.company</div>
      <Burger></Burger>
    </nav>

    <Sidebar>
      <ul class="sidebar-panel-nav">
        <li>
          <a href="#">
                <div class="nav-item-icon nav-item-dashboard"></div>
                <div class="nav-item-text">Tổng quan</div>
          </a>
        </li>
        <li>
          <a href="#">
                <div class="nav-item-icon nav-item-report"></div>
                <div class="nav-item-text">Tài sản</div>
          </a>
        </li>
        <li> <div class="nav-item-icon nav-item-report"></div>
              <div class="nav-item-text">Công cụ dụng cụ</div>
        </li>
        <li>
              <router-link class="nav-item" to="/dictionary/assets">
                <div class="nav-item-icon nav-item-dic"></div>
                <div class="nav-item-text">Danh mục</div>
            </router-link>
        </li>
        <li>    <a href="#">
                <div class="sprite"></div>
                <div class="nav-item-text">Tra cứu</div>
                </a>
        </li>
        <li>
          <a href="#">
                <div class="nav-item-icon nav-item-setting"></div>
                <div class="nav-item-text">Hệ thống</div>
          </a>
        </li>
        <li>
          <a href="#">
                <div class="nav-item-icon nav-item-report"></div>
                <div class="nav-item-text">Báo cáo</div>
          </a>
        </li>
      </ul>
    </Sidebar>
  </div> -->

     <b-navbar class="navbar">
        <div class="logo-site">
            <div class="logo-box">
                
                <h1>QLTS <b-navbar-brand href="#"></b-navbar-brand></h1>
            </div>
        </div>
        <b-navbar-toggle target="navbar-toggle-collapse">
          <template #default="{ expanded }">
            <b-icon v-if="expanded" icon="chevron-bar-up"></b-icon>
            <b-icon v-else icon="chevron-bar-down"></b-icon>
          </template>
      </b-navbar-toggle>
        <div class="navbar-content">
          <nav class="mb-3">
            <b-nav-item>
            <a class="nav-item">
                <div class="nav-item-icon nav-item-dashboard"></div>
                <div class="nav-item-text">Tổng quan</div>
            </a>
            </b-nav-item>
          </nav>
            <a class="nav-item">
                <div class="nav-item-icon nav-item-report"></div>
                <div class="nav-item-text">Tài sản</div>
            </a>
            <a class="nav-item">
                
                <div class="nav-item-text">Công cụ dụng cụ</div>
            </a>
            <router-link class="nav-item" to="/dictionary/assets">
                <div class="nav-item-icon nav-item-dic"></div>
                <div class="nav-item-text">Danh mục</div>
            </router-link>
            <a class="nav-item">
                <div class="sprite"></div>
                <div class="nav-item-text">Tra cứu</div>
            </a>
            <a class="nav-item">
                <div class="nav-item-icon nav-item-setting"></div>
                <div class="nav-item-text">Hệ thống</div>
            </a>
            <a class="nav-item">
                <div class="nav-item-icon nav-item-report"></div>
                <div class="nav-item-text">Báo cáo</div>
            </a>
          

        </div>
     </b-navbar> 
</template>
<script>
    
// import Burger from "./Burger";
// import Sidebar from "./SlideBar";
export default {
  name: 'MenuBarLinks',
  components: {
    // Burger,
    // Sidebar
  },
  data () {
    return {
      isOpen: false,
      searchSvg:'',
      customer: '/dictionary/customer',
      employee: '/dictionary/employee'
    };
  },
  methods: {
    toggle() {
      this.isOpen = !this.isOpen
     }
  },
  created(){
    this.searchSvg= require (`/src/assets/icon/search-eye-line.svg`)
  }
  
};
</script>
<style>

html {
  height: 100%;
  overflow: hidden;
}

body {
  border: 0;
  margin: 0;
  padding: 0;
  font-family: "Lato";
  height: 100%;
 
}

.logo {
  align-self: center;
  color: #fff;
  font-weight: bold;
  font-family: "Lato";
}

.main-nav {
  display: flex;
  justify-content: space-between;
  padding: 0.5rem 0.8rem;
}

ul.sidebar-panel-nav {
  list-style-type: none;
}

ul.sidebar-panel-nav > li > a {
  color: #fff;
  text-decoration: none;
  font-size: 1.5rem;
  display: block;
  padding-bottom: 0.5em;
}
</style>



