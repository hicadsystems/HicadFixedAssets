<template>
    <div>
        <!-- Asset Class Form -->
        <div class="page-wrapper">
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
                <form>
                   <div class="card-body">
                        <div class="row">
                        <div class="col-sm-2 col-md-2 col-xl-2">
                            <div class="form-group">
                                <label class="form-label">Class Code</label>
                                <input type="text" name="Code" class="form-control" />
                            </div>
                        </div>
                        <div class="col-6 col-xl-6">
                            <div class="form-group">
                                <label class="form-label"> Class Description</label>
                                <input class="form-control" name="Description" />
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
                                                    <input class="form-control" type="text">
                                                </div>
                                                <h5>%</h5>
                                        </div>
                                        <div class="form-group row">
                                                <label for="rate" class="col-sm-4 col-form-label">Method :</label>
                                                <div class="col-sm-7">
                                                    <select class="form-control" type="text"></select>
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
                                                <select class="form-control" type="text"></select>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="rate" class="col-sm-4 col-form-label">Accum.Depr.Code :</label>
                                            <div class="col-sm-7">
                                                <select class="form-control" type="text"></select>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="rate" class="col-sm-4 col-form-label">Expenses Code :</label>
                                            <div class="col-sm-7">
                                                <select class="form-control" type="text"></select>
                                            </div>
                                        </div>
                                    </fieldset>
                                </form>
                            </div>
                            <div>
                                <button type="submit" class="btn btn-primary mb-2">Add</button>
                                <button type="submit" class="btn btn-primary mb-2">Delete</button>
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
        vuejsDatepicker
    }
}
</script>
<style scoped>
/* .label {
  display: inline-block;
  width: 140px;
  text-align: right;
}​ */
</style>