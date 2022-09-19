﻿using System;
using Scriban.Runtime;

public class CustomFunctions : ScriptObject
{

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

	public static void SetupCustomFunction(ScriptObject target)
	{
		target.Import("to_camel",
			new Func<string, string>(text => ToCamel(text)));
		target.Import("to_pascal",
			new Func<string, string>(text => ToPascal(text)));
		target.Import("to_snake",
			new Func<string, string>(text => ToSnake(text)));
		target.Import("to_lower_snake",
			new Func<string, string>(text => ToLowerSnake(text)));
		target.Import("to_upper_snake",
			new Func<string, string>(text => ToUpperSnake(text)));

	}
}
