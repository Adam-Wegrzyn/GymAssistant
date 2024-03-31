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
            CreateMap<ExerciseDto, Exercise>().ReverseMap();
            CreateMap<TrainingDto, Training>().ReverseMap();
            CreateMap<TrainingLogDto, TrainingLog>().ReverseMap();
            CreateMap<TrainingSetDto, TrainingSet>().ReverseMap();
        }


    }
}
