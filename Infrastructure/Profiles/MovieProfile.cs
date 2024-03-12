using Domain.Movie.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MovieApp.Models; // il faut installer le nuget automapper

namespace Infrastructure.Profiles
{
    public class MovieProfile : Profile // herité profile
    {
        public MovieProfile()
        {
            // A to B
            //CreateMap<A, B>()
            //  .ForMember(dest => dest.BB, opt => opt.MapFrom(src => src.AA))// map member AA with BB
            // .ReverseMap();// reverse from B to A

            // A to B
            CreateMap<MovieModel, MovieModelView>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)) // Map Name de MovieModel à Name de MovieModelView
               .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)) // Map Description de MovieModel à Description de MovieModelView

                .ReverseMap();// reverse from B to A

            // il reste la configuration je vais te l'envoyer 

        }
    }

   // class A
    //{
      //  public int AA { get; set; }
    //}

    //class B
    //{
     //   public int BB { get; set; }
    //}
}
