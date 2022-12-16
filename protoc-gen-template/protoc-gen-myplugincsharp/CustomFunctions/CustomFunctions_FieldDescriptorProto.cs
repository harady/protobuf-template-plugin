using System;
using Google.Protobuf.Reflection;
using Scriban.Runtime;

public class CustomFunctions_FieldDescriptorProto
{
	public static string ToCsType(FieldDescriptorProto param)
	{
		return param.HasTypeName
			? CustomFunctions_String.ToShortName(param.TypeName)
			: param.Type.ToCsTypeName();
	}

	public static string ToCsType(FieldDescriptorProto param)
	{
		return param.HasTypeName
			? CustomFunctions_String.ToShortName(param.TypeName)
			: param.Type.ToCsTypeName();
	}

	public static string ToCsType(FieldDescriptorProto param)
	{
		return param.HasTypeName
			? CustomFunctions_String.ToShortName(param.TypeName)
			: param.Type.ToCsTypeName();
	}

	public static bool IsRepeated(FieldDescriptorProto param)
	{
		return param.Label == FieldDescriptorProto.Types.Label.Repeated;
	}

	public static void SetupCustomFunction(ScriptObject target)
	{
		target.Import("to_cs_type",
			new Func<FieldDescriptorProto, string>(type => ToCsType(type)));
		target.Import("is_repeated",
			new Func<FieldDescriptorProto, bool>(type => IsRepeated(type)));
	}
}
