using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizAppDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Quizzes",
                type: "nvarchar(140)",
                maxLength: 140,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("43e0817d-8e88-41dd-bcfa-7ec05ef7f283"), "Take a shot at this quiz, which will help you determine your IQ, your QA knowledge. Best luck.", "QA Quiz" },
                    { new Guid("44f8f00a-17e6-46d9-9e0c-be3326514c02"), "If you are in the management field and looking for a well-researched 'Introduction to Management' practice quiz with answers, you've reached the right place. Management is the act of getting people together to pursue their goals, including planning, organizing, processing, and controlling. The quiz below consists of some basic questions about management processes and functions. Do you think you can quickly answer all of them? Take up this quiz and prove your knowledge now.", "Management Quiz" },
                    { new Guid("73b4acad-b234-40b5-aa20-35d4f071a89e"), "With the advancement of society and the internet, the investment world has changed dramatically. How well do you know about various investment strategies? If you know enough, then feel free to give this fun and informative quiz a try! Just answer a few questions to enter the world of stocks, online trading, bond, etc. Are you ready? There's no time bar, so feel free to take this quiz as often as possible! We hope you learn some new things with the quiz! Good Luck!", "Investment Quiz" },
                    { new Guid("b1336dc5-1db4-4ec8-aa88-9d17c8d0267d"), "This is a quiz with HR test questions. The first one, made in a series of tests made to help me prepare for my human resource management exam. All material was taken from the Human Resource Management Book by David Lepak and Mary Gowan. Why don't you give it a try and let it do the same for you? All the best, and share it with your classmates!", "HR Quiz" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CorrectAnswer", "QuestionText", "QuizId" },
                values: new object[,]
                {
                    { new Guid("109ea928-d48c-42d5-aeef-c70622f86f1c"), "Conceptual", "What skills depend on the manager's ability to think in the abstract?", new Guid("44f8f00a-17e6-46d9-9e0c-be3326514c02") },
                    { new Guid("21d1a3ea-e936-4b56-8dd4-e82494122afc"), "Independent logic paths in the program", "The cyclomatic complexity metric provides the designer with information regarding the number of", new Guid("43e0817d-8e88-41dd-bcfa-7ec05ef7f283") },
                    { new Guid("38cf6409-c1de-4553-af07-d15bd6a019a5"), "HR practices", "Tools a company uses to manage employees are?", new Guid("b1336dc5-1db4-4ec8-aa88-9d17c8d0267d") },
                    { new Guid("489eddce-71ee-4cc2-9d0e-555a0582431f"), "It's easier to invest too much too fast", "Which of the following is NOT a benefit of online trading?", new Guid("73b4acad-b234-40b5-aa20-35d4f071a89e") },
                    { new Guid("546e58f3-f8b8-4596-b74a-95c7dd27a346"), "A black box testing technique appropriate to all levels of testing", "Equivalence partitioning is:", new Guid("43e0817d-8e88-41dd-bcfa-7ec05ef7f283") },
                    { new Guid("7a5593dc-a11f-458c-98d3-2ec8b5476c8b"), "Mutual Fund", "Which of the following type of investment allows an individual to purchase into an entire industry, commodity group, or stock market?", new Guid("73b4acad-b234-40b5-aa20-35d4f071a89e") },
                    { new Guid("82850071-298d-4155-9342-a30769b2cc8a"), "Managing Employee Competencies", "Ensuring Employees have the necessary knowledge, skills, abilities, and other talents to achieve work objectives falls under which of the following categories?", new Guid("b1336dc5-1db4-4ec8-aa88-9d17c8d0267d") },
                    { new Guid("839f2a81-5566-400e-8af9-df42d221df5c"), "Health care", "Which of the following is not one of the benefits, health, and wellness required by law?", new Guid("b1336dc5-1db4-4ec8-aa88-9d17c8d0267d") },
                    { new Guid("8d3d6d09-f092-419d-84f1-c39ffec5a2bf"), "Controlling", "Monitoring and correcting ongoing activities that facilitate goal attainment is defined as:", new Guid("44f8f00a-17e6-46d9-9e0c-be3326514c02") },
                    { new Guid("a9682130-8486-402c-a678-3b1fdae669a8"), "Technical skills", "The skills necessary to accomplish or understand the specific kind of work done in an organization are called what?", new Guid("44f8f00a-17e6-46d9-9e0c-be3326514c02") },
                    { new Guid("d134ce37-f871-4be3-aa47-ed363abddc96"), "Bond", "Increasing the percentage of which type of investment in your portfolio will lower your overall investment risk?", new Guid("73b4acad-b234-40b5-aa20-35d4f071a89e") },
                    { new Guid("f390b872-dea2-4fe6-a1c9-2bed45d98830"), "Traceablity Matrix", "Executing the same test case by giving the number of inputs on same build called as", new Guid("43e0817d-8e88-41dd-bcfa-7ec05ef7f283") }
                });

            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "Id", "QuestionId", "Text" },
                values: new object[,]
                {
                    { new Guid("01ed4ddf-491f-4850-9781-1309938af31b"), new Guid("109ea928-d48c-42d5-aeef-c70622f86f1c"), "Decision-making" },
                    { new Guid("03ababf4-bb09-493c-8e7f-99c19d4c90bd"), new Guid("489eddce-71ee-4cc2-9d0e-555a0582431f"), "One can monitor investments in real time" },
                    { new Guid("046f194f-933a-4b43-a48a-d81264f8f6a8"), new Guid("d134ce37-f871-4be3-aa47-ed363abddc96"), "Equity" },
                    { new Guid("259c1073-6276-4a52-a3b5-8333d743654f"), new Guid("7a5593dc-a11f-458c-98d3-2ec8b5476c8b"), "ETF" },
                    { new Guid("28cbc296-8184-447a-ab69-5f2821165a78"), new Guid("839f2a81-5566-400e-8af9-df42d221df5c"), "Social Security" },
                    { new Guid("2964bab6-6070-440f-b850-e9d922a2442d"), new Guid("546e58f3-f8b8-4596-b74a-95c7dd27a346"), "A black box testing technique than can only be used during system testing" },
                    { new Guid("2be15a5f-fc23-4a3c-a9ea-e54f5f270e93"), new Guid("d134ce37-f871-4be3-aa47-ed363abddc96"), "REIT" },
                    { new Guid("2d31c648-d5b8-410b-b154-1670f06c0a14"), new Guid("a9682130-8486-402c-a678-3b1fdae669a8"), "Technical skills" },
                    { new Guid("32249414-02a0-4168-aa71-3a0d1d8fb12e"), new Guid("f390b872-dea2-4fe6-a1c9-2bed45d98830"), "Test Matrix" },
                    { new Guid("3309d1b1-c234-48cf-bad5-f40b983a3df2"), new Guid("7a5593dc-a11f-458c-98d3-2ec8b5476c8b"), "RRSP" },
                    { new Guid("3c308389-4fd9-402a-978e-b41cf875a10c"), new Guid("546e58f3-f8b8-4596-b74a-95c7dd27a346"), "A white box testing technique appropriate for component testing" },
                    { new Guid("40617427-0bc4-4209-9ff7-3d6a30f95570"), new Guid("f390b872-dea2-4fe6-a1c9-2bed45d98830"), "Traceablity Matrix" },
                    { new Guid("41a7fae1-7e84-4b8a-a1cb-dd4007fd5e0b"), new Guid("839f2a81-5566-400e-8af9-df42d221df5c"), "Health care" },
                    { new Guid("43eed3a4-b55a-4189-a08d-59d56f5d49a4"), new Guid("489eddce-71ee-4cc2-9d0e-555a0582431f"), "It's easier to invest too much too fast" },
                    { new Guid("4412969c-053f-4625-9204-beffaabc0109"), new Guid("8d3d6d09-f092-419d-84f1-c39ffec5a2bf"), "Leading" },
                    { new Guid("4fc92837-8131-4fe0-ba53-e8f96b1fc41a"), new Guid("839f2a81-5566-400e-8af9-df42d221df5c"), "Compliance with OSHA" },
                    { new Guid("50068619-b8cf-4a50-ba76-df21f03c90f1"), new Guid("489eddce-71ee-4cc2-9d0e-555a0582431f"), "Online accessibility" },
                    { new Guid("563288eb-baff-4d4a-a4bd-5e5c7b994307"), new Guid("8d3d6d09-f092-419d-84f1-c39ffec5a2bf"), "Controlling" },
                    { new Guid("59b9a61f-6927-4619-b98e-3c2435e1344b"), new Guid("82850071-298d-4155-9342-a30769b2cc8a"), "Managing Employee Competencies" },
                    { new Guid("645710ca-d812-4be3-9757-2a4f6e6866fa"), new Guid("a9682130-8486-402c-a678-3b1fdae669a8"), "Time management skills" },
                    { new Guid("65b56702-b549-4165-bf70-88c51290a081"), new Guid("38cf6409-c1de-4553-af07-d15bd6a019a5"), "HR tools" },
                    { new Guid("6ab62c60-7db4-4cf5-8977-d701f8ac54a9"), new Guid("38cf6409-c1de-4553-af07-d15bd6a019a5"), "HR practices" },
                    { new Guid("6ace3361-fed0-4784-a01e-e9ac083f6bd2"), new Guid("82850071-298d-4155-9342-a30769b2cc8a"), "Compensation and incentives" },
                    { new Guid("70a74497-01a5-4b2a-9d7f-d05f4775f0d9"), new Guid("21d1a3ea-e936-4b56-8dd4-e82494122afc"), "Independent logic paths in the program" },
                    { new Guid("75716c14-8663-4af3-92d6-c83148b1680a"), new Guid("82850071-298d-4155-9342-a30769b2cc8a"), "Managing Employee Attitudes and Behaviors" },
                    { new Guid("93c828b1-3065-419c-94ee-3009b0086a5f"), new Guid("d134ce37-f871-4be3-aa47-ed363abddc96"), "Bond" },
                    { new Guid("970f6630-05c3-457c-a87c-2e861a337641"), new Guid("f390b872-dea2-4fe6-a1c9-2bed45d98830"), "Checklist" },
                    { new Guid("a6480e73-91e5-4752-9deb-3a1fecb59379"), new Guid("546e58f3-f8b8-4596-b74a-95c7dd27a346"), "A black box testing technique appropriate to all levels of testing" },
                    { new Guid("b85bc922-1781-48b1-bc50-f777ad9aeb85"), new Guid("109ea928-d48c-42d5-aeef-c70622f86f1c"), "Conceptual" },
                    { new Guid("d4048da5-7848-4da7-9c84-48094b888c96"), new Guid("7a5593dc-a11f-458c-98d3-2ec8b5476c8b"), "Mutual Fund" },
                    { new Guid("e78c6e55-6a67-4a4f-a6cc-888de8c1de97"), new Guid("21d1a3ea-e936-4b56-8dd4-e82494122afc"), "Cycles in the program" },
                    { new Guid("ead20d3a-817d-4d45-adaa-2c859d5734a6"), new Guid("8d3d6d09-f092-419d-84f1-c39ffec5a2bf"), "Organizing" },
                    { new Guid("f5ed2e32-ed03-400e-9761-9c6633c934fa"), new Guid("a9682130-8486-402c-a678-3b1fdae669a8"), "Conceptual skills" },
                    { new Guid("f602b9e1-0a0e-4150-9865-d0133910ecac"), new Guid("21d1a3ea-e936-4b56-8dd4-e82494122afc"), "Statements in the program" },
                    { new Guid("f9922860-dd0a-4019-b8e0-9ec0f46afaca"), new Guid("109ea928-d48c-42d5-aeef-c70622f86f1c"), "Interpersonal" },
                    { new Guid("fc0df8ce-3ce1-4d75-9f4a-bed6a06d36e6"), new Guid("38cf6409-c1de-4553-af07-d15bd6a019a5"), "HR department" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("01ed4ddf-491f-4850-9781-1309938af31b"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("03ababf4-bb09-493c-8e7f-99c19d4c90bd"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("046f194f-933a-4b43-a48a-d81264f8f6a8"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("259c1073-6276-4a52-a3b5-8333d743654f"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("28cbc296-8184-447a-ab69-5f2821165a78"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("2964bab6-6070-440f-b850-e9d922a2442d"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("2be15a5f-fc23-4a3c-a9ea-e54f5f270e93"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("2d31c648-d5b8-410b-b154-1670f06c0a14"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("32249414-02a0-4168-aa71-3a0d1d8fb12e"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("3309d1b1-c234-48cf-bad5-f40b983a3df2"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("3c308389-4fd9-402a-978e-b41cf875a10c"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("40617427-0bc4-4209-9ff7-3d6a30f95570"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("41a7fae1-7e84-4b8a-a1cb-dd4007fd5e0b"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("43eed3a4-b55a-4189-a08d-59d56f5d49a4"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("4412969c-053f-4625-9204-beffaabc0109"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("4fc92837-8131-4fe0-ba53-e8f96b1fc41a"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("50068619-b8cf-4a50-ba76-df21f03c90f1"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("563288eb-baff-4d4a-a4bd-5e5c7b994307"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("59b9a61f-6927-4619-b98e-3c2435e1344b"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("645710ca-d812-4be3-9757-2a4f6e6866fa"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("65b56702-b549-4165-bf70-88c51290a081"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("6ab62c60-7db4-4cf5-8977-d701f8ac54a9"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("6ace3361-fed0-4784-a01e-e9ac083f6bd2"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("70a74497-01a5-4b2a-9d7f-d05f4775f0d9"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("75716c14-8663-4af3-92d6-c83148b1680a"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("93c828b1-3065-419c-94ee-3009b0086a5f"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("970f6630-05c3-457c-a87c-2e861a337641"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("a6480e73-91e5-4752-9deb-3a1fecb59379"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("b85bc922-1781-48b1-bc50-f777ad9aeb85"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("d4048da5-7848-4da7-9c84-48094b888c96"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("e78c6e55-6a67-4a4f-a6cc-888de8c1de97"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("ead20d3a-817d-4d45-adaa-2c859d5734a6"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("f5ed2e32-ed03-400e-9761-9c6633c934fa"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("f602b9e1-0a0e-4150-9865-d0133910ecac"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("f9922860-dd0a-4019-b8e0-9ec0f46afaca"));

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: new Guid("fc0df8ce-3ce1-4d75-9f4a-bed6a06d36e6"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("109ea928-d48c-42d5-aeef-c70622f86f1c"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("21d1a3ea-e936-4b56-8dd4-e82494122afc"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("38cf6409-c1de-4553-af07-d15bd6a019a5"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("489eddce-71ee-4cc2-9d0e-555a0582431f"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("546e58f3-f8b8-4596-b74a-95c7dd27a346"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("7a5593dc-a11f-458c-98d3-2ec8b5476c8b"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("82850071-298d-4155-9342-a30769b2cc8a"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("839f2a81-5566-400e-8af9-df42d221df5c"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("8d3d6d09-f092-419d-84f1-c39ffec5a2bf"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("a9682130-8486-402c-a678-3b1fdae669a8"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("d134ce37-f871-4be3-aa47-ed363abddc96"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("f390b872-dea2-4fe6-a1c9-2bed45d98830"));

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: new Guid("43e0817d-8e88-41dd-bcfa-7ec05ef7f283"));

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: new Guid("44f8f00a-17e6-46d9-9e0c-be3326514c02"));

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: new Guid("73b4acad-b234-40b5-aa20-35d4f071a89e"));

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: new Guid("b1336dc5-1db4-4ec8-aa88-9d17c8d0267d"));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Quizzes",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(140)",
                oldMaxLength: 140);
        }
    }
}
