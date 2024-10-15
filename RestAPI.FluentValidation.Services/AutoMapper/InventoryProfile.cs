using AutoMapper;
using RestAPI.FluentValidation.Interfaces.Model;
using DB = Common.DB.Model;

namespace RestAPI.FluentValidation.Services.AutoMapper
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<DB.Item , Item> ();
        }
    }
}
