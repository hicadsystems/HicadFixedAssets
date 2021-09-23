<template>
  <div>
    <div>
      <div class="page-wrapper">
        <div class="page-header">
          <div class="row align-items-end">
            <div class="col-lg-8">
              <div class="page-header-title">
                <div class="d-inline">
                  <h4>ADDITION AND DISPOSAL REPORT</h4>
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
        <form @submit="checkForm">
          <div class="card-body">
            <div class="form-group row">
              <div class="col-sm-4">
                <div class="row ml-4">
                  <div class="form-check">
                    <input
                      class="form-check-input col-6"
                      type="radio"
                      name="exampleRadios"
                      id="exampleRadios2"
                      value="option2"
                    />
                    <label class="form-check-label" for="exampleRadios2">
                      <b>Addition</b>
                    </label>
                  </div>
                </div>
              </div>

              <div class="col-sm-4">
                <div class="row ml-4">
                  <div class="form-check">
                    <input
                      class="form-check-input col-6"
                      type="radio"
                      name="exampleRadios"
                      id="exampleRadios2"
                      value="option2"
                    />
                    <label class="form-check-label" for="exampleRadios2">
                      <b> Disposal</b>
                    </label>
                  </div>
                </div>
              </div>
            </div>

            <div class="form-group row col md-4">
              <div class="col md-4">
                <div>
                  <label for=""><b>From </b></label>
                  <vuejsDatepicker
                    input-class="form-control col-4 mr-1"
                    type="date"
                  ></vuejsDatepicker>
                </div>
                <div>
                  <label for=""><b>To </b></label>
                  <vuejsDatepicker input-class="form-control col-4" type="date">
                  </vuejsDatepicker>
                </div>
              </div>

            </div>
          </div>
          <button type="submit" class="btn btn-submit btn-primary">
            Process
          </button>
        </form>
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
};
</script>