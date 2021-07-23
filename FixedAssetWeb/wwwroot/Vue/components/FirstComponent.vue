<template>
    <div>
        this year is {{ year }}
    </div>
</template>
<script>
export default {
    data(){
      return{
         year : new Date().getFullYear()
      } 
    }  
  
}
</script>