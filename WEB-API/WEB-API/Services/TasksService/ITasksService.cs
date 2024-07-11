using WEB_API.Models;

namespace WEB_API.Services.TasksService
{
    public interface ITasksService
    {
        /// <summary>
        /// Create a new task based on the object received.
        /// </summary>
        /// <param name="task">The task object which is going to be added.</param>
        /// <returns>Return a serviceResponse with the result for the operation.</returns>
        ServiceResponse<Tasks> Add(Tasks task);

        /// <summary>
        /// Update/edit a task based on the object received.
        /// </summary>
        /// <param name="task">The task object which is going to be edited.</param>
        /// <returns>Return a serviceResponse with the result for the operation.</returns>
        ServiceResponse<Tasks> Update(Tasks task);

        /// <summary>
        /// Delete a task based on the id received.
        /// </summary>
        /// <param name="id">The id from the task that's being deleted.</param>
        /// <returns>Return a serviceResponse with the result for the operation.</returns>
        ServiceResponse<Tasks> Delete(int id);

        /// <summary>
        /// Get all tasks registered in the database.
        /// </summary>
        /// <returns>Return a serviceResponse with the result for the operation.</returns>
        ServiceResponse<IList<Tasks>> GetAll();

        /// <summary>
        /// Get a task based on the id received.
        /// </summary>
        /// <param name="id">The task which the id is going to return.</param>
        /// <returns>Return a serviceResponse with the result for the operation.</returns>
        ServiceResponse<Tasks> GetTaskById(int id);
    }
}
