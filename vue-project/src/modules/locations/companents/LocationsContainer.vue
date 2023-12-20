<template>
  <!--Content-->
  <article class="mt-[20px] px[24px] px-[80px]">

    <div class="flex flex-col items-center justify-center">

      <!-- Locations tap-->
      <locations-tap @onCategorySelected="onCategorySelected" :selectedCategoryId="selectedCategoryId"/>

      <!--LocationsGrid-->
      <locations-grid :locations="locations"/>

    </div>

  </article>
</template>
<script setup lang="ts">
import LocationsTap from "@/modules/locations/companents/LocationsTab.vue";
import LocationsGrid from "@/modules/locations/companents/LocationsGrid.vue";
import {Location} from "@/modules/locations/models/Location";
import {onBeforeMount, ref} from "vue";
import {LocationFilter} from "@/modules/locations/models/LocationFilter";
import {AirBnBApiClient} from "@/Infrastructures/AirBnBApiClient/brokers/AirBnBApiClient";
import type {Guid} from "guid-typescript";

const airBnbApiClient = new AirBnBApiClient();

const locations = ref<Location[]>([])

onBeforeMount(async () => {
  await  loadAsync();
});

const loadAsync = async () => {
  const filter = new LocationFilter(null, 20, 1);
  const locationsResponse = await airBnbApiClient.locations.getAsync(filter);
  if(locationsResponse.isSuccess){
    locations.value = locationsResponse.response;
  }
}

const selectedCategoryId = ref<string>("");

const onCategorySelected = async (id: string) => {
  console.log(id)
  const filter = new LocationFilter(id, 10, 1);
  const locationsResponse = await airBnbApiClient.locations.getAsync(filter)
  selectedCategoryId.value = id;
  if(locationsResponse.isSuccess){
    locations.value = locationsResponse.response;
  }
}

</script>