using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdFunding.Application.DTOs.StudentDto;

namespace CrowdFunding.Application.Contract
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDTO>> GetAllStudentsAsync();
        Task<StudentDTO?> GetStudentByIdAsync(int id);
        Task<StudentDTO> CreateStudentAsync(StudentCreateDto createDto);

        Task UpdateStudentAsync(int id, StudentUpdateDto updateDto);

        Task DeleteStudentAsync(int id);

    }
}
