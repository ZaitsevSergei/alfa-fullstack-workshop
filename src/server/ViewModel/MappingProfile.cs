using AutoMapper;
using Server.Models;
using Server.ViewModels;

namespace Server.ViewModel
{
    /// <summary>
    /// Profile to map entities
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Card, CardDto>();
            CreateMap<Transaction, TransactionDto>();
        }
    }
}
