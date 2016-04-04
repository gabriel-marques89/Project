using AutoMapper;
using Project.Domain.Entities;
using Project.Presentation.ViewModels;

namespace Project.Presentation.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        // Não realizar este override na versão 4.x e superiores
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<PersonViewModel, Person>();
        }
    }
}