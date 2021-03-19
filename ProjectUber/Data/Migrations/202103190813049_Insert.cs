namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Insert : DbMigration
    {
        public override void Up()
        {
            Sql(("INSERT INTO Towns(name,country,zipcode) Values('Haskovo','Bulgaria',6300)"));
            Sql(("INSERT INTO Towns(name,country,zipcode) Values('Dimitrovgrad','Bulgaria',6400)"));
            Sql(("INSERT INTO Towns(name,country,zipcode) Values('Sofia','Bulgaria',1000)"));
            Sql(("INSERT INTO Towns(name,country,zipcode) Values('Berlin','German',10000)"));
            Sql(("INSERT INTO Towns(name,country,zipcode) Values('London','England',20000)"));

            Sql(("INSERT INTO Vehicles(model,horsepower) Values('Audi A3',184)"));
            Sql(("INSERT INTO Vehicles(model,horsepower) Values('Opel Astra 1998',101"));
            Sql(("INSERT INTO Vehicles(model,horsepower) Values('Ferrari 812 GTS',789)"));
            Sql(("INSERT INTO Vehicles(model,horsepower) Values('Volkswagen Passat B5',130)"));
            Sql(("INSERT INTO Vehicles(model,horsepower) Values('Mercedes C220 2002',349)"));

            Sql(("INSERT INTO Drivers(firstname,lastname,age,countorders,rating,vehicleid) Values('Angel','Evtimov',24,103,3.4,1)"));
            Sql(("INSERT INTO Drivers(firstname,lastname,age,countorders,rating,vehicleid) Values('Petar','Hristov',33,154,4.7,2)"));
            Sql(("INSERT INTO Drivers(firstname,lastname,age,countorders,rating,vehicleid) Values('Todor','Nestorov',42,213,2.9,3)"));
            Sql(("INSERT INTO Drivers(firstname,lastname,age,countorders,rating,vehicleid) Values('Thomas','Muller',19,24,3.3,4)"));
            Sql(("INSERT INTO Drivers(firstname,lastname,age,countorders,rating,vehicleid) Values('John','Stones',23,87,4.3,5)"));

            Sql(("INSERT INTO DriverProfiles(username,password,driverid) Values('AEvtimov1997','Angel1234',1)"));
            Sql(("INSERT INTO DriverProfiles(username,password,driverid) Values('Petar_H','12081988',2)"));
            Sql(("INSERT INTO DriverProfiles(username,password,driverid) Values('TodorNestorov007','Todor_Nestorov',3)"));
            Sql(("INSERT INTO DriverProfiles(username,password,driverid) Values('ThoMasMullEr','Thomasthomas1',4)"));
            Sql(("INSERT INTO DriverProfiles(username,password,driverid) Values('John-Stones-1998','StonesTheBest',5)"));

            Sql(("INSERT INTO Users(firstname,lastname,age,countorders) Values('Dimitar','Ranchev',44,87)"));
            Sql(("INSERT INTO Users(firstname,lastname,age,countorders) Values('Melisa','Kuneva',21,25)"));
            Sql(("INSERT INTO Users(firstname,lastname,age,countorders) Values('Petya','Dimitrova',16,16)"));
            Sql(("INSERT INTO Users(firstname,lastname,age,countorders) Values('Kai','Havertz',39,80)"));
            Sql(("INSERT INTO Users(firstname,lastname,age,countorders) Values('Raheem','Sterling',27,40)"));

            Sql(("INSERT INTO UserProfiles(username,password,userid) Values('Dimitar_Ranchev','DimRanchev77',1)"));
            Sql(("INSERT INTO UserProfiles(username,password,userid) Values('Meli2000','KKKuneva',2)"));
            Sql(("INSERT INTO UserProfiles(username,password,userid) Values('Dimitrova_P','Petya000D',3)"));
            Sql(("INSERT INTO UserProfiles(username,password,userid) Values('KaiHaverts0711','Haverts07Kai',4)"));
            Sql(("INSERT INTO UserProfiles(username,password,userid) Values('Raheem_Sterling_Raheem','Raheemraheem1',5)"));

            Sql(("INSERT INTO Orders(date,price,userprofileid,driverprofileid,townid) Values('2021-01-03',22.03,1,1,1)"));
            Sql(("INSERT INTO Orders(date,price,userprofileid,driverprofileid,townid) Values('2020-11-23',32.98,2,2,2)"));
            Sql(("INSERT INTO Orders(date,price,userprofileid,driverprofileid,townid) Values('2020-09-30',11.00,3,3,3)"));
            Sql(("INSERT INTO Orders(date,price,userprofileid,driverprofileid,townid) Values('2019-10-09',123.76,4,4,4)"));
            Sql(("INSERT INTO Orders(date,price,userprofileid,driverprofileid,townid) Values('2017-11-11',17.73,5,5,5)"));
        }
        
        public override void Down()
        {
        }
    }
}
