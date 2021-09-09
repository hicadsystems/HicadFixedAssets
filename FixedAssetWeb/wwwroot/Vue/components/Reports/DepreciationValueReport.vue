<template>
      <v-data-table
        :headers="headers"
        :items="covidList"
        :items-per-page="5"
        :sort-by.sync="columnName"
        :sort-desc.sync="isDescending"
        class="elevation-1"
        ></v-data-table>
</template>
<script>
import $axios from 'axios';

export default {

    data(){
        return{
            columnName:'cases',
            isDescending:true,
            headers:[
                {
                    text:'area',
                    align:'start',
                    value:'name_ja',
                },
                {text:'cases',value:'cases'},
                {text:'deaths',value:'deaths'},
            ],
        }
    },
    async asyncData({ $axios }){
        const response = await $axios.get('https://covid19-japan-web-api.now.sh/api/v1/prefectures')
            return{
                covidList:response.data
            }
    }       
}
</script>