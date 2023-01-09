using Application.Services.Repositories;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Auth
{
    public class AuthManager:IAuthService
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly ITokenHelper _tokenHelper;


        public AuthManager(IUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _tokenHelper = tokenHelper;
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {
            IPaginate<UserOperationClaim> userOperationClaims =
                await _userOperationClaimRepository.GetListAsync(u => u.UserId == user.Id,
                    include: u => u.Include(u => u.OperationClaim));

            IList<OperationClaim> operationClaims = userOperationClaims.Items.Select(u => new OperationClaim
            {
                Id = u.OperationClaim.Id, Name = u.OperationClaim.Name
            }).ToList();

            AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
            return accessToken;
        }
    }
}
