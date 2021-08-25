<template>
    <div>
        <!-- Confirm pop-up -->
    <vue-confirm-dialog></vue-confirm-dialog>


        <!-- Asset Class Form -->
        <div v-if="isFormVisible">
            <div  class="page-wrapper">
            <div class="page-header">
                <div class="row align-items-end">
                    <div class="col-lg-8">
                        <div class="page-header-title">
                            <div class="d-inline">
                                <h4>Classification Input Form</h4> 
                                <span>ADD NEW ASSET CLASS</span>
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
    

        <div class="page body">
            <div class="card">
                <form @submit.prevent="checkForm" method="post">
                   <div class="card-body">
                        <div class="row">
                        <div class="col-sm-2 col-md-2 col-xl-2">
                            <div class="form-group">
                                <label class="form-label">Class Code</label>
                                <input 
                                name="classcode"
                                v-model="objectBody.classcode"
                                :readonly="CreateOrUpdate == 'Update'" 
                                class="form-control" />
                            </div>
                        </div>
                        <div class="col-6 col-xl-6">
                            <div class="form-group">
                                <label class="form-label"> Class Description</label>
                                <input 
                                name="classdesc"
                                v-model="objectBody.classdesc" 
                                class="form-control" />
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-xl-5">
                            <form>
                                    <fieldset>
                                        <legend>Depreciation Calculation</legend>
                                        <div class="form-group row">
                                                <label for="rate" class="col-sm-4 col-form-label">Rate :</label>
                                                <div class="col-sm-4">
                                                    <input 
                                                    name="deprrate"
                                                    v-model="objectBody.deprrate" 
                                                    class="form-control" />
                                                </div>
                                                <h5>%</h5>
                                        </div>
                                        <div class="form-group row">
                                                <label for="rate" class="col-sm-4 col-form-label">Method :</label>
                                                <div class="col-sm-7">
                                                    <input 
                                                    name="classdesc"
                                                    v-model="objectBody.deprmethod" 
                                                    class="form-control" />
                                                    <!-- <select
                                                    name="deptmethod"
                                                    v-model="objectBody.deprmethod" 
                                                    class="form-control">
                                                    <option></option>
                                                    </select> -->
                                                </div>
                                        </div>
                                        <div class="form-group row">
                                                <label for="rate" class="col-sm-4 col-form-label">Order on Annual<br> Depreciation Report :</label>
                                                <div class="col-sm-4">
                                                    <input class="form-control" type="text">
                                                </div>
                                        </div>
                                    </fieldset>
                            </form>
                            </div>
                            <div class="col-xl-7">
                                <form>
                                    <fieldset>
                                        <legend>Ledger</legend>
                                        <div class="form-group row">
                                            <label for="rate" class="col-sm-4 col-form-label">Cost Code :</label>
                                            <div class="col-sm-7">
                                                <input 
                                                name="led_cost_code"
                                                v-model="objectBody.led_cost_code" 
                                                class="form-control" />
                                                <!-- <select 
                                                name="led_cost_code"
                                                v-model="objectBody.led_cost_code" 
                                                class="form-control">
                                                <option></option>
                                                </select> -->
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="rate" class="col-sm-4 col-form-label">Accum.Depr.Code :</label>
                                            <div class="col-sm-7">
                                                <input 
                                                name="led_accum_depr_code"
                                                v-model="objectBody.led_accum_depr_code" 
                                                class="form-control" />
                                                <!-- <select 
                                                name="led_accum_depr_code"
                                                v-model="objectBody.led_accum_depr_code" 
                                                class="form-control">
                                                <option></option>
                                                </select> -->
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="rate" class="col-sm-4 col-form-label">Expenses Code :</label>
                                            <div class="col-sm-7">
                                                <input 
                                                name="led_exp_code"
                                                v-model="objectBody.led_exp_code" 
                                                class="form-control" />
                                                <!-- <select 
                                                name="led_exp_code"
                                                v-model="objectBody.led_exp_code" 
                                                class="form-control">
                                                <option></option>
                                                </select> -->
                                            </div>
                                        </div>
                                    </fieldset>
                                </form>
                            </div>
                            <div role="group" class="btn-group mr-2 sw-btn-group-extra">
                                <button 
                                 v-if="this.objectBody.classcode != '' && this.objectBody.classdesc != '' 
                                 && this.objectBody.deprrate != '' 
                                 && this.objectBody.deprmethod !='' && this.objectBody.led_cost_code !='' 
                                 && this.objectBody.led_accum_depr_code != '' && this.objectBody.Led_exp_code !='' "
                                 v-on:click="checkForm"
                                type="submit" 
                                class="btn btn-primary mb-2">
                                {{ CreateOrUpdate }}
                                </button>
                            </div>
                            <div role="group" class="btn-group mr-2 sw-btn-group-extra">
                                <button @click.prevent="onCancel()" class="btn btn-danger">Cancel</button>
                            </div>
                        </div>
                    </div>
                   </div>
                </form>
            </div>
        </div>
        </div>

        <!-- NAV DIV -->
        <nav v-if="!isFormVisible" aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item" aria-current="page">
            <a @click="showForm()"><span class="btn btn-primary h5">Create Class</span></a>
            </li>
        </ol>
        </nav>
      <!--END OF NAV DIV -->

        <!-- Set Asset Class Table -->
        <div v-if="!isFormVisible">
      <div class="page-wrapper">
        <div class="page-header">
          <div class="row align-items-end">
            <div class="col-lg-8">
                <div class="page-header-title">
                  <div class="d-inline">
                    <h4>ASSET CLASS TABLE</h4>
                    <span>THE LIST OF ALL ASSET CLASS</span>
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

      <div class="page-body">
        <div class="card">
          <div class="card-body">
            <table id="datatables-buttons" class="table table-striped" style="width:100%">
                <thead>
                    <tr>
                        <th>Class Code</th>
                        <th>Class Description</th>
                        <th>Rate</th>
                        <th>Method</th>
                        <th>Cost Code</th>
                        <th>Accum.Depr.Code</th>
                        <th>Expenses Code</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(AssetClass,index) in classList" :key="index">
                        <td>{{ AssetClass.classcode }}</td>
                        <td>{{ AssetClass.classdesc }}</td>
                        <td>{{ AssetClass.deprrate }}</td>
                        <td>{{ AssetClass.deprmethod }}</td>
                        <td>{{ AssetClass.led_cost_code }}</td>
                        <td>{{ AssetClass.led_accum_depr_code }}</td>
                        <td>{{ AssetClass.led_exp_code }}</td>

                        <td>
                
                            <button type="button" class="btn btn-submit btn-primary" @click="editAssetClass(AssetClass.classcode)" >Edit</button>
                            <button type="button" class="btn btn-submit btn-danger" @click="deleteAssetClass(AssetClass.classcode, AssetClass.classdesc)" >Delete</button>
                        </td>
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
import vuejsDatepicker from 'vuejs-datepicker';
export default {
    components: {
        vuejsDatepicker
    },

    data() {
        return{
            isFormVisible: false,
            errors: [],
            showCreateButton: true,
            canProcess: true,
            classList: null,
            CreateOrUpdate: "Create",
            objectBody: {
                classcode: "",
                classdesc: "",
                deprrate: "",
                deprmethod: "",
                led_cost_code:"",
                led_accum_depr_code: "",
                led_exp_code:"",
            },
        }
    },
    methods: {
        checkForm: function (e) {
        this.errors = [];

        if (this.objectBody.classcode == "") this.errors.push("Code required.");

        if (this.objectBody.classdesc == "")
            this.errors.push("Description required.");

        if (this.objectBody.deprrate == "")
            this.errors.push("Depreciation Rate required.");

        if (this.objectBody.deprmethod == "") this.errors.push("Method required.");

        if (this.objectBody.led_cost_code == "")
            this.errors.push("Cost Code required.");

        if (this.objectBody.led_accum_depr_code == "")
            this.errors.push("Accum.Depr.Code required.");

        if (this.objectBody.led_exp_code == "")
            this.errors.push("Expenses Code required.");

        if (
            this.objectBody.classcode &&
            this.objectBody.classdesc &&
            this.objectBody.deprrate &&
            this.objectBody.deprmethod &&
            this.objectBody.led_cost_code &&
            this.objectBody.led_accum_depr_code &&
            this.objectBody.led_exp_code
        ) {
                this.errors = [];

                this.postPost();
            }

        e.preventDefault();
        },

        postPost() {
            if(this.CreateOrUpdate == "Create"){
            axios
            .post(`/api/AssetClass/createclass/`, this.objectBody)
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

            this.$alert("Class Created Successfully!!!", "Ok", "success");

            this.isFormVisible = false;
            }

            if(this.CreateOrUpdate == "Update"){
      
                axios
                .put(`/api/AssetClass/updateclass/`, this.objectBody)
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

                this.$alert("Class Updated Successfully!!!", "Ok", "success");

                this.isFormVisible = false;
            }
        },


        showForm() {
        this.isFormVisible = true;

        this.showCreateButton = false;
        },

        editAssetClass(classcode) {
            axios
            .get(`/api/AssetClass/getclassByCode/${classcode}`)
            .then((response) => {
                console.log(response.data.data);
                this.objectBody.classcode = response.data.data.classcode;
                this.objectBody.classdesc = response.data.data.classdesc;
                this.objectBody.deprrate = response.data.data.deprrate;
                this.objectBody.deprmethod = response.data.data.deprmethod;
                this.objectBody.led_cost_code = response.data.data.led_cost_code;
                this.objectBody.led_accum_depr_code = response.data.data.led_accum_depr_code;
                this.objectBody.led_exp_code = response.data.data.led_exp_code;

                this.isFormVisible = true;

                this.CreateOrUpdate = "Update";
            });
        },

        deleteAssetClass(classcode, classdesc){
            this.$confirm({
                message: "Delete " + classdesc + " ?",
                button: {
                    no: "NO",
                    yes: "YES"
                },
                callback: confirm => {
                    if(confirm){
                        // alert("deleted " + classcode + " " + classdesc);
                        axios.get(`/api/AssetClass/removeclass/${classcode}`)
                        .then(response => {
                        if (response.data.responseCode == '200') {

                            this.$alert(classdesc + " Deleted Successfully!!!", "Ok", "success");
                        }

                        }).catch(e => {
                            this.errors.push(e)
                        });
              
                    }
                },
            });
        },

        onCancel() {
            this.errors = [];

            this.objectBody.classcode = "";
            this.objectBody.classdesc = "";
            this.objectBody.deprrate = "";
            this.objectBody.deprmethod = "";
            this.objectBody.led_cost_code = "";
            this.objectBody.led_accum_depr_code = "";
            this.objectBody.led_exp_code = "";
        },
    },
    
    mounted(){
        axios
        .get("/api/AssetClass/getAllclasss")
        .then((response) => (this.classList = response.data));
    }
}
</script>
<style scoped>
</style>