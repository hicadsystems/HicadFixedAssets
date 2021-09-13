<template>
    <div>
        <div>
            <div  class="page-wrapper">
                <div class="page-header">
                    <div class="row align-items-end">
                        <div class="col-lg-8">
                            <div class="page-header-title">
                                <div class="d-inline">
                                    <h4>ASSET REG REPORT</h4> 
                                    <!-- <span>ADD NEW ASSET CLASS</span> -->
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
                                            @click="setDate"
                                            class="form-check-input col-6"
                                            type="radio"
                                            name="exampleRadios"
                                            id="exampleRadios2"
                                            value="option2"
                                        />
                                        <label class="form-check-label" for="exampleRadios2">
                                            <b>Sort by Date</b>
                                        </label>
                                        <!-- <input  v-if="selectDate" type="date" class="form-control col-4" /> -->
                                    </div>
                                </div>
                            </div>
                            
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
                                            <b>Sort by Class</b>
                                        </label>
                                        <!-- <input  v-if="selectDate" type="date" class="form-control col-4" /> -->
                                    </div>
                                </div>
                            </div>
                            

                            <div class="col-sm-4">
                                <div class="row ml-4">
                                    <div class="form-check">
                                        <input
                                            @click="setDept"
                                            class="form-check-input col-6"
                                            type="radio"
                                            name="exampleRadios"
                                            id="exampleRadios2"
                                            value="option2"
                                        />
                                        <label class="form-check-label" for="exampleRadios2">
                                            <b>Sort by Dept</b>
                                        </label>
                                        <!-- <input  v-if="selectDate" type="date" class="form-control col-4" /> -->
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col md-4" v-if="selectDate">
                                <div>
                                    <label for="" ><b>From </b></label>
                                    <vuejsDatepicker
                                        input-class="form-control col-4 mr-1"
                                        v-model="objectBody.startDate" 
                                        type="date"
                                        format="MM/dd/yyyy"
                                    ></vuejsDatepicker>
                                </div>
                                <div>
                                    <label for="" ><b>To </b></label>
                                    <vuejsDatepicker
                                        input-class="form-control col-4"
                                        v-model="objectBody.endDate" 
                                        type="date"
                                        format="MM/dd/yyyy"
                                    >
                                    </vuejsDatepicker>
                                </div>
                            </div>

                            <div class="col md-2" v-if="selectClass">
                                <div>
                                    <label for="" ><b>Class </b></label>
                                </div>
                                <div>
                                    <select
                                        name="assetclass"
                                        v-model="sortClassCode"
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

                            <div class="col md-2" v-if="selectDept">
                                <div>
                                    <label for="" ><b>Department </b></label>
                                </div>
                                <div>
                                    <select 
                                        name="assetclass"
                                        v-model="sortDept"
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
                        </div>
                    </div>
                    <button 
                    type="submit" 
                    class="btn btn-submit btn-primary"
                    @click.prevent="sortingProcess()"
                     >Process
                    </button>
                </form>
            </div>
        </div>


        <!-- ASSET TABLE -->
        <div v-if="!isFormVisible">
            <!-- <div class="page-wrapper">
                <div class="page-header">
                    <div class="row align-items-end">
                        <div class="col-lg-8">
                            <div class="page-header-title">
                                <div class="d-inline">
                                    <h4>LIST OF ASSETS</h4>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div> -->

            <button type="button" class="btn btn-submit btn-primary" >Show Report</button>
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
                                    <td>{{ assetReg.assetCode }}</td>
                                    <td>{{ assetReg.assetDesc }}</td>
                                    <td>{{ assetReg.classDesc }}</td>
                                    <td>{{ assetReg.unitDesc }}</td>
                                    <td>{{ assetReg.buslineDesc }}</td>
                                    <td>{{ assetReg.purchval }}</td>
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
            selectDate: false,
            selectDept: false,
            selectClass: false,
            isFormVisible: false,
            responseMessage: "",
            assetRegList: null,
            costCenterList: null,
            classList: null,
            sortClassCode: "",
            sortDept: "",
            objectBody: {
                assetCode: "",
                assetDesc: "",
                class: "",
                busline: "",
                purchval: "",
                purchdate: "",
                dept: "",
                class: "",
                startDate: "",
                endDate: "",
            }
        }
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

    // axios
    //   .get("/api/AssetRegisteration/getAllAssets")
    //   .then((response) => (this.assetRegList = response.data));
    },

    methods: {
        setDate() {
            this.selectDate = true;
            this.selectClass = false;
            this.selectDept = false;
        },

        setClass() {
            this.selectDate = false;
            this.selectClass = true;
            this.selectDept = false;
        },

        setDept() {
            this.selectDate = false;
            this.selectClass = false;
            this.selectDept = true;
        },

        sortingProcess() {
            
            if(this.selectDate === true){
                axios
                .get(`/api/AssetRegisteration/getAssetsregByDate/${this.startDate}/${this.endDate}`)
                .then((response) => {
                console.log(response.data.responseCode)
                if (response.data.responseCode === 404){
                    this.$alert(`No Asset available for the selected Dates!!`, "No Records Found", "Warning");
                }
                this.assetRegList = response.data.data;
                
                });

                console.log(this.assetRegList);
            }

            if(this.selectClass === true){
                axios
                .get(`/api/AssetRegisteration/getAssetsregByClasscode/${this.sortClassCode}`)
                .then((response) => {
                console.log(response.data.responseCode)
                if (response.data.responseCode === 404){
                    this.$alert(`No Asset available for the selected Class!!`, "No Records Found", "Warning");
                }
                this.assetRegList = response.data.data;
                
                });

                console.log(this.assetRegList);
            }

            if(this.selectDept === true){
                axios
                .get(`/api/AssetRegisteration/getAssetsregByDept/${this.sortDept}`)
                .then((response) => {
                console.log(response.data.responseCode)
                if (response.data.responseCode === 404){
                    this.$alert(`No Asset available in selected Deparment!!`, "No Records Found", "Warning");
                }
                this.assetRegList = response.data.data;
                
            });
                console.log(this.assetRegList);


            }
        },
    }
};
</script>