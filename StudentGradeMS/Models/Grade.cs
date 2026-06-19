using System;

namespace StudentGradeMS.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public decimal Score { get; set; }
        public DateTime ExamDate { get; set; }
        public string Remarks { get; set; }
        public string StudentName { get; set; }
        public string StudentNo { get; set; }
        public string CourseName { get; set; }
        public string ClassName { get; set; }
    }
}
