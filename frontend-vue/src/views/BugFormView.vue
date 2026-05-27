<template>
    <main>
        <RouterLink to="/">Back Home</RouterLink>
        <h1>Submit Bug</h1>
        <form @submit.prevent="submitForm">
            <div>
                <label for="displayID">Display ID (eventually auto-generated)</label>
                <input id="displayID" v-model="displayID" type="text">
            </div>
            <div>
                <label for="title">Title</label>
                <input id="title" v-model="title" type="text">
            </div>
            <div>
                <label for="description">Description</label>
                <textarea id="description" v-model="description"></textarea>
            </div>
            <div>
                <label for="status">Status</label>
                <select id="status" v-model="status">
                    <option value="Open">Open</option>
                    <option value="InProgress">In Progress</option>
                    <option value="Fixed">Fixed</option>
                    <option value="Reopened">Reopened</option>
                    <option value="Closed">Closed</option>
                </select>
            </div>
            <div>
                <label for="priority">Priority</label>
                <select id="priority" v-model="priority">
                    <option value="Low">Low</option>
                    <option value="Medium">Medium</option>
                    <option value="High">High</option>
                    <option value="Critical">Critical</option>
                </select>
            </div>

            <button type="submit">Submit</button>
        </form>
    </main>

</template>

<script setup lang="ts">
import { ref } from 'vue'
import { RouterLink } from 'vue-router'
import type { BugPost } from '@/types/bug'
import { BACKEND_BASE_URL } from '@/utils/utils'

const displayID = ref('')
const title = ref('')
const description = ref('')
const status = ref('Open')
const priority = ref('Low')

async function submitForm()
{
    const bug: BugPost = {
        displayID: displayID.value,
        title: title.value,
        description: description.value,
        status: status.value,
        priority: priority.value,
    }

    const response = await fetch(`${BACKEND_BASE_URL}/bugs`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(bug)
    })
}
</script>

<style scoped>
</style>