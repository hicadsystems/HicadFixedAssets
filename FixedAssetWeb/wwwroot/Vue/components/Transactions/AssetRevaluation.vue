<template>
    <div>
        <!-- Asset Revaluation Form -->
        <div>
            <div  class="page-wrapper">
                <div class="page-header">
                    <div class="row align-items-end">
                        <div class="col-lg-8">
                            <div class="page-header-title">
                                <div class="d-inline">
                                    <h4>ASSET REVALUATION FORM</h4> 
                                    <span>ASSET REVALUATION</span>
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
                <form @submit.prevent="checkForm" method="post">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-12 col-xl-6 m-b-30">
                                <label class="form-label">ASSET DESCRIPTION</label>
                                <select 
                                name=""
                                v-model="objectBody.assetCode"
                                @change="getAssetValue()"
                                class="form-control">
                                <option 
                                    v-for="blist in assetRegList"
                                    v-bind:value="blist.assetCode"
                                    v-bind:key="blist.assetCode"
                                    required
                                >
                                {{ blist.assetDesc }}
                                </option>
                                </select>
                            </div>
                            <div class="col-12 col-xl-3 m-b-30">
                                <label class="form-label">REVALUATION DATE</label>
                                <vuejsDatepicker
                                    input-class="form-control"
                                    name=""
                                    v-model="objectBody.Revaldate"
                                    type="date"
                                    required
                                >
                                </vuejsDatepicker>
                                <!-- <input 
                                name=""
                                class="form-control" /> -->
                            </div> 
                        </div>
                        <div class="row">
                            <div class="col-12 col-xl-4 m-b-30">
                                <label class="form-label">OLD VALUE</label>
                                <input 
                                name="purchval"
                                placeholder="Current Value"
                                v-model="objectBody.purchval"
                                class="form-control"
                                readonly
                                />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-12 col-xl-4 m-b-30">
                                <label class="form-label">NEW VALUE</label>
                                <input 
                                name=""
                                v-model="objectBody.Revalval"
                                class="form-control" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-6">
                                <div role="group" class="btn-group mr-2 m-b-30 sw-btn-group-extra">
                                    <button 
                                    v-if="this.objectBody.Revaldate != '' && this.objectBody.Revalval != ''"
                                    v-on:click="checkForm" 
                                    type="submit" 
                                    class="btn btn-submit btn-primary">
                                    Accept
                                    </button>
                                </div>
                                <div role="group" class="btn-group mr-2 m-b-30 sw-btn-group-extra">
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
import vuejsDatepicker from 'vuejs-datepicker';
export default {
    components: {
        vuejsDatepicker,
    },

    data() {
        return {
            errors: [],
            assetRegList: null,
            canProcess: true,
            objectBody:{
                assetCode: "",
                purchval: "",
                Revaldate: "",
                Revalval: "",
            }
        };
    },

    mounted() {
        axios
        .get("/api/AssetRegisteration/getAllAssets")
        .then((response) => (this.assetRegList = response.data));
    },

    methods: {
        checkForm: function (e) {
            this.postPost();
        },
        getAssetValue() {
            axios
            .get(
            `/api/AssetRegisteration/getAssetsregByCode/${this.objectBody.assetCode}`
            )
            .then((response) => {
                this.objectBody.purchval = response.data.data.purchval;
                console.log(response.data.data);
            });
        },

        postPost() {
            axios
            .put(`/api/AssetRegisteration/assetrevaluation`, this.objectBody)
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

            this.$alert("Asset Revaluation Successful!!!", "Ok", "success");
        },

        onCancel() {
            this.errors = [];

            this.objectBody.assetCode = "";
            this.objectBody.purchval = "";
            this.objectBody.Revaldate = "";
            this.objectBody.Revalval = "";
        },
    },
};
</script>