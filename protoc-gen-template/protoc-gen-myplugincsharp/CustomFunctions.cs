using Scriban.Runtime;

public class CustomFunctions : ScriptObject
{
	public static string Hello()
	{
		return "Hello! Hello!";
	}


	public static string ToCamel(string text)
	{
		return text.ToCamelCase();
	}

	public static string ToPascal(string text)
	{
		return text.ToPascalCase();
	}

	public static string ToSnake(string text)
	{
		return text.ToSnakeCase();
	}

	public static string ToLowerSnake(string text)
	{
		return text.ToSnakeCase().ToLower();
	}

	public static string ToUpperSnake(string text)
	{
		return text.ToSnakeCase().ToUpper();
	}
}
