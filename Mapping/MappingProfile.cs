using AutoMapper;
using SmartGoalApp.Controllers.Resources;
using SmartGoalApp.Models;

namespace SmartGoalApp.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<Folder, FolderResource>();
            CreateMap<User, UserResource>();
            CreateMap<Goal, SaveGoalResource>();
            CreateMap<Task, TaskResource>();
            CreateMap<Goal, GoalResource>();

            //API Resource to Domain
            CreateMap<SaveGoalResource, Goal>()
                .ForMember(v => v.Id, opt => opt.Ignore());
            CreateMap<SaveTaskResource, Task>()
                .ForMember(v => v.Id, opt => opt.Ignore());
            CreateMap<SaveFolderResource, Folder>()
                .ForMember(v => v.Id, opt => opt.Ignore());
        }
    }
}
