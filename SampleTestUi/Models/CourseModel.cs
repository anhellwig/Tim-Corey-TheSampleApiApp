namespace SampleTestUi.Models;

public class CourseModel
{
    public int Id { get; set; }

    public bool IsPreorder { get; set; }

    public required string CourseUrl { get; set; }

    public required string CourseType { get; set; }

    public required string CourseName { get; set; }

    public int CourseLessonCount { get; set; }

    public decimal CourseLengthInHours { get; set; }

    public required string ShortDescription { get; set; }

    public required string CourseImage { get; set; }

    public int PriceInUSD { get; set; }

    public required string CoursePreviewLink { get; set; }
}
