window.Vue = require('vue')
window.axios = require('axios')
import store from './store'

import CreateCompanyComponent from './components/CreateCompanyComponent.vue';
import ViewCompanyComponent from './components/ViewCompanyComponent.vue';
import CreateCostCenter from './components/CreateCostCenter.vue';
import ViewCostCenter from './components/ViewCostCenter.vue';
import CreateBusinesslineComponent from './components/CreateBusinesslineComponent.vue';
import ViewBusinesslineComponent from './components/ViewBusinesslineComponent.vue';

const files = require.context('./', true, /\.vue$/i)
files.keys().map(key => Vue.component(key.split('/').pop().split('.')[0], files(key).default));

Vue.component('create-company-component', CreateCompanyComponent);
Vue.component('view-company-component',ViewCompanyComponent);
Vue.component('create-cost-center',CreateCostCenter);
Vue.component('view-cost-center',ViewCostCenter);
Vue.component('create-businessline-component',CreateBusinesslineComponent);
Vue.component('view-businessline-component',ViewBusinesslineComponent);
 
const app = new Vue({
    el: "#app",
    store
});