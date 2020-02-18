using Campus.net.Domain.MainData;
using Campus.net.Shared;
using System.Collections.Generic;

namespace Campus.net.DAL
{
    public interface IStudentRepository : IRepository<Student>
    {
        IReadOnlyCollection<Student> GetPaginatedCountOfStudents(PaginationDto paginationDto);
    }
}