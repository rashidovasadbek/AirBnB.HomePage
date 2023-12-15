<template>

    <div class="p fixed h-20 top-0 z-10 content-padding w-full bg-defaultBackground flex justify-between items-center border-b border-borderSecondary text-textPrimary">

      <!--Loge-->
      <main-logo/>

      <!-- Location menu -->
      <locations-menu/>

      <!-- Profile menu -->
      <profile-menu/>

      <!-- Locations filter -->

      <!-- Bottom border -->
      <div class="absolute border-b-2 border-borderSecondary"></div>

    </div>

</template>
<script setup lang="ts">
import MainLogo from "@/common/components/icons/MainLogo.vue";
import LocationsMenu from "@/modules/locations/companents/LocationsMenu.vue";
import ProfileMenu from "@/modules/locations/companents/ProfileMenu.vue";

</script>