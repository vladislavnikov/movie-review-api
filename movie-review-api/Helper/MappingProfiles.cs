using AutoMapper;
using movie_review_api.Data.Models;
using movie_review_api.DTOs.Movie;

namespace movie_review_api.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();

            CreateMap<MovieCreateDto, Movie>();
            CreateMap<Movie, MovieCreateDto>();
        }
    }
}
