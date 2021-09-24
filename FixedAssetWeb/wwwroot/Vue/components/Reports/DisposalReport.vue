<template>
  <div>
    <div>
      <div class="page-wrapper">
        <div class="page-header">
          <div class="row align-items-end">
            <div class="col-lg-8">
              <div class="page-header-title">
                <div class="d-inline">
                  <h4>DISPOSAL REPORT</h4>
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
    </div>

    <div class="page-body">
      <div class="card">
        <form>
          <div class="card-body">
            <div class="form-group row">
              <div class="col-sm-4">
                <div class="row ml-4">
                  <div class="form-check">
                    <input
                      @click="AllDisposal()"
                      class="form-check-input col-6"
                      type="radio"
                      name="exampleRadios"
                      id="exampleRadios2"
                      value="option2"
                    />
                    <label class="form-check-label" for="exampleRadios2">
                      <b>All Disposal</b>
                    </label>
                  </div>
                </div>
              </div>
              <div class="col-sm-4">
                <div class="row ml-4">
                  <div class="form-check">
                    <input
                      @click="DispByDate()"
                      class="form-check-input col-6"
                      type="radio"
                      name="exampleRadios"
                      id="exampleRadios2"
                      value="option2"
                    />
                    <label class="form-check-label" for="exampleRadios2">
                      <b> Disposal by Date</b>
                    </label>
                  </div>
                </div>
              </div>
            </div>

            <div class="form-group row col md-4">
              <div class="col md-4" v-if="dispDate">
                <div>
                  <label for=""><b>From </b></label>
                  <vuejsDatepicker
                    v-model="sortAssetsList.startDate"
                    input-class="form-control col-4 mr-1"
                    type="date"
                  ></vuejsDatepicker>
                </div>
                <div>
                  <label for=""><b>To </b></label>
                  <vuejsDatepicker
                    v-model="sortAssetsList.endDate"
                    input-class="form-control col-4"
                    type="date"
                  >
                  </vuejsDatepicker>
                </div>
              </div>
            </div>
          </div>
          <button
            type="submit"
            class="btn btn-submit btn-primary"
            @click.prevent="sortingProcess()"
          >
            Process
          </button>
        </form>
      </div>
    </div>

    <!-- ASSET TABLE -->
    <div>
      <button
        type="button"
        class="btn btn-submit btn-primary"
        v-on:click="generateReport"
      >
        Show Report
      </button>
      <div class="page-body">
        <div class="card">
          <div class="card-body">
            <table
              id="datatables-buttons"
              class="table table-striped"
              style="width: 100%"
            >
              <thead>
                <tr>
                  <th>Code</th>
                  <th>Description</th>
                  <th>Location</th>
                  <th>Disposed Value</th>
                  <th>Disposed Date</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="(assetReg, index) in assetRegList" :key="index">
                  <td>{{ assetReg.assetCode }}</td>
                  <td>{{ assetReg.assetDesc }}</td>
                  <td>{{ assetReg.dept }}</td>
                  <td>{{ assetReg.dispval }}</td>
                  <td>{{ assetReg.dispdate }}</td>
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
import moment from "moment";
export default {
  components: {
    vuejsDatepicker,
    VueSimpleAlert,
    moment,
  },

  data() {
    return {
      dispDate: false,
      selectDisp: false,
      isFormVisible: false,
      responseMessage: "",
      assetRegList: null,
      classList: null,
      sortClassCode: "",
      sortDept: "",
      sortAssetsList: {
        classCode: "null",
        classDept: "null",
        startDate: null,
        endDate: null,
      },
      objectBody: {
        assetCode: "",
        assetDesc: "",
        dept: "",
        dispval: "",
        dispdate: "",
      },
    };
  },

  methods: {
    AllDisposal() {
      this.dispDate = false;
      this.selectDisp = true;
    },

    DispByDate() {
      this.dispDate = true;
      this.selectDisp = false;
    },

    sortingProcess() {
      axios
        .post(`/api/AssetDisposal/getDisposedAsset/`, this.sortAssetsList)

        .then((response) => {
          if (response.data.responseCode === 404) {
            this.$alert(
              `No Asset available for the selected Parameter!!`,
              "No Records Found",
              "Warning"
            );
          }

          this.assetRegList = response.data.data;
        });
    },

    generateReport() {
      let startDay = moment(this.sortAssetsList.startDate).format(
        "MM DD YYYY, h:mm:ss a"
      );

      let endDay = moment(this.sortAssetsList.endDate).format(
        "MM DD YYYY, h:mm:ss a"
      );

      if (startDay === "Invalid date" && endDay === "Invalid date") {
        startDay = null;
        endDay = null;
      }

      window.open(`/Report/PrintAssetDisposal/${startDay}/${endDay}`);
    },
  },
};
</script>