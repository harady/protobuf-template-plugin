#!/bin/sh

rm -rf output

# サーバー側
ruby codegen.rb -i codegen_server_cs.yml

# Unity側
ruby codegen.rb -i codegen_unity_cs.yml

# マスターデータ側
sh protoc_sheet.sh
