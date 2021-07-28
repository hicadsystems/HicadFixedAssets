<template>
  <div class="page-wrapper">
    <div class="page-header">
      <div class="row align-items-end">
        <div class="col-lg-8">
          <div class="page-header-title">
            <div class="d-inline">
              <h4>Asset Movement</h4>
              <span>Move Asset To Another Department</span>
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

    <div class="page-body">
      <div class="card">
        <form>
          <div class="card-body">
            <div class="row">
              <div class="col-sm-8 col-md-8 col-xl-8 m-b-30">
                <h4 class="sub-title">Assert Description</h4>
                <select
                  name="aassetdesc"
                  class="form-control form-control-inverse"
                >
                  <option selected>Select Asset</option>
                  <option value="opt1">ABUJA LAND AT GARKI</option>
                  <option value="opt2">10 TABLES FOR CONFERENCE ROOM</option>
                  <option value="opt3">VOLKS WAGON BUS</option>
                </select>
              </div>

              <div class="col-sm-4 col-md-4 col-xl-4 m-b-30">
                <h4 class="sub-title">Movement Date</h4>
                <input
                  name="Date"
                  placeholder="dd/mm/yyyy"
                  class="form-control-inverse"
                />
              </div>
            </div>
            <div class="row">
              <div class="col-sm-12 col-md-12 col-xl-8 m-b-30">
                <div class="form-group">
                  <label class="form-label">Old Location</label>
                  <input
                    name="oldlocation"
                    placeholder="Old Location"
                    class="form-control"
                    readonly
                  />
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-sm-12 col-md-12 col-xl-8 m-b-30">
                <h4 class="sub-title">New Location</h4>
                <select
                  name="aassetdesc"
                  class="form-control form-control-inverse"
                >
                  <option selected>Select New Department</option>
                  <option value="opt1">ABUJA LAND AT GARKI</option>
                  <option value="opt2">10 TABLES FOR CONFERENCE ROOM</option>
                  <option value="opt3">VOLKS WAGON BUS</option>
                </select>
              </div>
            </div>
            <div class="row">
              <div class="col-6">
                <div role="group" class="btn-group mr-2 sw-btn-group-extra">
                  <button type="submit" class="btn btn-submit btn-primary">
                    Accept
                  </button>
                </div>
                <div role="group" class="btn-group mr-2 sw-btn-group-extra">
                  <button type="submit" class="btn btn-submit btn-danger">
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
export default {
  data() {
    return {
      year: new Date().getFullYear(),
    };
  },
};
</script>