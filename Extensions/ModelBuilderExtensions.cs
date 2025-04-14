using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HalaqatManagmentSystem_API.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void AddEnumCheckConstraint<TEnum>(this EntityTypeBuilder builder, string tableName, string columnName) where TEnum : Enum
        {
            var enumValues = Enum.GetValues(typeof(TEnum)).Cast<int>().ToList();
            var isLinear = enumValues.Zip(enumValues.Skip(1), (a, b) => b - a).All(diff => diff == 1);

            if (isLinear)
            {
                var minValue = enumValues.Min();
                var maxValue = enumValues.Max();

                builder.ToTable(tableName, t =>
                {
                    t.HasCheckConstraint($"CK_{tableName}_{columnName}", $"[{columnName}] >= {minValue} AND [{columnName}] <= {maxValue}");
                });
            }
        }
    }
}
