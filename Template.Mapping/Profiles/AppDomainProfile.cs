using AutoMapper;
using $ext_projectname$.Domain;
using $ext_projectname$.Domain.Entities;
using $ext_projectname$.ViewModels;
using $ext_projectname$.ViewModels.AppObject;
using $ext_projectname$.ViewModels.AppObjects;

namespace $safeprojectname$.Profiles
{
    public class AppDomainProfile : Profile
    {
        public AppDomainProfile()
        {
            CreateMap<EntityBase<long>, EntityBase_vw<long>>().ReverseMap();
            CreateMap<News, News_vw>().ReverseMap();
            CreateMap<Book, Book_vw>().ReverseMap();
            CreateMap<Tweet, Tweet_vw>().ReverseMap();
            CreateMap<NewsAnalitics, NewsAnalitics_vw>().ReverseMap();
        }
    }
}
