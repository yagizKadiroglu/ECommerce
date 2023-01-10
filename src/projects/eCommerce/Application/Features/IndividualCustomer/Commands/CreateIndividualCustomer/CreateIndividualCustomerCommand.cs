using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.IndividualCustomer.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Domain.Entities;

namespace Application.Features.IndividualCustomer.Commands.CreateIndividualCustomer
{
    public class CreateIndividualCustomerCommand:IRequest<CreatedIndividualCustomerDto>
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }
    }

    public class CreateIndividualCustomerCommandHandler:IRequestHandler<CreateIndividualCustomerCommand,CreatedIndividualCustomerDto>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IMapper _mapper;

        public CreateIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _mapper = mapper;
        }

        public async Task<CreatedIndividualCustomerDto> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.IndividualCustomer mappedIndividualCustomer =
                _mapper.Map<Domain.Entities.IndividualCustomer>(request);

            Domain.Entities.IndividualCustomer createdIndividualCustomer =
                await _individualCustomerRepository.AddAsync(mappedIndividualCustomer);

            CreatedIndividualCustomerDto createdIndividualCustomerDto =
                _mapper.Map<CreatedIndividualCustomerDto>(createdIndividualCustomer);

            return createdIndividualCustomerDto;

        }
    }
}
