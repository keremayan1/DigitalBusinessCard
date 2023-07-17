using AuthServer.API.Application.Features.OperationClaims.Commands.Add;
using AuthServer.API.Application.Features.OperationClaims.Commands.Delete;
using AuthServer.API.Application.Features.OperationClaims.Commands.Update;
using AuthServer.API.Application.Features.OperationClaims.DTOs;
using AutoMapper;
using Core.Security.Entities;

namespace AuthServer.API.Application.Features.OperationClaims.Profiles
{
    public class OperationClaimMapping:Profile
    {
        public OperationClaimMapping()
        {
            CreateMap<OperationClaim, CreatedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();

            CreateMap<OperationClaim, UpdatedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, UpdateOperationClaimCommand>().ReverseMap();

            CreateMap<OperationClaim, DeletedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, DeleteOperationClaimCommand>().ReverseMap();
        }
    }
}
