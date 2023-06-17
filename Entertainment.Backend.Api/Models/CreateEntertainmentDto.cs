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
        public Guid? UserId { get; set; }
        public string? UrlSite { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public long Price { get; set; }
        public TypeEntertainment TypeEntertainment { get; set; }
        public string? Details { get; set; }
        public Area Area { get; set; }
        /// <summary>
        /// Maybe not worked with double
        /// </summary>
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? UrlImage { get; set; }
        public byte? Ranking { get; set; }
        public string Address { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateEntertainmentDto, CreateEntertainmentCommand>()
                .ForMember(entertainmentVm => entertainmentVm.Name,
                    opt => opt.MapFrom(entertainment => entertainment.Name))
                .ForMember(entertainmentVm => entertainmentVm.City,
                    opt => opt.MapFrom(entertainment => entertainment.City))
                .ForMember(entertainmentVm => entertainmentVm.Price,
                    opt => opt.MapFrom(entertainment => entertainment.Price))
                .ForMember(entertainmentVm => entertainmentVm.TypeEntertainment,
                    opt => opt.MapFrom(entertainment => entertainment.TypeEntertainment))
                .ForMember(entertainmentVm => entertainmentVm.Details,
                    opt => opt.MapFrom(entertainment => entertainment.Details))
                .ForMember(entertainmentVm => entertainmentVm.Area,
                    opt => opt.MapFrom(entertainment => entertainment.Area))
                .ForMember(entertainmentVm => entertainmentVm.Latitude,
                    opt => opt.MapFrom(entertainment => entertainment.Latitude))
                .ForMember(entertainmentVm => entertainmentVm.Longitude,
                    opt => opt.MapFrom(entertainment => entertainment.Longitude))
                .ForMember(entertainmentVm => entertainmentVm.UrlImage,
                    opt => opt.MapFrom(entertainment => entertainment.UrlImage))
                .ForMember(entertainmentVm => entertainmentVm.Ranking,
                    opt => opt.MapFrom(entertainment => entertainment.Ranking))
                .ForMember(entertainmentVm => entertainmentVm.UrlSite,
                    opt => opt.MapFrom(entertainment => entertainment.UrlSite))
                .ForMember(entertainmentVm => entertainmentVm.Address,
                    opt => opt.MapFrom(entertainment => entertainment.Address));
        }
    }
}
