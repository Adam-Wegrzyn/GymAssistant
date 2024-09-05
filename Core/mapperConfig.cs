using AutoMapper;
using Data.Common.DTO;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class mapperConfig: Profile
    {
        public mapperConfig()
        {
            CreateMap<ExerciseDTO, Exercise>().ReverseMap();
            CreateMap<TrainingDTO, Training>().ReverseMap();
            CreateMap<TrainingLogDTO, TrainingLog>().ReverseMap()
                .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration));
            CreateMap<TrainingSetDTO, TrainingSet>().ReverseMap();
            CreateMap<TrainingSetExerciseDTO, TrainingSetExercise>().ReverseMap();

        }


    }
}
