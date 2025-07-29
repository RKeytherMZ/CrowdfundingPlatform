using System;
using System.Collections.Generic;
using AutoMapper;
using CrowdFunding.Application.Contract;
using CrowdFunding.Application.DTOs.DonationDto;
using CrowdFunding.Domain.Entities;
using CrowdFunding.Infrastructure.Interfaces;

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
    }
}
