namespace Domain.Models;

public class Student
{
    public int StudentId {get; set;}
    public string Fullname {get; set;}=null!;
    public string? Email {get; set;}
    public string Phone {get; set;}=null!;
    public DateOnly EnrollmentDate {get; set;}
}
