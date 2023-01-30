using AutoMapper;
using WebApi.Entities;
using WebApi.Application.GenreOperations.CreateGenre;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.FilmOperations.Queries.GetFilm;
using WebApi.Application.FilmOperations.Commands.CreateFilm;
using WebApi.Application.FilmOperations.Queries.GetFilmDetail;
using WebApi.Application.OyuncuOperations.Commands.CreateOyuncu;
using WebApi.Application.OyuncuOperations.Queries.GetOyuncu;
using WebApi.Application.OyuncuOperations.Queries.GetOyuncuDetail;
using WebApi.Application.YonetmenOperations.Commands.CreateYonetmen;
using WebApi.Application.YonetmenOperations.Queries.GetYonetmen;
using WebApi.Application.YonetmenOperations.Queries.GetYonetmenDetail;
using WebApi.Application.CustomerOperations.Commands.CreateCustomer;
using WebApi.Application.SiparisOperations.Commands.CreateSiparis;
using WebApi.Application.SiparisOperations.Queries.GetSiparis;
using WebApi.Application.SiparisOperations.Queries.GetSiparisDetail;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {   
        public MappingProfile()
        {

            CreateMap<CreateFilmModel, Film>();      
            CreateMap<Film, FilmDetailViewModel>()
                .ForMember(dest => dest.FilmTuru, opt => opt.MapFrom(src => src.FilmTuru.TurIsmi));
                //.ForMember(dest => dest.Yonetmen, opt => opt.MapFrom(src => src.Yonetmen.Name + " " + src.Yonetmen.LastName))
                //.ForMember(dest => dest.Oyuncular, opt => opt.MapFrom(src => returnOyunular(src.Actors)));
            CreateMap<Film, FilmViewModel>()
                .ForMember(dest => dest.FilmTuru, opt => opt.MapFrom(src => src.FilmTuru.TurIsmi));
                //.ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.LastName))
                //.ForMember(dest => dest.Actors, opt => opt.MapFrom(src => returnActors(src.Actors)));

            CreateMap<CreateSiparisModel, Siparis>();      
            CreateMap<Siparis, SiparisDetailViewModel>()
            .ForMember(dest => dest.CustomerAdi, opt => opt.MapFrom(src => src.Customer.CustomerAdi + " " + src.Customer.CustomerSoyadi))
            .ForMember(dest => dest.FilmAdi, opt => opt.MapFrom(src => src.FilmAdi))
            .ForMember(dest => dest.Fiyat, opt => opt.MapFrom(src => src.FilmBedeli + " $"));
            CreateMap<Siparis, SiparisViewModel>()
            .ForMember(dest => dest.CustomerAdi, opt => opt.MapFrom(src => src.Customer.CustomerAdi + " " + src.Customer.CustomerSoyadi))
            .ForMember(dest => dest.FilmAdi, opt => opt.MapFrom(src => src.FilmAdi))
            .ForMember(dest => dest.Fiyat, opt => opt.MapFrom(src => src.FilmBedeli + " $"));


            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<CreateGenreModel, Genre>();

            CreateMap<Oyuncu, OyuncuViewModel>();
            CreateMap<Oyuncu, OyuncuDetailViewModel>();
            CreateMap<CreateOyuncuModel, Oyuncu>();

            CreateMap<Yonetmen, YonetmenViewModel>();
            CreateMap<Yonetmen, YonetmenDetailViewModel>();
            CreateMap<CreateYonetmenModel, Yonetmen>();

            CreateMap<CreateCustomerModel, Customer>();
    
        }
    }
}