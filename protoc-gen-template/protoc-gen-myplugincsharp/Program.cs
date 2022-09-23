﻿using Google.Protobuf;
using Google.Protobuf.Compiler;
using Scriban;
using Scriban.Runtime;
using System.Text;

namespace protoc_gen_myplugincsharp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			CodeGeneratorRequest request;
			using (var stdin = Console.OpenStandardInput()) {
				request = Deserialize<CodeGeneratorRequest>(stdin);
			}

			var paramDict = ParseParameter(request.Parameter);
			var templatePath = (string)paramDict["template"];

			var templateStr = File.ReadAllText(templatePath, Encoding.UTF8);
			var template = Template.Parse(templateStr);

			var response = new CodeGeneratorResponse();
			var fileToGenerates = request.FileToGenerate.ToHashSet();

			var outputFileDescs = request.ProtoFile
				.Where(file => fileToGenerates.Contains(file.Name));

			foreach (var fileDesc in outputFileDescs) {
				var filename
					= Path.GetFileNameWithoutExtension(fileDesc.Name)
						.ToPascalCase();
				filename += paramDict["fileSuffix"];

				var model = new { File = fileDesc };
				var scriptObject = new ScriptObject();
				CustomFunctions.SetupCustomFunction(scriptObject);
				scriptObject.Import(model);

				var context = new TemplateContext();
				context.PushGlobal(scriptObject);
				var output = template.Render(context);

				if (output.Trim().Length == 0) { continue; }

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