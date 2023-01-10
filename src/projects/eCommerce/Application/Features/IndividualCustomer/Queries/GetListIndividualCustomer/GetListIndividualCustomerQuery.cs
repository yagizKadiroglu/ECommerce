using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.IndividualCustomer.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.IndividualCustomer.Queries.GetListIndividualCustomer
{
    public class GetListIndividualCustomerQuery:IRequest<IndividualCustomerListModel>
    {
        public PageRequest PageRequest { get; set; }
    }
    public class GetListIndividualCustomerQueryHandler:IRequestHandler<GetListIndividualCustomerQuery,IndividualCustomerListModel>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IMapper _mapper;

        public GetListIndividualCustomerQueryHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _mapper = mapper;
        }

        public async Task<IndividualCustomerListModel> Handle(GetListIndividualCustomerQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Domain.Entities.IndividualCustomer> individualCustomers =
                await _individualCustomerRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

            IndividualCustomerListModel individualCustomerListModel =
                _mapper.Map<IndividualCustomerListModel>(individualCustomers);
            return individualCustomerListModel;
        }
    }
}
