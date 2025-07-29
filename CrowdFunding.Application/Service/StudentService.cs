using System;
using System.Collections.Generic;
using AutoMapper;
using CrowdFunding.Application.Contract;
using CrowdFunding.Application.DTOs.StudentDto;
using CrowdFunding.Domain.Entities;
using CrowdFunding.Infrastructure.Interfaces;

namespace CrowdFunding.Application.Service
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
        {
            var students = await _unitOfWork.Students.GetAllAsync();
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }

        public async Task<StudentDto?> GetStudentByIdAsync(int id)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(id);
            return _mapper.Map<StudentDto>(student);
        }

        public async Task<StudentDto> CreateStudentAsync(StudentCreateDto createDto)
        {
            var existingStudent = await _unitOfWork.Students.GetByEmailAsync(createDto.Email);
            if (existingStudent != null)
            {
                throw new ArgumentException("A student with this email already exists.");
            }

            var student = _mapper.Map<Student>(createDto);

            student.PasswordHash = createDto.Password; 


            await _unitOfWork.Students.AddAsync(student);
            await _unitOfWork.CompleteAsync(); 

            return _mapper.Map<StudentDto>(student);
        }

    }
}
