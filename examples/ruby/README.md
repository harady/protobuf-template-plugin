# Example: Ruby

Generates Ruby classes with `attr_accessor` and keyword-argument initializers from `.proto`.

## Output

Given [`proto/user.proto`](proto/user.proto), running `codegen.rb` produces:

- `output/user.rb` — Ruby classes + module-based enums

## Run

```bash
ruby ../../proto/codegen.rb codegen.yml
```
