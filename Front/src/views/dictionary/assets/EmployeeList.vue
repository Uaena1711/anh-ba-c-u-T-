<template>
  <div class="content-body">
    <div class="header-content">
      <div class="title">Danh sách Tài sản</div>
      <div class="content-feature">
        <button
          id="btnAdd"
          class="m-btn m-btn-default"
          v-on:click="btnAddOnClick"
        >
          <div class="m-btn-icon icon-add"></div>
          <div class="btn-text">Thêm</div>
        </button>
        <Details
          v-if="!ishideParent"
          v-on:canclePostForm="cancleForm"
          v-on:Create-event="updateArray"
          v-on:save-employee="save"
          :assetTypeParent="this.assetType"
          :isHide='this.ishideParent'
          :employee1='this.selectedEmployee'
          :departmentParent='this.department'
          />
      </div>
    </div>
    <div class="filter-bar">
      <div class="filter-left">
        <input
          id="txtSearchEmployee"
          class="icon-search input-search"
          type="text"
          placeholder="Tìm kiếm theo Mã  hoặc Tên"
          v-model="filterText"
        />
        <select v-model="filterAssetTypeId">
                      <option v-for="option in assetType" v-bind:value="option.assetTypeId" :key="option.assetTypeId">
                        {{ option.assetTypeCode }}
                      </option>
        </select>
        <select v-model="filerDepartmentId">
                      <option v-for="option in department" v-bind:value="option.departmentId" :key="option.departmentId">
                        {{ option.departmentCode }}
                      </option>
        </select>
        <input
          type="number"
          v-model="filterYear"
        />
      </div>
      <div id="search-icon-me" >

        <a-icon type="search" :style="{ fontSize: '25px', color: '#FF69B4'}" v-on:submit.prevent="filterData" @click="filterData" />
      </div>
      <div class="filter-right"> 
        <button :disabled='this.hasDelete' v-on:submit.prevent="multiDelete" @click="multiDelete" >
          <a-icon type="delete" :style="{ fontSize: '25px' ,color: '#FF0000', border: '1px' }" />
        </button>
      </div>
      
    </div>


    <div id="table-scroll"
      class="grid grid-employee el-table el-table--fit el-table--scrollable-y el-table--enable-row-hover el-table--enable-row-transition"
    >
      <table
        id="header-fixed"
        cellspacing="0"
        cellpadding="0"
        border="0"
        class="el-table__body"
        style="min-width: 100%"
      >
        <thead class="has-gutter">
          <tr class="el-table__row">
            <th
              colspan="1"
              rowspan="1"
              class="el-table_30_column_114 is-leaf"
              fieldName="STT"
            >
              <div class="cell">STT</div>
            </th>
            <th
              colspan="1"
              rowspan="1"
              class="el-table_30_column_116 is-leaf"
              fieldName="IncreaseDate"
              formatType="dd/mm/yyyy"
              
            >
              <div class="cell">Ngày ghi tăng</div>
            </th>
            <th
              colspan="1"
              rowspan="1"
              class="el-table_30_column_115 is-leaf"
              fieldName="AssetCode"
            >
              <div class="cell">Mã tài sản</div>
            </th>
            <th
              colspan="1"
              rowspan="1"
              class="el-table_30_column_116 is-leaf"
              fieldName="AssetName"
            >
              <div class="cell">Tên tài sản</div>
            </th>
            
            <th
              colspan="1"
              rowspan="1"
              class="el-table_30_column_116 is-leaf"
              fieldName="AssetTypeId"
            >
              <div class="cell">Loại tài sản</div>
            </th>
            <th
              colspan="1"
              rowspan="1"
              class="el-table_30_column_116 is-leaf"
              fieldName="departmentId"
            >
              <div class="cell">Tên phòng ban</div>
            </th>
            <th
              colspan="1"
              rowspan="1"
              class="el-table_30_column_116 is-leaf"
              fieldName="orginalPrice"
            >
              <div class="cell">Nguyên giá </div>
            </th>
            <th
              colspan="1"
              rowspan="1"
              class="el-table_30_column_116 is-leaf"
              fieldName="orginalPrice"
            >
              <div class="cell">Hành động </div>
            </th>
            
            <th
              colspan="1"
              rowspan="1"
              class="el-table_30_column_116 is-leaf"
              fieldName="orginalPrice"
            >
              <div class="cell">Chọn</div>
            </th>
          </tr>
        </thead>
        <tbody>
          <tr
            class="el-table__row"
            v-for="(asset, index) in pageEmployee"
            :key="index"
            
          >
          <td>
              <div class="cell">{{ index +1 }}</div>
            </td>
            <td>
              <div class="cell">{{ asset.increaseDate | formatDate  }}</div>
            </td>
            <td>
              <div class="cell">{{ asset.assetCode }}</div>
            </td>
            <td>
              <div class="cell">{{ asset.assetName }}</div>
            </td>
            <td>
              <div class="cell">{{ formatAssetType (asset.assetTypeId)  }}</div>
            </td>
            <td>
              <div class="cell">{{ formatDepartment( asset.departmentId)}}</div>
            </td>
            <td>
              <div class="cell">{{ asset.originalPrice | formatMoney }}</div>
            </td>

            <td>
            
                  <a-icon  @click="rowOnClick(asset)" type="profile" />
            
                  <a-icon v-on:submit.prevent="deleteAsset" @click="deleteAsset(asset.assetId)"  type="delete" />
                
                  <a-icon @click="btnCopyClick(asset)" type="edit" />
              
            </td>
            <td>
              <input type="checkbox"  v-bind:value="asset.assetId" v-model="selectedForDelete"> 
              
            </td>
            
          </tr>
        </tbody>
      </table>
    </div>
    <div class="paging-bar">
      <jw-pagination :pageSize = "13"
        :items="assets"
        @changePage="onChangePage"
        :labels="customLabels"
      ></jw-pagination>
    </div>
    
  </div>
</template>
<script>
import * as axios from "axios";
import Details from "./EmployeeProfileDetail";
import moment from 'moment';


const customLabels = {
    first: '<<',
    last: '>>',
    previous: '<',
    next: '>'
};

export default {
  name: "Employees",

  components: {
    Details
  },

  filters:{
          formatDate: function(value) {
          if (value) {
          return moment(String(value)).format('DD/MM/YYYY')
  }
          else {
          return "Không có ngày ghi tăng"
  }
},
        formatMoney: function(value){
          if(value){
            return value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")

          }
          else {
            return "Không có nguyên giá"
          }
        }
        


  },
  methods: {
    btnAddOnClick() {
      this.selectedEmployee = this.createAsset;
      this.ishideParent = false;
    
    },
    btnCopyClick(asset){
      this.selectedEmployee = {...asset}
      this.selectedEmployee.assetId = null
      this.selectedEmployee.assetCode = null
      this.selectedEmployee.assetName = null
      this.ishideParent = false;

    },
    formatDepartment(value){
         if(value == null|| value === ""){
            return "không có phòng"
          }
          if(this.department.length !=0){
            let i=0
            for( i = 0; i< this.department.length; i++){
              if(this.department[i].departmentId === value) break
            }
            return this.department[i].departmentName
          }
          else {
            return ""
          }
        },
    formatAssetType(value){
          if(value == null || value === ""){
            return "không có kiểu"
          }
          if(this.assetType.length !=0){
            let i=0
            for( i = 0; i< this.assetType.length; i++){
              if(this.assetType[i].assetTypeId === value) break
            }
            return this.assetType[i].assetTypeName
          }
          else {
            return ""
          }
        },
    onChangePage(xxx) {
      // update page of items
      this.pageEmployee = xxx;
    },
    rowOnClick(asset){
      this.selectedEmployee = asset;
      
      this.ishideParent = false;
      
    },
    cancleForm(value){
      this.ishideParent = value;
    },
    async save(value){
      if(this.isCreate == true){
          this.assets.push(value);
        
          await axios.post('https://localhost:44312/api/v1/Asset/', value)
          .then(
            response => {
              console.log(response)
              if(response.status == 201){
                alert("Thêm thành công")
              }
              else {
                alert(response.data.userMsg)
              }
            }
          )
          this.cancleForm(true)

      }
      
      else {
        await axios.put('https://localhost:44312/api/v1/Asset', value).then(
            response => {
              if(response.status == 201){
                alert("Sửa thành công")
              }
            }
          )
          .catch(function(error){
                console.log(error)
          })
        for(let i = 0; i< this.assets.length; i++){
          if(this.assets[i].id == value.assetId){
            this.assets[i] = value;
          }
        }
        this.cancleForm(true)
      }
    
    },

    async filterData(){
        await axios.get('https://localhost:44312/api/v1/Asset/filter', {
          params: {
          filter: this.filterText,
          year: this.filterYear,
          DepartId: this.filerDepartmentId,
          TypeId: this.filterAssetTypeId

                }
              })
              .then(response => {
                
                  this.assets = response.data    
                
              })
              .catch( (e)=> console.log(e))

    },

    async deleteAsset(asssetId){
      if(confirm("Bạn có chắc muốn xóa tài sản này khỏi danh sách?")) {

        
        await axios.delete('https://localhost:44312/api/v1/Asset/'+asssetId ).then(
          response => {
            for(let i = 0; i< this.assets.length ; i++){
            if(this.assets[i].assetId === asssetId ){
            this.assets.splice(i,1)
            if(response.status == 204){
              alert("Xóa thành công")
            }
          }
        }
      });
        
      } 
    },
    async multiDelete(){
      if(confirm("Bạn có chắc chắn muốn xóa những tài sản đã chọn")){
        for(let i = 0 ; i< this.selectedForDelete.length; i++){
              await axios.delete('https://localhost:44312/api/v1/Asset/'+this.selectedForDelete[i] ).then(
              response => {
                if(response.status == 204){
                this.assets.splice(this.assets.findIndex( a => a.assetId === this.selectedForDelete[i]),1)
                }
          });
        }
        this.selectedForDelete = []
      }
    },
    updateArray(isCreate){
      this.isCreate = isCreate;
    }
  },

  

  data() {
    return {
      assetType: [],
      department:[],
      selectedForDelete: [],
      ishideParent: Boolean,
      isCreate: Boolean,
      selectedEmployee: {
      
      },

      createAsset: {
        assetCode: null,
        assetName: null,
        increaseDate: null,
        timeUse: 0,
        wearRate: 0,
        originalPrice: 0,
        wearValue: 0,
        isUsed: Boolean,
        assetTypeId: null,
        departmentId: null
            
      },
      customLabels,
      assets: [],
      pageEmployee:[],
      filterText: null,
      filterYear: null,
      filterAssetTypeId: null,
      filerDepartmentId: null
    };
  },
  async created() {
    
    const res2= await axios.get("https://localhost:44312/api/v1/AssetType")
    this.assetType = res2.data
    this.assetType.unshift({
      assetTypeId: null,
      assetTypeCode: "Tất cả loại tài sản"
    })

    

    const res3 = await axios.get("https://localhost:44312/api/v1/Department").catch((e) => console.log(e))
    this.department = res3.data;
    this.department.unshift({
      departmentId: null,
      departmentCode: "Tất cả phòng ban"
    })
    const response = await axios.get("https://localhost:44312/api/v1/Asset/filter").catch((e) => console.log(e)

    )
    this.assets = response.data;     
  },
  computed: {
    hasDelete: function(){
      if(this.selectedForDelete.length!== 0){
        return false
      }
      else 
      return true
    }
  }
};
</script>
<style lang="scss" scoped>

#table-scroll {
  height:612px;
  overflow:auto;  
  margin-top:20px;
}

table, th, td {
  border: 1px solid black;
  border-collapse: collapse;
}
.grid-employee {
  margin-top: 10px;
  height: calc(100vh - 234px);
}

.el-avatar-employee {
  padding-top: 16px;
  padding-right: 16px;
}

.el-left {
  width: calc(100% - 180px);
}

.el-avatar-employee .el-avatar {
  border: 1px solid #ccc;
  width: 160px;
  height: 160px;
  margin: 0 auto;
  border-radius: 50%;
  cursor: pointer;
  /* background-image: url("/assets/img/default-avatar.jpg"); */
  background-repeat: no-repeat;
  background-position: center;
  background-size: cover;
}

.el-avatar-note {
  font-size: 12px;
}
.filter-left {
  display: flex;
}
.filter-left select {
  margin-left: 10px;
  margin-right: 10px;
}

.currency-for-input {
  position: absolute;
  right: 40px;
  line-height: 40px;
  font-style: italic;
}

#txtSearchEmployee {
  min-width: 300px;
}
</style>

