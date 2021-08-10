<template>
  <div class="page-wrapper">
    <div class="page-header">
      <div class="row align-items-end">
        <div class="col-lg-8">
          <div class="page-header-title">
            <div class="d-inline">
              <h4>Asset Movement</h4>
              <span>Move Asset To Another Location</span>
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

    <!-- <div v-if="errors" class="has-error"> {{ [errors] }}</div>
    <div v-if="responseMessage" class="has-error"> {{ responseMessage }}</div> -->

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
        <form @submit.prevent="checkForm"  method="post">
          <div class="card-body">
            <div class="row">
              <div class="col-sm-8 col-md-8 col-xl-8 m-b-30">
                <h4 class="sub-title">Asset Description</h4>
                <select
                  name="assetdesc"
                  v-model="objectBody.assetCode"
                  @change="getUnitCodeDescription()"
                  class="form-control form-control-inverse"
                >
                  <option
                    v-for="asset in assetList"
                    v-bind:value="asset.assetCode"
                    v-bind:key="asset.assetCode"
                    required
                  >
                    {{ asset.assetDesc }}
                  </option>
                </select>
              </div>

              <div class="row">
                <div class="col-sm-4 col-md-4 col-xl-8 m-b-30">
                <label class="form-label">Movement Date</label>
                <vuejsDatepicker 
                   input-class="form-control" 
                   name="movedate"
                   type="date"
                   v-model="objectBody.movedate"
                   required
                   > 
                </vuejsDatepicker>
              </div>
              </div>
            </div>
            <div class="row">
              <div class="col-sm-8 col-md-18 col-xl-8 m-b-30">
                <div class="form-group">
                  <label class="sub-title">OLD LOCATION</label>
                  <input
                    name="oldlocation"
                    placeholder="Current Location"
                    v-model="objectBody.unitCodeDescription"
                    class="form-control"
                    readonly
                  />
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-sm-8 col-md-18 col-xl-8x m-b-30">
                <h4 class="sub-title">NEW LOCATION</h4>
                <select
                  name="assetlocation"
                  v-model="objectBody.newUnitCode"
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
            </div>
            <div class="row">
              <div class="col-6">
                <div role="group" class="btn-group mr-2 sw-btn-group-extra">
                  <button 
                    v-if="this.objectBody.movedate != '' && this.objectBody.newUnitCode != ''"
                    v-on:click="checkForm" 
                    type="submit" 
                    class="btn btn-submit btn-primary"
                  >
                    Accept
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
      errors: [],
      responseMessage: "",
      assetList: null,
      costCenterList: null,
      canProcess: true,
      objectBody: {
        assetCode: "",
        newUnitCode: "",
        movedate: "",
        oldUnitCode: "",
        unitCodeDescription: "",
      },
    };
  },

  mounted() {
    axios
      .get("/api/AssetMovement/getAllAssets")
      .then((response) => (this.assetList = response.data));

    axios
      .get("/api/AssetMovement/getAllCostCenters")
      .then((response) => (this.costCenterList = response.data));
  },

  computed: {},

  methods: {
    checkForm: function (e) {

      this.errors = [];

      if (this.objectBody.assetCode == "") 
          this.errors.push("Asset required.");
          //this.onEmptyField();

      if (this.objectBody.newUnitCode == "")
          this.errors.push("New Locatiion Required.");
          //this.onEmptyField();

      if (this.objectBody.movedate == "") 
          this.errors.push("Date required.");
          //this.onEmptyField();

      if (
        this.objectBody.assetCode &&
        this.objectBody.newUnitCode &&
        this.objectBody.movedate
      ) {
        this.errors = [];
        this.postPost();
      }

      e.preventDefault();
    },

    postPost() {
      axios
        .put(`/api/AssetMovement/updateAssetUnitCode/`, this.objectBody)
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

      this.$alert("Asset Movement Successful!!!", "Ok", "success");
    },

    getUnitCodeDescription() {
      axios
        .get(
          `/api/AssetMovement/getUnitDescByAssetCode/${this.objectBody.assetCode}`
        )
        .then((response) => {
          this.objectBody.oldUnitCode = response.data.oldUnitCode;
          this.objectBody.unitCodeDescription =
            response.data.data.unitCodeDescription;
          console.log(response.data.data);
        });
    },

    onCancel() {
      this.errors = [];

      this.objectBody.assetCode = "";
      this.objectBody.assetCode = "";
      this.objectBody.newUnitCode = "";
      this.objectBody.newUnitCode = "";
      this.objectBody.movedate = "";
      this.objectBody.movedate = "";
      this.objectBody.unitCodeDescription = "";
      this.objectBody.unitCodeDescription = "";
    },

    onEmptyField(){
      this.objectBody.assetCode = "";
      this.objectBody.assetCode = "";
      this.objectBody.newUnitCode = "";
      this.objectBody.newUnitCode = "";
      this.objectBody.movedate = "";
      this.objectBody.movedate = "";
      this.objectBody.unitCodeDescription = "";
      this.objectBody.unitCodeDescription = "";
    }
  },
};
</script>