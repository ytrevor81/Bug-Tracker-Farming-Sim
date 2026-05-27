export interface BugGet
{
    id: number
    displayID: string
    title: string
    description: string
    status: string
    priority: string
    createdAt: string
}

export interface BugPost
{
    displayID: string
    title: string
    description: string
    status: string
    priority: string
}