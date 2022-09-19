package main

import (
	"io/ioutil"
	"log"
	"os"

	"github.com/golang/protobuf/proto"
	"./generator"
)

func main() {
	log.SetFlags(0)

	g := generator.New()

	data, err := ioutil.ReadAll(os.Stdin)
	if err != nil {
		log.Fatalf("[error] reading input: %v", err)
	}

	if err := proto.Unmarshal(data, g.Request); err != nil {
		log.Fatalf("[error]　parsing input proto： %v", err)
	}

	if len(g.Request.FileToGenerate) == 0 {
		log.Fatalf("no files to generate")
	}

	g.CommandLineParameters(g.Request.GetParameter())

	g.InitTemplate()

	g.GenerateAllFiles()

	// Send back the results.
	data, err = proto.Marshal(g.Response)
	if err != nil {
		log.Fatalf("[error] failed to marshal output proto: %v", err)
	}
	_, err = os.Stdout.Write(data)
	if err != nil {
		log.Fatalf("[error] failed to write output proto: %v", err)
	}
}
