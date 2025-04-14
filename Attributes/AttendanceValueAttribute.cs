namespace HalaqatManagmentSystem_API.Attributes;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class AttendanceValueAttribute(double value) : Attribute
{
    public double Value { get; } = value;

}
