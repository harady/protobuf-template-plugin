using System;
using Google.Protobuf.Reflection;
using Scriban.Runtime;

public class CustomFunctions
{
	public static void SetupCustomFunction(ScriptObject target)
	{
		CustomFunctions_String.SetupCustomFunction(target);
		CustomFunctions_DescriptorProto.SetupCustomFunction(target);
		CustomFunctions_FieldDescriptorProto.SetupCustomFunction(target);
	}
}
