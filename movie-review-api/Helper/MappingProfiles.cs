using AutoMapper;
using movie_review_api.Data.Models;
using movie_review_api.DTOs.Director;
using movie_review_api.DTOs.Genre;
using movie_review_api.DTOs.Movie;

namespace movie_review_api.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();

            CreateMap<MovieCreateDto, Movie>();

            CreateMap<MovieUpdateDto, Movie>();

            CreateMap<Director, DirectorDto>();
            CreateMap<DirectorDto, Director>();

            CreateMap<DirectorCreateDto, Director>();

            CreateMap<DirectorUpdateDto, Director>();

            CreateMap<Genre, GenreDto>();
            CreateMap<GenreDto, Genre>();

            CreateMap<GenreCreateDto, Genre>();

            CreateMap<GenreUpdateDto, Genre>();


        }
    }
}
