using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.IndividualCustomer.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.IndividualCustomer.Commands.DeleteIndividualCustomer
{
    public class DeleteIndividualCustomerCommand:IRequest<DeletedIndividualCustomerDto>
    {
        public int Id { get; set; }
    }

    public class DeleteIndividualCustomerHandler:IRequestHandler<DeleteIndividualCustomerCommand,DeletedIndividualCustomerDto>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IMapper _mapper;
        public async Task<DeletedIndividualCustomerDto> Handle(DeleteIndividualCustomerCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.IndividualCustomer mappedIndividualCustomer = _mapper.Map<Domain.Entities.IndividualCustomer>(request);
            Domain.Entities.IndividualCustomer? getDeleteIndividualCustomer = await _individualCustomerRepository.GetAsync(i => i.Id == request.Id);
            Domain.Entities.IndividualCustomer deletedIndividualCustomer = await _individualCustomerRepository.DeleteAsync(getDeleteIndividualCustomer);
            DeletedIndividualCustomerDto deletedIndividualCustomerDto = _mapper.Map<DeletedIndividualCustomerDto>(deletedIndividualCustomer);

            return deletedIndividualCustomerDto;

        }
    }
}
