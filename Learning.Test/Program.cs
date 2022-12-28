 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.Dal;
using Learning.Dal.Models;
using MongoDB.Driver;
using Learning.Dal.Context;
using Learning.Bll.Implementation;

Random random = new Random();
int RandomMoney = random.Next(20, 100);
int randint = random.Next(1,5);

ENames RandomNames()
{
    var rnd = new Random();
    return (ENames)rnd.Next(Enum.GetNames(typeof(ENames)).Length);
}

ELastNames RandomLastNames()
{
    var rnd = new Random();
    return (ELastNames)rnd.Next(Enum.GetNames(typeof(ELastNames)).Length);
}

EColors RandomColors() 
{
    var rnd = new Random();
    return (EColors)rnd.Next(Enum.GetNames(typeof(EColors)).Length);
}

EComputerPerifery RandomCP()
{
    var rnd = new Random();
    return (EComputerPerifery)rnd.Next(Enum.GetNames(typeof(EComputerPerifery)).Length);
}



var product1 = new ProductModel()
{
    ProductId = Guid.NewGuid(),
    Price = random.Next(100, 200),
    Count = random.Next(1, 20),
    Name = RandomCP().ToString(),
    Type = "Computer_perifery",
    Color = RandomColors().ToString()
};

var product2 = new ProductModel()
{
    ProductId = Guid.NewGuid(),
    Price = random.Next(100, 200),
    Count = random.Next(1, 20),
    Name = RandomCP().ToString(),
    Type = "Computer_perifery",
    Color = RandomColors().ToString()
};
var product3 = new ProductModel()
{
    ProductId = Guid.NewGuid(),
    Price = random.Next(100, 200),
    Count = random.Next(1, 20),
    Name = RandomCP().ToString(),
    Type = "Computer_perifery",
    Color = RandomColors().ToString()
};

var user = new UserModel()
{
    UserId = Guid.NewGuid(),
    BankAccountId = Guid.NewGuid(),
    FirstName = RandomNames().ToString(),
    LastName = RandomLastNames().ToString(),
    Email = "",
    Password = "passsbwoed"

};

var user2 = new UserModel()
{
    UserId = Guid.NewGuid(),
    BankAccountId = Guid.NewGuid(),
    FirstName = RandomNames().ToString(),
    LastName = RandomLastNames().ToString(),
    Email = "sggggg@gmail.com",
    Password = "passsdasdb"

};

var bank = new BankModel()
{
    BankAccountId = Guid.NewGuid(),
    AmounOfMoney = random.Next(20, 100)
};

var bank2 = new BankModel()
{
    BankAccountId = Guid.NewGuid(),
    AmounOfMoney = 100
};

var UPP = new UserPurchasedProductModel()
{
    UserId = Guid.NewGuid(),
    TotalPrice = 10003,
    ProductID = 3
};

var testid = new TestModel()
{
    SomeIDGuid = Guid.NewGuid(),
    SomeIdInt = 1,
    SomeIDStr = "1"
};


TestContext testC = new TestContext();

UserService userService = new UserService();
UserContext userContext = new UserContext();

ProductService productService = new ProductService();
ProductContext productContext = new ProductContext();

BankService bankService = new BankService();
BankContext bankContext = new BankContext();

UserPurchasedProductContext userPurchasedProductContext = new UserPurchasedProductContext();
//UserPurchasedProductService userPurchasedProductService = new UserPurchasedProductService();

//userPurchasedProductContext.DeleteUPPFromMongoDb(UPP);


//userContext.DeleteUserFromMongoDb(user);//passed
//userService.InsertUser(user);//passed
//userContext.UpdateUserInMongoDb(user);//passed
//userContext.DeleteCollection(user);//passed

//userContext.ReadUserWithFilterFromMongoDb(user);//in progress


Console.ForegroundColor = ConsoleColor.Green;
Console.Write(randint);



enum ENames
{
    Stepan,
    Josh,
    Barbara,
    Enthony,
    Sara,
    Michle
};

enum ELastNames
{
    Bandera,
    Martinez,
    Rodriguez,
    Davis,
    Miller,
    Garcia,
    Jones ,
    Smith,
};

enum EColors 
{ 
    yellow,
    orange,
    green,
    white,
    blue,
    black,
    cyan,
    magenta,
    red
};

enum EComputerPerifery 
{ 
    keyboard,
    headphones,
    mouse,
    monitor,
    laptop
};



