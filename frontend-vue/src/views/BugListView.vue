<template>
    <header>
        <h1>Bug List</h1>
    </header>

    <main>
        <RouterLink to="/create">Create Bug</RouterLink>
        
        <div v-for="bug in bugs" :key="bug.id">
            <h2>{{ bug.displayID }}</h2>
            <p>Title: {{ bug.title }}</p>
            <p>Description: {{ bug.description }}</p>
            <p>Status: {{ formatStatus(bug.status) }}</p>
            <p>Priority: {{ bug.priority }}</p>
            <p>Created At: {{ formatTimestamp(bug.createdAt) }}</p>
        </div>
    </main>
</template>

<script setup lang="ts">
import { ref, onMounted} from 'vue'
import { RouterLink } from 'vue-router'
import type { BugGet } from '@/types/bug'
import { formatStatus, formatTimestamp, BACKEND_BASE_URL } from '@/utils/utils'

const bugs = ref<BugGet[]>([])

onMounted(async () => 
{
    const response = await fetch(`${BACKEND_BASE_URL}/bugs`)
    const data = await response.json()
    bugs.value = data
})
</script>

<style scoped>
</style>