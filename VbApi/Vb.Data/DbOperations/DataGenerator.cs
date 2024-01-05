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
                            Address1= "Address11",
                            Address2= "Address22",
                            Country= "Country1",
                            City="City1",
                            County= "County1",
                            PostalCode= "Code1",
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
                            ContactType= "Type1",
                            Information=" Information1",
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
                            IBAN= "IBAN1",
                            Balance= 1,
                            CurrencyType="EUR",
                            Name="Name",
                            OpenDate= DateTime.Now,
                            AccountTransactions=new List<AccountTransaction>
                            {
                                new AccountTransaction {
                                    InsertUserId =1,
                                    InsertDate=DateTime.Now,
                                    IsActive=true,
                                    ReferenceNumber= "ReferenceNumber1",
                                    TransactionDate=DateTime.Now,
                                    Amount= 0,
                                    Description= "Description",
                                    TransferType= "ty1"
                                }
                            },
                            EftTransactions = new List<EftTransaction>
                            {
                                new EftTransaction {
                                    InsertUserId =1,
                                    UpdateDate=DateTime.Now,
                                    IsActive=true,
                                    ReferenceNumber= "Number1",
                                    TransactionDate=DateTime.Now,
                                    Amount= 1,
                                    Description= "Description",
                                    SenderAccount= "SenderAccount",
                                    SenderIban= "SenderIban",
                                    SenderName= "SenderName",
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
                            Address1= "Address12",
                            Address2= "Address22",
                            Country= "Country2",
                            City="City2",
                            County= "County2",
                            PostalCode= "Code2",
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
                            ContactType= "Type2",
                            Information=" Information2",
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
                            IBAN= "IBAN2",
                            Balance= 2,
                            CurrencyType="EUR",
                            Name="Name",
                            OpenDate= DateTime.Now,
                            AccountTransactions=new List<AccountTransaction>
                            {
                                new AccountTransaction {
                                    InsertUserId =2,
                                    InsertDate=DateTime.Now,
                                    IsActive=true,
                                    ReferenceNumber= "ReferenceNumber2",
                                    TransactionDate=DateTime.Now,
                                    Amount= 0,
                                    Description= "Description",
                                    TransferType= "ty2"
                                }
                            },
                            EftTransactions = new List<EftTransaction>
                            {
                                new EftTransaction {
                                    InsertUserId =2,
                                    UpdateDate=DateTime.Now,
                                    IsActive=true,
                                    ReferenceNumber= "Number2",
                                    TransactionDate=DateTime.Now,
                                    Amount= 2,
                                    Description= "Description",
                                    SenderAccount= "SenderAccount",
                                    SenderIban= "SenderIban",
                                    SenderName= "SenderName",
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
                            IsActive=true,
                            Address1= "Address13",
                            Address2= "Address22",
                            Country= "Country3",
                            City="City3",
                            County= "County3",
                            PostalCode= "Code3",
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
                            ContactType= "Type3",
                            Information=" Information3",
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
                            IBAN= "IBAN3",
                            Balance= 3,
                            CurrencyType="EUR",
                            Name="Name",
                            OpenDate= DateTime.Now,
                            AccountTransactions=new List<AccountTransaction>
                            {
                                new AccountTransaction {
                                    InsertUserId =3,
                                    InsertDate=DateTime.Now,
                                    IsActive=true,
                                    ReferenceNumber= "ReferenceNumber3",
                                    TransactionDate=DateTime.Now,
                                    Amount= 0,
                                    Description= "Description",
                                    TransferType= "ty3"
                                }
                            },
                            EftTransactions = new List<EftTransaction>
                            {
                                new EftTransaction {
                                    InsertUserId =3,
                                    UpdateDate=DateTime.Now,
                                    IsActive=true,
                                    ReferenceNumber= "Number3",
                                    TransactionDate=DateTime.Now,
                                    Amount= 3,
                                    Description= "Description",
                                    SenderAccount= "SenderAccount",
                                    SenderIban= "SenderIban",
                                    SenderName= "SenderName",
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
                            Address1= "Address14",
                            Address2= "Address22",
                            Country= "Country4",
                            City="City4",
                            County= "County4",
                            PostalCode= "Code4",
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
                            ContactType= "Type4",
                            Information=" Information4",
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
                            IBAN= "IBAN4",
                            Balance= 4,
                            CurrencyType="EUR",
                            Name="Name",
                            OpenDate= DateTime.Now,
                            AccountTransactions=new List<AccountTransaction>
                            {
                                new AccountTransaction {
                                    InsertUserId =4,
                                    InsertDate=DateTime.Now,
                                    IsActive=true,
                                    ReferenceNumber= "ReferenceNumber4",
                                    TransactionDate=DateTime.Now,
                                    Amount= 0,
                                    Description= "Description",
                                    TransferType= "ty4"
                                }
                            },
                            EftTransactions = new List<EftTransaction>
                            {
                                new EftTransaction {
                                    InsertUserId =4,
                                    UpdateDate=DateTime.Now,
                                    IsActive=true,
                                    ReferenceNumber= "Number4",
                                    TransactionDate=DateTime.Now,
                                    Amount= 4,
                                    Description= "Description",
                                    SenderAccount= "SenderAccount",
                                    SenderIban= "SenderIban",
                                    SenderName= "SenderName",
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

