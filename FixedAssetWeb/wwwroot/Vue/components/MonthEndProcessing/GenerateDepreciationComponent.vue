<template>
  <div class="page-wrapper">
    <div class="page-header">
      <div class="row align-items-end">
        <div class="col-lg-8">
          <div class="page-header-title">
            <div class="d-inline">
              <h4>Generate Depreciation</h4>
              <span>Input Date To Calculate Depreciation</span>
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

    <!-- <div v-if="errors" class="has-error"> {{ [errors] }}</div>
    <div v-if="responseMessage" class="has-error"> {{ responseMessage }}</div> -->

    <p v-if="errors.length">
    <b>Please correct the following error(s):</b>
    <ul>
      <li 
          v-for="error in errors" 
          v-bind:key="error.length">
          <h6 style="color: red;" class="has-error"> {{ error }} </h6>
      </li>
    </ul>
  </p>

    <div class="page-body">
      <div class="card">
        <form @submit.prevent="checkForm"  method="post">
          <div class="card-body">
            <div class="row">

              <div class="col-sm-6 col-md-6 col-xl-6 m-b-30">
                <label class="form-label">DEPRECIATION DATE</label>
                <vuejsDatepicker 
                   input-class="form-control" 
                   name="depdate"
                   v-model="objectBody.depdate"
                   type="date"
                   required
                   > 
                </vuejsDatepicker>
              </div>
            </div>

            <div class="row">
              <div class="col-6">
                <div role="group" class="btn-group mr-2 sw-btn-group-extra">
                  <button 
                    v-if="this.objectBody.depdate != ''"
                    v-on:click="checkForm" 
                    type="submit" 
                    class="btn btn-submit btn-primary"
                  >
                    Accept
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
      errors: [],
      responseMessage: "",
      objectBody: {
        depdate: '',
      }
    }
  },

  methods: {
    checkForm: function (e) {
      this.errors = [];

      this.postPost();

      e.preventDefault();
    },

    postPost() {
      axios
        .post(`/api/GenerateDepreciation/date/`,this.objectBody)
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
      
      this.$alert("Generated Depreciation!!!", "Ok", "success");

      this.onCancel();
    },

    onCancel() {
      this.errors = [];

      this.objectBody.depdate = " ";
    }

  }
}
</script>

<style>

</style>