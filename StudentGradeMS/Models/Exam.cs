namespace StudentGradeMS.Models
{
    public class Exam
    {
        public string StudentNo { get; set; }
        public string Sname { get; set; }
        public string Class { get; set; }
        public int Chinese { get; set; }
        public int Math { get; set; }
        public int English { get; set; }
        public int Computer { get; set; }
        public int Total { get { return Chinese + Math + English + Computer; } }
        public double Average { get { return Total / 4.0; } }
    }
}
