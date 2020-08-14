# twitter.sendmessage 

## Syntax

```G1ANT
twitter.sendmessage createnamevalue ⟦text⟧ postvalue ⟦text⟧
```

## Description

This command allows the user to send messages to friends on Twitter. Ensure that the user is first logged into twitter and then execute the posting process. 

| Argument         | Type       | Required   | Default Value                                               | Description                                                 |
| ---------------- | ---------- | ---------- | ----------------------------------------------------------- | ----------------------------- |
| `Type`          | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)     | no        |   chrome                                                          | Name of browser|
| `email`          | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)     | yes        |                                                             | Mention your email ID|
| `pword`          | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)     | yes        |                                                            | Mention your password|
| `createnamevalue`          | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)     | yes        |                                                            | Enter name of the person to send the message|
| `postvalue`          | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)     | yes        |                                                            | Mention the message to be sent|
|  `result`  | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)  |no   | ♥result   |Name of a variable where the command's result will be stored |
| `if`  | [bool](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/BooleanStructure.md) | no       | true                                                        | Executes the command only if a specified condition is true   |
| `timeout` | [timespan](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TimeSpanStructure.md) | no       | [♥timeoutcommand](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Addon.Core/Variables/TimeoutCommandVariable.md) | Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
| `errorcall`| [procedure](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/ProcedureStructure.md) | no       |                                                             | Name of a procedure to call when the command throws an exception or when a given `timeout` expires |
| `errorjump`| [label](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/LabelStructure.md) | no       |                                                             | Name of the label to jump to when the command throws an exception or when a given `timeout` expires |
| `errormessage` | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no       |                                                             | A message that will be shown in case the command throws an exception or when a given `timeout` expires, and no `errorjump` argument is specified |
| `errorresult`  | [variable](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/VariableStructure.md) | no       |                                                             | Name of a variable that will store the returned exception. The variable will be of [error](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/ErrorStructure.md) structure  |

For more information about `if`, `timeout`, `errorcall`, `errorjump`, `errormessage` and `errorresult` arguments, see [Common Arguments](https://manual.g1ant.com/link/G1ANT.Manual/appendices/common-arguments.md) page.

# Sequence of Operation
1. The Robot opens the twitter web browser and waits for the user to provide credentials for logging in.
2. Once the authentication is successfully approved, the robot then guides the user to the chat section where messages can be sent to the person who uses twitter exchanging a common piece of information. 
## Example

This simple script demonstrates how messages can be sent on twitter with the help of G1ANT studio.
```G1ANT
dialog ‴Twitter Features with G1ANT Studio‴
twitter.open
delay 5
twitter.login email ‴hi@gmail.com‴ pword ‴tbmf124‴
delay 5
twitter.sendmessage createnamevalue ‴Harsh‴ postvalue ‴Hi Harsh! Welcome to Twitter‴
delay 2
```
