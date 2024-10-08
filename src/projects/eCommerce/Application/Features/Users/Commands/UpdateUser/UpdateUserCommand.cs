﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Users.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using MediatR;

namespace Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand:IRequest<UpdatedUserDto>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class  UpdateUserCommandHandler:IRequestHandler<UpdateUserCommand,UpdatedUserDto>
    {
        private readonly  IUserRepository _userRepository;
        private readonly  IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User mappedUser = _mapper.Map<User>(request);

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
            mappedUser.PasswordHash = passwordHash;
            mappedUser.PasswordSalt = passwordSalt;

            User updatedUser = await _userRepository.UpdateAsync(mappedUser);
            UpdatedUserDto updatedUserDto = _mapper.Map<UpdatedUserDto>(updatedUser);
            return updatedUserDto;
        }
    }
}
