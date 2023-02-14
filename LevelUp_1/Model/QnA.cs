namespace LevelUp_1.Model
{
    public class QnA
    {
        public int Id { get; set; }
        public int Domain_Id { get; set; }
        public string Question { get; set; } = string.Empty;
        public string Option1 { get; set; }= string.Empty;
        public string Option2 { get; set; }=string.Empty;
        public string Option3 { get; set; } = string.Empty;
        public string Option4 { get; set; } = string.Empty;
        public string CorrectAns { get; set; } = string.Empty;
    }
}
