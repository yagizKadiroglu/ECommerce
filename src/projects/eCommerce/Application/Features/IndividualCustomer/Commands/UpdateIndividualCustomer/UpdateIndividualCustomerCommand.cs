using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.IndividualCustomer.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.IndividualCustomer.Commands.UpdateIndividualCustomer
{
    public class UpdateIndividualCustomerCommand:IRequest<UpdatedIndividualCustomerDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }
    }

    public class UpdateIndividualCustomerCommandHandler:IRequestHandler<UpdateIndividualCustomerCommand,UpdatedIndividualCustomerDto>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IMapper _mapper;

        public UpdateIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedIndividualCustomerDto> Handle(UpdateIndividualCustomerCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.IndividualCustomer mappedIndividualCustomer =
                _mapper.Map<Domain.Entities.IndividualCustomer>(request);
            Domain.Entities.IndividualCustomer updatedIndividualCustomer =
                await _individualCustomerRepository.UpdateAsync(mappedIndividualCustomer);

            UpdatedIndividualCustomerDto updatedIndividualCustomerDto =
                _mapper.Map<UpdatedIndividualCustomerDto>(updatedIndividualCustomer);

            return updatedIndividualCustomerDto;


        }
    }
}
