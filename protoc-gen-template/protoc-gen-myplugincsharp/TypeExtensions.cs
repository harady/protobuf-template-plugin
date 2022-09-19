using System;
using System.Collections.Generic;
using Scriban.Runtime;
using Google.Protobuf.Reflection;

public static class TypeExtensions
{
	public static string ToCsTypeName(
		this FieldDescriptorProto.Types.Type type)
	{
		return typeDict.GetValueOrDefault(type, "");
	}

	static Dictionary<FieldDescriptorProto.Types.Type, string> typeDict
		= new Dictionary<FieldDescriptorProto.Types.Type, string> {
			{ FieldDescriptorProto.Types.Type.Double, "double" },
			{ FieldDescriptorProto.Types.Type.Float, "float" },
			{ FieldDescriptorProto.Types.Type.Int64, "long" },
			{ FieldDescriptorProto.Types.Type.Fixed64, "ulong" },
			{ FieldDescriptorProto.Types.Type.Int32, "int" },
			{ FieldDescriptorProto.Types.Type.Fixed32, "uint" },
			{ FieldDescriptorProto.Types.Type.Bool, "bool" },
			{ FieldDescriptorProto.Types.Type.String, "string" },
			{ FieldDescriptorProto.Types.Type.Group, "GROUP" },
			{ FieldDescriptorProto.Types.Type.Message, "MESSAGE" },
			{ FieldDescriptorProto.Types.Type.Bytes, "Google.Protobuf.ByteString" },
			{ FieldDescriptorProto.Types.Type.Uint32, "uint" },
			{ FieldDescriptorProto.Types.Type.Enum, "ENUM" },
			{ FieldDescriptorProto.Types.Type.Sfixed32, "int" },
			{ FieldDescriptorProto.Types.Type.Sfixed64, "long" },
			{ FieldDescriptorProto.Types.Type.Sint32, "int" },
			{ FieldDescriptorProto.Types.Type.Sint64, "long" },
		};

}
