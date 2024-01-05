using AutoMapper;
using Vb.Data.Entity;
using Vb.Schema;

namespace Vb.Business.Mapper;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<CreateCustomerRequest, Customer>().ForMember(dest => dest.CustomerNumber, opt => opt.Ignore())
            .ForMember(dest => dest.InsertDate, opt => opt.MapFrom(src => DateTime.Now));
        CreateMap<CreateAccountRequestForCustomer, Account>().ForMember(dest => dest.CustomerNumber, opt => opt.Ignore())
            .ForMember(dest => dest.AccountNumber, opt => opt.Ignore())
            .ForMember(dest => dest.InsertDate, opt => opt.MapFrom(src => DateTime.Now));
        CreateMap<CreateAddressRequestForCustomer, Address>().ForMember(dest => dest.CustomerNumber, opt => opt.Ignore())
            .ForMember(dest => dest.InsertDate, opt => opt.MapFrom(src => DateTime.Now));
        CreateMap<CreateContactRequestForCustomer, Contact>().ForMember(dest => dest.CustomerNumber, opt => opt.Ignore())
            .ForMember(dest => dest.InsertDate, opt => opt.MapFrom(src => DateTime.Now));
        CreateMap<Customer, CustomerResponse>();
        
        CreateMap<CreateAddressRequest, Address>().ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.InsertDate, opt => opt.MapFrom(src => DateTime.Now));
        CreateMap<Address, AddressResponse>();
        
        
        CreateMap<CreateContactRequest, Contact>().ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.InsertDate, opt => opt.MapFrom(src => DateTime.Now));
        CreateMap<Contact, ContactResponse>();
        
        CreateMap<CreateAccountRequest, Account>()
            .ForMember(dest => dest.InsertDate, opt => opt.MapFrom(src => DateTime.Now));
        CreateMap<Account, AccountResponse>();


        CreateMap<CreateAccountTransactionRequest, AccountTransaction>().ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.TransactionDate, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.InsertDate, opt => opt.MapFrom(src => DateTime.Now));
        CreateMap<AccountTransaction, AccountTransactionResponse>();
        
        CreateMap<CreateEftTransactionRequest, EftTransaction>().ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.TransactionDate, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.InsertDate, opt => opt.MapFrom(src => DateTime.Now));
        CreateMap<EftTransaction, EftTransactionResponse>();
    }
}