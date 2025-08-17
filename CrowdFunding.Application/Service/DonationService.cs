using System;
using System.Collections.Generic;
using AutoMapper;
using CrowdFunding.Application.Contract;
using CrowdFunding.Application.DTOs.DonationDto;
using CrowdFunding.Domain.Entities;
using CrowdFunding.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CrowdFunding.Application.Service
{
    public class DonationService : IDonationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DonationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DonationDto> CreateDonationAsync(DonationCreateDto createDto)
        {

            var project = await _unitOfWork.Projects.GetByIdAsync(createDto.ProjectId);
            if (project == null)
            {
                throw new KeyNotFoundException($"Project with ID {createDto.ProjectId} not found for donation.");
            }

            var donation = _mapper.Map<Donation>(createDto);

            project.ReceiveDonation(donation.Amount);

            await _unitOfWork.Donations.AddAsync(donation);

            _unitOfWork.Projects.Update(project);

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<DonationDto>(donation);
        }

        public async Task<IEnumerable<DonationDto>> GetDonationsByProjectIdAsync(int projectId)
        {
            var donations = await _unitOfWork.Donations.GetDonationsByStudentProjectIdAsync(projectId); // Usa el método específico del repositorio
            return _mapper.Map<IEnumerable<DonationDto>>(donations);
        }

        
        public async Task<IEnumerable<DonationDto>> GetAllDonationsAsync()
        {
            // Llama al nuevo método GetAllAsync() en el repositorio
            var donations = await _unitOfWork.Donations.GetAllAsync();

            // Mapea el resultado a un DTO y lo devuelve
            return _mapper.Map<IEnumerable<DonationDto>>(donations);
        }


        public async Task UpdateDonationAsync(int id, DonationUpdateDTO updateDto)
        {
            var donation = await _unitOfWork.Donations.GetByIdAsync(id);
            if (donation == null)
            {
                throw new KeyNotFoundException("Donación no encontrada.");
            }

            // Obtiene el monto original de la donación antes de la actualización
            var originalAmount = donation.Amount;

            // Actualiza la donación con los nuevos datos
            _mapper.Map(updateDto, donation);

            // Encuentra el proyecto relacionado
            var project = await _unitOfWork.Projects.GetByIdAsync(donation.ProjectId);
            if (project == null)
            {
                throw new InvalidOperationException("El proyecto asociado a la donación no existe.");
            }

            // Calcula la diferencia y ajusta el monto del proyecto
            var amountDifference = donation.Amount - originalAmount;
            project.AmountRaised += amountDifference;

            await _unitOfWork.CompleteAsync();
        }

        
        public async Task DeleteDonationAsync(int id)
        {
            // Encuentra la donación por su ID
            var donation = await _unitOfWork.Donations.GetByIdAsync(id);
            if (donation == null)
            {
                throw new KeyNotFoundException("Donación no encontrada.");
            }

            // Encuentra el proyecto relacionado
            var project = await _unitOfWork.Projects.GetByIdAsync(donation.ProjectId);
            if (project == null)
            {
                // Puedes lanzar una excepción si el proyecto no existe
                throw new InvalidOperationException("El proyecto asociado a la donación no existe.");
            }

            // Resta el monto de la donación al monto total recaudado del proyecto
            project.AmountRaised -= donation.Amount;


            //  Elimina la donación
            _unitOfWork.Donations.Delete(donation);

            // Guarda todos los cambios de una vez
            await _unitOfWork.CompleteAsync();
        }
    }
}
