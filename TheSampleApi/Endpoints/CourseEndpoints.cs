using TheSampleApi.Data;
using TheSampleApi.Models;

namespace TheSampleApi.Endpoints;

public static class CourseEndpoints
{
    public static void MapCourseEndpoints(this WebApplication app)
    {
        app.MapGet("/courses", LoadAllCoursesAsync);
        app.MapGet("/courses/{id}", LoadCourseByIdAsync);
    }

    private static async Task<IResult> LoadAllCoursesAsync(CourseData courseData,
        string? courseType, string? search, int? delayInMs)
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

        if (delayInMs is not null)
        {
            // max delay of 5 minutes
            if (delayInMs > 300000)
            {
                delayInMs = 300000;
            }

            await Task.Delay(delayInMs.Value);
        }

        return Results.Ok(output);
    }

    private static async Task<IResult> LoadCourseByIdAsync(CourseData courseData, int id, int? delayInMs)
    {
        CourseModel? output = courseData.Courses.SingleOrDefault(x => x.Id == id);

        if (delayInMs is not null)
        {
            // max delay of 5 minutes
            if (delayInMs > 300000)
            {
                delayInMs = 300000;
            }

            await Task.Delay(delayInMs.Value);
        }

        if (output is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(output);
    }
}
