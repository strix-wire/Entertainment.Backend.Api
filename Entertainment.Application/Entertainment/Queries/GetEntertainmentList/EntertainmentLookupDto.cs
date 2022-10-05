using AutoMapper;
using Entertainment.Application.Common.Mappings;
using Entertainment.Application.Entertainment.Queries.GetEntertainmentDetails;
using Entertainment.Domain;
using MediatR;

namespace Entertainment.Application.Entertainment.Queries.GetEntertainmentList
{
    public class EntertainmentLookupDto : IMapWith<EntertainmentEntity>
    {
        public Guid Id { get; set; }
        public long Price { get; set; }
        public TypeEntertainment TypeEntertainment { get; set; }
        public string? Details { get; set; }
        public Area Area { get; set; }
        /// <summary>
        /// Maybe not worked with double
        /// </summary>
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EntertainmentEntity, EntertainmentLookupDto>()
                .ForMember(entertainmentVm => entertainmentVm.Id,
                    opt => opt.MapFrom(entertainment => entertainment.Id))
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
                .ForMember(entertainmentVm => entertainmentVm.CreationDate,
                    opt => opt.MapFrom(entertainment => entertainment.CreationDate))
                .ForMember(entertainmentVm => entertainmentVm.EditDate,
                    opt => opt.MapFrom(entertainment => entertainment.EditDate));
        }
    }
}
