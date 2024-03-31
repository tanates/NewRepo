export type AddProjectType = {
    Id :string , 
    NameProject:string ,
    CustomerCompany :string , 
    ExecutingCompany : string ,  
    emailEmployee : string ,
    StartDateProject : Date, 
    EndDateProject : Date,
    PriorityProject: number
}
export type RemoveProject = {
    id:string; 
    name :string
}

