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
        <form>
          <div class="card-body">
            <div class="form-group row">
              <div class="col-lg-2">
                <div>
                  <label class="form-label"><b>Process Month </b></label>
                </div>
                <div>
                  <input name="processmonth" class="form-control" />
                </div>
              </div>

              <div class="col-lg-2">
                <div>
                  <label class="form-label"><b>Process Year </b></label>
                </div>
                <div>
                  <input name="processyear" class="form-control" />
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-4">
                <div role="group" class="btn-group mr-2 sw-btn-group-extra">
                  <button type="submit" class="btn btn-submit btn-primary">
                    Continue
                  </button>
                </div>
                <div role="group" class="btn-group mr-2 sw-btn-group-extra">
                  <button class="btn btn-danger">Cancel</button>
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
export default {};
</script>