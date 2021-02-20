<template>
  <div>
    <ValidationObserver>
    <div
      class="m-dialog dialog-detail"
      title="Ghi tăng tài sản"
      
    >
      <div class="dialog-modal"></div>
      <div class="dialog-content">
        <div class="dialog-header">
          <div class="dialog-header-title">Ghi tăng tài sản</div>
          <div class="dialog-header-close">
            <button v-on:click="btnCancelOnClick">x</button>
          </div>
        </div>
        <div class="dialog-body">
          <div class="m-row m-flex">
            
            <div class="m-col el-left m-flex-4">
              <hr class="hr-group-label" />
              <div class="m-row mg-top-0 m-flex">
                <div class="m-col m-flex-1">
                  <div class="m-label">
                    Mã tài sản (<span class="label-required">*</span>)
                  </div>
                  <ValidationProvider  rules="required" v-slot="{errors}" >
                      <div
                                hasFeedback
                                :validateStatus="validate(errors[0])"
                                :help='errors[0]'
                                class="m-control">
                      <span style="color:red" v-for="(error, index) in errors" :key="index">{{error}}</span>
                    <input
                      class="input-required"
                      type="text"
                      v-model="asset.assetCode"
                    />
                  </div>
                  </ValidationProvider>
                </div>
                <div class="m-flex-1 mg-left-10px">
                  <div class="m-label">
                    Tên tài sản (<span class="label-required">*</span>)
                  </div>
                  <ValidationProvider  rules="required" v-slot="{errors}" >
                  <div class="m-control">
                    <span style="color:red" v-for="(error, index) in errors" :key="index">{{error}}</span>
                    <a-input 
                                hasFeedback
                                :validateStatus="validate(errors[0])"
                                :help='errors[0]'
                                class="input-required"
                                type="text"
                                required
                                v-model="asset.assetName"
                    />
                    
                  </div>
                  </ValidationProvider>
                </div>
              </div>



              <div class="m-row mg-top-0 m-flex">
                <div class="m-col m-flex-1">
                  <div class="m-label">
                    Mã phòng ban 
                  </div>
                  <div class="m-control">
                    <select v-model="asset.departmentId">
                      <option v-for="option in department" v-bind:value="option.departmentId" :key="option.departmentId">
                        {{ option.departmentCode }}
                      </option>
                    </select>
                  </div>
                </div>
                <div class="m-flex-1 mg-left-10px">
                  <div class="m-label">
                    Tên phòng ban 
                  </div>
                  <div class="m-control">
                    <input
                      
                      class="input-required"
                      type="text"
                      v-model="selectedDeparentmentName"
                    />
                  </div>
                </div>
              </div>



              <div class="m-row mg-top-0 m-flex">
                <div class="m-col m-flex-1">
                  <div class="m-label">
                    Mã loại tài sản 
                  </div>
                  <div class="m-control">
                    <select v-model="asset.assetTypeId">
                      <option v-for="option in assetType" v-bind:value="option.assetTypeId" :key="option.assetTypeId">
                        {{ option.assetTypeCode }}
                      </option>
                    </select>
                    
                  </div>
                </div>
                <div class="m-flex-1 mg-left-10px">
                  <div class="m-label">
                    Tên tài sản 
                  </div>
                  <div class="m-control">
                    <input
                      fieldName="FullName"
                      class="input-required"
                      type="text"
                      v-model="selectedassetTypeName"
                    />
                  </div>
                </div>
              </div>






              <div class="m-row m-flex">
                <div class="m-flex-1">
                  <div class="m-label">Ngày ghi tăng</div>
                  <input
                    class="m-combobox-input"
                    type="date"
                    autocomplete="on"
                    v-model="asset.increaseDate"
                  />
                </div>
                <div class="m-flex-1 mg-left-10px">
                  <ValidationProvider  rules="int" v-slot="{errors}" >
                  <div class="m-label">Thời gian sử dụng</div>
                  <span style="color:red" v-for="(error, index) in errors" :key="index">{{error}}</span>
                  <input         hasFeedback
                                :validateStatus="validate(errors[0])"
                                :help='errors[0]'
                    class="m-combobox-input"
                    type="number"
                    v-model="asset.timeUse"
                  />
                  </ValidationProvider>
                </div>
                <div class="m-flex-1 mg-left-10px">
                  <ValidationProvider  rules="int" v-slot="{errors}" >
                  <div class="m-label">Tỉ lệ hao mòn</div>
                  <span style="color:red" v-for="(error, index) in errors" :key="index">{{error}}</span>
                  <input        hasFeedback
                                :validateStatus="validate(errors[0])"
                                :help='errors[0]'
                    class="m-combobox-input"
                    type="number"
                    v-model="asset.wearRate"
                  />
                  </ValidationProvider>
                </div>
              </div>
              <div class="m-row m-flex">
                <div class="m-flex-1">
                  <div
                    class="m-label"
                    title="Giá trị nguyên gốc"
                  >
                    Giá trị nguyên gốc
                  </div>
                  <ValidationProvider  rules="int" v-slot="{errors}" >
                    
                  <div class="m-control">
                    <span style="color:red" v-for="(error, index) in errors" :key="index">{{error}}</span>
                    <input       hasFeedback
                                :validateStatus="validate(errors[0])"
                                :help='errors[0]'
                      id="txtIdentityNumber"
                      type="number"
                      
                      v-model="asset.originalPrice"
                    />
                  </div>
                  </ValidationProvider>
                </div>
                <div class="m-flex-1 mg-left-10px">
                  <ValidationProvider  rules="int" v-slot="{errors}" >
                  <div class="m-label">Giá trị hao mòn năm </div>
                  <span style="color:red" v-for="(error, index) in errors" :key="index">{{error}}</span>
                  <input         hasFeedback
                                :validateStatus="validate(errors[0])"
                                :help='errors[0]'
                    class="m-combobox-input"
                    type="number"
                    autocomplete="off"
                    v-model="asset.wearValue"
                  />
                  </ValidationProvider>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="dialog-footer">
          <button id="btnCancel" class="m-btn m-btn-default m-btn-cancel" v-on:click="btnCancelOnClick">
            Hủy
          </button>
          <button id="btnSave" class="m-btn m-btn-default" v-on:click="btnSave" >
            <span class="btn-text">Lưu</span>
          </button>
        </div>
      </div>
    </div>
    </ValidationObserver>
  </div>
</template>
<script>
import { ValidationProvider, ValidationObserver, extend } from 'vee-validate';
import { required } from 'vee-validate/dist/rules';
 extend('required', {
    ...required,
    message: 'Trường này cần có giá trị'
  });
  extend('int', {
    validate: value => {
      return !Number.isInteger(value);
    },
    message: 'không phải số nguyên'
  });
const labelCol = {
    xs: { span: 24 },
    sm: { span: 6 },
  }
  const wrapperCol = {
    xs: { span: 24 },
    sm: { span: 15 },
  }
export default {
  props: ['isHide', 'employee1', 'isCreate', 'assetTypeParent', "departmentParent"],
  components: {
      ValidationProvider,
      ValidationObserver
  },

  computed: {
      selectedassetTypeName: function(){
        if(this.asset.assetTypeId == null){
          return "No content"
        }
        else {

        
        let i = 0
        for( i = 0; i< this.assetType.length; i++){
          if(this.assetType[i].assetTypeId === this.asset.assetTypeId){
            
            break
          }
        }
        return this.assetType[i].assetTypeName
        }
      },
      selectedDeparentmentName: function(){
        if(this.asset.departmentId == null){
          return "không có phòng ban"
        }

        else {
          let i = 0;
          for( i = 0; i< this.department.length; i++){
            if(this.department[i].departmentId === this.asset.departmentId)
            break
          }
          return this.department[i].departmentName
        }
        
      }

  },

  methods: {
    btnAddOnClick() {
      this.isHide = false;
    },
   validate(error) {
        if (error == null) {
          return "success";
        }
        else {
          return "error";
        }
      },
    btnCancelOnClick() {
      this.$emit('canclePostForm',true);
    
      
    },
    rowOnClick(employee) {
      alert(employee.fullName);
    },
    btnSave(){
      
      if(this.asset.assetId == null){
        this.$emit('Create-event',true )
      }
      else {
        this.$emit('Create-event',false )
      }
      this.$emit("save-employee", this.asset )
    }
  },

  created(){
    if(this.employee1 != null){
      this.asset = {...this.employee1};
    }
    
      this.assetType = this.assetTypeParent
      this.department = this.departmentParent
  },

  data() {
    return {
      assetType: [],
      department: [],
      labelCol,
      wrapperCol,
      errors: [],

      dialog: false,
      display: "none",

      asset: {
        assetId : null,
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
            
      }
    };
  },
};
</script>
<style scoped>
table, th, td {
  border: 1px solid black;
  border-collapse: collapse;
}
.isHide {
  display: none;
}
.m-dialog {
  z-index: 999;
}

.dialog-header {
  position: relative;
  height: 40px;
  line-height: 60px;
  padding-left: 16px;
  display: flex;
  font-size: 24px;
}

.dialog-header-close {
  position: absolute;
  right: 16px;
  width: 24px;
  height: 24px;
  border-radius: 50%;
  cursor: pointer;
  top: 10px;
  align-items: center;
  border: none;
  background-color: transparent;
  font-size: 24px;
  line-height: 24px;
}
.dialog-modal {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  background-color: black;
  opacity: 0.4;
}

.dialog-content {
  position: fixed;
  border-radius: 5px;
  width: 750px;
  background-color: #fff;
  left: calc(50% - 325px);
  top: calc(70% - 450px);
}
.dialog-body {
  padding: 0 16px 16px 16px;
}
.dialog-footer {
  display: flex;
  width: 100%;
  height: 60px;
  background-color: #e9ebee;
  border-radius: 0 0 5px 5px;
  align-items: center;
  justify-content: flex-end;
  padding: 12px 24px;
  box-sizing: border-box;
}
.el-avatar-employee {
  padding-top: 16px;
  padding-right: 16px;
}
.el-avatar-note {
  font-size: 12px;
}
.el-avatar-employee .el-avatar {
  border: 1px solid #ccc;
  width: 160px;
  height: 160px;
  margin: 0 auto;
  border-radius: 50%;
  cursor: pointer;
  background-image: url(/content/img/default-avatar.jpg);
  background-repeat: no-repeat;
  background-position: center;
  background-size: cover;
}
.currency-for-input {
  position: absolute;
  right: 40px;
  line-height: 40px;
  font-style: italic;
}
</style>