using AutoMapper;
using Candidates.Api.ViewModels;
using Candidates.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Candidate, CandidateViewModel>();
        CreateMap<CandidateViewModel, Candidate>();
    }
}
