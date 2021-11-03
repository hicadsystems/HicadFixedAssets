<template>
  <div>
    <div>
      <div class="page-wrapper">
        <div class="page-header">
          <div class="row align-items-end">
            <div class="col-lg-8">
              <div class="page-header-title">
                <div class="d-inline">
                  <h4>UPDATE ASSET DEPRECIATION</h4>
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

    <div class="page body">
      <div style="text-align: center" class="card">
        <form @submit.prevent="checkForm" method="post">
          <div class="card-body">
            <div class="form-group row">
              <div class="col-lg-2">
                <div>
                  <label class="form-label">
                    Process Month 
                  </label>
                </div>
                <div>
                  <input
                    type="number"
                    name="processmonth"
                    v-model="objectBody.processMonth"
                    class="form-control"
                    placeholder="00"
                  />
                </div>
              </div>

              <div class="col-lg-2">
                <div>
                  <label class="form-label">
                    Process Year 
                  </label>
                </div>
                <div>
                  <input
                    type="number"
                    name="processyear"
                    v-model="objectBody.processYear"
                    class="form-control"
                    placeholder="0000"
                  />
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-4">
                <div role="group" class="btn-group mr-2 sw-btn-group-extra">
                  <button
                    v-if="
                      this.objectBody.processMonth != '' &&
                      this.objectBody.processYear != ''
                    "
                    v-on:click="checkForm"
                    type="submit"
                    class="btn btn-submit btn-primary"
                  >
                    Continue
                  </button>
                </div>
                <div role="group" class="btn-group mr-2 sw-btn-group-extra">
                  <button @click.prevent="onCancel()" class="btn btn-danger">
                    Cancel
                  </button>
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
import VueSimpleAlert from "vue-simple-alert";
export default {
  components: {
    VueSimpleAlert,
  },

  data() {
    return {
      errors: [],
      responseMessage: "",
      objectBody: {
        processMonth: "",
        processYear: "",
      },
    };
  },

  methods: {
    checkForm: function (e) {
      this.errors = [];

      this.postPost();

      e.preventDefault();
    },

    postPost() {
      axios
        .get(
          `/api/UpdateDepreciation/UpdateAssets/${this.objectBody.processMonth}/${this.objectBody.processYear}/`
        )
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
    },
  },
};
</script>