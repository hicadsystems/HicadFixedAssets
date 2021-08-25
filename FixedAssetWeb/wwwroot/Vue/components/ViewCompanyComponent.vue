<template>
    	<!-- WRAPPER -->
    <div>
        
        <div class="card-body">
            <div v-if="responseMessage" class="has-error"> {{ responseMessage }}</div>
            <table id="datatables-buttons" class="table table-striped" style="width:100%">
                <thead>
                    <tr>
                        <th>Company Code</th>
                        <th>Name</th>
                        <th>Address</th>
                        <th>Year</th>
                        <th>Month</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(balanceSheet,index) in companyList" :key="index">
                        <td>{{ balanceSheet.comp_code }}</td>
                        <td>{{ balanceSheet.comp_name }}</td>
                        <td>{{ balanceSheet.address }}</td>
                        <td>{{ balanceSheet.processyear }}</td>
                        <td>{{ balanceSheet.processmonth }}</td>
                        
                        <td>
                            <button type="button" class="btn btn-submit btn-primary" @click="processRetrieve(balanceSheet)">Edit</button>
                            <button type="button" class="btn btn-submit btn-primary" @click="processDelete(balanceSheet.id)">Delete</button>
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
                    companyList: null,
                    responseMessage:''
                };
            },
        created() {
            this.$store.state.objectToUpdate = null;
        },
    watch:{
         '$store.state.objectToUpdate':function (newVal, oldVal) {
            this.getAllCompany();
            //this.processDelete();
        }
    },
    mounted () {
        this.getAllCompany();
       // this.processDelete();
     },
     methods: {
 
        processRetrieve : function (balanceSheet) {
            this.$store.state.objectToUpdate = balanceSheet;
         },
         processDelete: function (id) {

             axios.get(`/api/Company/RemoveCompany/${id}`)
                 .then(response => {
                     if (response.data.responseCode == '200') {
                         
                         this.$alert("Company Deleted Successfully!!!", "Ok", "success");

                         this.getAllBalanceSheets();
                     }
                 }).catch(e => {
                            this.errors.push(e)
                        });

         },
         getAllCompany: function () {
             axios
            .get('/api/Company/getAllCompany')
            .then(response => (this.companyList = response.data))
         }
    }
    
};
</script>