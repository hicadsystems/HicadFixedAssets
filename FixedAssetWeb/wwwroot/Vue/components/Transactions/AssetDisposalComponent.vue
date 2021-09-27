<template>
    <div>
         <!-- Confirm pop-up -->
       <vue-confirm-dialog></vue-confirm-dialog>

       <div class="page-wrapper">
           <div class="page-header">
                <div class="row align-items-end">
                <div class="col-lg-8">
                    <div class="page-header-title">
                       <div class="d-inline">
                           <h4>Asset Disposal</h4>
                           <span>Perform Asset Disposal</span>
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
        <form @submit.prevent="" method="post">
          <div class="card-body">
            <div class="row">
              <div class="col-sm-6 col-md-6 col-xl-6 m-b-30">
                <label class="from-label">Asset Description</label>
                <select
                  name="assetdesc"
                  v-model="assetCode"
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
            </div>
            <div class="row">
              <div class="col-6">
                <div role="group" class="btn-group mr-2 sw-btn-group-extra">
                  <button
                    @click.prevent="sortingProcess()"
                    type="submit"
                    class="btn btn-submit btn-primary"
                  >
                    Accept
                  </button>
                </div>
              </div>
            </div>
          </div>
        </form>
      </div>
    </div>

    <!-- ASSET TABLE -->
        <div v-if="!isFormVisible">
            <div class="page-body">
                <div class="card">
                    <div class="card-body">
                        <table id="datatables-buttons" class="table table-striped" style="width:100%">
                            <thead>
                                <tr>
                                    <th>Asset Description</th>
                                    <th>Department</th>
                                    <th>Classification</th>
                                    <th>Current Amount</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr v-for="(deprAsset,index) in DeprAssetsList" :key="index">
                                    <td>{{ deprAsset.assetdesc }}</td>
                                    <td>{{ deprAsset.newloc }}</td>
                                    <td>{{ deprAsset.newclass }}</td>
                                    <td>{{ deprAsset.depreciation }}</td>
                                    <td>
                                        <button type="button" class="btn btn-submit btn-danger" @click="disposeAsset(deprAsset.assetdesc, deprAsset.depreciation )" >Dispose</button>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
       </div>
    </div>
</template>

<script>
import vuejsDatepicker from "vuejs-datepicker";
import VueSimpleAlert from "vue-simple-alert";
import moment from "moment";

export default {
  components: {
    vuejsDatepicker,
    VueSimpleAlert,
    moment,
  },

  data() {
    return {
      errors: [],
      isFormVisible: false,
      responseMessage: "",
      DeprAssetsList: null,
      assetList: null,
      assetCode: "",
    };
  },

  mounted() {
    axios
      .get("/api/AssetReclassification/getAllAssets")
      .then((response) => (this.assetList = response.data));
  },

  methods: {
    sortingProcess() {
      axios
        .get(`/api/GenerateDepreciation/depreciationSummary/${this.assetCode}`)

        .then((response) => {
          if (response.data.responseCode === 404) {
            this.$alert(
              `No Asset available for the selected Parameter!!`,
              "No Records Found",
              "Warning"
            );
          }

          console.log(response.data.data);

          this.DeprAssetsList = response.data.data;
        });
    },

    disposeAsset(assetdesc, amount) {
      this.$confirm({
        message: "Dispose " + assetdesc + " ?",
        button: {
          no: "NO",
          yes: "YES",
        },
        callback: (confirm) => {
          if (confirm) {
            alert("Dispose " + this.assetCode + " " + assetdesc);
            axios
              .get(`/api/AssetDisposal/assetDisposalAction/${this.assetCode}/${amount}`)
              .then((response) => {
                if (response.data.responseCode == "200") {
                  this.$alert(
                    assetdesc + " Disposed Successfully!!!",
                    "Ok",
                    "success"
                  );
                }
              })
              .catch((e) => {
                this.errors.push(e);
              });
            }
        },
      });
    },
  },
};
</script>