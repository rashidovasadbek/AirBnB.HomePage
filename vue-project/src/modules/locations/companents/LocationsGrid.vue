<template>
  <div class="mt-[160px] grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-5 xl:grid-cols-5 gap-y-10 gap-x-4 place-items-center">

    <location-card v-for="location in locations" :location="location"/>

  </div>
</template>
<script setup lang="ts">

import LocationCard from "@/modules/locations/companents/LocationCard.vue";
import {AirBnBApiClient} from "@/Infrastructures/AirBnBApiClient/brokers/AirBnBApiClient";
import {onBeforeMount, type PropType, ref} from "vue";
import {LocationFilter} from "@/modules/locations/models/LocationFilter";
import {Location} from "@/modules/locations/models/Location";

const airBnbApiClient = new AirBnBApiClient();

const props = defineProps({
  locations: {
    type: Array as PropType<Array<Location>>,
    required: true
  }
});
</script>