using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizAppDAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuizId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRolesList",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRolesList", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRolesList_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRolesList_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Choices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Choices_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("5491d598-3798-4c4f-a99f-f021e1406797"), "The test contains 5 questions and there is no time limit. The test is not official,\r\n                           it's just a nice way to see how much you know, or don't know, about C#.", "C# Quiz" },
                    { new Guid("6e60e6cb-5f99-459d-9e89-96425b57462f"), "The test contains 5 questions and there is no time limit. The test is not official,\r\n                           it's just a nice way to see how much you know, or don't know, about HTML.", "HTML Quiz" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("6690193a-3dbc-416c-8a20-9751b4c48f57"), "User" },
                    { new Guid("c86deec2-7efa-4c13-a4ea-7614c37945d2"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CorrectAnswer", "QuestionText", "QuizId" },
                values: new object[,]
                {
                    { new Guid("1fc869a5-d338-4fcb-96ba-1db79cc0814c"), "<br>", "What is the correct HTML element for inserting a line break?", new Guid("6e60e6cb-5f99-459d-9e89-96425b57462f") },
                    { new Guid("4fbd2b0c-9c48-4da7-b5dc-5dbce6b1d7b2"), "<em>", "Choose the correct HTML element to define emphasized text", new Guid("6e60e6cb-5f99-459d-9e89-96425b57462f") },
                    { new Guid("56891f72-811b-467b-a88e-d3f9be4b7081"), "// This is a comment", "How do you insert COMMENTS in C# code?", new Guid("5491d598-3798-4c4f-a99f-f021e1406797") },
                    { new Guid("749ac7fa-4687-4c0c-a2e4-974cba61a0e8"), "The + sign", "Which operator is used to add together two values?", new Guid("5491d598-3798-4c4f-a99f-f021e1406797") },
                    { new Guid("7c29852e-e182-459d-88a0-0634e1a093a2"), "Hyper Text Markup Language", "What does HTML stand for?", new Guid("6e60e6cb-5f99-459d-9e89-96425b57462f") },
                    { new Guid("93fa1335-2bbd-4161-9f3c-824e22bd75e9"), "int x = 5;", "How do you create a variable with the numeric value 5?", new Guid("5491d598-3798-4c4f-a99f-f021e1406797") },
                    { new Guid("a4ba9808-9beb-4152-9504-d0d1618a7307"), "<h1>", "Choose the correct HTML element for the largest heading:", new Guid("6e60e6cb-5f99-459d-9e89-96425b57462f") },
                    { new Guid("b9744d37-d7c6-43c5-81ab-b82b02e01aa3"), "Console.WriteLine(\"Hello World\")", "What is a correct syntax to output 'Hello World' in C#?", new Guid("5491d598-3798-4c4f-a99f-f021e1406797") },
                    { new Guid("cbbce265-2cbf-467f-a838-eddf6bcedd9f"), "The World Wide Web Consortium", "Who is making the Web standards?", new Guid("6e60e6cb-5f99-459d-9e89-96425b57462f") },
                    { new Guid("fb5f6c2d-8dd5-4281-91ce-f548ded2228e"), "string", "Which data type is used to create a variable that should store text?", new Guid("5491d598-3798-4c4f-a99f-f021e1406797") }
                });

            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "Id", "QuestionId", "Text" },
                values: new object[,]
                {
                    { new Guid("10167de8-022b-4d8a-9828-17c4632b2391"), new Guid("b9744d37-d7c6-43c5-81ab-b82b02e01aa3"), "System.out.println(\"Hello World\");" },
                    { new Guid("1b6d7f63-9562-41da-ac00-b5284b1f5104"), new Guid("a4ba9808-9beb-4152-9504-d0d1618a7307"), "<h1>" },
                    { new Guid("1f5f51e3-40b9-4d77-aa82-ce37f7841871"), new Guid("749ac7fa-4687-4c0c-a2e4-974cba61a0e8"), "The & sign" },
                    { new Guid("25769432-9fc5-4be8-b82f-3aa1b653bcc4"), new Guid("cbbce265-2cbf-467f-a838-eddf6bcedd9f"), "The World Wide Web Consortium" },
                    { new Guid("29effdc0-ee24-4d23-b44c-daaae32b5a0b"), new Guid("fb5f6c2d-8dd5-4281-91ce-f548ded2228e"), "myString" },
                    { new Guid("2d3b4929-6a1f-4145-8460-c5c2d58f3026"), new Guid("56891f72-811b-467b-a88e-d3f9be4b7081"), "// This is a comment" },
                    { new Guid("34822d54-cd25-49c6-adb2-1483669e4199"), new Guid("93fa1335-2bbd-4161-9f3c-824e22bd75e9"), "int x = 5;" },
                    { new Guid("6e504be4-e44d-4dd5-b321-21c894cf3a0c"), new Guid("4fbd2b0c-9c48-4da7-b5dc-5dbce6b1d7b2"), "<i>" },
                    { new Guid("6e72a0df-ec71-46a8-9ef7-87ab7c6b2261"), new Guid("b9744d37-d7c6-43c5-81ab-b82b02e01aa3"), "cout << \"Hello World\"" },
                    { new Guid("7770b965-4695-4b19-b4ab-2c23168523b7"), new Guid("a4ba9808-9beb-4152-9504-d0d1618a7307"), "<heading>" },
                    { new Guid("7b5f1282-1620-44fc-967b-7efd1e04b232"), new Guid("7c29852e-e182-459d-88a0-0634e1a093a2"), "Hyper Text Markup Language" },
                    { new Guid("8a2e6b18-f8dd-4401-92a3-e98f80926faf"), new Guid("fb5f6c2d-8dd5-4281-91ce-f548ded2228e"), "Txt" },
                    { new Guid("97419e21-ddf9-442c-9603-b99de96d8c35"), new Guid("7c29852e-e182-459d-88a0-0634e1a093a2"), "Home Tool Markup Language" },
                    { new Guid("9e00556e-cbb5-4f0b-8ad4-52c1a74cb67b"), new Guid("4fbd2b0c-9c48-4da7-b5dc-5dbce6b1d7b2"), "<em>" },
                    { new Guid("9f9b48f9-61f9-4ec3-af43-4bb7a786c92d"), new Guid("93fa1335-2bbd-4161-9f3c-824e22bd75e9"), "x = 5;" },
                    { new Guid("a3605028-62da-473f-a5e6-5dde9d101a92"), new Guid("7c29852e-e182-459d-88a0-0634e1a093a2"), "Hyperlinks and Text Markup Language" },
                    { new Guid("b30e6130-73d6-4453-9524-428aabf3d1ff"), new Guid("b9744d37-d7c6-43c5-81ab-b82b02e01aa3"), "Console.WriteLine(\"Hello World\")" },
                    { new Guid("b803ce0e-1997-4b00-a589-8bf53d10d846"), new Guid("749ac7fa-4687-4c0c-a2e4-974cba61a0e8"), "The * sign" },
                    { new Guid("be3bb536-d5b6-407d-a93f-631e5a8dea2c"), new Guid("93fa1335-2bbd-4161-9f3c-824e22bd75e9"), "num x = 5" },
                    { new Guid("c20e9f32-3cc1-41da-8eda-700edc0e7a1e"), new Guid("56891f72-811b-467b-a88e-d3f9be4b7081"), "# This is a comment" },
                    { new Guid("c6c67a58-dd8a-4fd7-85da-9f4efd67d7cf"), new Guid("56891f72-811b-467b-a88e-d3f9be4b7081"), "/* This is a comment" },
                    { new Guid("d58f8fd9-0d2f-44ce-a0f1-c302e0a1fb77"), new Guid("fb5f6c2d-8dd5-4281-91ce-f548ded2228e"), "string" },
                    { new Guid("d616ac6b-1aa3-4681-9c15-6e9ae87fc867"), new Guid("4fbd2b0c-9c48-4da7-b5dc-5dbce6b1d7b2"), "<italic>" },
                    { new Guid("dfc1af88-6627-43ac-9ca3-9a62078a6b73"), new Guid("a4ba9808-9beb-4152-9504-d0d1618a7307"), "<head>" },
                    { new Guid("e79a571d-4387-4c01-9acd-3adaf7a9ab8e"), new Guid("1fc869a5-d338-4fcb-96ba-1db79cc0814c"), "<br>" },
                    { new Guid("e825085f-09d1-45f5-8b65-b1b64da29a88"), new Guid("cbbce265-2cbf-467f-a838-eddf6bcedd9f"), "Google" },
                    { new Guid("e836d58c-44be-4943-b526-8ed6e1d0449b"), new Guid("cbbce265-2cbf-467f-a838-eddf6bcedd9f"), "Mozilla" },
                    { new Guid("ec646784-d6bd-4c27-9001-c84cb56f7a20"), new Guid("1fc869a5-d338-4fcb-96ba-1db79cc0814c"), "<break>" },
                    { new Guid("ef9a7cca-2a36-4029-a8d8-fbbe3f48a2f3"), new Guid("749ac7fa-4687-4c0c-a2e4-974cba61a0e8"), "The + sign" },
                    { new Guid("fe72f62d-a9f6-4251-b204-10d4243c414b"), new Guid("1fc869a5-d338-4fcb-96ba-1db79cc0814c"), "<lb>" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Choices_QuestionId",
                table: "Choices",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuizId",
                table: "Questions",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRolesList_RoleId",
                table: "UserRolesList",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Choices");

            migrationBuilder.DropTable(
                name: "UserRolesList");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Quizzes");
        }
    }
}
