<template>
  <div class="flex gap-6 md:gap-12 overflow-x-scroll no-scrollbar">
    <location-category-card v-for="location in locationCategories" @onCategorySelected="onCategorySelected"
                            :locationCategory="location" :selectedCategoryId="selectedCategoryId"/>
  </div>
</template>

<script lang="ts" setup>

import {AirBnBApiClient} from "@/Infrastructures/AirBnBApiClient/brokers/AirBnBApiClient";
import {defineEmits, defineProps, onBeforeMount, ref} from "vue";
import LocationCategoryCard from "@/modules/locations/companents/LocationCategoryCard.vue";
import {LocationCategory} from "@/modules/locations/models/locationCategory";

const airBnbApiClient = new AirBnBApiClient();
const locationCategories = ref<LocationCategory[]>([]);

onBeforeMount(async () => {
  const locationResponse = await airBnbApiClient.locationCategories.getAsync();
  locationCategories.value = locationResponse.response!;

  console.log("test", locationCategories.value)

});

const props = defineProps({
  selectedCategoryId: {
    type: String,
    required: true
  }
});

const emit = defineEmits<{
  'onCategorySelected': [id: string]
}>();

const onCategorySelected = (id: string) => {
  emit('onCategorySelected', id);
}

</script>