using Scriban.Runtime;

namespace protoc_gen_myplugincsharp
{
	public class CustomScriptObject : ScriptObject
	{
		public static string ToCamel(string text)
		{
			return text.ToCamelCase();
		}

		public static string ToPascalCase(string text)
		{
			return text.ToPascalCase();
		}

		public static string ToSnakeCase(string text)
		{
			return text.ToSnakeCase();
		}

		public static string ToLowerSnakeCase(string text)
		{
			return text.ToSnakeCase().ToLower();
		}

		public static string ToUpperSnakeCase(string text)
		{
			return text.ToSnakeCase().ToUpper();
		}
	}
}