<template>
  <div>
    <!-- Asset Registration Form -->
    <div v-if="isFormVisible" class="page-wrapper">
    <div class="page-header">
      <div class="row align-items-end">
        <div class="col-lg-8">
          <div class="page-header-title">
            <div class="d-inline">
              <h4>Asset Registration Form</h4>
              <span>ADD NEW ASSET</span>
            </div>
          </div>
        </div>
        <div class="col-lg-4">
          <div class="page-header-breadcrumb">
            <ul class="breadcrumb-title">
              <li class="breadcrumb-item">
                <a href="index.html"> <i class="feather icon-home"></i> </a>
              </li>
              <li class="breadcrumb-item">
                <a href="#!">Data Table</a>
              </li>
              <li class="breadcrumb-item">
                <a href="#!">Styling</a>
              </li>
            </ul>
          </div>
        </div>
      </div>
    </div>

    <!-- <div v-if="errors" class="has-error">{{ this.errors }}</div>
    <div v-if="responseMessage" class="has-error">{{ responseMessage }}</div> -->

  <p v-if="errors.length">
    <b>Please correct the following error(s):</b>
    <ul>
      <li 
          v-for="error in errors" 
          v-bind:key="error.length">
          <h6 style="color: red;" class="has-error"> {{ error }} </h6>
      </li>
    </ul>
  </p>

    <div class="page-body">
      <div class="card">
        <form @submit.prevent="checkForm" method="post">
          <div class="card-body">
            <div class="row">
              <div class="col-sm-3 col-md-3 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">ASSET CODE</label>
                            <input 
                              type="text" 
                              name="assetcode" 
                              class="form-control form-control-inverse"
                              v-model="objectBody.assetCode"
                              :readonly="CreateOrUpdate == 'Update'" 
                            />
                        </div>
                </div>
                <div class="col-sm-9 col-md-9 col-xl-9">
                        <div class="form-group">
                            <label class="form-label">ASSET DESCRIPTION</label>
                            <input 
                              type="text" 
                              name="assetdesc" 
                              class="form-control form-control-inverse"
                              v-model="objectBody.assetDesc" 
                            />
                        </div>
                </div>
            </div>
            <div class="row">
              <div class="col-sm-9 col-md-9 col-xl-9 m-b-30">
                <label class="form-label">ASSET CLASSIFICATION</label>
                <select
                  name="assetclass"
                  v-model="objectBody.class"
                  class="form-control form-control-inverse"
                  required
                >
                  <option
                    v-for="clist in classList"
                    v-bind:value="clist.classcode"
                    v-bind:key="clist.classcode"
                    required
                  >
                  {{ clist.classdesc }}
                  </option>
                </select>
              </div>
              <div class="col-sm-3 col-md-3 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">DEPRECIATION RATE</label>
                            <input 
                              type="number" 
                              name="deprate"
                              v-model="objectBody.depr_rate" 
                              class="form-control form-control-inverse"
                            />
                        </div>
                </div>
            </div>

            <div class="row">
              <div class="col-sm-6 col-md-6 col-xl-6 m-b-30">
                <label class="form-label">DEPARTMENT</label>
                <select
                  name="assetclass"
                  v-model="objectBody.dept"
                  class="form-control form-control-inverse"
                  required
                >
                  <option
                    v-for="clist in costCenterList"
                    v-bind:value="clist.unitcode"
                    v-bind:key="clist.unitcode"
                    required
                  >
                  {{ clist.unitdesc }}
                  </option>
                </select>
              </div>
              <div class="col-sm-6 col-md-6 col-xl-6 m-b-30">
                <label class="form-label">BUSINESS LINE</label>
                <select
                  name="assetclass"
                  v-model="objectBody.busline"
                  class="form-control form-control-inverse"
                  required
                >
                  <option
                    v-for="blist in businessLineList"
                    v-bind:value="blist.code"
                    v-bind:key="blist.code"
                    required
                  >
                  {{ blist.description }}
                  </option>
                </select>
              </div>
              
            </div>

            <div class="row">
                <div class="col-sm-4 col-md-4 col-xl-4 m-b-30">
                  <label class="form-label">RECLASSIFICATION DATE</label>
                  <vuejsDatepicker
                    input-class="form-control"
                    name="reclassdate"
                    v-model="objectBody.reclassdate"
                    type="date"
                    required
                  >
                  </vuejsDatepicker>
                </div>
                <div class="col-sm-4 col-md-4 col-xl-4 m-b-30">
                  <label class="form-label">PURCHASE</label>
                  <div class="row">
                      <div class="col-sm-6 col-md-6 col-xl-6">
                          <label class="form-label">DATE</label>
                          <vuejsDatepicker
                            input-class="form-control"
                            name="purchdate"
                            v-model="objectBody.purchdate"
                            type="date"
                            required
                          >
                          </vuejsDatepicker>
                      </div>
                      <div class="col-sm-6 col-md-6 col-xl-6">
                          <div class="form-group">
                            <label class="form-label">VALUE</label>
                            <input 
                              type="number" 
                              name="purchval"
                              v-model="objectBody.purchval"
                              class="form-control form-control-inverse"
                            />
                        </div>
                      </div>
                  </div>
                </div>

                <div class="col-sm-4 col-md-4 col-xl-4 m-b-30">
                  <label class="form-label">INSURANCE</label>
                  <div class="row">
                      <div class="col-sm-6 col-md-6 col-xl-6">
                          <label class="form-label">DATE</label>
                          <vuejsDatepicker
                            input-class="form-control"
                            name="insurdate"
                            v-model="objectBody.insurdate"
                            type="date"
                            required
                          >
                          </vuejsDatepicker>
                      </div>
                      <div class="col-sm-6 col-md-6 col-xl-6">
                          <div class="form-group">
                            <label class="form-label">VALUE</label>
                            <input 
                              type="number" 
                              name="insurdval"
                              v-model="objectBody.insuredval" 
                              class="form-control form-control-inverse" 
                            />
                        </div>
                      </div>
                  </div>
                </div>
            </div>

             <div class="row">
                <div class="col-sm-4 col-md-4 col-xl-4 m-b-30">
                  <label class="form-label">LAST MOVEMENT DATE</label>
                  <vuejsDatepicker
                    input-class="form-control"
                    name="lastmovdate"
                    v-model="objectBody.movedate"
                    type="date"
                    required
                  >
                  </vuejsDatepicker>
                </div>
                <div class="col-sm-4 col-md-4 col-xl-4 m-b-30">
                  <label class="form-label">DISPOSAL</label>
                  <div class="row">
                      <div class="col-sm-6 col-md-6 col-xl-6">
                          <label class="form-label">DATE</label>
                          <vuejsDatepicker
                            input-class="form-control"
                            name="dispdate"
                            v-model="objectBody.dispdate"
                            type="date"
                            required
                          >
                          </vuejsDatepicker>
                      </div>
                      <div class="col-sm-6 col-md-6 col-xl-6">
                          <div class="form-group">
                            <label class="form-label">VALUE</label>
                            <input 
                              type="number" 
                              name="dispval"
                              v-model="objectBody.dispval"
                              class="form-control form-control-inverse" 
                            />
                        </div>
                      </div>
                  </div>
                </div>

                <div class="col-sm-4 col-md-4 col-xl-4 m-b-30">
                  <label class="form-label">REVALUATION</label>
                  <div class="row">
                      <div class="col-sm-6 col-md-6 col-xl-6">
                          <label class="form-label">DATE</label>
                          <vuejsDatepicker
                            input-class="form-control"
                            name="revaldate"
                            v-model="objectBody.revaldate"
                            type="date"
                            required
                          >
                          </vuejsDatepicker>
                      </div>
                      <div class="col-sm-6 col-md-6 col-xl-6">
                          <div class="form-group">
                            <label class="form-label">VALUE</label>
                            <input 
                              type="number" 
                              name="revalval"
                              v-model="objectBody.revalval" 
                              class="form-control form-control-inverse" 
                            />
                        </div>
                      </div>
                  </div>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-4 col-md-4 col-xl-4 m-b-30">
                    <div class="form-group">
                            <label class="form-label">ACCUMULATED DEPRECIATION VALUE</label>
                            <input 
                              type="number" 
                              name="accum_depval"
                              v-model="objectBody.accum_depre" 
                              class="form-control form-control-inverse"
                            />
                    </div>
                </div>
            </div>
            
            <div class="row">
              <div class="col-6">
                <div role="group" class="btn-group mr-2 sw-btn-group-extra">
                  <button
                    v-if="this.objectBody.assetCode != '' && this.objectBody.assetDesc != '' && this.objectBody.assetclass != '' 
                    && this.objectBody.dept !='' && this.objectBody.depr_rate !=''  "
                    v-on:click="checkForm"
                    type="submit"
                    class="btn btn-submit btn-primary"
                  >
                    {{ CreateOrUpdate }}
                  </button>
                </div>
                <div role="group" class="btn-group mr-2 sw-btn-group-extra">
                  <button @click.prevent="onCancel()" class="btn btn-danger">Cancel</button>
                </div>
              </div>
            </div>
          </div>
        </form>
      </div>
    </div>
  </div>
    <!-- End Of Asset Registration Form -->
    <!-- NAV DIV -->
    <nav v-if="!isFormVisible" aria-label="breadcrumb">
      <ol class="breadcrumb">
        <li class="breadcrumb-item" aria-current="page">
          <a @click="showForm()"><span class="btn btn-primary h5">Create Asset</span></a>
        </li>
      </ol>
    </nav>
    <!--END OF NAV DIV -->

    <!-- ASSET TABLE -->
    <div v-if="!isFormVisible">
      <div class="page-wrapper">
        <div class="page-header">
          <div class="row align-items-end">
            <div class="col-lg-8">
                <div class="page-header-title">
                  <div class="d-inline">
                    <h4>ASSET LIST TABLE</h4>
                    <span>THE LIST OF ALL ASSET</span>
                  </div>
                </div>
            </div>
            <div class="col-lg-4">
              <div class="page-header-breadcrumb">
                <ul class="breadcrumb-title">
                  <li class="breadcrumb-item">
                    <a href="index.html"> <i class="feather icon-home"></i> </a>
                  </li>
                  <li class="breadcrumb-item">
                    <a href="#!">Data Table</a>
                  </li>
                  <li class="breadcrumb-item">
                    <a href="#!">Styling</a>
                  </li>
                </ul>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div class="page-body">
        <div class="card">
          <div class="card-body">
            <table id="datatables-buttons" class="table table-striped" style="width:100%">
                <thead>
                    <tr>
                        <th>Code</th>
                        <th>Description</th>
                        <th>Classification</th>
                        <th>Location</th>
                        <th>Business Line</th>
                        <th>Purchase Value</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(assetReg,index) in assetRegList" :key="index">
                        <td>{{ assetReg.id }}</td>
                        <td>{{ assetReg.assetCode }}</td>
                        <td>{{ assetReg.assetDesc }}</td>
                        <td style="display:none;">{{ assetReg.classCode }}</td>
                        <td style="display:none;">{{ assetReg.id }}</td>
                        <td>{{ assetReg.classDesc }}</td>
                        <td style="display:none;">{{ assetReg.unitCode }}</td>
                        <td>{{ assetReg.unitDesc }}</td>
                        <td style="display:none;">{{ assetReg.busline }}</td>
                        <td>{{ assetReg.buslineDesc }}</td>
                        <td>{{ assetReg.purchval }}</td>

                        <td>
                
                            <button type="button" class="btn btn-submit btn-primary" @click="editAssetReg(assetReg.assetCode)" >Edit</button>
                            <button type="button" class="btn btn-submit btn-danger" @click="deleteAssetReg(assetReg.assetCode)" >Delete</button>
                        </td>
                    </tr>
                </tbody>
              
            </table>
          </div>
        </div>
      </div>
    </div>

  </div>
</template>


<script>
import vuejsDatepicker from "vuejs-datepicker";
import VueSimpleAlert from "vue-simple-alert";
export default {
  components: {
    vuejsDatepicker,
    VueSimpleAlert,
  },

  data() {
    return {
      isFormVisible: false,
      errors: [],
      showCreateButton: true,
      responseMessage: "",
      CreateOrUpdate: "Create",
      canProcess: true,
      classList: null,
      costCenterList: null,
      businessLineList: null,
      assetRegList: null,
      objectBody: {
        assetCode: "",
        assetDesc: "",
        class: "",
        dept: "",
        busline: "",
        purchdate: "",
        revaldate: "",
        reclassdate: "",
        movedate: "",
        dispdate: "",
        purchval: "",
        accum_depre: "",
        dispval: "",
        revalval: "",
        insurdate: "",
        insuredval: "",
        year_depr: "",
        depr_rate: "",
      },
    };
  },

  mounted() {
    axios
      .get("/api/AssetReclassification/getAllClassifications")
      .then((response) => (this.classList = response.data));

    axios
      .get("/api/AssetMovement/getAllCostCenters")
      .then((response) => (this.costCenterList = response.data));

    axios
      .get("/api/BusinessLine/getAllBusinessLine")
      .then((response) => (this.businessLineList = response.data));

    axios
      .get("/api/AssetRegisteration/getAllAssets")
      .then((response) => (this.assetRegList = response.data));
  },

  computed: {},

  methods: {
    checkForm: function (e) {
      this.errors = [];

      if (this.objectBody.assetCode == "") this.errors.push("Asset required.");

      if (this.objectBody.assetDesc == "")
        this.errors.push("Asset Description required.");

      if (this.objectBody.class == "")
        this.errors.push("Classification required.");

      if (this.objectBody.dept == "") this.errors.push("Location required.");

      if (this.objectBody.busline == "")
        this.errors.push("Business Line required.");

      if (this.objectBody.purchdate == "")
        this.errors.push("Purchase Date required.");

      if (this.objectBody.revaldate == "")
        this.errors.push("Revaluation date required.");

      if (this.objectBody.reclassdate == "")
        this.errors.push("Reclassification date required.");

      if (this.objectBody.movedate == "")
        this.errors.push("Movement date required.");

      if (this.objectBody.dispdate == "")
        this.errors.push("Disposal date required.");

      if (this.objectBody.purchval == "")
        this.errors.push("Purchase value required.");

      if (this.objectBody.accum_depre == "")
        this.errors.push("Accumulated depreciation required.");

      if (this.objectBody.dispval == "")
        this.errors.push("Disposal value required.");

      if (this.objectBody.revalval == "")
        this.errors.push("Revaluation value required.");

      if (this.objectBody.insurdate == "")
        this.errors.push("Insurance date required.");

      if (this.objectBody.insuredval == "")
        this.errors.push("Insurance value required.");

      if (this.objectBody.depr_rate == "")
        this.errors.push("Depreciation rate required.");

      if (
        this.objectBody.assetCode &&
        this.objectBody.assetDesc &&
        this.objectBody.class &&
        this.objectBody.dept &&
        this.objectBody.busline &&
        this.objectBody.purchdate &&
        this.objectBody.revaldate &&
        this.objectBody.depr_rate
      ) {
        this.errors = [];

        this.postPost();
      }

      e.preventDefault();
    },

    postPost() {
      if(this.CreateOrUpdate == "Create"){
        axios
        .post(`/api/AssetRegisteration/createAssetsreg/`, this.objectBody)
        .then((response) => {
          this.responseMessage = response.data.responseDescription;
          this.canProcess = true;

          if (response.data.responseCode == "200") {
            //this Clears the Input field.
            this.onCancel();
          }
        })
        .catch((e) => {
          this.errors.push(e);
        });

      this.$alert("Asset Created Successfully!!!", "Ok", "success");

      this.isFormVisible = false;
      }

      if(this.CreateOrUpdate == "Update"){
      
        axios
        .put(`/api/AssetRegisteration/updateAssetsreg/`, this.objectBody)
        .then((response) => {
          this.responseMessage = response.data.responseDescription;
          this.canProcess = true;

          if (response.data.responseCode == "200") {
            //this Clears the Input field.
            this.onCancel();
          }
        })
        .catch((e) => {
          this.errors.push(e);
        });

      this.$alert("Asset Updated Successfully!!!", "Ok", "success");

      this.isFormVisible = false;
      }
    },

    showForm() {
      this.isFormVisible = true;

      this.showCreateButton = false;
    },

    editAssetReg(assetCode) {
      axios
        .get(`/api/AssetRegisteration/getAssetsregByCode/${assetCode}`)
        .then((response) => {
          console.log(response.data.data);
          this.objectBody.assetCode = response.data.data.assetCode;
          this.objectBody.assetDesc = response.data.data.assetDesc;
          this.objectBody.class = response.data.data.class;
          this.objectBody.dept = response.data.data.dept;
          this.objectBody.busline = response.data.data.busline;
          this.objectBody.purchdate = response.data.data.purchdate;
          this.objectBody.revaldate = response.data.data.revaldate;
          this.objectBody.reclassdate = response.data.data.reclassdate;
          this.objectBody.movedate = response.data.data.movedate;
          this.objectBody.dispdate = response.data.data.dispdate;
          this.objectBody.purchval = response.data.data.purchval;
          this.objectBody.accum_depre = response.data.data.accum_depre;
          this.objectBody.dispval = response.data.data.dispval;
          this.objectBody.revalval = response.data.data.revalval;
          this.objectBody.insurdate = response.data.data.insurdate;
          this.objectBody.insuredval = response.data.data.insuredval;
          this.objectBody.year_depr = response.data.data.year_depr;
          this.objectBody.depr_rate = response.data.data.depr_rate;

          this.isFormVisible = true;

          this.CreateOrUpdate = "Update";
        });
    },

    deleteAssetReg(assetCode){

      axios.get(`/api/BusinessLine/RemoveBusinessLine/${assetCode}`)
            .then(response => {
              if (response.data.responseCode == '200') {

                  alert("businessline successfully deleted");

              }

              }).catch(e => {
                  this.errors.push(e)
              });
    },
 
    onCancel() {
      this.errors = [];

      this.objectBody.assetCode = "";
      this.objectBody.assetCode = "";
      this.objectBody.assetDesc = "";
      this.objectBody.assetDesc = "";
      this.objectBody.class = "";
      this.objectBody.class = "";
      this.objectBody.dept = "";
      this.objectBody.dept = "";
      this.objectBody.busline = "";
      this.objectBody.busline = "";
      this.objectBody.purchdate = "";
      this.objectBody.purchdate = "";
      this.objectBody.revaldate = "";
      this.objectBody.revaldate = "";
      this.objectBody.reclassdate = "";
      this.objectBody.reclassdate = "";
      this.objectBody.movedate = "";
      this.objectBody.movedate = "";
      this.objectBody.dispdate = "";
      this.objectBody.dispdate = "";
      this.objectBody.purchval = "";
      this.objectBody.purchval = "";
      this.objectBody.accum_depre = "";
      this.objectBody.accum_depre = "";
      this.objectBody.dispval = "";
      this.objectBody.dispval = "";
      this.objectBody.revalval = "";
      this.objectBody.revalval = "";
      this.objectBody.insurdate = "";
      this.objectBody.insurdate = "";
      this.objectBody.insuredval = "";
      this.objectBody.insuredval = "";
      this.objectBody.depr_rate = "";
      this.objectBody.depr_rate = "";
    },
  },
};
</script>

<style>
</style>