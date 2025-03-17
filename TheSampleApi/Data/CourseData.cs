using System.Text.Json;
using TheSampleApi.Models;

namespace TheSampleApi.Data;

public class CourseData
{
    public CourseData()
    {
        JsonSerializerOptions jso = new() { PropertyNameCaseInsensitive = true };

        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "course-data.json");

        string json = File.ReadAllText(filePath);

        Courses = JsonSerializer.Deserialize<List<CourseModel>>(json, jso) ?? [];
    }

    public List<CourseModel> Courses { get; }
}
