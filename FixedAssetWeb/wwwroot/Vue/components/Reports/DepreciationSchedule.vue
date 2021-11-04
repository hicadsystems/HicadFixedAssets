<template>
  <div>
    <div>
      <div class="page-wrapper">
        <div class="page-header">
          <div class="row align-items-end">
            <div class="col-lg-8">
              <div class="page-header-title">
                <div class="d-inline">
                  <h4>DEPRECIATION SCHEDULE</h4>
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
            <div class="row">
              <div class="col-xl-5">
                <form>
                  <fieldset>
                    <legend>Arranged By</legend>
                    <div class="col-sm-4">
                      <div class="row ml-4">
                        <div class="form-check">
                          <input
                            @click="setClass"
                            class="form-check-input col-6"
                            type="radio"
                            name="exampleRadios"
                            id="exampleRadios2"
                            value="option2"
                          />
                          <label class="form-check-label" for="exampleRadios2">
                            <b> Class </b>
                          </label>
                        </div>
                      </div>
                    </div>

                    <div class="col-sm-4">
                      <div class="row ml-4">
                        <div class="form-check">
                          <input
                            @click="setDept"
                            class="form-check-input col-4"
                            type="radio"
                            name="exampleRadios"
                            id="exampleRadios2"
                            value="option2"
                          />
                          <label class="form-check-label" for="exampleRadios2">
                            <b> Department </b>
                          </label>
                        </div>
                      </div>
                    </div>

                    <div class="col-sm-4">
                      <div class="row ml-4">
                        <div class="form-check">
                          <input
                            @click="setBus"
                            class="form-check-input col-4"
                            type="radio"
                            name="exampleRadios"
                            id="exampleRadios2"
                            value="option2"
                          />
                          <label class="form-check-label" for="exampleRadios2">
                            <b> Business Line </b>
                          </label>
                        </div>
                      </div>
                    </div>
                  </fieldset>
                </form>
              </div>

              <div class="col-xl-7">
                <form>
                  <fieldset>
                    <legend>Option</legend>
                    <div class="col-sm-4">
                      <div class="row ml-4">
                        <div class="form-check">
                          <input
                            @click="setAll"
                            class="form-check-input col-6"
                            type="radio"
                            name="exampleRadios"
                            id="exampleRadios2"
                            value="option2"
                          />
                          <label class="form-check-label" for="exampleRadios2">
                            <b> All </b>
                          </label>
                        </div>
                      </div>
                    </div>

                    <div class="col-sm-4">
                      <div class="row ml-4">
                        <div class="form-check">
                          <input
                            @click="setSpecific"
                            class="form-check-input col-4"
                            type="radio"
                            name="exampleRadios"
                            id="exampleRadios2"
                            value="option2"
                          />
                          <label class="form-check-label" for="exampleRadios2">
                            <b> Specific </b>
                          </label>
                        </div>
                      </div>
                    </div>
                  </fieldset>
                </form>
              </div>
            </div>

            <div class="form-group row col md-4">
              <div class="col-lg-4" v-if="this.specificClass">
                <div>
                  <label for=""><b>Class</b></label>
                </div>
                <div>
                  <select
                    name="assetclass"
                    v-model="objectBody.classCode"
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

              <div class="col-lg-4" v-if="this.specificDepartment">
                <div>
                  <label for=""><b>Department</b></label>
                </div>
                <div>
                  <select
                    name="assetclass"
                    v-model="objectBody.classDept"
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

              <div class="col-lg-4" v-if="this.specificBusinessLine">
                <div>
                  <label for=""><b>Business Line</b></label>
                </div>
                <div>
                  <select
                    name="assetclass"
                    v-model="objectBody.busLine"
                    class="form-control form-control-inverse"
                    required
                  >
                    <option
                      v-for="clist in businessLineList"
                      v-bind:value="clist.Code"
                      v-bind:key="clist.Code"
                      required
                    >
                      {{ clist.description }}
                    </option>
                  </select>
                </div>
              </div>
            </div>
          </div>
          <div role="group" class="btn-group mr-2 sw-btn-group-extra">
            <button 
              type="submit" 
              class="btn btn-primary mb-2"
              v-on:click="generateReport">
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
      Class: false,
      Department: false,
      BusinessLine: false,
      specificClass: false,
      specificDepartment: false,
      specificBusinessLine: false,
      All: false,
      Specific: false,
      classList: null,
      costCenterList: null,
      businessLineList: null,
      objectBody: {
        classCode: "null",
        classDept: "null",
        busLine: "null",
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
  },

  methods: {
    setClass() {
      this.Class = true;
      this.Department = false;
      this.BusinessLine = false;
    },

    setDept() {
      this.Class = false;
      this.Department = true;
      this.BusinessLine = false;
    },

    setBus() {
      this.Class = false;
      this.Department = false;
      this.BusinessLine = true;
    },

    setSpecific() {
      if (this.Class == true) {
        this.specificClass = true;
        this.specificDepartment = false;
        this.specificBusinessLine = false;
      } else if (this.Department == true) {
        this.specificClass = false;
        this.specificDepartment = true;
        this.specificBusinessLine = false;
      } else {
        this.specificClass = false;
        this.specificDepartment = false;
        this.specificBusinessLine = true;
      }
    },

    setAll() {
      this.specificClass = false;
      this.specificDepartment = false;
      this.specificBusinessLine = false;
    },

    generateReport(){
      if(this.Class != false){
        window.open(
        `/Report/DepreciationScheduleForClass/${this.objectBody.classCode}`
      );
      }
      else if(this.Department != false){
        window.open(
        `/Report/DepreciationScheduleForDepartment/${this.objectBody.classDept}`
      );
      }
      else if(this.BusinessLine != false){
        window.open(
        `/Report/DepreciationScheduleForBusinessline/${this.objectBody.busLine}`
      );
      }
    },
  },
};
</script>