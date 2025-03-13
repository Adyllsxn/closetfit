namespace ClosetFit.Application.Mappings;
public class CategoriaProfile : Profile
{
    public CategoriaProfile()
    {
        CreateMap<CategoriaEntity, CategoriaGetDTO>().ReverseMap();
        CreateMap<CategoriaEntity, CategoriaDeleteDTO>().ReverseMap();
        CreateMap<CategoriaEntity, CategoriaUpdateDTO>().ReverseMap();
        CreateMap<CategoriaEntity, CategoriaPostDTO>().ReverseMap();
    }
}
