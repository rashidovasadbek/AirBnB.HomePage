<template>

  <div class="fixed w-full top-0 pt-2 mt-20 z-10 bg-white  flex items-center justify-center gap-4 content-padding">

        <!-- Location previous pagination -->
        <div class="md-3">
          <button class="border border-borderSecondary h-8 w-8 flex items-center justify-center rounded-full shadow-md">
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32" aria-hidden="true" role="presentation" focusable="false"
                 style="display: block; fill: none; height: 12px; width: 12px; stroke: currentcolor; stroke-width: 5.33333; overflow: visible;">
              <path fill="none" d="M20 28 8.7 16.7a1 1 0 0 1 0-1.4L20 4"></path>
            </svg>
          </button>
        </div>

        <!-- Locations categories -->
        <location-categories/>

        <!-- Location next pagination -->
        <div class="md-3">
          <button class="border border-borderSecondary h-8 w-8 flex items-center justify-center rounded-full shadow-md">
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32" aria-hidden="true" role="presentation " focusable="false"
                 style="display: block; fill: none; height: 12px; width: 12px; stroke: currentcolor; stroke-width: 5.33333; overflow: visible;">
              <path
                  fill="none" d="m12 4 11.3 11.3a1 1 0 0 1 0 1.4L12 28"></path>
            </svg>
          </button>
        </div>

        <!-- Filters actions -->
        <div class="w-[500px] hidden lg:flex items-center justify-center pb-3">

          <!-- Locations filter -->
          <button class="ml-3 flex group h-12 w-auto px-4 border border-borderSecondary justify-center items-center rounded-lg gap-3">
            <svg class="text-textSecondary select-text" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32" aria-hidden="true"
                 role="presentation"
                 focusable="false"
                 style="display: block; fill: none; height: 16px; width: 16px; stroke: currentcolor; stroke-width: 4; overflow: visible;">
              <path fill="none"
                    d="M7 16H3m26 0H15M29 6h-4m-8 0H3m26 20h-4M7 16a4 4 0 1 0 8 0 4 4 0 0 0-8 0zM17 6a4 4 0 1 0 8 0 4 4 0 0 0-8 0zm0 20a4 4 0 1 0 8 0 4 4 0 0 0-8 0zm0 0H3"></path>
            </svg>
            <span>Filters</span>
          </button>

          <button class="ml-3 flex group h-12 w-auto px-4 border border-borderSecondary justify-center items-center rounded-lg gap-3">
            <span class="text-xs font-medium whitespace-nowrap">Display total before taxes</span>
          </button>

        </div>

  </div>

</template>
<script setup lang="ts">
import LocationCategories from "@/modules/locations/companents/LocationCategories.vue";
</script>