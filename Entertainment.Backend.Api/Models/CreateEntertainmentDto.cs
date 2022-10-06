using AutoMapper;
using Entertainment.Application.Common.Mappings;
using Entertainment.Application.Entertainment.Commands.CreateEntertainment;
using Entertainment.Domain;

namespace Entertainment.Backend.Api.Models
{
    public class CreateEntertainmentDto : IMapWith<CreateEntertainmentCommand>
    {
        /// <summary>
        /// Not used yet
        /// </summary>
        public Guid UserId { get; set; }
        public long Price { get; set; }
        public TypeEntertainment TypeEntertainment { get; set; }
        public string? Details { get; set; }
        public Area Area { get; set; }
        /// <summary>
        /// Maybe not worked with double
        /// </summary>
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateEntertainmentDto, CreateEntertainmentCommand>()
                .ForMember(entertainment => entertainment.TypeEntertainment,
                    opt => opt.MapFrom(entertainmentDto => entertainmentDto.TypeEntertainment))
                .ForMember(entertainment => entertainment.Price,
                    opt => opt.MapFrom(entertainmentDto => entertainmentDto.Price))
                .ForMember(entertainment => entertainment.Details,
                    opt => opt.MapFrom(entertainmentDto => entertainmentDto.Details))
                .ForMember(entertainment => entertainment.Area,
                    opt => opt.MapFrom(entertainmentDto => entertainmentDto.Area))
                .ForMember(entertainment => entertainment.Latitude,
                    opt => opt.MapFrom(entertainmentDto => entertainmentDto.Latitude))
                .ForMember(entertainment => entertainment.Longitude,
                    opt => opt.MapFrom(entertainmentDto => entertainmentDto.Longitude));
        }
    }
}
