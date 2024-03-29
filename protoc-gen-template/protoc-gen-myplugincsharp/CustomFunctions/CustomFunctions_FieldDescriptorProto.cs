﻿using System;
using Google.Protobuf.Reflection;
using Scriban.Runtime;

public class CustomFunctions_FieldDescriptorProto
{
	/// <summary>
	/// このフィールドのC#における型を取得する.
	/// </summary>
	public static string ToCsType(FieldDescriptorProto param)
	{
		return param.HasTypeName
			? CustomFunctions_String.ToShortName(param.TypeName)
			: param.Type.ToCsTypeName();
	}

	/// <summary>
	/// このフィールドにRepeatedラベルが付いているか否かを取得する.
	/// </summary>
	public static bool IsRepeated(FieldDescriptorProto param)
	{
		return param.Label == FieldDescriptorProto.Types.Label.Repeated;
	}

	/// <summary>
	/// このフィールドのRubyにおける型を取得する.
	/// </summary>
	public static string ToRbType(FieldDescriptorProto param)
	{
		return param.HasTypeName
			? CustomFunctions_String.ToShortName(param.TypeName)
			: param.Type.ToRbTypeName();
	}

	/// <summary>
	/// このフィールドのRubyにおける型のデフォルト値を取得する.
	/// </summary>
	public static string ToRbTypeDefault(FieldDescriptorProto param)
	{
		return param.HasTypeName
			? $"{CustomFunctions_String.ToShortName(param.TypeName)}.new"
			: param.Type.ToRbTypeDefaultValue();
	}

	public static void SetupCustomFunction(ScriptObject target)
	{
		target.Import("to_cs_type",
			new Func<FieldDescriptorProto, string>(type => ToCsType(type)));

		target.Import("is_repeated",
			new Func<FieldDescriptorProto, bool>(type => IsRepeated(type)));

		target.Import("to_rb_type",
			new Func<FieldDescriptorProto, string>(type => ToRbType(type)));
		target.Import("to_rb_type_default",
			new Func<FieldDescriptorProto, string>(type => ToRbTypeDefault(type)));

	}
}
