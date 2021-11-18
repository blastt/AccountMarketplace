using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public class LoginQuery : IRequest<UserDto>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginQueryHandler : IRequestHandler<LoginQuery, UserDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;
        private readonly IJwtGenerator _jwtGenerator;

        public LoginQueryHandler(IApplicationDbContext context, IMapper mapper, IIdentityService identityService, IJwtGenerator jwtGenerator)
        {
            _context = context;
            _mapper = mapper;
            _identityService = identityService;
            _jwtGenerator = jwtGenerator;
        }
        public async Task<UserDto> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var userId = await _identityService.GetUserIdAsync(request.UserName);
            if (userId == null)
            {
                throw new Exception(HttpStatusCode.Unauthorized.ToString());
            }
            var result = await _identityService.CheckPasswordSignInAsync(userId, request.Password);

            if (result.Succeeded)
            {
                return new UserDto
                {
                    Email = "Not implemented",
                    Token = _jwtGenerator.CreateToken(request.UserName),
                    UserName = request.UserName,
                    Roles = (await _identityService.GetUserRoles(userId)).ToArray()
                };
            }
            throw new Exception(HttpStatusCode.Unauthorized.ToString());
        }
    }
}
