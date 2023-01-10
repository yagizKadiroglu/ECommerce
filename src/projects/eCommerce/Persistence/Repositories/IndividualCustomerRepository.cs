﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class IndividualCustomerRepository:EfRepositoryBase<IndividualCustomer,BaseDbContext>,IIndividualCustomerRepository
    {
        public IndividualCustomerRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
