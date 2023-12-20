<template>

  <!--  <div v-if="isSelected">Selected</div>-->

  <button type="button" @click="onCategorySelected" class="select-none">
    <span class="h-[80px] select-common group min-w-[50px] flex flex-col justify-center items-center">
      <img class="h-[24px] w-[24px] mb-2  select-transition"
           :src="locationCategory.imagePath"
           alt="Location selection icon"
           :class="isSelected ? 'selected-opacity': 'opacity-40 select-opacity'">
      <span
          class="text-xs font-medium whitespace-nowrap select-none"
          :class="isSelected ? 'selected-opacity': 'opacity-40 select-opacity'"
      >{{ locationCategory.name }}</span>
      <span class="mt-[10px] w-4/5 h-[2px] bg-black"
            :class="isSelected ? 'selected-opacity': 'opacity-0 select-opacity'"
      ></span>
    </span>
  </button>

</template>

<script setup lang="ts">

import {defineProps, defineEmits, computed} from "vue";
import type {LocationCategory} from "../models/LocationCategory";

const props = defineProps({
  selectedCategoryId: {
    type: String,
    required: true
  },
  locationCategory: {
    type: Object as () => LocationCategory,
    required: true
  }
});

const emit = defineEmits<{
  'onCategorySelected': [id: string]
}>();


const onCategorySelected = () => {
  emit('onCategorySelected', props.locationCategory.id);
}

const isSelected = computed(() => props.locationCategory.id === props.selectedCategoryId);


</script>