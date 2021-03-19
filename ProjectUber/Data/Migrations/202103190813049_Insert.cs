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

        }
        
        public override void Down()
        {
        }
    }
}
