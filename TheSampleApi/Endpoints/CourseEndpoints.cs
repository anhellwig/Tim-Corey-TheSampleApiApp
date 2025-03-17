using TheSampleApi.Data;
using TheSampleApi.Models;

namespace TheSampleApi.Endpoints;

public static class CourseEndpoints
{
    public static void MapCourseEndpoints(this WebApplication app)
    {
        app.MapGet("/courses", LoadAllCourses);
        app.MapGet("/courses/{id}", LoadCourseById);
    }

    private static IResult LoadAllCourses(CourseData courseData,
        string? courseType, string? search)
    {
        List<CourseModel> output = courseData.Courses;

        if (!string.IsNullOrWhiteSpace(courseType))
        {
            output.RemoveAll(x => !string.Equals(x.CourseType, courseType,
                StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(search))
        {
            output.RemoveAll(x =>
                !x.CourseName.Contains(search, StringComparison.OrdinalIgnoreCase) &&
                !x.ShortDescription.Contains(search, StringComparison.OrdinalIgnoreCase));
        }

        return Results.Ok(output);
    }

    private static IResult LoadCourseById(CourseData courseData, int id)
    {
        CourseModel? output = courseData.Courses.SingleOrDefault(x => x.Id == id);

        if (output is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(output);
    }
}
