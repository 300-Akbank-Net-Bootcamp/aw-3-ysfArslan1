using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vb.Data;
using Vb.Data;
using Vb.Data.Entity;

namespace Vb.Data;

public class DataGenerator
{
    //Database de data üretmek içinkullanılıyor // program.cs de çalıştırılıyor
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var content = new VbDbContext(serviceProvider.GetRequiredService<DbContextOptions<VbDbContext>>())) 
        {
            if (content.Customers.Any()) 
            {
                return;
            }

            content.Customers.AddRange(
                new Customer
                {
                    InsertUserId =1,
                    InsertDate=DateTime.Now,
                    IsActive=true,
                    IdentityNumber ="11111111111",
                    FirstName="Ali" ,
                    LastName ="C----",
                    CustomerNumber=1 ,
                    DateOfBirth= DateTime.Now,
                    LastActivityDate = DateTime.Now,
                    Addresses = new List<Address>{
                        new Address {
                            InsertUserId =1,
                            InsertDate=DateTime.Now,
                            IsActive=true,
                            Address1= "string",
                            Address2= "string",
                            Country= "string",
                            City="string",
                            County= "string",
                            PostalCode= "string",
                            IsDefault= true
                        }
                    },
                    Contacts = new List<Contact>
                    {
                        new Contact
                        {
                            InsertUserId =1,
                            InsertDate=DateTime.Now,
                            IsActive=true,
                            ContactType= "string",
                            Information=" string1",
                            IsDefault= true
                        }
                    },
                    Accounts= new List<Account>
                    {
                        new Account
                        {
                            InsertUserId =1,
                            InsertDate=DateTime.Now,
                            IsActive=true,
                            AccountNumber= 1,
                            IBAN= "string",
                            Balance= 1,
                            CurrencyType="EUR",
                            Name="string",
                            OpenDate= DateTime.Now,
                            AccountTransactions=new List<AccountTransaction>
                            {
                                new AccountTransaction {
                                    InsertUserId =1,
                                    InsertDate=DateTime.Now,
                                    IsActive=true,
                                    ReferenceNumber= "string",
                                    TransactionDate=DateTime.Now,
                                    Amount= 0,
                                    Description= "string",
                                    TransferType= "string"
                                }
                            },
                            EftTransactions = new List<EftTransaction>
                            {
                                new EftTransaction {
                                    InsertUserId =1,
                                    UpdateDate=DateTime.Now,
                                    IsActive=true,
                                    ReferenceNumber= "string",
                                    TransactionDate=DateTime.Now,
                                    Amount= 1,
                                    Description= "string",
                                    SenderAccount= "string",
                                    SenderIban= "string",
                                    SenderName= "string",
                                }
                            }
                        }
                    }
                },
                 new Customer
                 {
                     InsertUserId = 2,
                     InsertDate = DateTime.Now,
                     IsActive = true,
                     IdentityNumber = "11111111112",
                     FirstName = "Ayşe",
                     LastName = "H----",
                     CustomerNumber = 2,
                     DateOfBirth = DateTime.Now,
                     LastActivityDate = DateTime.Now,
                     Addresses = new List<Address>{
                        new Address {
                            InsertUserId =2,
                            InsertDate=DateTime.Now,
                            IsActive=true,
                            Address1= "string",
                            Address2= "string",
                            Country= "string",
                            City="string",
                            County= "string",
                            PostalCode= "string",
                            IsDefault= true
                        }
                    },
                     Contacts = new List<Contact>
                    {
                        new Contact
                        {
                            InsertUserId =2,
                            InsertDate=DateTime.Now,
                            IsActive=true,
                            ContactType= "string",
                            Information=" string2",
                            IsDefault= true
                        }
                    },
                     Accounts = new List<Account>
                    {
                        new Account
                        {
                            InsertUserId =2,
                            InsertDate=DateTime.Now,
                            IsActive=true,
                            AccountNumber= 2,
                            IBAN= "string",
                            Balance= 2,
                            CurrencyType="EUR",
                            Name="string",
                            OpenDate= DateTime.Now,
                            AccountTransactions=new List<AccountTransaction>
                            {
                                new AccountTransaction {
                                    InsertUserId =2,
                                    InsertDate=DateTime.Now,
                                    IsActive=true,
                                    ReferenceNumber= "string",
                                    TransactionDate=DateTime.Now,
                                    Amount= 0,
                                    Description= "string",
                                    TransferType= "string"
                                }
                            },
                            EftTransactions = new List<EftTransaction>
                            {
                                new EftTransaction {
                                    InsertUserId =2,
                                    InsertDate=DateTime.Now,
                                    IsActive=true,
                                    ReferenceNumber= "string",
                                    TransactionDate=DateTime.Now,
                                    Amount= 2,
                                    Description= "string",
                                    SenderAccount= "string",
                                    SenderIban= "string",
                                    SenderName= "string",
                                }
                            }
                        }
                    }
                 },
                  new Customer
                  {
                      InsertUserId = 3,
                      InsertDate = DateTime.Now,
                      IsActive = true,
                      IdentityNumber = "11111111113",
                      FirstName = "Hasan",
                      LastName = "K----",
                      CustomerNumber = 3,
                      DateOfBirth = DateTime.Now,
                      LastActivityDate = DateTime.Now,
                      Addresses = new List<Address>{
                        new Address {
                            InsertUserId =3,
                            InsertDate=DateTime.Now,
                            UpdateUserId=3,
                            UpdateDate=DateTime.Now,
                            IsActive=true,
                            Address1= "string",
                            Address2= "string",
                            Country= "string",
                            City="string",
                            County= "string",
                            PostalCode= "string",
                            IsDefault= true
                        }
                    },
                      Contacts = new List<Contact>
                    {
                        new Contact
                        {
                            InsertUserId =3,
                            InsertDate=DateTime.Now,
                            IsActive=true,
                            ContactType= "string",
                            Information=" string3",
                            IsDefault= true
                        }
                    },
                      Accounts = new List<Account>
                    {
                        new Account
                        {
                            InsertUserId =3,
                            InsertDate=DateTime.Now,
                            IsActive=true,
                            AccountNumber= 3,
                            IBAN= "string",
                            Balance= 3,
                            CurrencyType="EUR",
                            Name="string",
                            OpenDate= DateTime.Now,
                            AccountTransactions=new List<AccountTransaction>
                            {
                                new AccountTransaction {
                                    InsertUserId =3,
                                    InsertDate=DateTime.Now,
                                    IsActive=true,
                                    ReferenceNumber= "string",
                                    TransactionDate=DateTime.Now,
                                    Amount= 0,
                                    Description= "string",
                                    TransferType= "string"
                                }
                            },
                            EftTransactions = new List<EftTransaction>
                            {
                                new EftTransaction {
                                    InsertUserId =3,
                                    InsertDate=DateTime.Now,
                                    IsActive=true,
                                    ReferenceNumber= "string",
                                    TransactionDate=DateTime.Now,
                                    Amount= 3,
                                    Description= "string",
                                    SenderAccount= "string",
                                    SenderIban= "string",
                                    SenderName= "string",
                                }
                            }
                        }
                    }
                  },
                   new Customer
                   {
                       InsertUserId = 4,
                       InsertDate = DateTime.Now,
                       IsActive = true,
                       IdentityNumber = "11111111114",
                       FirstName = "Aslı",
                       LastName = "T----",
                       CustomerNumber = 4,
                       DateOfBirth = DateTime.Now,
                       LastActivityDate = DateTime.Now,
                       Addresses = new List<Address>{
                        new Address {
                            InsertUserId =4,
                            InsertDate=DateTime.Now,
                            IsActive=true,
                            Address1= "string",
                            Address2= "string",
                            Country= "string",
                            City="string",
                            County= "string",
                            PostalCode= "string",
                            IsDefault= true
                        }
                    },
                       Contacts = new List<Contact>
                    {
                        new Contact
                        {
                            InsertUserId =4,
                            InsertDate=DateTime.Now,
                            IsActive=true,
                            ContactType= "string",
                            Information=" string4",
                            IsDefault= true
                        }
                    },
                       Accounts = new List<Account>
                    {
                        new Account
                        {
                            InsertUserId =4,
                            InsertDate=DateTime.Now,
                            IsActive=true,
                            AccountNumber= 4,
                            IBAN= "string",
                            Balance= 4,
                            CurrencyType="EUR",
                            Name="string",
                            OpenDate= DateTime.Now,
                            AccountTransactions=new List<AccountTransaction>
                            {
                                new AccountTransaction {
                                    InsertUserId =4,
                                    InsertDate=DateTime.Now,
                                    IsActive=true,
                                    ReferenceNumber= "string",
                                    TransactionDate=DateTime.Now,
                                    Amount= 4,
                                    Description= "string",
                                    TransferType= "string"
                                }
                            },
                            EftTransactions = new List<EftTransaction>
                            {
                                new EftTransaction {
                                    InsertUserId =4,
                                    InsertDate=DateTime.Now,
                                    IsActive=true,
                                    ReferenceNumber= "string",
                                    TransactionDate=DateTime.Now,
                                    Amount= 4,
                                    Description= "string",
                                    SenderAccount= "string",
                                    SenderIban= "string",
                                    SenderName= "string",
                                }
                            }
                        }
                    }
                   }

            );

            content.SaveChanges();
            
        }
    }
}

