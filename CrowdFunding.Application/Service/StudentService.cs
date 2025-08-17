using System;
using System.Collections.Generic;
using AutoMapper;
using CrowdFunding.Application.Contract;
using CrowdFunding.Application.DTOs.StudentDto;
using CrowdFunding.Domain.Entities;
using CrowdFunding.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<StudentDTO>> GetAllStudentsAsync()
        {
            var students = await _unitOfWork.Students.GetAllAsync();
            return _mapper.Map<IEnumerable<StudentDTO>>(students);
        }

        public async Task<StudentDTO?> GetStudentByIdAsync(int id)
        {
            var student = await _unitOfWork.Students.GetStudentWithProjectsAsync(id);
            if (student == null)
            {
                return null; // o NotFound() en el controlador
            }
            return _mapper.Map<StudentDTO>(student);
        }

        public async Task<StudentDTO> CreateStudentAsync(StudentCreateDto createDto)
        {
            var existingStudent = await _unitOfWork.Students.GetByEmailAsync(createDto.Email);
            if (existingStudent != null)
            {
                throw new ArgumentException("A student with this email already exists.");
            }

            var student = _mapper.Map<Student>(createDto);

            


            await _unitOfWork.Students.AddAsync(student);
            await _unitOfWork.CompleteAsync(); 

            return _mapper.Map<StudentDTO>(student);
        }

        public async Task UpdateStudentAsync(int id, StudentUpdateDto updateDto)
        {
            var existingStudent = await _unitOfWork.Students.GetByIdAsync(id);
            if (existingStudent == null)
            {
                throw new KeyNotFoundException("Estudiante no encontrado.");
            }

            // Mapea los campos del DTO al modelo de entidad
            _mapper.Map(updateDto, existingStudent);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteStudentAsync(int id)
        {
            // Obtienes el estudiante que quieres eliminar
            var existingStudent = await _unitOfWork.Students.GetByIdAsync(id);
            if (existingStudent == null)
            {
                throw new KeyNotFoundException("Estudiante no encontrado.");
            }

            // Le pasas la entidad completa a tu repositorio para que la elimine
            _unitOfWork.Students.Delete(existingStudent);
            await _unitOfWork.CompleteAsync();
        }

    }
}
