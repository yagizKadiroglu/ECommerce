using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.IndividualCustomer.Commands.CreateIndividualCustomer;
using Application.Features.IndividualCustomer.Commands.DeleteIndividualCustomer;
using Application.Features.IndividualCustomer.Commands.UpdateIndividualCustomer;
using Application.Features.IndividualCustomer.Dtos;
using Application.Features.IndividualCustomer.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.IndividualCustomer.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.IndividualCustomer, CreatedIndividualCustomerDto>().ReverseMap();
            CreateMap<Domain.Entities.IndividualCustomer, CreateIndividualCustomerCommand>().ReverseMap();
            CreateMap<Domain.Entities.IndividualCustomer, UpdatedIndividualCustomerDto>().ReverseMap();
            CreateMap<Domain.Entities.IndividualCustomer, UpdateIndividualCustomerCommand>().ReverseMap();
            CreateMap<Domain.Entities.IndividualCustomer, DeletedIndividualCustomerDto>().ReverseMap();
            CreateMap<Domain.Entities.IndividualCustomer, DeleteIndividualCustomerCommand>().ReverseMap();

            CreateMap<IPaginate<Domain.Entities.IndividualCustomer>, IndividualCustomerListModel>().ReverseMap();
            CreateMap<Domain.Entities.IndividualCustomer, IndividualCustomerListDto>().ReverseMap();
            CreateMap<Domain.Entities.IndividualCustomer, IndividualCustomerDto>().ReverseMap();
        }
    }
}
