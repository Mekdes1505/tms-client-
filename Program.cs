// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using System.Diagnostics;
String ? region = null ; 
String? upperRegion = region ? .ToUpper();
Console.WriteLine($"Region(conditional): {upperRegion}");
String displayRegion = region ?? "Unassigned";
Console.WriteLine($"Region (coalesced): {displayRegion}");
region ??= "Addis Ababa";
Console.WriteLine($"Region (assigned): {region}");
String studentName = "Abebe";
String studentId = "STU-001";
int enrollmentCount =  3;
decimal grantAmount = 1999.99m;
DateTime enrolledAt = DateTime.UtcNow; 
String ? campusRegion = null ;
Console.WriteLine($"Student:{studentName} ({studentId})");
Console.WriteLine($"Courses: {enrollmentCount}");
Console.WriteLine($"Grant:{grantAmount:F2}"); 
Console.WriteLine($"Enrolled: {enrolledAt:yyyy-MM-dd}");
Console.WriteLine($"Campus: {campusRegion ?? "Not assigned"}");
decimal grantPerStudent = 1999.99m;
decimal totalAllocation = grantPerStudent * 100_000 ;
Console.WriteLine($"Total Allocated (decimal):{totalAllocation}");
Console.WriteLine($"Total Allocated (formatted):{totalAllocation:F2}");



  
var enrollment = new EnrollmentRecord("STU-001", "CS-401", DateTime.UtcNow);
Console.WriteLine(enrollment);
var corrected = enrollment with { CourseCode = "CS-402" };
Console.WriteLine(corrected);
var duplicate = new EnrollmentRecord("STU-001", "CS-401", enrollment.EnrolledAt);
Console.WriteLine($"Same data? {enrollment == duplicate}");


/*
List <Student> students = [
 new Student{Id = "S1",Name = "Abebe", Age = 22 , GPA = 3.8m},
  new Student{Id = "S2",Name = "kidaane", Age = 24, GPA = 3.0m},
   new Student{Id = "S3",Name = "sara", Age = 26, GPA = 3.3m},
    new Student{Id = "S4",Name = "Dawit", Age = 21 , GPA = 2.5m},
];
   var leaderboard = students.Where(x=>x.GPA>=3.5m);
foreach(var entry in leaderboard)
Console.WriteLine($"{entry.Name}:{entry.GPA}"); 


var course = new Course{ Code = "CS-401", Title = "Advanced C#", Capacity = 30 };
Console.WriteLine($"Course: {course.Title} (Capacity: {course.Capacity})");
// Invalid capacity — should throw
// Invalid capacity - should throw
try
{
    course.Capacity = -5;
} // <-- You were missing this closing brace!
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Caught: {ex.Message}");
}


try
{
    course.Title = " ";
} 
catch (ArgumentException ex)
{
    Console.WriteLine($"Caught: {ex.Message}");

}
{
var s = new Student { Id = "S1", Name = "Abeba", Age = 20, GPA = 3.8m };
Console.WriteLine($"Student: {s.Name}, GPA: {s.GPA}");}



void PrintGradeReport(IEnumerable<IGradable> assessments)
{
    Console.WriteLine("--- Grade Report ---");
    foreach (var item in assessments)
    {
        Console.WriteLine($"{item.Title}: {item.CalculateGrade():F2}%");
    }
}


IGradable[] cohortAssessments = [
    new Quiz { Title = "C# Basics", CorrectAnswers = 18, TotalQuestions = 20 },
    new LabAssignment { Title = "Registration API", FunctionalityScore = 90m, CodeQualityScore = 85m }
];


PrintGradeReport(cohortAssessments);*/

var sw = Stopwatch.StartNew();
for(int i = 0;i<5;i++)
{
    Thread.Sleep(3000);
}
Console.WriteLine($"Blocking Sequential:{sw.ElapsedMilliseconds}ms");
sw.Restart();
var tasks = Enumerable.Range(0, 5).Select(_ => Task.Delay(300));
await Task.WhenAll(tasks);
Console.WriteLine($"Async parallel: {sw.ElapsedMilliseconds}ms");



async Task<Stud> FetchStudentAsync(string id)
{
Console.WriteLine($" Fetching {id}...");
await Task.Delay(300); // Simulate database latency
return new Stud 
{
Id = id,
Namee=$"Stud-{id}",
Age = 20,
GPA = id switch
{
"S1" => 3.8m,
"S2" => 2.4m,
"S3" => 3.5m,
"S4" => 1.9m,
"S5" => 3.2m,
_ =>2.5m
}
};}

async Task<Course> FetchCourseAsync(string code)
{
Console.WriteLine($" Fetching course {code}...");
await Task.Delay(200); // Simulate database latency
return new Course
{
    Code = code,
Title = $"Course-{code}",
Capacity = code switch
{
"CRS-101" => 2,
"CRS-201" => 30,
"CRS-301" => 15,
_ =>25
}
};
}

sw.Restart();
// Start all fetches simultaneously students AND courses
string[] studentIds = ["S1", "S2", "S3", "S4", "S5"];
string[] courseCodes = ["CRS-101", "CRS-201", "CRS-301"];
var studentTasks = studentIds.Select(id => FetchStudentAsync(id));
var courseTasks = courseCodes.Select(code => FetchCourseAsync(code));
// Both arrays load concurrently
Stud[] student = await Task.WhenAll(studentTasks);
Course[] courses = await Task.WhenAll(courseTasks);
Console.WriteLine($"\nLoaded {student.Length} students and {courses.Length} courses in {sw.ElapsedMilliseconds}ms");
foreach (var s in student)
{
Console.WriteLine($" {s.Namee} GPA: {s.GPA}");
}