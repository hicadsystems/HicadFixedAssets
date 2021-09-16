import Vuex from 'vuex'
import Vue from 'vue'
import moment from 'moment'

Vue.use(Vuex)
Vue.use(moment)

export default new Vuex.Store({
  state: {
    objectToUpdate:null // The TV inventory
  },
  
  getters: {
    // Here we will create a getter
  },
  
  mutations: {
    // Here we will create Jenny
    // Jenny
    updateBalSheet(state, newObj) {
        state.objectToUpdate = newObj
      }
  },
  
  actions: {
    // Here we will create Larry
    updateBalSheet(context) {
        // For now we only remove a tv,
        // but this action can contain logic
        // so we could expand it in the future.
        
          // If we enough TVs, ask Jenny to remove it
          context.commit('updateBalSheet', newObj)
        
      }
  }
});