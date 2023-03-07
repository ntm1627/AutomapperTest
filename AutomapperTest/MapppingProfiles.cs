using AutoMapper;
using AutomapperTest.Dto;
using AutomapperTest.Entity;
using System.Collections.Generic;

namespace API.Helpers
{
    public class MapppingProfiles : Profile
    {
        public MapppingProfiles()
        {
            CreateMap<ParentCreationDto, Parent>();
            CreateMap<Parent, ParentToDisplayDto>();

            CreateMap<ParentForUpdateDto, Parent>()
                .ForMember(x => x.Children, o => o.MapFrom(MapChildren));
            CreateMap<ChildForUpdateDto, Child>();

            CreateMap<ChildCreationDto, Child>();
            CreateMap<Child, ChildToDisplayDto>().ReverseMap();  //with navigation properties
        }

        private List<ChildForUpdateDto> MapChildren(ParentForUpdateDto parentForUpdateDto, Parent parent)
        {
            var children = new List<ChildForUpdateDto>();
            if (parentForUpdateDto.Children == null) { return children; }

            foreach (var child in parentForUpdateDto.Children)
            {
                children.Add(new ChildForUpdateDto()
                {
                    FirstName = child.FirstName,
                    LastName = child.LastName,
                    SchoolName = child.SchoolName,
                    ParentId = child.ParentId,
                });
            }

            return children;
        }
    }
}