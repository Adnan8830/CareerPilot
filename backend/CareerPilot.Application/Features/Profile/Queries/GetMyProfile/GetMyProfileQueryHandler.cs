using CareerPilot.Application.DTOs;
using CareerPilot.Application.Interfaces;
using CareerPilot.Application.Interfaces.Repositories;
using MediatR;

namespace CareerPilot.Application.Features.Profile.Queries.GetMyProfile;

public class GetMyProfileQueryHandler
    : IRequestHandler<GetMyProfileQuery, ProfileDto>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IUserRepository _userRepository;
    private readonly ICacheService _cacheService;

    public GetMyProfileQueryHandler(
    ICurrentUserService currentUserService,
    IUserRepository userRepository,
    ICacheService cacheService)
    {
        _currentUserService = currentUserService;
        _userRepository = userRepository;
        _cacheService = cacheService;
    }

    public async Task<ProfileDto> Handle(
        GetMyProfileQuery request,
        CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;
        var cacheKey = $"Profile_{userId}";


        var cachedProfile = await _cacheService.GetAsync<ProfileDto>(cacheKey);

        if (!(cachedProfile is null))
        {
            return cachedProfile;
        }
        var user = await _userRepository.GetByIdAsync(userId);

        if (user == null)
        {
            throw new NotFoundException("User not found.");
        }

        var profile = new ProfileDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            LinkedInUrl = user.LinkedInUrl,
            GitHubUrl = user.GitHubUrl,
            YearsOfExperience = user.YearsOfExperience
        };

        await _cacheService.SetAsync(
            cacheKey,
            profile,
            TimeSpan.FromMinutes(5),
            TimeSpan.Zero);

        return profile;
    }
}