export function formatStatus(status: string) : string
{
    if (status == "InProgress")
        return "In Progress";

    else if (status == "In Progress")
        return "InProgress";

    return status;
}

const dateFormatter = new Intl.DateTimeFormat('en-US', {
    month: "short",
    day: "numeric",
    year: "numeric",
    hour: "2-digit",
    minute: "2-digit",
})

export function formatTimestamp(timestamp: string) : string
{
    const date = new Date(timestamp);
    return dateFormatter.format(date);
}

export const BACKEND_BASE_URL = 'http://localhost:5238/api';