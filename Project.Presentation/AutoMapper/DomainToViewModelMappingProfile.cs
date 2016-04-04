using AutoMapper;
using Project.Domain.Entities;
using Project.Presentation.ViewModels;

namespace Project.Presentation.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        // Não realizar este override na versão 4.x e superiores
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Person, PersonViewModel>();
        }
    }
}