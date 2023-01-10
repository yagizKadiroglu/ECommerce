using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.IndividualCustomer.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.IndividualCustomer.Queries.GetByIdIndividualCustomer
{
    public class GetByIdIndividualCustomerQuery:IRequest<IndividualCustomerDto>
    {
        public int Id { get; set; }
    }

    public class GetByIdIndividualCustomerQueryHandler:IRequestHandler<GetByIdIndividualCustomerQuery,IndividualCustomerDto>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IMapper _mapper;

        public GetByIdIndividualCustomerQueryHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _mapper = mapper;
        }

        public async Task<IndividualCustomerDto> Handle(GetByIdIndividualCustomerQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.IndividualCustomer individualCustomer = await _individualCustomerRepository.GetAsync(i => i.Id == request.Id);
            IndividualCustomerDto individualCustomerDto = _mapper.Map<IndividualCustomerDto>(individualCustomer);
            return individualCustomerDto;
        }
    }
}
