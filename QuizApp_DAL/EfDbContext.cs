using Microsoft.EntityFrameworkCore;
using QuizApp_DAL.Entities;
using QuizApp_DAL.RolesHelper;

namespace QuizApp_DAL
{
    public class EfDbContext : DbContext
    {
        private IRolesHelper _rolesHelper;
        public DbSet<Quiz>? Quizzes { get; set; }
        public DbSet<Question>? Questions { get; set; }
        public DbSet<Choice>? Choices { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<UserRoles>? UserRolesList { get; set; }

        public EfDbContext(DbContextOptions<EfDbContext> options, IRolesHelper rolesHelper) : base(options)
        {
            _rolesHelper = rolesHelper;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRoles>()
                .HasKey(nameof(UserRoles.UserId), nameof(UserRoles.RoleId));

            foreach (var role in new RolesList())
            {
                modelBuilder.Entity<Role>().HasData
                   (new Role { Id = _rolesHelper[role], Title = role });
            }

            modelBuilder.Entity<Quiz>().HasData
               (new Quiz
               {
                   Id = Guid.Parse("5491d598-3798-4c4f-a99f-f021e1406797"),
                   Title = "C# Quiz",
                   Description = @"The test contains 5 questions and there is no time limit. The test is not official,
                           it's just a nice way to see how much you know, or don't know, about C#."
               },
               new Quiz
               {
                   Id = Guid.Parse("6e60e6cb-5f99-459d-9e89-96425b57462f"),
                   Title = "HTML Quiz",
                   Description = @"The test contains 5 questions and there is no time limit. The test is not official,
                           it's just a nice way to see how much you know, or don't know, about HTML."
               },
               new Quiz
               {
                   Id = Guid.Parse("44f8f00a-17e6-46d9-9e0c-be3326514c02"),
                   Title = "Management Quiz",
                   Description = @"If you are in the management field and looking for a well-researched 'Introduction to Management' practice quiz with answers, you've reached the right place. Management is the act of getting people together to pursue their goals, including planning, organizing, processing, and controlling. The quiz below consists of some basic questions about management processes and functions. Do you think you can quickly answer all of them? Take up this quiz and prove your knowledge now."
               },
               new Quiz
               {
                   Id = Guid.Parse("43e0817d-8e88-41dd-bcfa-7ec05ef7f283"),
                   Title = "QA Quiz",
                   Description = @"Take a shot at this quiz, which will help you determine your IQ, your QA knowledge. Best luck."
               },
               new Quiz
               {
                   Id = Guid.Parse("b1336dc5-1db4-4ec8-aa88-9d17c8d0267d"),
                   Title = "HR Quiz",
                   Description = @"This is a quiz with HR test questions. The first one, made in a series of tests made to help me prepare for my human resource management exam. All material was taken from the Human Resource Management Book by David Lepak and Mary Gowan. Why don't you give it a try and let it do the same for you? All the best, and share it with your classmates!"
               },
               new Quiz
               {
                   Id = Guid.Parse("73b4acad-b234-40b5-aa20-35d4f071a89e"),
                   Title = "Investment Quiz",
                   Description = @"With the advancement of society and the internet, the investment world has changed dramatically. How well do you know about various investment strategies? If you know enough, then feel free to give this fun and informative quiz a try! Just answer a few questions to enter the world of stocks, online trading, bond, etc. Are you ready? There's no time bar, so feel free to take this quiz as often as possible! We hope you learn some new things with the quiz! Good Luck!"
               });

            modelBuilder.Entity<Question>().HasData
              (new Question
              {
                  Id = Guid.Parse("b9744d37-d7c6-43c5-81ab-b82b02e01aa3"),
                  QuestionText = "What is a correct syntax to output 'Hello World' in C#?",
                  CorrectAnswer = "Console.WriteLine(\"Hello World\")",
                  QuizId = Guid.Parse("5491d598-3798-4c4f-a99f-f021e1406797")
              },
              new Question
              {
                  Id = Guid.Parse("749ac7fa-4687-4c0c-a2e4-974cba61a0e8"),
                  QuestionText = "Which operator is used to add together two values?",
                  CorrectAnswer = "The + sign",
                  QuizId = Guid.Parse("5491d598-3798-4c4f-a99f-f021e1406797")
              },
              new Question
              {
                  Id = Guid.Parse("56891f72-811b-467b-a88e-d3f9be4b7081"),
                  QuestionText = "How do you insert COMMENTS in C# code?",
                  CorrectAnswer = "// This is a comment",
                  QuizId = Guid.Parse("5491d598-3798-4c4f-a99f-f021e1406797")
              },
              new Question
              {
                  Id = Guid.Parse("fb5f6c2d-8dd5-4281-91ce-f548ded2228e"),
                  QuestionText = "Which data type is used to create a variable that should store text?",
                  CorrectAnswer = "string",
                  QuizId = Guid.Parse("5491d598-3798-4c4f-a99f-f021e1406797")
              }, new Question
              {
                  Id = Guid.Parse("93fa1335-2bbd-4161-9f3c-824e22bd75e9"),
                  QuestionText = "How do you create a variable with the numeric value 5?",
                  CorrectAnswer = "int x = 5;",
                  QuizId = Guid.Parse("5491d598-3798-4c4f-a99f-f021e1406797")
              },
              new Question
              {
                  Id = Guid.Parse("7c29852e-e182-459d-88a0-0634e1a093a2"),
                  QuestionText = "What does HTML stand for?",
                  CorrectAnswer = "Hyper Text Markup Language",
                  QuizId = Guid.Parse("6e60e6cb-5f99-459d-9e89-96425b57462f")
              },
              new Question
              {
                  Id = Guid.Parse("cbbce265-2cbf-467f-a838-eddf6bcedd9f"),
                  QuestionText = "Who is making the Web standards?",
                  CorrectAnswer = "The World Wide Web Consortium",
                  QuizId = Guid.Parse("6e60e6cb-5f99-459d-9e89-96425b57462f")
              },
              new Question
              {
                  Id = Guid.Parse("a4ba9808-9beb-4152-9504-d0d1618a7307"),
                  QuestionText = "Choose the correct HTML element for the largest heading:",
                  CorrectAnswer = "<h1>",
                  QuizId = Guid.Parse("6e60e6cb-5f99-459d-9e89-96425b57462f")
              },
              new Question
              {
                  Id = Guid.Parse("1fc869a5-d338-4fcb-96ba-1db79cc0814c"),
                  QuestionText = "What is the correct HTML element for inserting a line break?",
                  CorrectAnswer = "<br>",
                  QuizId = Guid.Parse("6e60e6cb-5f99-459d-9e89-96425b57462f")
              }, new Question
              {
                  Id = Guid.Parse("4fbd2b0c-9c48-4da7-b5dc-5dbce6b1d7b2"),
                  QuestionText = "Choose the correct HTML element to define emphasized text",
                  CorrectAnswer = "<em>",
                  QuizId = Guid.Parse("6e60e6cb-5f99-459d-9e89-96425b57462f")
              },
              new Question
              {
                  Id = Guid.Parse("109ea928-d48c-42d5-aeef-c70622f86f1c"),
                  QuestionText = "What skills depend on the manager's ability to think in the abstract?",
                  CorrectAnswer = "Conceptual",
                  QuizId = Guid.Parse("44f8f00a-17e6-46d9-9e0c-be3326514c02")
              },
              new Question
              {
                  Id = Guid.Parse("a9682130-8486-402c-a678-3b1fdae669a8"),
                  QuestionText = "The skills necessary to accomplish or understand the specific kind of work done in an organization are called what?",
                  CorrectAnswer = "Technical skills",
                  QuizId = Guid.Parse("44f8f00a-17e6-46d9-9e0c-be3326514c02")
              },
              new Question
              {
                  Id = Guid.Parse("8d3d6d09-f092-419d-84f1-c39ffec5a2bf"),
                  QuestionText = "Monitoring and correcting ongoing activities that facilitate goal attainment is defined as:",
                  CorrectAnswer = "Controlling",
                  QuizId = Guid.Parse("44f8f00a-17e6-46d9-9e0c-be3326514c02")
              },
              new Question
              {
                  Id = Guid.Parse("f390b872-dea2-4fe6-a1c9-2bed45d98830"),
                  QuestionText = "Executing the same test case by giving the number of inputs on same build called as",
                  CorrectAnswer = "Traceablity Matrix",
                  QuizId = Guid.Parse("43e0817d-8e88-41dd-bcfa-7ec05ef7f283")
              },
              new Question
              {
                  Id = Guid.Parse("21d1a3ea-e936-4b56-8dd4-e82494122afc"),
                  QuestionText = "The cyclomatic complexity metric provides the designer with information regarding the number of",
                  CorrectAnswer = "Independent logic paths in the program",
                  QuizId = Guid.Parse("43e0817d-8e88-41dd-bcfa-7ec05ef7f283")
              },
              new Question
              {
                  Id = Guid.Parse("546e58f3-f8b8-4596-b74a-95c7dd27a346"),
                  QuestionText = "Equivalence partitioning is:",
                  CorrectAnswer = "A black box testing technique appropriate to all levels of testing",
                  QuizId = Guid.Parse("43e0817d-8e88-41dd-bcfa-7ec05ef7f283")
              },
              new Question
              {
                  Id = Guid.Parse("38cf6409-c1de-4553-af07-d15bd6a019a5"),
                  QuestionText = "Tools a company uses to manage employees are?",
                  CorrectAnswer = "HR practices",
                  QuizId = Guid.Parse("b1336dc5-1db4-4ec8-aa88-9d17c8d0267d")
              },
              new Question
              {
                  Id = Guid.Parse("82850071-298d-4155-9342-a30769b2cc8a"),
                  QuestionText = "Ensuring Employees have the necessary knowledge, skills, abilities, and other talents to achieve work objectives falls under which of the following categories?",
                  CorrectAnswer = "Managing Employee Competencies",
                  QuizId = Guid.Parse("b1336dc5-1db4-4ec8-aa88-9d17c8d0267d")
              },
              new Question
              {
                  Id = Guid.Parse("839f2a81-5566-400e-8af9-df42d221df5c"),
                  QuestionText = "Which of the following is not one of the benefits, health, and wellness required by law?",
                  CorrectAnswer = "Health care",
                  QuizId = Guid.Parse("b1336dc5-1db4-4ec8-aa88-9d17c8d0267d")
              },
              new Question
              {
                  Id = Guid.Parse("7a5593dc-a11f-458c-98d3-2ec8b5476c8b"),
                  QuestionText = "Which of the following type of investment allows an individual to purchase into an entire industry, commodity group, or stock market?",
                  CorrectAnswer = "Mutual Fund",
                  QuizId = Guid.Parse("73b4acad-b234-40b5-aa20-35d4f071a89e")
              },
              new Question
              {
                  Id = Guid.Parse("489eddce-71ee-4cc2-9d0e-555a0582431f"),
                  QuestionText = "Which of the following is NOT a benefit of online trading?",
                  CorrectAnswer = "It's easier to invest too much too fast",
                  QuizId = Guid.Parse("73b4acad-b234-40b5-aa20-35d4f071a89e")
              },
              new Question
              {
                  Id = Guid.Parse("d134ce37-f871-4be3-aa47-ed363abddc96"),
                  QuestionText = "Increasing the percentage of which type of investment in your portfolio will lower your overall investment risk?",
                  CorrectAnswer = "Bond",
                  QuizId = Guid.Parse("73b4acad-b234-40b5-aa20-35d4f071a89e")
              }
              );

            modelBuilder.Entity<Choice>().HasData
            (new Choice
            {
                Id = Guid.Parse("10167de8-022b-4d8a-9828-17c4632b2391"),
                Text = "System.out.println(\"Hello World\");",
                QuestionId = Guid.Parse("b9744d37-d7c6-43c5-81ab-b82b02e01aa3")
            },
            new Choice
            {
                Id = Guid.Parse("6e72a0df-ec71-46a8-9ef7-87ab7c6b2261"),
                Text =  "cout << \"Hello World\"",
                QuestionId = Guid.Parse("b9744d37-d7c6-43c5-81ab-b82b02e01aa3")
            },
            new Choice
            {
                Id = Guid.Parse("b30e6130-73d6-4453-9524-428aabf3d1ff"),
                Text = "Console.WriteLine(\"Hello World\")",
                QuestionId = Guid.Parse("b9744d37-d7c6-43c5-81ab-b82b02e01aa3")
            },
            new Choice
            {        
                Id = Guid.Parse("1f5f51e3-40b9-4d77-aa82-ce37f7841871"),
                Text = "The & sign",
                QuestionId = Guid.Parse("749ac7fa-4687-4c0c-a2e4-974cba61a0e8")
            },
            new Choice
            {
                Id = Guid.Parse("b803ce0e-1997-4b00-a589-8bf53d10d846"),
                Text = "The * sign",
                QuestionId = Guid.Parse("749ac7fa-4687-4c0c-a2e4-974cba61a0e8")
            },
            new Choice
            {
                Id = Guid.Parse("ef9a7cca-2a36-4029-a8d8-fbbe3f48a2f3"),
                Text = "The + sign",
                QuestionId = Guid.Parse("749ac7fa-4687-4c0c-a2e4-974cba61a0e8")
            },
            new Choice
            {  
                Id = Guid.Parse("c6c67a58-dd8a-4fd7-85da-9f4efd67d7cf"),
                Text = "/* This is a comment",
                QuestionId = Guid.Parse("56891f72-811b-467b-a88e-d3f9be4b7081")
            },
            new Choice
            {
                Id = Guid.Parse("2d3b4929-6a1f-4145-8460-c5c2d58f3026"),
                Text = "// This is a comment",
                QuestionId = Guid.Parse("56891f72-811b-467b-a88e-d3f9be4b7081")
            },
            new Choice
            {
                Id = Guid.Parse("c20e9f32-3cc1-41da-8eda-700edc0e7a1e"),
                Text = "# This is a comment",
                QuestionId = Guid.Parse("56891f72-811b-467b-a88e-d3f9be4b7081")
            },
            new Choice
            {       
                Id = Guid.Parse("29effdc0-ee24-4d23-b44c-daaae32b5a0b"),
                Text = "myString",
                QuestionId = Guid.Parse("fb5f6c2d-8dd5-4281-91ce-f548ded2228e")
            },
            new Choice
            {
                Id = Guid.Parse("8a2e6b18-f8dd-4401-92a3-e98f80926faf"),
                Text = "Txt",
                QuestionId = Guid.Parse("fb5f6c2d-8dd5-4281-91ce-f548ded2228e")
            },
            new Choice
            {
                Id = Guid.Parse("d58f8fd9-0d2f-44ce-a0f1-c302e0a1fb77"),
                Text = "string",
                QuestionId = Guid.Parse("fb5f6c2d-8dd5-4281-91ce-f548ded2228e")
            },
            new Choice
            {       
                Id = Guid.Parse("9f9b48f9-61f9-4ec3-af43-4bb7a786c92d"),
                Text = "x = 5;",
                QuestionId = Guid.Parse("93fa1335-2bbd-4161-9f3c-824e22bd75e9")
            },
            new Choice
            {
                Id = Guid.Parse("34822d54-cd25-49c6-adb2-1483669e4199"),
                Text = "int x = 5;",
                QuestionId = Guid.Parse("93fa1335-2bbd-4161-9f3c-824e22bd75e9")
            },
            new Choice
            {
                Id = Guid.Parse("be3bb536-d5b6-407d-a93f-631e5a8dea2c"),
                Text = "num x = 5",
                QuestionId = Guid.Parse("93fa1335-2bbd-4161-9f3c-824e22bd75e9")
            },
            new Choice
            { 
                Id = Guid.Parse("a3605028-62da-473f-a5e6-5dde9d101a92"),
                Text = "Hyperlinks and Text Markup Language",
                QuestionId = Guid.Parse("7c29852e-e182-459d-88a0-0634e1a093a2")
            },
            new Choice
            {
                Id = Guid.Parse("97419e21-ddf9-442c-9603-b99de96d8c35"),
                Text = "Home Tool Markup Language",
                QuestionId = Guid.Parse("7c29852e-e182-459d-88a0-0634e1a093a2")
            },
            new Choice
            {
                Id = Guid.Parse("7b5f1282-1620-44fc-967b-7efd1e04b232"),
                Text = "Hyper Text Markup Language",
                QuestionId = Guid.Parse("7c29852e-e182-459d-88a0-0634e1a093a2")
            },
            new Choice
            { 
                Id = Guid.Parse("25769432-9fc5-4be8-b82f-3aa1b653bcc4"),
                Text = "The World Wide Web Consortium",
                QuestionId = Guid.Parse("cbbce265-2cbf-467f-a838-eddf6bcedd9f")
            },
            new Choice
            {
                Id = Guid.Parse("e836d58c-44be-4943-b526-8ed6e1d0449b"),
                Text = "Mozilla",
                QuestionId = Guid.Parse("cbbce265-2cbf-467f-a838-eddf6bcedd9f")
            },
            new Choice
            {
                Id = Guid.Parse("e825085f-09d1-45f5-8b65-b1b64da29a88"),
                Text = "Google",
                QuestionId = Guid.Parse("cbbce265-2cbf-467f-a838-eddf6bcedd9f")
            },
            new Choice
            {     
                Id = Guid.Parse("7770b965-4695-4b19-b4ab-2c23168523b7"),
                Text = "<heading>",
                QuestionId = Guid.Parse("a4ba9808-9beb-4152-9504-d0d1618a7307")
            },
            new Choice
            {
                Id = Guid.Parse("1b6d7f63-9562-41da-ac00-b5284b1f5104"),
                Text = "<h1>",
                QuestionId = Guid.Parse("a4ba9808-9beb-4152-9504-d0d1618a7307")
            },
            new Choice
            {
                Id = Guid.Parse("dfc1af88-6627-43ac-9ca3-9a62078a6b73"),
                Text = "<head>",
                QuestionId = Guid.Parse("a4ba9808-9beb-4152-9504-d0d1618a7307")
            },
            new Choice
            {   
                Id = Guid.Parse("ec646784-d6bd-4c27-9001-c84cb56f7a20"),
                Text = "<break>",
                QuestionId = Guid.Parse("1fc869a5-d338-4fcb-96ba-1db79cc0814c")
            },
            new Choice
            {
                Id = Guid.Parse("fe72f62d-a9f6-4251-b204-10d4243c414b"),
                Text = "<lb>",
                QuestionId = Guid.Parse("1fc869a5-d338-4fcb-96ba-1db79cc0814c")
            },
            new Choice
            {
                Id = Guid.Parse("e79a571d-4387-4c01-9acd-3adaf7a9ab8e"),
                Text = "<br>",
                QuestionId = Guid.Parse("1fc869a5-d338-4fcb-96ba-1db79cc0814c")
            },
            new Choice
            {      
                Id = Guid.Parse("9e00556e-cbb5-4f0b-8ad4-52c1a74cb67b"),
                Text = "<em>",
                QuestionId = Guid.Parse("4fbd2b0c-9c48-4da7-b5dc-5dbce6b1d7b2")
            },
            new Choice
            {
                Id = Guid.Parse("d616ac6b-1aa3-4681-9c15-6e9ae87fc867"),
                Text = "<italic>",
                QuestionId = Guid.Parse("4fbd2b0c-9c48-4da7-b5dc-5dbce6b1d7b2")
            },
            new Choice
            {
                Id = Guid.Parse("6e504be4-e44d-4dd5-b321-21c894cf3a0c"),
                Text = "<i>",
                QuestionId = Guid.Parse("4fbd2b0c-9c48-4da7-b5dc-5dbce6b1d7b2")
            },
            new Choice
            {
                Id = Guid.Parse("b85bc922-1781-48b1-bc50-f777ad9aeb85"),
                Text = "Conceptual",
                QuestionId = Guid.Parse("109ea928-d48c-42d5-aeef-c70622f86f1c")
            },
            new Choice
            {
                Id = Guid.Parse("01ed4ddf-491f-4850-9781-1309938af31b"),
                Text = "Decision-making",
                QuestionId = Guid.Parse("109ea928-d48c-42d5-aeef-c70622f86f1c")
            },
            new Choice
            {
                Id = Guid.Parse("f9922860-dd0a-4019-b8e0-9ec0f46afaca"),
                Text = "Interpersonal",
                QuestionId = Guid.Parse("109ea928-d48c-42d5-aeef-c70622f86f1c")
            },
            new Choice
            {
                Id = Guid.Parse("2d31c648-d5b8-410b-b154-1670f06c0a14"),
                Text = "Technical skills",
                QuestionId = Guid.Parse("a9682130-8486-402c-a678-3b1fdae669a8")
            },
            new Choice
            {
                Id = Guid.Parse("645710ca-d812-4be3-9757-2a4f6e6866fa"),
                Text = "Time management skills",
                QuestionId = Guid.Parse("a9682130-8486-402c-a678-3b1fdae669a8")
            },
            new Choice
            {
                Id = Guid.Parse("f5ed2e32-ed03-400e-9761-9c6633c934fa"),
                Text = "Conceptual skills",
                QuestionId = Guid.Parse("a9682130-8486-402c-a678-3b1fdae669a8")
            },
            new Choice
            {
                Id = Guid.Parse("563288eb-baff-4d4a-a4bd-5e5c7b994307"),
                Text = "Controlling",
                QuestionId = Guid.Parse("8d3d6d09-f092-419d-84f1-c39ffec5a2bf")
            },
            new Choice
            {
                Id = Guid.Parse("ead20d3a-817d-4d45-adaa-2c859d5734a6"),
                Text = "Organizing",
                QuestionId = Guid.Parse("8d3d6d09-f092-419d-84f1-c39ffec5a2bf")
            },
            new Choice
            {
                Id = Guid.Parse("4412969c-053f-4625-9204-beffaabc0109"),
                Text = "Leading",
                QuestionId = Guid.Parse("8d3d6d09-f092-419d-84f1-c39ffec5a2bf")
            },
            new Choice
            {
                Id = Guid.Parse("40617427-0bc4-4209-9ff7-3d6a30f95570"),
                Text = "Traceablity Matrix",
                QuestionId = Guid.Parse("f390b872-dea2-4fe6-a1c9-2bed45d98830")
            },
            new Choice
            {
                Id = Guid.Parse("32249414-02a0-4168-aa71-3a0d1d8fb12e"),
                Text = "Test Matrix",
                QuestionId = Guid.Parse("f390b872-dea2-4fe6-a1c9-2bed45d98830")
            },
            new Choice
            {
                Id = Guid.Parse("970f6630-05c3-457c-a87c-2e861a337641"),
                Text = "Checklist",
                QuestionId = Guid.Parse("f390b872-dea2-4fe6-a1c9-2bed45d98830")
            },
            new Choice
            {
                Id = Guid.Parse("70a74497-01a5-4b2a-9d7f-d05f4775f0d9"),
                Text = "Independent logic paths in the program",
                QuestionId = Guid.Parse("21d1a3ea-e936-4b56-8dd4-e82494122afc")
            },
            new Choice
            {
                Id = Guid.Parse("f602b9e1-0a0e-4150-9865-d0133910ecac"),
                Text = "Statements in the program",
                QuestionId = Guid.Parse("21d1a3ea-e936-4b56-8dd4-e82494122afc")
            },
            new Choice
            {
                Id = Guid.Parse("e78c6e55-6a67-4a4f-a6cc-888de8c1de97"),
                Text = "Cycles in the program",
                QuestionId = Guid.Parse("21d1a3ea-e936-4b56-8dd4-e82494122afc")
            },
            new Choice
            {
                Id = Guid.Parse("a6480e73-91e5-4752-9deb-3a1fecb59379"),
                Text = "A black box testing technique appropriate to all levels of testing",
                QuestionId = Guid.Parse("546e58f3-f8b8-4596-b74a-95c7dd27a346")
            },
            new Choice
            {
                Id = Guid.Parse("3c308389-4fd9-402a-978e-b41cf875a10c"),
                Text = "A white box testing technique appropriate for component testing",
                QuestionId = Guid.Parse("546e58f3-f8b8-4596-b74a-95c7dd27a346")
            },
            new Choice
            {
                Id = Guid.Parse("2964bab6-6070-440f-b850-e9d922a2442d"),
                Text = "A black box testing technique than can only be used during system testing",
                QuestionId = Guid.Parse("546e58f3-f8b8-4596-b74a-95c7dd27a346")
            },
            new Choice
            {
                Id = Guid.Parse("6ab62c60-7db4-4cf5-8977-d701f8ac54a9"),
                Text = "HR practices",
                QuestionId = Guid.Parse("38cf6409-c1de-4553-af07-d15bd6a019a5")
            },
            new Choice
            {
                Id = Guid.Parse("fc0df8ce-3ce1-4d75-9f4a-bed6a06d36e6"),
                Text = "HR department",
                QuestionId = Guid.Parse("38cf6409-c1de-4553-af07-d15bd6a019a5")
            },
            new Choice
            {
                Id = Guid.Parse("65b56702-b549-4165-bf70-88c51290a081"),
                Text = "HR tools",
                QuestionId = Guid.Parse("38cf6409-c1de-4553-af07-d15bd6a019a5")
            },
            new Choice
            {
                Id = Guid.Parse("59b9a61f-6927-4619-b98e-3c2435e1344b"),
                Text = "Managing Employee Competencies",
                QuestionId = Guid.Parse("82850071-298d-4155-9342-a30769b2cc8a")
            },
            new Choice
            {
                Id = Guid.Parse("75716c14-8663-4af3-92d6-c83148b1680a"),
                Text = "Managing Employee Attitudes and Behaviors",
                QuestionId = Guid.Parse("82850071-298d-4155-9342-a30769b2cc8a")
            },
            new Choice
            {
                Id = Guid.Parse("6ace3361-fed0-4784-a01e-e9ac083f6bd2"),
                Text = "Compensation and incentives",
                QuestionId = Guid.Parse("82850071-298d-4155-9342-a30769b2cc8a")
            },
            new Choice
            {
                Id = Guid.Parse("41a7fae1-7e84-4b8a-a1cb-dd4007fd5e0b"),
                Text = "Health care",
                QuestionId = Guid.Parse("839f2a81-5566-400e-8af9-df42d221df5c")
            },
            new Choice
            {
                Id = Guid.Parse("28cbc296-8184-447a-ab69-5f2821165a78"),
                Text = "Social Security",
                QuestionId = Guid.Parse("839f2a81-5566-400e-8af9-df42d221df5c")
            },
            new Choice
            {
                Id = Guid.Parse("4fc92837-8131-4fe0-ba53-e8f96b1fc41a"),
                Text = "Compliance with OSHA",
                QuestionId = Guid.Parse("839f2a81-5566-400e-8af9-df42d221df5c")
            },
            new Choice
            {
                Id = Guid.Parse("d4048da5-7848-4da7-9c84-48094b888c96"),
                Text = "Mutual Fund",
                QuestionId = Guid.Parse("7a5593dc-a11f-458c-98d3-2ec8b5476c8b")
            },
            new Choice
            {
                Id = Guid.Parse("3309d1b1-c234-48cf-bad5-f40b983a3df2"),
                Text = "RRSP",
                QuestionId = Guid.Parse("7a5593dc-a11f-458c-98d3-2ec8b5476c8b")
            },
            new Choice
            {
                Id = Guid.Parse("259c1073-6276-4a52-a3b5-8333d743654f"),
                Text = "ETF",
                QuestionId = Guid.Parse("7a5593dc-a11f-458c-98d3-2ec8b5476c8b")
            },
            new Choice
            {
                Id = Guid.Parse("43eed3a4-b55a-4189-a08d-59d56f5d49a4"),
                Text = "It's easier to invest too much too fast",
                QuestionId = Guid.Parse("489eddce-71ee-4cc2-9d0e-555a0582431f")
            },
            new Choice
            {
                Id = Guid.Parse("03ababf4-bb09-493c-8e7f-99c19d4c90bd"),
                Text = "One can monitor investments in real time",
                QuestionId = Guid.Parse("489eddce-71ee-4cc2-9d0e-555a0582431f")
            },
            new Choice
            {
                Id = Guid.Parse("50068619-b8cf-4a50-ba76-df21f03c90f1"),
                Text = "Online accessibility",
                QuestionId = Guid.Parse("489eddce-71ee-4cc2-9d0e-555a0582431f")
            },
            new Choice
            {
                Id = Guid.Parse("93c828b1-3065-419c-94ee-3009b0086a5f"),
                Text = "Bond",
                QuestionId = Guid.Parse("d134ce37-f871-4be3-aa47-ed363abddc96")
            },
            new Choice
            {
                Id = Guid.Parse("2be15a5f-fc23-4a3c-a9ea-e54f5f270e93"),
                Text = "REIT",
                QuestionId = Guid.Parse("d134ce37-f871-4be3-aa47-ed363abddc96")
            },
            new Choice
            {
                Id = Guid.Parse("046f194f-933a-4b43-a48a-d81264f8f6a8"),
                Text = "Equity",
                QuestionId = Guid.Parse("d134ce37-f871-4be3-aa47-ed363abddc96")
            });
        }
    }
}
