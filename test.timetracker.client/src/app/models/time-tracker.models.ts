export interface TimeEntry
{
    id:number;
    personId:number;
    personName:string;
    taskId:number;
    taskName:string;
    dateAndTime:string
}

export interface Person
{
    id:number;
    name:string;
}

export interface TaskItem
{
    id:number;
    taskName:string;
    description:string
}