public record EnrollmentRecord(String studentId, String CourseCode, DateTime EnrolledAt);
public class Enrollment
{
  public String studentId {get;set;} = String.Empty;
  public String CourseCode{get;set;} = String.Empty;
  public  DateTime ProcessedAt{get;set;}  }
public class Course
{
public required string Code { get; init; }
public required string Title
{
get;
set => field = !string.IsNullOrWhiteSpace(value)
? value
: throw new ArgumentException("Title cannot be empty or whitespace.", nameof(value));}
public int Capacity
{
get;
set => field = value > 0
? value
: throw new ArgumentOutOfRangeException(nameof(value), "System constraint: Capacity must begreater than zero.");
}
public int EnrolledCount { get; set; }
}

public class Stud
{
    public string Id{get;set;}
   public int Age{get;set;}
   public string Namee{get;set;}
   public decimal GPA{get;set;}

}

/*
public class Student
{
    
public required String   Id { get; init; }
public required String Name
{
get;
set => field = !string.IsNullOrWhiteSpace(value)
? value
: throw new ArgumentException("Name cannot be empty or whitespace.", nameof(value));
}
public int Age
{
get;
set => field = value is >= 16 and <= 100
? value
: throw new ArgumentOutOfRangeException(nameof(value), "Age must be between 16 and 100.");
}
public decimal GPA
{
get;
set => field = value is >= 0.0m and <= 4.0m
? value
: throw new ArgumentOutOfRangeException(nameof(value), "GPA must be between 0.0 and 4.0.");
}
}

*/

public interface IGradable
{
    string Title { get; }
    decimal CalculateGrade();
}

// STEP 2: Now implement it on your classes
public class Quiz : IGradable
{
    public required string Title { get; init; }
    public required int CorrectAnswers { get; init; }
    public required int TotalQuestions { get; init; }
    
    public decimal CalculateGrade()
    {
        if (TotalQuestions == 0) return 0m;
        return (decimal)CorrectAnswers / TotalQuestions * 100m;
    }
}

public class LabAssignment : IGradable
{
    public required string Title { get; init; }
    public required decimal FunctionalityScore { get; init; }
    public required decimal CodeQualityScore { get; init; }
    
    public decimal CalculateGrade()
    {
        // 70% functionality, 30% code quality
        return (FunctionalityScore * 0.7m) + (CodeQualityScore * 0.3m);
    }
}