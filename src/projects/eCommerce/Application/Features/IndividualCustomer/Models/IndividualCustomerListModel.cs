using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.IndividualCustomer.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.IndividualCustomer.Models
{
    public class IndividualCustomerListModel:BasePageableModel
    {
        public List<IndividualCustomerListDto> Items { get; set; }
    }
}
