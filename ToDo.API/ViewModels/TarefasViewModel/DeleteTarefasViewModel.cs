using System.ComponentModel.DataAnnotations;

namespace ToDo.API.ViewModels.TasksViewModel;

public class DeleteTarefasViewModel
{
    [Required(ErrorMessage = "É preciso informar o id da task.")]
    public Guid Id { get; set; }
}