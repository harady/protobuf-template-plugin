using System;
using System.Collections.Generic;
using Scriban.Runtime;
using Google.Protobuf.Reflection;

public static class TypeExtensions
{
	public static string ToCsTypeName(
		this FieldDescriptorProto.Types.Type type)
	{

	}

	static Dictionary<FieldDescriptorProto.Types.Type, string> typeDict
		= new Dictionary<FieldDescriptorProto.Types.Type, string> {
			{ FieldDescriptorProto.Types.Type.Double, "double" },
			{ FieldDescriptorProto.Types.Type.Float, "double" },
			{ FieldDescriptorProto.Types.Type.Int64, "double" },
			{ FieldDescriptorProto.Types.Type.Int32, "double" },
			{ FieldDescriptorProto.Types.Type.Fixed64, "double" },
			{ FieldDescriptorProto.Types.Type.Fixed32, "double" },
			{ FieldDescriptorProto.Types.Type.Bool, "double" },
			{ FieldDescriptorProto.Types.Type.String, "double" },
			{ FieldDescriptorProto.Types.Type.Double, "double" },
			{ FieldDescriptorProto.Types.Type.Double, "double" },
			{ FieldDescriptorProto.Types.Type.Double, "double" },
			{ FieldDescriptorProto.Types.Type.Double, "double" },
			{ FieldDescriptorProto.Types.Type.Double, "double" },
			{ FieldDescriptorProto.Types.Type.Double, "double" }
		};

}
