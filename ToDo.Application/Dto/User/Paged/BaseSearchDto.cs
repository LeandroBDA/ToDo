namespace ToDo.Application.Dto.User.Paged;

public class BaseSearchDto
{
    public int Page { get; set; } = 1;
    public int PerPage { get; set; } = 10;
}