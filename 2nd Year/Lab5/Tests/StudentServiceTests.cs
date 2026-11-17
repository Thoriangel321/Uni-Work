using System;
using System.Collections.Generic;
using Lab5.BLL.Interfaces;
using Lab5.BLL.Models;
using Lab5.BLL.Services;
using Moq;
using Xunit;

namespace Lab5.Tests
{
    public class StudentServiceTests
    {
        private Student CreateValidStudent(double height = 180, double weight = 70)
        {
            return new Student
            {
                LastName = "Kovalenko",
                FirstName = "Ivan",
                Height = height,
                Weight = weight,
                StudentCard = "КВ101",
                Passport = "АА123456"
            };
        }

        [Fact]
        public void Constructor_NullRepository_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new StudentService(null));
        }

        [Fact]
        public void ValidateStudent_NullStudent_ThrowsArgumentNullException()
        {
            var mockRepo = new Mock<IStudentRepository>();
            var service = new StudentService(mockRepo.Object);

            Assert.Throws<ArgumentNullException>(() => service.ValidateStudent(null));
        }

        [Fact]
        public void ValidateStudent_EmptyName_ThrowsArgumentException()
        {
            var mockRepo = new Mock<IStudentRepository>();
            var service = new StudentService(mockRepo.Object);
            var student = CreateValidStudent();
            student.FirstName = "";

            Assert.Throws<ArgumentException>(() => service.ValidateStudent(student));
        }

        [Fact]
        public void ValidateStudent_InvalidHeightOrWeight_ThrowsArgumentException()
        {
            var mockRepo = new Mock<IStudentRepository>();
            var service = new StudentService(mockRepo.Object);
            var student = CreateValidStudent(100, 50);

            Assert.Throws<ArgumentException>(() => service.ValidateStudent(student));
        }

        [Fact]
        public void ValidateStudent_EmptyDocuments_ThrowsArgumentException()
        {
            var mockRepo = new Mock<IStudentRepository>();
            var service = new StudentService(mockRepo.Object);
            var student = CreateValidStudent();
            student.Passport = "";

            Assert.Throws<ArgumentException>(() => service.ValidateStudent(student));
        }

        [Fact]
        public void SaveStudents_ValidList_CallsRepositorySaveAll()
        {
            var mockRepo = new Mock<IStudentRepository>();
            var service = new StudentService(mockRepo.Object);
            var students = new List<Student> { CreateValidStudent() };

            service.SaveStudents(students);

            mockRepo.Verify(r => r.SaveAll(It.IsAny<IEnumerable<Student>>()), Times.Once);
        }

        [Fact]
        public void CountIdealWeightStudents_ReturnsExpectedCount()
        {
            var mockRepo = new Mock<IStudentRepository>();
            mockRepo.Setup(r => r.GetAll()).Returns(new List<Student>
            {
                CreateValidStudent(180, 70),
                CreateValidStudent(165, 50),
                CreateValidStudent(170, 60)
            });
            var service = new StudentService(mockRepo.Object);

            int count = service.CountIdealWeightStudents();

            Assert.Equal(2, count);
        }

        [Fact]
        public void GainWeight_WhenIdealReached_InvokesEvent()
        {
            var mockRepo = new Mock<IStudentRepository>();
            var service = new StudentService(mockRepo.Object);
            var student = CreateValidStudent(175, 60);
            bool notified = false;
            service.IdealWeightReached += s => notified = true;

            service.GainWeight(student, 5);

            Assert.True(notified);
            Assert.Equal(65, student.Weight);
        }

        [Fact]
        public void GainWeight_InvalidAmount_ThrowsArgumentException()
        {
            var mockRepo = new Mock<IStudentRepository>();
            var service = new StudentService(mockRepo.Object);
            var student = CreateValidStudent();

            Assert.Throws<ArgumentException>(() => service.GainWeight(student, -2));
        }

        [Fact]
        public void LoseWeight_WhenIdealReached_InvokesEvent()
        {
            var mockRepo = new Mock<IStudentRepository>();
            var service = new StudentService(mockRepo.Object);
            var student = CreateValidStudent(175, 70);
            bool notified = false;
            service.IdealWeightReached += s => notified = true;

            service.LoseWeight(student, 5);

            Assert.True(notified);
            Assert.Equal(65, student.Weight);
        }

        [Fact]
        public void LoseWeight_InvalidAmount_ThrowsArgumentException()
        {
            var mockRepo = new Mock<IStudentRepository>();
            var service = new StudentService(mockRepo.Object);
            var student = CreateValidStudent(175, 60);

            Assert.Throws<ArgumentException>(() => service.LoseWeight(student, 65));
        }

        [Fact]
        public void Student_RideBicycle_ReturnsExpectedString()
        {
            var student = CreateValidStudent();

            string result = student.RideBicycle();

            Assert.Equal("Ivan Kovalenko rides a bicycle", result);
        }
    }
}