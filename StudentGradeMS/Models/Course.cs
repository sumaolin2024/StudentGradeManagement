namespace StudentGradeMS.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseNo { get; set; }
        public string CourseName { get; set; }
        public int Credit { get; set; }
        public string TeacherName { get; set; }
        public string Semester { get; set; }
    }
}
