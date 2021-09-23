<template>
    <div>
        <div>
            <div  class="page-wrapper">
                <div class="page-header">
                    <div class="row align-items-end">
                        <div class="col-lg-8">
                            <div class="page-header-title">
                                <div class="d-inline">
                                    <h4>INSURANCE RENEWAL REPORT</h4> 
                                    
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
                                            @click="setAllAsset"
                                            class="form-check-input col-6"
                                            type="radio"
                                            name="exampleRadios"
                                            id="exampleRadios2"
                                            value="option2"
                                        />
                                        <label class="form-check-label" for="exampleRadios2">
                                            <b>All Asset</b>
                                        </label>
                                        
                                    </div>
                                </div>
                            </div>
                            
                            <div class="col-sm-4">
                                <div class="row ml-4">
                                    <div class="form-check">
                                        <input
                                            @click="specificAsset"
                                            class="form-check-input col-6"
                                            type="radio"
                                            name="exampleRadios"
                                            id="exampleRadios2"
                                            value="option2"
                                        />
                                        <label class="form-check-label" for="exampleRadios2">
                                            <b> Specific Asset</b>
                                        </label>
                                        
                                    </div>
                                </div>
                            </div>
                            
                        </div>

                        <div class="form-group row col md-4">
                            <div class="col-lg-4 " v-if="specificAsset">
                                <div>
                                    <label for="" ><b>Asset Code </b></label>
                                </div>
                                <div>
                                    <select 
                                        name="assetclass"
                                        v-model="sortAssetsList.assetDescription"
                                        class="form-control form-control-inverse"
                                        required
                                    >
                                    <option
                                    v-for="asset in assetList"
                                    v-bind:value="asset.assetCode"
                                    v-bind:key="asset.assetCode"
                                    required
                                    >
                                    </option>
                                    </select>
                                </div>
                            </div>
                        </div>
                    </div>
                    <button 
                    type="submit" 
                    class="btn btn-submit btn-primary"
                     >Process
                    </button>
                </form>
            </div>
        </div>

        <!-- ASSET TABLE -->
        <div>
            <button type="button" class="btn btn-submit btn-primary">Show Report</button>
            <div class="page-body">
                <div class="card">
                    <div class="card-body">
                        <table id="datatables-buttons" class="table table-striped" style="width:100%">
                            <thead>
                                <tr>
                                    <th>Asset Code</th>
                                    <th>Asset Description</th>
                                    <th>Asset Location</th>
                                    <th>Asset Class</th>
                                    <th>Insurance Renewal Date</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr v-for="(insRenew,index) in insuranceList" :key="index">
                                    <td>{{ insRenew.assetCode }}</td>
                                    <td>{{ insRenew.assetDesc }}</td>
                                    <td>{{ insRenew.Dept }}</td>
                                    <td>{{ insRenew.Class }}</td>
                                    <td>{{ insRenew.Insurdate }}</td>
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
            specificAsset: false,
            assetList: null,
            insuranceList: null,
            sortAssetsList: {
                assetDescription: "null",
            },
            objectBody: {
                assetCode,
            }
        }
    },

    mounted() {
        axios
            .get("/api/AssetMovement/getAllAssets")
            .then((response) => (this.assetList = response.data));
    },

    methods: {
        SpecificAsset() {
            this.specificAsset = true;
        },
    }
}
</script>