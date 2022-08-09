using SimpleMigrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAccountServer.Migrations
{
    [Migration(1, "Create Accounts table")]
    public class CreateAccountTable : Migration
    {
        protected override void Down()
        {
            Execute("DROP TABLE accounts");
        }

        protected override void Up()
        {
            Execute(@"CREATE TABLE accounts (
                id serial not null primary key,
                username text not null,
                password text not null,
                created_at timestamp not null default now(),
                question text not null,
                answer text not null
            )");
        }
    }
}
