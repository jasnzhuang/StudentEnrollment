﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentEnrollment.Models;
using StudentEnrollment.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment.Proxy.Tests
{
    [TestClass()]
    public class APIProxyTests
    {
        APIProxy proxy;
        public APIProxyTests()
        {
            this.proxy = new APIProxy();
}

        [TestMethod]
        [TestCategory("APIProxy")]
        public void APIProxyTest()
        {
            Assert.IsNotNull(this.proxy);
        }

        [TestMethod]
        [TestCategory("APIProxy")]
        public void APIProxyLoginTest()
        {
           
            //User user = this.proxy.login("
        }

        [TestMethod]
        [TestCategory("APIProxy")]
        public void getAdminAPITest()
        {
            Admin admin = this.proxy.getAdmin(1);
            Assert.IsNotNull(admin);
            Assert.IsNotNull(admin.Email);
            Assert.IsNotNull(admin.ID);
            Assert.IsNotNull(admin.FirstName);
            Assert.IsNotNull(admin.LastName);
            Assert.AreEqual(admin.FirstName, "John");
            Assert.AreEqual(admin.LastName, "Doe");
        }

        [TestMethod]
        [TestCategory("APIProxy")]
        public void getCourseAPITest()
        {
            Course course = this.proxy.getCourse(1);
            Assert.IsNotNull(course);
            Assert.IsNotNull(course.Availability);
            Assert.IsNotNull(course.CourseCode);
            Assert.IsNotNull(course.ID);
            Assert.IsNotNull(course.Credits);
            Assert.IsNotNull(course.MinGPA);
            Assert.IsNotNull(course.Name);
        }

        [TestMethod]
        [TestCategory("APIProxy")]
        public void getCourseListAPITest()
        {
            Course[] courseList = this.proxy.getCourseList();
            Assert.IsNotNull(courseList);
            foreach (Course course in courseList)
            {
                Assert.IsNotNull(course);
                Assert.IsNotNull(course.Availability);
                Assert.IsNotNull(course.CourseCode);
                Assert.IsNotNull(course.ID);
                Assert.IsNotNull(course.Credits);
                Assert.IsNotNull(course.MinGPA);
                Assert.IsNotNull(course.Name);

            }
            Assert.AreEqual("SWEN-345", courseList[0].CourseCode);
        }

        [TestMethod]
        [TestCategory("APIProxy")]
        public void getSectionAPITest()
        {
            Section section = this.proxy.getSection(1);
            Assert.IsNotNull(section);
        }

        [TestMethod]
        [TestCategory("APIProxy")]
        public void getLocationAPITest()
        {
            Location loc = this.proxy.getLocation(1);
            Assert.IsNotNull(loc);
        }

        [TestMethod]
        [TestCategory("APIProxy")]
        public void getCurrentTermAPITest()
        {
            Term term = this.proxy.getCurrentTerm();
            Assert.IsNotNull(term);
        }

        [TestMethod]
        [TestCategory("APIProxy")]
        public void getTermAPITest()
        {
            Term term = this.proxy.getTerm("20161");
            Assert.IsNotNull(term);
        }

        [TestMethod]
        [TestCategory("APIProxy")]
        public void getTermsAPITest()
        {
            Term[] terms = this.proxy.getTerms();
            Assert.IsNotNull(terms);
        }

        [TestMethod]
        [TestCategory("APIProxy")]
        public void getStudentAPITest()
        {
            Student student = this.proxy.getStudent(1);
            Assert.IsNotNull(student);
        }

        [TestMethod]
        [TestCategory("APIProxy")]
        public void getInstructorAPITest()
        {
            Instructor instructor = this.proxy.getInstructor(1); //TODO: Make sure the getProfessorUser function in the API gets fixed
            Assert.IsNotNull(instructor);
            Assert.IsNotNull(instructor.ID);
            Assert.IsNotNull(instructor.FirstName);
            Assert.IsNotNull(instructor.LastName);
            Assert.IsNotNull(instructor.Email);
        }

        [TestMethod]
        [TestCategory("APIProxy")]
        public void getBookAPITest()
        {
            Book book = this.proxy.getBook(1);
            Assert.IsNotNull(book);
        }

        [TestMethod]
        [TestCategory("APIProxy")]
        public void getCourseSectionsAPITest()
        {
            Course course = proxy.getCourse(1);
            Section[] sections = this.proxy.getCourseSections(course);
            Assert.IsNotNull(sections);
        }

        [TestMethod]
        [TestCategory("APIProxy")]
        public void getStudentSectionsAPITest()
        {
            Student student = proxy.getStudent(1);
            Section[] sections = this.proxy.getStudentSections(student);
            Assert.IsNotNull(sections);
        }

        [TestMethod]
        [TestCategory("APIProxy")]
        public void getInstructorSectionsAPITest()
        {
            Instructor instructor = proxy.getInstructor(1);
            Section[] sections = this.proxy.getInstructorSections(instructor);
            Assert.IsNotNull(sections);
        }

        [TestMethod]
        [TestCategory("APIProxy")]
        public void getSectionStudentsAPITest()
        {
            Section section = proxy.getSection(1);
            Student[] students = proxy.getSectionStudents(section);
            Assert.IsNotNull(students);
        }

        [TestMethod]
        [TestCategory("APIProxy")]
        public void getCoursePrereqsAPITest()
        {
            Course course = proxy.getCourse(1);
            Course[] prereqs = this.proxy.getCoursePrereqs(course);
            Assert.IsNotNull(prereqs);
        }

        [TestMethod]
        [TestCategory("APIProxy")]
        public void getSectionBooksAPITest()
        {
            Section section = proxy.getSection(1);
            Book[] books = proxy.getSectionBooks(section);
            Assert.IsNotNull(books);
        }

        [TestMethod]
        [TestCategory("APIProxy")]
        public void createCourseAPITest()
        {
            Course course = new Course(11, "TEST", "Unit Test Course", 1, 1, false);
            int id = this.proxy.createCourse(course);
            Assert.IsNotNull(this.proxy.getCourse(id));
            this.proxy.deleteCourse(id);
            Assert.IsNull(this.proxy.getCourse(id));
        }

        [TestMethod]
        [TestCategory("APIProxy")]
        public void createSectionAPITest()
        {
            Assert.Fail();
            Section section = new Section(11, 1, 1, 1, 1, 1, false); // Properly check it was created to pass
            this.proxy.createSection(section);
        }

        [TestMethod]
        [TestCategory("APIProxy")]
        public void createStudentAPITest()
        {
            Student student = new Student(11, "username", "email", "firstName", "lastName", 1, 1.0f);
            this.proxy.createStudent(student, "testpassword");
        }

        [TestMethod]
        [TestCategory("APIProxy")]
        public void createTermAPITest()
        {
            Term term = new Term(11, "20203", new DateTime(2020, 1, 1), new DateTime(2020, 5, 1));
            this.proxy.createTerm(term);
        }

        [TestMethod]
        [TestCategory("APIProxy")]
        public void createBookAPITest()
        {
            Book book = new Book(100000, "Test Book", 555, "http://www.rd.com/wp-content/uploads/sites/2/2016/04/01-cat-wants-to-tell-you-laptop.jpg", 5051.000, true, 5);
            this.proxy.createBook(book, "Me", "MyselfAndI", "Addison");
        }

        
        [TestMethod]
        [TestCategory("APIProxy")]
        public void enrollStudentAPITest()
        {
            Student student = this.proxy.getStudent(4);
            Section section = this.proxy.getSection(1);

            this.proxy.enrollStudent(student, section);
            Section[] sections = this.proxy.getStudentSections(student);
            Assert.IsTrue(sections.Contains(section));
            //Console.Write(sections);
            //Assert.AreEqual(sections[1].ID, section.ID);
        }

        [TestMethod]
        [TestCategory("APIProxy")]
        public void toggleCourseAPITest()
        {
            Course course = this.proxy.getCourse(1);
            bool avail = course.Availability;
            this.proxy.toggleCourse(1);
            if (avail)
            {
               
                Assert.IsFalse(this.proxy.getCourse(1).Availability);
            }
            else
            {
                Assert.IsTrue(this.proxy.getCourse(1).Availability);
            }
            this.proxy.toggleCourse(1);
        }

        [TestMethod]
        [TestCategory("APIProxy")]
        public void toggleSectionAPITest()
        {

            Section section = this.proxy.getSection(1);
            bool avail = section.Availability;
            this.proxy.toggleSection(1);
            if (avail)
            {

                Assert.IsFalse(this.proxy.getSection(1).Availability);
            }
            else
            {
                Assert.IsTrue(this.proxy.getSection(1).Availability);
            }
            this.proxy.toggleSection(1);

        }

        [TestMethod]
        [TestCategory("APIProxy")]
        public void updateCourseAPITest()
        {
            Course course = this.proxy.getCourse(1);
            Assert.IsNotNull(course);
            String testCode = "TEST-1234";
            String testName = "Test Update";
            int testCredits = 666;
            int testGPA = 666;
            Course updateCourse = new Course(course.ID, testCode, testName, testCredits, testGPA, course.Availability);
            this.proxy.updateCourse(updateCourse);
            updateCourse = this.proxy.getCourse(1);
            Assert.AreEqual(updateCourse.ID, 1);
            Assert.AreEqual(updateCourse.CourseCode, testCode);
            Assert.AreEqual(updateCourse.Name, testName);
            Assert.AreEqual(updateCourse.Credits, testCredits);
            Assert.AreEqual(updateCourse.MinGPA, testGPA);
            this.proxy.updateCourse(course);
            updateCourse = this.proxy.getCourse(1);
            Assert.AreEqual(course, updateCourse);
        }

        [TestMethod]
        [TestCategory("APIProxy")]
        public void updateSectionAPITest()
        {
            Section section = this.proxy.getSection(1);
            Assert.IsNotNull(section);
            int testMaxStudents = 666;
            int testTermID = 666;
            int testInstructorID = 666;
            int testCourseID = 666;
            int testLocationID = 666;
            Section updateSection = new Section(section.ID, testMaxStudents, testTermID, testInstructorID, testCourseID, testLocationID, section.Availability);
            this.proxy.updateSection(updateSection);
            updateSection = this.proxy.getSection(1);
            Assert.AreEqual(updateSection.ID, 1);
            Assert.AreEqual(updateSection.MaxStudents, testMaxStudents);
            Assert.AreEqual(updateSection.TermID, testTermID);
            Assert.AreEqual(updateSection.InstructorID, testInstructorID);
            Assert.AreEqual(updateSection.CourseID, testCourseID);
            Assert.AreEqual(updateSection.LocationID, testLocationID);
            this.proxy.updateSection(section);
            updateSection = this.proxy.getSection(1);
            Assert.AreEqual(section, updateSection);
        }
        [TestMethod]
        [TestCategory("APIProxy")]
        public void getSectionWaitlistAPITest()
        {
            Section section = this.proxy.getSection(1);
            Student student = this.proxy.getStudent(1);
            Student[] students = this.proxy.getSectionWaitlist(section);
            Assert.IsNotNull(students);
            Assert.AreEqual(student.FirstName, students[0].FirstName);
        }


        [TestMethod]
        [TestCategory("APIProxy")]
        public void deleteCourseTest()
        {
            Course course = new Course(1, "TESTCOURSE", "TEST COURSE", 4, 4, true);
            int id = this.proxy.createCourse(course);
            Assert.AreNotEqual(id, -1);
            this.proxy.deleteCourse(id);
            Assert.IsNull(this.proxy.getCourse(id));
        }


        [Ignore]
        [TestMethod]
        [TestCategory("APIProxy")]
        public void waitlistStudentAPITest()
        {
            Student student = this.proxy.getStudent(1);
            Section section = this.proxy.getSection(1);

            this.proxy.waitlistStudent(student, section);

            Assert.IsTrue(this.proxy.getSectionWaitlist(section).Contains(student));
        }

        [Ignore]
        [TestMethod]
        [TestCategory("APIProxy")]
        public void withdrawStudentAPITest()
        {
            Assert.Fail();
        }
    }
}