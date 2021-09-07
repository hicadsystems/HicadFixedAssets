<template>
  <!-- WRAPPER -->
  <div>
    <div class="card-body">
      <div>
        <button type="button" class="btn btn-submit btn-primary" v-on:click="generateReport">
          Print Report
        </button>
      </div>
      <div v-if="responseMessage" class="has-error">{{ responseMessage }}</div>
      <table
        id="datatables-buttons"
        class="table table-striped"
        style="width: 100%"
      >
        <thead>
          <tr>
            <th>Code</th>
            <th>Description</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(costCenter, index) in costCenterList" :key="index">
            <td>{{ costCenter.unitcode }}</td>
            <td>{{ costCenter.unitdesc }}</td>

            <td>
              <button
                type="button"
                class="btn btn-submit btn-primary"
                @click="processRetrieve(costCenter)"
              >
                Edit
              </button>
              <button
                type="button"
                class="btn btn-submit btn-primary"
                @click="processDelete(costCenter.id)"
              >
                Delete
              </button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>

  <!-- END WRAPPER -->
</template>

<script>
export default {
  data() {
    return {
      costCenterList: null,
      responseMessage: "",
    };
  },
  created() {
    this.$store.state.objectToUpdate = null;
  },
  watch: {
    "$store.state.objectToUpdate": function (newVal, oldVal) {
      this.getAllCostCenters();
      this.processDelete();
    },
  },
  mounted() {
    this.getAllCostCenters();
    this.processDelete();
  },
  methods: {
    processRetrieve: function (costCenter) {
      this.$store.state.objectToUpdate = costCenter;
    },
    processDelete: function (id) {
      axios
        .get(`/api/CostCenter/RemoveCostCenter/${id}`)
        .then((response) => {
          if (response.data.responseCode == "200") {
            alert("balance sheet successfully deleted");
            this.getAllCostCenters();
          }
        })
        .catch((e) => {
          this.errors.push(e);
        });
    },
    getAllCostCenters: function () {
      axios
        .get("/api/CostCenter/getAllCostCenters")
        .then((response) => (this.costCenterList = response.data));
    },
    generateReport(){
       window.open(`/Statictable/PrintCostcenter/`, "_blank")
    }
  },
};
</script>