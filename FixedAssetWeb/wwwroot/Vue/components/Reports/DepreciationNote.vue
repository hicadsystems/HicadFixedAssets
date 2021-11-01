<template>
  <div>
    <div>
      <div class="page-wrapper">
        <div class="page-header">
          <div class="row align-items-end">
            <div class="col-lg-8">
              <div class="page-header-title">
                <div class="d-inline">
                  <h4>DEPRECIATION NOTE</h4>
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
                      @click="SetAllAsset"
                      class="form-check-input col-6"
                      type="radio"
                      name="exampleRadios"
                      id="exampleRadios2"
                      value="option2"
                    />
                    <label class="form-check-label" for="exampleRadios2">
                      <b>All Assets</b>
                    </label>
                  </div>
                </div>
              </div>
              <div class="col-sm-4">
                <div class="row ml-4">
                  <div class="form-check">
                    <input
                      @click="SetSpecificAsset"
                      class="form-check-input col-4"
                      type="radio"
                      name="exampleRadios"
                      id="exampleRadios2"
                      value="option2"
                    />
                    <label class="form-check-label" for="exampleRadios2">
                      <b> Specific Asset By Class </b>
                    </label>
                  </div>
                </div>
              </div>
            </div>

            <div class="form-group row col md-4">
              <div class="col-lg-4" v-if="SpecificAsset">
                <div>
                  <label for=""><b>Class</b></label>
                </div>
                <div>
                  <select
                    name="assetclass"
                    v-model="SortAssetsList.ClassCode"
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
              </div>
            </div>

            <div class="form-group row col md-4">
              <div class="col-lg-2">
                <div>
                  <label class="form-label">
                    <b>Month</b>
                  </label>
                </div>
                <div>
                  <input
                    name="month"
                    v-model="SortAssetsList.Month"
                    class="form-control"
                    required
                  />
                </div>
              </div>

              <div class="col-lg-2">
                <div>
                  <label class="form-label">
                    <b>Year</b>
                  </label>
                </div>
                <div>
                  <input
                    name="year"
                    v-model="SortAssetsList.Year"
                    class="form-control"
                    required
                  />
                </div>
              </div>
            </div>
          </div>
          <div role="group" class="btn-group mr-2 sw-btn-group-extra">
            <button
              v-if="this.SortAssetsList.Month != '' && this.SortAssetsList.Year != ''"
              type="submit"
              class="btn btn-primary mb-2"
              v-on:click="generateReport"
            >
              Continue
            </button>
          </div>
          <div role="group" class="btn-group mr-2 sw-btn-group-extra">
            <button class="btn btn-danger mb-2">Cancel</button>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import VueSimpleAlert from "vue-simple-alert";
import moment from "moment";

export default {
  components: {
    VueSimpleAlert,
    moment,
  },

  data() {
    return {
      AllAsset: false,
      SpecificAsset: false,
      classList: null,
      SortAssetsList: {
        AllAssets: "null",
        ClassCode: "null",
        Month: "",
        Year: "",
      },
    };
  },
  mounted() {
    axios
      .get("/api/AssetReclassification/getAllClassifications")
      .then((response) => (this.classList = response.data));

    // axios.get("/api/Company/GetCompanyMonthAndYear").then((response) => {
    //   this.SortAssetsList.Year = response.data.data.year;
    //   this.SortAssetsList.Month = response.data.data.month;
    // });
  },

  methods: {
    SetAllAsset() {
      this.selectAsset = true;
      this.SpecificAsset = false;
    },
    SetSpecificAsset() {
      this.AllAsset = false;
      this.SpecificAsset = true;
    },

    generateReport() {
      window.open(
        `/Report/DepreciationNotesReport/${this.SortAssetsList.ClassCode}/${this.SortAssetsList.Month}/${this.SortAssetsList.Year}`
      );
    },
  },
};
</script>