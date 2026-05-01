# Example: TypeScript

Generates TypeScript `interface` definitions and service interfaces from `.proto`.

## Output

Given [`proto/user.proto`](proto/user.proto), running `codegen.rb` produces:

- `output/user.ts` — TypeScript interfaces + enum const object
- `output/user_service.ts` — Service interface with typed request/response

## Run

```bash
ruby ../../proto/codegen.rb codegen.yml
```
