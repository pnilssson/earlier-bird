namespace EarlierBird.Domain.Entities;

public sealed class Package
{
    public string Id { get; private set; }
    public int Weight { get; private set; }
    public int Length { get; private set; }
    public int Height { get; private set; }
    public int Width { get; private set; }
    public bool IsValid { get; private set; }

    public Package(int weight, int length, int height, int width)
    {
        Id = GetId();
        Weight = weight;
        Length = length;
        Height = height;
        Width = width;
        IsValid = IsPackageValid();
    }

    private string GetId()
    {
        var random = new Random();
        string id = "999";
        for (int i = 0; i < 15; i++)
        {
            id = string.Concat(id, random.Next(9).ToString());
        }
        return id;
    }

    private bool IsPackageValid()
    {
        return Weight <= 20000 && Length <= 60 && Height <= 60 && Width <= 60;
    }
}