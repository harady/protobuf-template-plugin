#!/bin/sh

rm -rf output/unity

# Unity側
ruby codegen.rb -i codegen_unity_cs2.yml

