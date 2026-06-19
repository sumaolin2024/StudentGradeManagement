-- ============================================
-- 学生成绩管理系统 - 数据库初始化脚本
-- ============================================

CREATE DATABASE StudentGradeDB;
GO

USE StudentGradeDB;
GO

-- 学生表
CREATE TABLE Students (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    StudentNo NVARCHAR(20) NOT NULL UNIQUE,
    Name NVARCHAR(50) NOT NULL,
    Gender NVARCHAR(4) DEFAULT N'男',
    Age INT DEFAULT 18,
    ClassName NVARCHAR(100),
    Phone NVARCHAR(20),
    Address NVARCHAR(200)
);
GO

-- 课程表
CREATE TABLE Courses (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CourseNo NVARCHAR(20) NOT NULL UNIQUE,
    CourseName NVARCHAR(100) NOT NULL,
    Credit INT DEFAULT 2,
    TeacherName NVARCHAR(50),
    Semester NVARCHAR(20)
);
GO

-- 成绩表
CREATE TABLE Grades (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    StudentId INT NOT NULL,
    CourseId INT NOT NULL,
    Score DECIMAL(5,2) NOT NULL,
    ExamDate DATETIME DEFAULT GETDATE(),
    Remarks NVARCHAR(200),
    CONSTRAINT FK_Grades_Students FOREIGN KEY (StudentId) REFERENCES Students(Id) ON DELETE CASCADE,
    CONSTRAINT FK_Grades_Courses FOREIGN KEY (CourseId) REFERENCES Courses(Id) ON DELETE CASCADE
);
GO

-- 插入示例数据
INSERT INTO Students (StudentNo, Name, Gender, Age, ClassName, Phone, Address) VALUES
(N'2024001', N'张三', N'男', 20, N'计算机科学2024级1班', N'13800138001', N'北京市海淀区'),
(N'2024002', N'李四', N'女', 19, N'计算机科学2024级1班', N'13800138002', N'北京市朝阳区'),
(N'2024003', N'王五', N'男', 21, N'软件工程2024级2班', N'13800138003', N'上海市浦东新区'),
(N'2024004', N'赵六', N'女', 20, N'软件工程2024级2班', N'13800138004', N'广州市天河区'),
(N'2024005', N'孙七', N'男', 22, N'信息管理2024级1班', N'13800138005', N'深圳市南山区');

INSERT INTO Courses (CourseNo, CourseName, Credit, TeacherName, Semester) VALUES
(N'CS101', N'数据结构与算法', 4, N'刘教授', N'2024-2025-1'),
(N'CS102', N'数据库原理', 3, N'陈教授', N'2024-2025-1'),
(N'CS103', N'操作系统', 4, N'周教授', N'2024-2025-1'),
(N'CS201', N'计算机网络', 3, N'吴教授', N'2024-2025-2'),
(N'CS202', N'软件工程', 3, N'郑教授', N'2024-2025-2');

INSERT INTO Grades (StudentId, CourseId, Score, ExamDate) VALUES
(1, 1, 92.5, '2025-01-15'),
(1, 2, 88.0, '2025-01-16'),
(1, 3, 76.5, '2025-01-17'),
(2, 1, 85.0, '2025-01-15'),
(2, 2, 91.0, '2025-01-16'),
(2, 3, 82.5, '2025-01-17'),
(3, 1, 78.0, '2025-01-15'),
(3, 2, 72.5, '2025-01-16'),
(4, 4, 95.0, '2025-06-20'),
(5, 5, 88.5, '2025-06-21');
GO
