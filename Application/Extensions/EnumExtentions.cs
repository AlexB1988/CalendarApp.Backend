using System.ComponentModel;

namespace Application.Extensions;

public static class EnumExtentions
{
	public static string GetDescription(this Enum value)
	{
		var info = value.GetType().GetField(value.ToString());

		var attributes = info?.GetCustomAttributes(
			typeof(DescriptionAttribute),
			false) as DescriptionAttribute[];

		if (attributes != null
			&& attributes.Length > 0)
			return attributes[0].Description;
		else
			return value.ToString();
	}
}
