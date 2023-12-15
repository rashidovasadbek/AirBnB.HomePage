<template>
  <!--Content-->
  <article class="mt-[20px] px[24px] px-[80px]">

    <div class="flex flex-col items-center justify-center">

      <!-- Locations tap-->
      <locations-tap />

      <!--LocationsGrid-->
      <locations-grid/>


    </div>

  </article>
</template>
<script setup lang="ts">
import LocationsTap from "@/modules/locations/companents/LocationsTap.vue";
import LocationsGrid from "@/modules/locations/companents/LocationsGrid.vue";
</script>