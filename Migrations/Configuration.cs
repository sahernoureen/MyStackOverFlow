namespace MyStackOverFlow.Migrations
{
    using Microsoft.AspNet.Identity;
    using MyStackOverFlow.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyStackOverFlow.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyStackOverFlow.Models.ApplicationDbContext context)
        {
            var passwordHash = new PasswordHasher();

            string password1 = passwordHash.HashPassword("1!Qwer");
            var User1 = new Models.ApplicationUser
            {
                Id = "1",
                Email = "saher@mail.com",
                EmailConfirmed = false,
                PasswordHash = password1,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEndDateUtc = null,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                UserName = "saher",
                Reputation = 180
            };


       string password2 = passwordHash.HashPassword("2!John");
        var User2 = new Models.ApplicationUser
        {
            Id = "2",
            UserName = "John",
            Email = "John@Mitt.com",
            PasswordHash = password2,
        Reputation = 150
            };

          
            string password3 = passwordHash.HashPassword("3!Mike");
            var User3 = new Models.ApplicationUser
            {
                Id = "3",
                UserName = "Mike",
                Email = "Mike@Mitt.com",
                PasswordHash = password3,
                Reputation = 100
        };

            context.Users.AddOrUpdate(x => x.Id, User1);
            context.Users.AddOrUpdate(x => x.Id, User2);
            context.Users.AddOrUpdate(x => x.Id, User3);

            context.SaveChanges();

            var tag1 = new Models.Tag { TagId = 1, Title = "MVC" };
            var tag2 = new Models.Tag { TagId = 2, Title = "C#" };
            var tag3 = new Models.Tag { TagId = 3, Title = "EF Model" };
            var tag4 = new Models.Tag { TagId = 4, Title = "Asp.net" };
            var tag5 = new Models.Tag { TagId = 5, Title = ".net Core" };
            var tag6 = new Models.Tag { TagId = 6, Title = "String" };
            context.Tags.AddOrUpdate(t => t.TagId, tag1);
            context.Tags.AddOrUpdate(t => t.TagId, tag2);
            context.Tags.AddOrUpdate(t => t.TagId, tag3);
            context.Tags.AddOrUpdate(t => t.TagId, tag4);
            context.Tags.AddOrUpdate(t => t.TagId, tag5);
            context.Tags.AddOrUpdate(t => t.TagId, tag6);


            var Q1 = new Models.Question
            {
                Id = 1,
                Tilte = "Introducing FOREIGN KEY constraint 'FK_dbo.Comments_dbo.Questions_QuestionId' " +
                "on table  may cause cycles or multiple cascade paths. in mvc ASP.net",
                Description = "ve been wrestling with this for a while and can't quite figure out what's happening. " +
                "I have a Card entity which contains Sides (usually 2) - and both Cards and Sides have a Stage. " +
                "I'm using EF Codefirst migrations and the migrations are failing with this error:",
                Qdate = DateTime.Parse("2016-05-02"),
                UserId = "1",
                QVoteCount = 45

            };

            var Q2 = new Models.Question
            {
                Id = 2,
                Tilte = "check which user is login asp.net mvc.",
                Description = "I want to show some div at the view only if user has logged in. " +
               "But Request.IsAuthenticated(and User.Identity.IsAuthenticated) is always true even in the very beginning," +
                "right after I start the website from Visual Studio.Apparently," +
                "it gets me as the user logged in Windows(because User.Identity.Name returns my Windows login)," +
                "but I need it to check if user has authenticated on website via FormsAuthentication.",
                Qdate = DateTime.Parse("2016-08-15"),
                UserId = "2",
                QVoteCount = 20
            };

            var Q3 = new Models.Question
            {
                Id = 3,
                Tilte = "pagedList doesnt show ordered data on 2nd page mvc c# EF code first?",

                Description = "My problem is that the search string is 'lost' when I page to the second page," +
                " so instead of a filtered set of results, I'm shown all the records.",
                Qdate = DateTime.Parse("2017-02-21"),
                UserId = "2",
                QVoteCount = 10
            };

            var Q4 = new Models.Question
            {
                Id = 4,
                Tilte = "Differnce between string And String c#",

                Description = "What is the difference between String and string in C# mvc .net?",
                Qdate = DateTime.Parse("2015-12-11"),
                UserId = "1",
                QVoteCount = 37
            };

            var Q5 = new Models.Question
            {
                Id = 5,
                Tilte = "How to properly write seed method in Entity Framework mvc?",
                Description = "ve been wrestling with this for a while and can't quite figure out what's happening. " +
            "I have a Card entity which contains Sides (usually 2) - and both Cards and Sides have a Stage. " +
            "I'm using EF Codefirst migrations and the migrations are failing with this error:",
                Qdate = DateTime.Parse("2018-09-10"),
                UserId = "3",
                  QVoteCount = 61
            };


            var Q6 = new Models.Question
            {
                Id = 6,
                Tilte = "Displaying Multiple Image Links instead of Text in WebGrid?",
                Description = "I have a WebGrid definition and three links in a single " +
                "column by using Html.ActionLink. But, when I do not use " +
                "LinkText property, the applicantId property is passed as null value to the Controller.",
                Qdate = DateTime.Parse("2018-10-13"),
                UserId = "4",
                QVoteCount = 25
            };
            var Q7 = new Models.Question
            {
                Id = 7,
                Tilte = "How to speed up large data in reactjs?",
                Description = "I am trying to get million of data " +
                "and showing the data tables. Now, I am trying to check static data instead of" +
                "getting from database . class UL extends React.Compontent { state = { data: [],..",
                Qdate = DateTime.Parse("2018-02-18"),
                UserId = "2",
                QVoteCount = 21
            };
            var Q8 = new Models.Question
            {
                Id = 8,
                Tilte = "Android Studio, cannot see anymore warnings, errors and println in “4:Run”?",
                Description = "i cant see anymore my warning, errors and println in my console, but i need it]",
                Qdate = DateTime.Parse("2016-01-07"),
                UserId = "2",
                QVoteCount = 10
            };
            var Q9 = new Models.Question
            {
                Id = 9,
                Tilte = "Push unique objects into array in JAVASCRIPT",
                Description = "I want to push object that only have unique id1 into array." +
                " Example: let array = [], obj = {}, access = true if(access){ obj['id1'] = 1 obj['id2'] = 2 if(array.indexOf(obj.id1) ",
                Qdate = DateTime.Parse("2017-02-01"),
                UserId = "1",
                QVoteCount = 18
            };
            var Q10 = new Models.Question
            {
                Id = 10,
                Tilte = "Access File System of a WSL as a seperate Drive",
                Description = "I have installed Ubuntu 20.04 from Microsoft Store as " +
                "a Windows Subsystem for Linux (WSL) and I need to access the system files of it " +
                "from Windows Explorer and access it as a separate Partition ",
                Qdate = DateTime.Parse("2015-02-11"),
                UserId = "1",
                QVoteCount = 18
            };
            var Q11 = new Models.Question
            {
                Id = 11,
                Tilte = "I have installed Ubuntu 20.04 from Microsoft Store as a Windows Subsystem for Linux (WSL)" +
                "and I need to access the system files of it from Windows Explorer and access it as a separate Partition" ,
                Description = "I have a question about Kotlin error messages. Let's say I have a simple error caused by not " +
                "closing a print statement: fun main() { println('Hello.' } and the error returned is: Hello.kt:2:54:",
                Qdate = DateTime.Parse("2016-08-07"),
                UserId = "1",
                QVoteCount = 18
            };


            context.Questions.AddOrUpdate(q => q.Id, Q1);
            context.Questions.AddOrUpdate(q => q.Id, Q2);
            context.Questions.AddOrUpdate(q => q.Id, Q3);
            context.Questions.AddOrUpdate(q => q.Id, Q4);
            context.Questions.AddOrUpdate(q => q.Id, Q5);

            Q1.Tag.Add(tag1);
            Q1.Tag.Add(tag2);
            Q1.Tag.Add(tag3);

            Q2.Tag.Add(tag4);
            Q2.Tag.Add(tag5);
            Q2.Tag.Add(tag6);

            Q3.Tag.Add(tag1);
            Q3.Tag.Add(tag3);
            Q3.Tag.Add(tag5);

            Q4.Tag.Add(tag1);
            Q4.Tag.Add(tag2);
            Q4.Tag.Add(tag4);

            Q5.Tag.Add(tag2);
            Q5.Tag.Add(tag3);
            Q5.Tag.Add(tag5);

            var Ans1 = new Models.Answer
            {
                Id = 1,
                UserId = "2",
                Description = "Owned entity types are never included by EF Core in the model by convention. You can use the " +
                "OwnsOne method in OnModelCreating or annotate the type with OwnedAttribute (new in EF Core 2.1) " +
                "to configure the type as an owned type in mvc",
                Ansdate = DateTime.Parse("2016-05-08"),
                QuestionId = 1,
                AnsVoteCount = 122

            };

            var Ans2 = new Models.Answer
            {
                Id = 2,
                UserId = "3",
                Description = "When using a relational database, the database provider selects a data type based on the .NET " +
                "type of the property.It also takes into account other metadata, such as the configured maximum length, " +
                "whether the property is part of a primary key, etc.",
                Ansdate = DateTime.Parse("2016-05-09"),
                QuestionId = 1,
                AnsVoteCount = 327

            };

            var Ans3 = new Models.Answer
            {
                Id = 3,
                UserId = "1",
                Description = "Owned entity types are never included by EF Core in the model by convention. You can use the " +
              "OwnsOne method in OnModelCreating or annotate the type with OwnedAttribute (new in EF Core 2.1) " +
              "to configure the type as an owned type in mvc",
                Ansdate = DateTime.Parse("2016-08-16"),
                QuestionId = 2,
                AnsVoteCount = 87
            };

            var Ans4 = new Models.Answer
            {
                Id = 4,
                UserId = "3",
                Description = "When using a relational database, the database provider selects a data type based on the .NET " +
                "type of the property.It also takes into account other metadata, such as the configured maximum length, " +
                "whether the property is part of a primary key, etc.",
                Ansdate = DateTime.Parse("2016-09-01"),
                QuestionId = 2,
               
                AnsVoteCount = 267
            };

            var Ans5 = new Models.Answer
            {
                Id = 5,
                UserId = "3",
                Description = "The problem is your PagedList entry doesn't include your sort order nor your current filter.+" +
                "In addition to adding ViewBag.CurrentSort as suggested by Vasanth,"+
               " you also need to change your PagedListPager to:",
                Ansdate = DateTime.Parse("2017-02-22"),
                QuestionId = 3,
                AnsVoteCount = 89
            };
            var Ans6 = new Models.Answer
            {
                Id = 6,
                UserId = "2",
                Description = "string is an alias in C# for System.String.So technically, " +
                "there is no difference. It's like int vs. System.Int32.",
                Ansdate = DateTime.Parse("2015-12-12"),
                QuestionId = 4,
                AnsVoteCount = 101
            };

            var Ans7 = new Models.Answer
            {
                Id = 7,
                UserId = "2",
                Description = "Alternatively, you can use context.Database.EnsureCreated() to create a new database " +
                "containing the seed data, for example for a test database or when using the in-memory provider or any " +
                "non-relation database. Note that if the database already exists, EnsureCreated() will neither update the " +
                "schema nor seed data in the database. " +
                "For relational databases you shouldn't call EnsureCreated() if you plan to use Migrations.",
                Ansdate = DateTime.Parse("2015-12-12"),
                QuestionId = 5,
                AnsVoteCount = 332
            };

            context.Answers.AddOrUpdate(A => A.Id, Ans1);
            context.Answers.AddOrUpdate(A => A.Id, Ans2);
            context.Answers.AddOrUpdate(A => A.Id, Ans3);
            context.Answers.AddOrUpdate(A => A.Id, Ans4);
            context.Answers.AddOrUpdate(A => A.Id, Ans5);
            context.Answers.AddOrUpdate(A => A.Id, Ans6);
            context.Answers.AddOrUpdate(A => A.Id, Ans7);
   
            var QCom1 = new Models.QComment
            {
                Id = 1,
                QuestionId = 1,
                UserId = "2",
                Comdate = DateTime.Parse("2017-02-21"),
                Description = "This Question can be found in another place"
            };
            var QCom2 = new Models.QComment
            {
                Id = 2,
                QuestionId = 1,
                UserId = "3",
                Comdate = DateTime.Parse("2017-08-12"),
                Description = "This is the 2nd Comment on Question 1"
            };

            var QCom3 = new Models.QComment
            {
                Id = 3,
                QuestionId = 2,
                UserId = "3",
                Comdate = DateTime.Parse("2016-09-18"),
                Description = "This is the 1st Comment on Question 2"
            };
            var QCom4 = new Models.QComment
            {
                Id = 4,
                QuestionId = 3,
                UserId = "1",
                Comdate = DateTime.Parse("2017-09-03"),
                Description = "This is the Ist Comment on Question 3"
            };


            var QCom5 = new Models.QComment
            {
                Id = 5,
                QuestionId = 5,
                UserId = "3",
                Comdate = DateTime.Parse("2018-08-12"),
                Description = "This is the 1st Comment on Question 5"
            };


            context.QComments.AddOrUpdate(QC => QC.Id, QCom1);
            context.QComments.AddOrUpdate(QC => QC.Id, QCom2);
            context.QComments.AddOrUpdate(QC => QC.Id, QCom3);
            context.QComments.AddOrUpdate(QC => QC.Id, QCom4);
            context.QComments.AddOrUpdate(QC => QC.Id, QCom5);

            var Acom1 = new Models.AComment
            {
                Id = 1,
                AnswerId = 1,
                UserId = "1",
                Comdate = DateTime.Parse("2018-08-13"),
                Description = "Found this answer very informative"
            };
            var Acom2 = new Models.AComment
            {
                Id = 2,
                AnswerId = 2,
                UserId = "1",
                Description = "This is the Comment on the given answer",
                 Comdate = DateTime.Parse("2019-06-17"),
            };
            var Acom3 = new Models.AComment
            {
                Id = 3,
                AnswerId = 2,
                UserId = "1",
                Comdate = DateTime.Parse("2019-03-31"),
                Description = "This is the Comment on the given answer"
            };
            var Acom4 = new Models.AComment
            {
                Id = 4,
                AnswerId = 3,
                UserId = "1",
                Comdate = DateTime.Parse("2019-07-08"),
                Description = "That works"
            };
            var Acom5 = new Models.AComment
            {
                Id = 5,
                AnswerId = 4,
                UserId = "2",
                Comdate = DateTime.Parse("2020-01-12"),
                Description = "Aah... Doesn't help"
            };

            var Acom6 = new Models.AComment
            {
                Id = 6,
                AnswerId = 5,
                UserId = "1",
                Comdate = DateTime.Parse("2020-02-23"),
                Description = "This is the comment on answer 5"
            };

            context.AComments.AddOrUpdate(AC => AC.Id, Acom1);
            context.AComments.AddOrUpdate(AC => AC.Id, Acom2);
            context.AComments.AddOrUpdate(AC => AC.Id, Acom3);
            context.AComments.AddOrUpdate(AC => AC.Id, Acom4);
            context.AComments.AddOrUpdate(AC => AC.Id, Acom5);
            context.AComments.AddOrUpdate(AC => AC.Id, Acom6);
 
            var vote1 = new Models.Vote
            {
                Id = 1, QuestionId = 1, UpVote = true
        };

            var vote2 = new Models.Vote
            {
                Id = 2,
                QuestionId = 2,
                DownVote = true
            };

            var vote3 = new Models.Vote
            {
                Id = 3,
                QuestionId = 2,
                UpVote = true
            };
            var vote4 = new Models.Vote
            {
                Id = 4,
                QuestionId = 2,
                UpVote = false
            };

            context.Votes.AddOrUpdate(v => v.Id, vote1);
            context.Votes.AddOrUpdate(v => v.Id, vote2);
            context.Votes.AddOrUpdate(v => v.Id, vote3);
            context.Votes.AddOrUpdate(v => v.Id, vote4);
            context.SaveChanges();




            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.



        }
    }
}
