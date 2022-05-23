using AutoMapper;
using ToysAndGames.Api.Controllers.Products;
using ToysAndGames.Model.Products;

namespace ToysAndGames.Api
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
        }
    }
}