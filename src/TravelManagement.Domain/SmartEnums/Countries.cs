using TravelManagement.Domain.Common;

namespace TravelManagement.Domain.SmartEnums;

public class Countries : SmartEnumerator
{
    public static Countries USA => new Countries(1, "United States Of America");
    public static Countries Argentina => new Countries(2, "Argentina");
    public static Countries Brazil => new Countries(3, "Brazil");
    public static Countries Colombia => new Countries(4, "Colombia");
    public static Countries Venezuela => new Countries(5, "Venezuela");

    private Countries(int id, string name) : base(id, name) { }
}