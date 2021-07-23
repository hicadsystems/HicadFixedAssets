<template>
    	<!-- WRAPPER -->
    <div>
        <div v-if="errors" class="has-error"> {{ [errors] }}</div>
        <div v-if="responseMessage" class="has-error"> {{ responseMessage }}</div>
        <form @submit="checkForm"  method="post">
            <div class="card-body">
                <div class="row">
                    <div class="col-12 col-xl-2">
                        <div class="form-group">
                            <label class="form-label">Code</label>
                            <input type="text" name="code" class="form-control" v-model="postBody.comp_code" required :readonly="submitorUpdate == 'Update'" />
                        </div>
                        </div>
                    <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Name</label>
                            <input class="form-control" name="name" v-model="postBody.comp_name" placeholder="" />
                        </div>
                    </div>

                     <div class="col-12 col-xl-5">
                        <div class="form-group">
                            <label class="form-label">Address</label>
                            <input type="text" name="address" class="form-control" v-model="postBody.address"  />
                        </div>
                        </div>
                    <div class="col-12 col-xl-2">
                        <div class="form-group">
                            <label class="form-label">Process Year</label>
                            <input class="form-control" name="description" v-model="postBody.processyear" placeholder="" />
                        </div>
                    </div>
                </div>
                <div class="row">
                     <div class="col-12 col-xl-2">
                        <div class="form-group">
                            <label class="form-label">Process Month</label>
                            <input type="text" name="address" class="form-control" v-model="postBody.processmonth"  />
                        </div>
                        </div>
                    <div class="col-12 col-xl-4">
                        <div class="form-group">
                            <label class="form-label">Salary scale</label>
                            <select class="form-control" v-model="postBody.salaryscale" required :disabled="autoselectenabled">
                              <option v-for="subt in records" v-bind:value="subt" v-bind:key="subt"> {{ subt }} </option>
                           </select>
                          
                        </div>
                    </div>
                     <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">retireage</label>
                            <input type="text" name="address" class="form-control" v-model="postBody.retireage"  />
                        </div>
                        </div>
                    <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">HrLink</label>
                            <select class="form-control" v-model="postBody.hrlink" required :disabled="autoselectenabled">
                              <option v-for="subt in records" v-bind:value="subt" v-bind:key="subt"> {{ subt }} </option>
                           </select>
                        </div>
                    </div>
                </div>
                <div class="row">
                     <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">town</label>
                            <input type="text" name="address" class="form-control" v-model="postBody.town"  />
                        </div>
                    </div>
                    <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Lg</label>
                            <input class="form-control" name="description" v-model="postBody.lg" placeholder="" />
                        </div>
                    </div>
                     <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">State</label>
                            <input class="form-control" name="description" v-model="postBody.state" placeholder="" />
                        </div>
                    </div>
                     <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Email</label>
                            <input class="form-control" name="description" v-model="postBody.email" placeholder="" />
                        </div>
                    </div>
                </div>
                <div class="row">
                     <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Box</label>
                            <input class="form-control" name="description" v-model="postBody.box" placeholder="" />
                        </div>
                    </div>
                     <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Tel</label>
                            <input class="form-control" name="description" v-model="postBody.tel" placeholder="" />
                        </div>
                    </div>
                     <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Server Address</label>
                            <input class="form-control" name="description" v-model="postBody.serveraddr" placeholder="" />
                        </div>
                    </div>
                     <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Server port</label>
                            <input class="form-control" name="description" v-model="postBody.serverport" placeholder="" />
                        </div>
                    </div>

                </div>
                <div class="row">
                     <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Email_pword</label>
                            <input type="password" class="form-control" name="description" v-model="postBody.email_pword" placeholder="" />
                        </div>
                    </div>
                     <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Monthly Tax</label>
                            <select class="form-control" v-model="postBody.mthly_tax" required :disabled="autoselectenabled">
                              <option v-for="subt in records" v-bind:value="subt" v-bind:key="subt"> {{ subt }} </option>
                           </select>
                        </div>
                    </div>
                     <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Runtype</label>
                            <input class="form-control" name="description" v-model="postBody.runtype" placeholder="" />
                        </div>
                    </div>
                    <div class="col-12 ">
                        <div class="btn-group mr-2 sw-btn-group-extra" v-if="canProcess" role="group">
                            <button class="btn btn-submit btn-primary" v-on:click="checkForm" type="submit">{{submitorUpdate}}</button>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
							
	<!-- END WRAPPER -->
</template>

<script>
export default {
    
    data() {
        return {
            errors: null,
            responseMessage:'',
            submitorUpdate : 'Submit',
            canProcess : true,
            records:["Yes","No"],
            autoselectenabled:false,
            postBody: {
                comp_code:'',
                comp_name:'',
                address:'',
                processyear:'',
                processmonth:'',
                salaryscale:'',
                retireage:'',
                hrlink:'',
                town:'',
                lg:'',
                state:'',
                email:'',
                box:'',
                tel:'',
                serveraddr:'',
                serverport:'',
                email_pword:'',
                mthly_tax:'',
                runtype:''
            }
    
        }
    },
    watch:{
         '$store.state.objectToUpdate':function (newVal, oldVal) {
         this.postBody.processyear = this.$store.state.objectToUpdate.processyear,
         this.postBody.address = this.$store.state.objectToUpdate.address,
         this.postBody.comp_code = this.$store.state.objectToUpdate.comp_code,
         this.postBody.comp_name = this.$store.state.objectToUpdate.comp_name,
         this.postBody.processmonth = this.$store.state.objectToUpdate.processmonth,
         this.postBody.salaryscale = this.$store.state.objectToUpdate.salaryscale,
         this.postBody.retireage = this.$store.state.objectToUpdate.retireage,
         this.postBody.hrlink = this.$store.state.objectToUpdate.hrlink,
          this.postBody.town = this.$store.state.objectToUpdate.town,
         this.postBody.lg = this.$store.state.objectToUpdate.lg,
         this.postBody.state = this.$store.state.objectToUpdate.state,
          this.postBody.email = this.$store.state.objectToUpdate.email,
          this.postBody.box = this.$store.state.objectToUpdate.box,
          this.postBody.tel = this.$store.state.objectToUpdate.tel,
          this.postBody.serveraddr = this.$store.state.objectToUpdate.serveraddr,
          this.postBody.serverport = this.$store.state.objectToUpdate.serverport,
           this.postBody.runtype = this.$store.state.objectToUpdate.runtype,
          this.postBody.mthly_tax = this.$store.state.objectToUpdate.mthly_tax

          this.submitorUpdate = 'Update';
               
        }
    },
    methods: {
        checkForm: function (e) {
            
         if (this.postBody.comp_code) {
              e.preventDefault();
              this.canProcess = false;
              this.postPost();
          }
          else{

          this.errors = [];
            this.errors.push('Company Code is Required');
          }
        },
        postPost() {

                if(this.submitorUpdate == 'Submit'){
                    axios.post(`/api/Company/createCompany`, this.postBody )
                        .then(response => {
                            this.responseMessage = response.data.responseDescription;this.canProcess = true;
                            if(response.data.responseCode == '200'){
                                this.postBody.comp_code=''; 
                                this.postBody.comp_name='';
                                this.postBody.address='';
                                this.postBody.processyear='';
                                this.postBody.processmonth='';
                                this.postBody.salaryscale='';
                                this.postBody.retireage='';
                                this.postBody.hrlink='';
                                this.postBody.town='';
                                this.postBody.lg='';
                                this.postBody.state='';
                                this.postBody.email='';
                                this.postBody.box='';
                                this.postBody.tel='';
                                this.postBody.serveraddr='';
                                this.postBody.serverport='';
                                this.postBody.email_pword='';
                                this.postBody.mthly_tax='';
                                this.postBody.runtype='';
                                
                            }
                        })
                        .catch(e => {
                            this.errors.push(e)
                        });
                }
                if(this.submitorUpdate == 'Update'){
                    axios.put(`/api/Company/updateCompany`, this.postBody )
                        .then(response => {
                            this.responseMessage = response.data.responseDescription;this.canProcess = true;
                            if(response.data.responseCode == '200'){
                                 this.submitorUpdate = 'Submit'
                                this.postBody.comp_code=''; 
                                this.postBody.comp_name='';
                                this.postBody.address='';
                                this.postBody.processyear='';
                                this.postBody.processmonth='';
                                this.postBody.salaryscale='';
                                this.postBody.retireage='';
                                this.postBody.hrlink='';
                                this.postBody.town='';
                                this.postBody.lg='';
                                this.postBody.state='';
                                this.postBody.email='';
                                this.postBody.box='';
                                this.postBody.tel='';
                                this.postBody.serveraddr='';
                                this.postBody.serverport='';
                                this.postBody.email_pword='';
                                this.postBody.mthly_tax='';
                                this.postBody.runtype='';
                                this.$store.state.objectToUpdate = "update";
                            }
                        })
                        .catch(e => {
                            this.errors.push(e)
                        });
                }
            }
        },
        computed: {
            setter(){
                let objecttoedit = this.$store.state.objectToUpdate;
                if(objecttoedit.bl_code){
                   
                     this.postBody.processyear = objecttoedit.processyear;
                     this.postBody.address = objecttoedit.address;
                     this.postBody.comp_code = objecttoedit.comp_code;
                     this.postBody.comp_name = objecttoedit.comp_name;
                     this.postBody.processmonth = objecttoedit.processmonth;
                     this.postBody.salaryscale = objecttoedit.salaryscale;
                     this.postBody.retireage = objecttoedit.retireage;
                     this.postBody.hrlink = objecttoedit.hrlink;
                     this.postBody.town = objecttoedit.town;
                     this.postBody.lg = objecttoedit.lg;
                     this.postBody.state = objecttoedit.state;
                    this.postBody.email = objecttoedit.email;
                    this.postBody.box = objecttoedit.box;
                     this.postBody.tel = objecttoedit.tel;
                     this.postBody.serveraddr = objecttoedit.serveraddr;
                     this.postBody.serverport = objecttoedit.serverport;
                     this.postBody.runtype = objecttoedit.runtype;
                     this.postBody.mthly_tax = objecttoedit.mthly_tax
                }
            }
        }
};
</script>