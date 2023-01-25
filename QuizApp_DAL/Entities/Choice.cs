namespace QuizApp_DAL.Entities
{
    public  class Choice : Entity
    {
        public string? Text { get; set; }
        public Guid QuestionId { get; set; }
        public Question? Question { get; set; }
    }
}
