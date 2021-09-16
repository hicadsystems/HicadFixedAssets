<template>
    <div>
        <div>
            <div  class="page-wrapper">
                <div class="page-header">
                    <div class="row align-items-end">
                        <div class="col-lg-8">
                            <div class="page-header-title">
                                <div class="d-inline">
                                    <h4>DEPRECIATION VALUE REPORT</h4> 
                                    
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
                <form action="">
                    <div class="card-body">
                        <div class="form-group row">
                            <div class="col md-4">
                                <div>
                                    <label for="" ><b>From </b></label>
                                    <vuejsDatepicker
                                        v-model="sortDepreciation.startDate"
                                        input-class="form-control col-4 mr-1" 
                                        type="date" 
                                    ></vuejsDatepicker>
                                </div>
                                <div>
                                    <label for="" ><b>To </b></label>
                                    <vuejsDatepicker
                                        v-model="sortDepreciation.endDate"
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
                     >Process
                    </button>
                </form>
            </div>
        </div>

         <!-- DEPRECIATION VALUE TABLE -->
        <div >

            <button type="button" class="btn btn-submit btn-primary" v-on:click="generateReport">Show Report</button>
            <div class="page-body">
                <div class="card">
                    <div class="card-body">
                        <table id="datatables-buttons" class="table table-striped" style="width:100%">
                            <thead>
                                <tr>
                                    <th>Asset Code</th>
                                    <th>Description</th>
                                    <th>Purchase Date</th>
                                    <th>Purchase Value</th>
                                    <th>Depreciation</th>
                                    <th>Accum Depreciation</th>
                                    <th>Book Value</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr v-for="(depVal,index) in deprList" :key="index">
                                    <td>{{ depVal.assetcode }}</td>
                                    <td>{{ depVal.assetdesc }}</td>
                                    <td>{{ depVal.purchdate }}</td>
                                    <td>{{ depVal.purchval }}</td>
                                    <td>{{ depVal.depreciation }}</td>
                                    <td>{{ depVal.accum_depr }}</td>
                                    <td>{{ depVal.bookval }}</td>
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
import moment from 'moment';
export default {
    components: {
        vuejsDatepicker,
        VueSimpleAlert,
    },
    data() {
        return {
            deprList: null,
            sortDepreciation: {
                startDate: null,
                endDate: null,
            },
            objectBody: {
                assetCode: "",
                assetDesc: "",
                purchdate: "",
                purchval: "",
                depreciation: "",
                accum_depr: "",
                bookval: "",
            }
        }
    },

    methods: {
        sortingProcess() {

                axios
                .post(`/api/GenerateDepreciation/sortAssetDepreciation/`, this.sortDepreciation)

                .then((response) => {

                if (response.data.responseCode === 404){

                    this.$alert(`No Value available for the selected Dates!!`, "No Records Found", "Warning");
                }

                this.deprList = response.data.data;
                
                });

        },

        generateReport(){

            let startDay = moment(this.sortDepreciation.startDate).format('MM DD YYYY, h:mm:ss a');

            let endDay = moment(this.sortDepreciation.endDate).format('MM DD YYYY, h:mm:ss a');

            if(startDay === "Invalid date" && endDay === "Invalid date" ){

                startDay = null;
                endDay = null;
            }

            window.open(`/MonthEndProcessing/PrintDeprValue/${startDay}/${endDay}`);

        },
    }
}
</script>