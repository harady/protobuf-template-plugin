debug:
	go install
	protoc -I./_example/proto --csharp_out=./_example/csharp/data/generated ./_example/proto/data/*.proto
	protoc -I./_example/proto --csharp-template_out=template=./template/csharp-data-partial.gotemplate,fileSuffix=.cs:./_example/csharp/data ./_example/proto/data/*.proto
	protoc -I./_example/proto --csharp-template_out=template=./template/csharp-data-partial.gotemplate,fileSuffix=ServiceData.cs:./_example/csharp/service ./_example/proto/service/*.proto
	protoc -I./_example/proto --csharp-template_out=template=./template/csharp-service.gotemplate,fileSuffix=ServiceGenerated.cs:./_example/csharp/service/generated ./_example/proto/service/*.proto
	protoc -I./_example/proto --csharp-template_out=template=./template/csharp-service-partial.gotemplate,fileSuffix=Service.cs:./_example/csharp/service ./_example/proto/service/*.proto
