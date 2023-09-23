using System.Reflection;

namespace TravelManagement.Domain.Common;
public abstract class SmartEnumerator
{
    public int Id { get; }
    public string Name { get; set; }
    protected SmartEnumerator(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public static IEnumerable<T> AsEnumerable<T>() where T : SmartEnumerator
    {
        var bindingFlags = BindingFlags.Public
                         | BindingFlags.Static
                         | BindingFlags.DeclaredOnly;

        return typeof(T).GetProperties(bindingFlags)
                        .Select(f => f.GetValue(null))
                        .Cast<T>();
    }

    public static List<T> ToList<T>() where T : SmartEnumerator
    {
        return AsEnumerable<T>().ToList();
    }

    public static T Get<T>(int id) where T : SmartEnumerator
    {
        return AsEnumerable<T>().SingleOrDefault(e => e.Id == id);
    }

    public static T Get<T>(string name) where T : SmartEnumerator
    {
        return AsEnumerable<T>().SingleOrDefault(e => e.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
    }

    public override string ToString()
    {
        return Name;
    }
}
