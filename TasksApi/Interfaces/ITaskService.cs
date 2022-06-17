﻿using NSMktAPI.Responses;

namespace NSMktAPI.Interfaces
{
    public interface ITaskService
    {
        Task<GetTasksResponse> GetTasks(int userId);

        Task<SaveTaskResponse> SaveTask(Task task);

        Task<DeleteTaskResponse> DeleteTask(int taskId, int userId);
    }
}
