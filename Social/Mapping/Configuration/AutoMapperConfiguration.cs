using AutoMapper;
using Social.Data.Mapping;
using System;

namespace Social.Mapping.Configuration
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => 
            {
                cfg.CreateMap<DateTime, DateTime>().ConvertUsing<UtcAndLocalConverter>();
                cfg.AddProfile<AspNetUserToDtoMapper>();
            });
        }

        public class UtcAndLocalConverter : ITypeConverter<DateTime, DateTime>
        {
            public DateTime Convert(DateTime source, DateTime destination, ResolutionContext context)
            {
                DateTime inputDate = source;
                if(inputDate.Kind == DateTimeKind.Utc || inputDate.Kind == DateTimeKind.Unspecified)
                {
                    return DateTime.SpecifyKind(inputDate, DateTimeKind.Utc);
                }
                return inputDate.ToUniversalTime();
            }
        }
    }
}