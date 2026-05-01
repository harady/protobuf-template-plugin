# Example: C#

Generates C# POCO classes and enums from `.proto`.

## Output

Given [`proto/user.proto`](proto/user.proto), running `codegen.rb` produces:

- `output/User.cs` — C# classes with auto-properties + enum

## Run

```bash
ruby ../../proto/codegen.rb codegen.yml
```
