<template>
<div>
        <div>
            <div  class="page-wrapper">
                <div class="page-header">
                    <div class="row align-items-end">
                        <div class="col-lg-8">
                            <div class="page-header-title">
                                <div class="d-inline">
                                    <h4>DEPRECIATION SUMMARY</h4> 
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
                            <div class="col-lg-4">
                                <div>
                                    <label for="" ><b>Select Asset</b></label>
                                </div>
                                <div>
                                    <select
                                        name="assetclass"
                                        v-model="assetCode"
                                        class="form-control form-control-inverse"
                                        required
                                    >
                                    <option
                                        v-for="alist in assetList"
                                        v-bind:value="alist.assetCode"
                                        v-bind:key="alist.assetCode"
                                        required
                                    >
                                    {{ alist.assetDesc }}
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
        <div>

            <button type="button" class="btn btn-submit btn-primary" v-on:click="generateReport">Show Report</button>
            <div class="page-body">
                <div class="card">
                    <div class="card-body">
                        <table id="datatables-buttons" class="table table-striped" style="width:100%">
                            <thead>
                                <tr>
                                    <th>Asset Description</th>
                                    <th>Business Line</th>
                                    <th>Department</th>
                                    <th>Classification</th>
                                    <th>Amount</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr v-for="(deprAsset,index) in DeprAssetsList" :key="index">
                                    <td>{{ deprAsset.assetdesc }}</td>
                                    <td>{{ deprAsset.busline }}</td>
                                    <td>{{ deprAsset.newloc }}</td>
                                    <td>{{ deprAsset.newclass }}</td>
                                    <td>{{ deprAsset.depreciation }}</td>
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
        moment,
    },

    data() {

        return {
            assetCode: 'null',
            assetList: null,
            responseMessage: "",
            DeprAssetsList: null,
        }

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

                if (response.data.responseCode === 404){

                    this.$alert(`No Asset available for the selected Parameter!!`, "No Records Found", "Warning");
                }

                console.log(response.data.data);

                this.DeprAssetsList = response.data.data;
                
                });

        },

        generateReport(){

        //     let startDay = moment(this.sortAssetsList.startDate).format('MM DD YYYY, h:mm:ss a');

        //     let endDay = moment(this.sortAssetsList.endDate).format('MM DD YYYY, h:mm:ss a');

        //     if(startDay === "Invalid date" && endDay === "Invalid date" ){

        //         startDay = null;
        //         endDay = null;
        //     }

        //     window.open(`/Statictable/PrintAssetreg/${this.sortAssetsList.classCode}/${this.sortAssetsList.classDept}/${startDay}/${endDay}`);

        },
    }
}
</script>