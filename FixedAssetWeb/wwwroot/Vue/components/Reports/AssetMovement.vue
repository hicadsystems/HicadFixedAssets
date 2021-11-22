<template>
  <div>
    <div>
      <div class="page-wrapper">
        <div class="page-header">
          <div class="row align-items-end">
            <div class="col-lg-8">
              <div class="page-header-title">
                <div class="d-inline">
                  <h4>ASSET MOVEMENT REPORT</h4>
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
        <form @submit="checkForm">
          <div class="card-body">
            <div class="form-group row">
              <div class="col-sm-4">
                <div class="row ml-4">
                  <div class="form-check">
                    <input
                      @click="setAllDept"
                      class="form-check-input col-6"
                      type="radio"
                      name="exampleRadios"
                      id="exampleRadios2"
                      value="option2"
                    />
                    <label class="form-check-label" for="exampleRadios2">
                      <b>All Dept</b>
                    </label>
                  </div>
                </div>
              </div>

              <div class="col-sm-4">
                <div class="row ml-4">
                  <div class="form-check">
                    <input
                      @click="SpecificDept"
                      class="form-check-input col-6"
                      type="radio"
                      name="exampleRadios"
                      id="exampleRadios2"
                      value="option2"
                    />
                    <label class="form-check-label" for="exampleRadios2">
                      <b> Specific Dept</b>
                    </label>
                  </div>
                </div>
              </div>
            </div>

            <div class="form-group row col md-4">
              <div class="col md-4" v-if="allDept">
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

              <div class="col-lg-4" v-if="specificDept">
                <div>
                  <label for=""><b>Department </b></label>
                </div>
                <div>
                  <select
                    name="assetclass"
                    v-model="sortAssetsList.classDept"
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
                <p>{{ errors.specificDept }}</p>
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
          <button 
            @click.prevent="onCancel()" 
            class="btn btn-danger"
          >
            Cancel
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
        PDF File
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
                  <th>Asset Code</th>
                  <th>Asset Description</th>
                  <th>Old Location</th>
                  <th>New Location</th>
                  <th>Movement Date</th>
                </tr>
              </thead>
              <tbody>
                <tr
                  v-for="(assetMove, index) in assetMovementList"
                  :key="index"
                >
                  <td>{{ assetMove.assetCode }}</td>
                  <td>{{ assetMove.assetdesc }}</td>
                  <td>{{ assetMove.oldloc }}</td>
                  <td>{{ assetMove.newloc }}</td>
                  <td>{{ assetMove.movedate }}</td>
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
      errors: [],
      allDept: false,
      specificDept: false,
      responseMessage: "",
      assetMovementList: null,
      costCenterList: null,
      sortAssetsList: {
        classCode: "null",
        classDept: "null",
        startDate: null,
        endDate: null,
      },
      objectBody: {
        assetCode: "",
        assetdesc: "",
        oldloc: "",
        newloc: "",
        movedate: "",
      },
    };
  },

  mounted() {
    axios
      .get("/api/AssetMovement/getAllCostCenters")
      .then((response) => (this.costCenterList = response.data));
  },

  methods: {
    setAllDept() {
      this.allDept = true;
      this.specificDept = false;
    },
    SpecificDept() {
      this.allDept = true;
      this.specificDept = true;
    },

    sortingProcess() {
      axios
        .post(`/api/AssetMovement/sortAssetMovement/`, this.sortAssetsList)

        .then((response) => {
          if (response.data.responseCode === 404) {
            this.$alert(
              `No Asset available for the selected Parameter!!`,
              "No Records Found",
              "Warning"
            );
          }

          this.assetMovementList = response.data.data;
        });
    },

    onCancel() {
      this.errors = [];

      this.sortAssetsList.classCode = "";
      this.sortAssetsList.classDept = "";
      this.sortAssetsList.startDate = "";
      this.sortAssetsList.endDate = "";
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

      window.open(
        `/Report/PrintAssetMovement/${this.sortAssetsList.classCode}/${this.sortAssetsList.classDept}/${startDay}/${endDay}`
      );
    },

    checkForm: function (e) {
      if (this.specificDept) {
        return true;
      }
      this.errors = [];

      if (!this.specificDept) {
        this.errors.push("Department required.");
      }

      e.preventDefault();
    },
  },
};
</script>