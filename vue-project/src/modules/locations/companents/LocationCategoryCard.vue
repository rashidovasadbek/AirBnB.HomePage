<template>

  <button type="button" @click="filter">
    <div class="h-[80px] select-common group min-w-[50px] flex flex-col justify-center items-center">
      <img class="h-[24px] w-[24px] mb-2 select-logo-img select-transition"
           :src="locationCategory.imagePath"
           alt="Location selection icon">
      <h5 class="text-xs font-medium select-text select-transition whitespace-nowrap">{{locationCategory.name}}</h5>
      <div class="mt-[10px] w-4/5 h-[2px] select-item select-transition"></div>
    </div>
  </button>

</template>

<script setup lang="ts">

import {defineProps, onBeforeMount} from "vue";
import type { LocationCategory } from "../models/locationCategory";
import locationCategories from "@/modules/locations/companents/LocationCategories.vue";
import {AirBnBApiClient} from "@/Infrastructures/AirBnBApiClient/brokers/AirBnBApiClient";

const props = defineProps({
    locationCategory: {
      type:  Object as () => LocationCategory,
      required: true
    }
});

var airBnbApiClient = new AirBnBApiClient();
function filter(event: any) {
  alert(
      /*onBeforeMount(async () =>
      {
        const locationResponse = await airBnbApiClient.locationCategories.getAsync();
        locationCategories.value = locationResponse.response!;

        console.log("test", locationCategories.value)
    })*/
  )
  // `event` is the native DOM event
  if (event) {
  }
}
</script>