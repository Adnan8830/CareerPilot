using CareerPilot.Application.DTOs;
using MediatR;

namespace CareerPilot.Application.Features.Profile.Queries.GetMyProfile;

public record GetMyProfileQuery : IRequest<ProfileDto>;