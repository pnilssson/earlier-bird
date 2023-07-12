namespace EarlierBird.Application.Models.Requests;

public class PackageCreateRequest
{
    public int Weight { get; set; }
    public int Length { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
}
