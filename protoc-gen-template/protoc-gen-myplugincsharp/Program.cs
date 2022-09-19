using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Google.Protobuf;
using Google.Protobuf.Compiler;
using Scriban;

namespace protoc_gen_myplugincsharp
{
	// assume current directory is the output directory, and it contains protoc.exe.
	// protoc.exe --plugin=protoc-gen-myplugincsharp.exe --myplugincsharp_out=./ --proto_path=%userprofile%\.nuget\packages\google.protobuf.tools\3.21.1\tools --proto_path=./ chat.proto

	internal class Program
	{
		static void Main(string[] args)
		{
			// you can attach debugger
			// System.Diagnostics.Debugger.Launch();

			// get request from standard input
			CodeGeneratorRequest request;
			using (var stdin = Console.OpenStandardInput()) {
				request = Deserialize<CodeGeneratorRequest>(stdin);
			}

			var paramDict = ParseParameter(request.Parameter);
			var templatePath = (string)paramDict["template"];

			var templateStr = File.ReadAllText(templatePath);
			var template = Template.Parse(templateStr);

			var response = new CodeGeneratorResponse();
			var fileToGenerates = request.FileToGenerate.ToHashSet();

			var outputFileDescs = request.ProtoFile
				.Where(file => fileToGenerates.Contains(file.Name));

			foreach (var fileDesc in outputFileDescs) {
				//var output = new StringBuilder();

				//// make service method list
				//foreach (var serviceType in fileDesc.Service) {
				//	output.AppendLine($"service {serviceType.Name}");

				//	foreach (var method in serviceType.Method) {
				//		output.AppendLine($"   {method.OutputType} {method.Name}({method.InputType})");
				//	}
				//}

				//// make message field list
				//foreach (var messageDesc in fileDesc.MessageType) {
				//	output.AppendLine($"message {messageDesc.Name}");

				//	foreach (var fieldDesc in messageDesc.Field) {
				//		output.AppendLine($"   {fieldDesc.TypeName} {fieldDesc.Name}");
				//	}

				//	foreach (var enumDesc in messageDesc.EnumType) {
				//		output.AppendLine($"   {enumDesc.Name}");
				//	}
				//}

				var filename
					= Path.GetFileNameWithoutExtension(fileDesc.Name)
						.ToPascalCase();
				filename += paramDict["fileSuffix"];

				var output = template.Render(new { File = fileDesc }); // => "Hello World!" 


				// set as response
				response.File.Add(
					new CodeGeneratorResponse.Types.File() {
						Name = filename,
						Content = output.ToString(),
					}
				);
			}

			// set result to standard output
			using (var stdout = Console.OpenStandardOutput()) {
				response.WriteTo(stdout);
			}
		}

		static Dictionary<string, object> ParseParameter(string parameter)
		{
			var result = new Dictionary<string, object>();

			var parameters = parameter.Split(',');
			foreach (var param in parameters) {
				var keyVal = param.Split('=');
				if (keyVal.Length != 2) { continue; }
				result[keyVal[0]] = keyVal[1];
			}

			return result;
		}


		static T Deserialize<T>(Stream stream) where T : IMessage<T>, new()
			=> new MessageParser<T>(() => new T()).ParseFrom(stream);
	}
}