using AutoMapper;
using Candidates.Api.ViewModels;
using Candidates.Models;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Candidate, CandidateViewModel>()
            .ForMember(dest => dest.CandidateExperiences, opt => opt.MapFrom(src => src.CandidateExperiences));
        CreateMap<CandidateExperience, CandidateExperienceViewModel>();

        CreateMap<CandidateViewModel, Candidate>()
            .ForMember(dest => dest.CandidateExperiences, opt => opt.MapFrom(src => src.CandidateExperiences));
        CreateMap<CandidateExperienceViewModel, CandidateExperience>();
    }
}
