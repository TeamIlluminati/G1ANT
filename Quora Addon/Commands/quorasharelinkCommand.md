# quora.sharelink

## Syntax

```G1ANT
quora.addquestions sharevalue ⟦text⟧ postvalue ⟦text⟧
```

## Description

This command allows users to add questions on quora

| Argument        | Type | Required | Default Value | Description |
| --------        | ---- | -------- | ------------- | ----------- |
| `sharevalue`      | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) |yes   |                 |Post a message |
| `postvalue`      | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) |yes   |                 |Post the URL |
|  `result`  | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)  |no   | ♥result   |Name of a variable where the command's result will be stored |
| `if`  | [bool](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/BooleanStructure.md) | no       | true                                                        | Executes the command only if a specified condition is true   |
| `timeout` | [timespan](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TimeSpanStructure.md) | no       | [♥timeoutcommand](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Addon.Core/Variables/TimeoutCommandVariable.md) | Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
| `errorcall`| [procedure](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/ProcedureStructure.md) | no       |                                                             | Name of a procedure to call when the command throws an exception or when a given `timeout` expires |
| `errorjump`| [label](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/LabelStructure.md) | no       |                                                             | Name of the label to jump to when the command throws an exception or when a given `timeout` expires |
| `errormessage` | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no       |                                                             | A message that will be shown in case the command throws an exception or when a given `timeout` expires, and no `errorjump` argument is specified |
| `errorresult`  | [variable](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/VariableStructure.md) | no       |                                                             | Name of a variable that will store the returned exception. The variable will be of [error](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/ErrorStructure.md) structure  |

For more information about `if`, `timeout`, `errorcall`, `errorjump`, `errormessage` and `errorresult` arguments, see [Common Arguments](https://manual.g1ant.com/link/G1ANT.Manual/appendices/common-arguments.md) page.

# Sequence of Operation

The user is supposed to have a Quora account before starting the process.
1. The user is allowed to login Quora
2. With the username and password, he is prompted to sign in to the account.
3. After which in the post section column, the user can then share a link to other people with his message

## Example

This simple script opens Quora, allows the user to login and then post a message with links to help others in need. 

```G1ANT
dialog message ‴Testing out Quora‴
quora.open
delay 10
dialog message ‴Quora is open‴
quora.login email ‴test1@gmail.com‴ pword ‴Password‴ timeout 5
delay 10
quora.sharelink sharevalue ‴Here is the link to your question‴ postvalue ‴https://stackoverflow.com/questions/63376934/rabin-fingerprinting-tables‴
```
