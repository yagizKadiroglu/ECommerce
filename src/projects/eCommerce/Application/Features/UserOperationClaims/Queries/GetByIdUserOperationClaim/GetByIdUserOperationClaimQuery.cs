﻿using Application.Features.UserOperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Queries.GetByIdUserOperationClaim;

public class GetByIdUserOperationClaimQuery : IRequest<UserOperationClaimDto>
{
    public int Id { get; set; }

    public class
        GetByIdUserOperationClaimQueryHandler : IRequestHandler<GetByIdUserOperationClaimQuery, UserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public GetByIdUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository,
            IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }


        public async Task<UserOperationClaimDto> Handle(GetByIdUserOperationClaimQuery request,
            CancellationToken cancellationToken)
        {

            UserOperationClaim? userOperationClaim =
                await _userOperationClaimRepository.GetAsync(b => b.Id == request.Id);
            UserOperationClaimDto userOperationClaimDto = _mapper.Map<UserOperationClaimDto>(userOperationClaim);
            return userOperationClaimDto;
        }
    }
}