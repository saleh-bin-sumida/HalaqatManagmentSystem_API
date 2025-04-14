
namespace HalaqatSchoolSystem.Shared.Attributes;


[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
sealed class SurahInfoAttribute : Attribute
{
    public string Name { get; }
    public int TotalVerses { get; }

    public SurahInfoAttribute(string name, int totalVerses)
    {
        Name = name;
        TotalVerses = totalVerses;
    }
}
