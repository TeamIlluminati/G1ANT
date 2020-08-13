# mediumandroid.search

## Syntax

```G1ANT
mediumandroid.search topic ⟦text⟧
```

## Description


This command will search topics on Medium app. It will return the articles present on that particular domain to enhance the knowledge of the USER.

| Argument        | Type | Required | Default Value | Description |
| --------        | ---- | -------- | ------------- | ----------- |
| `topic`       | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) |yes  |                  |Enter the topic to search here |
|  `result`  | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)  |no   | ♥result   |Name of a variable where the command's result will be stored |
| `if`  | [bool](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/BooleanStructure.md) | no       | true                                                        | Executes the command only if a specified condition is true   |
| `timeout` | [timespan](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TimeSpanStructure.md) | no       | [♥timeoutcommand](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Addon.Core/Variables/TimeoutCommandVariable.md) | Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
| `errorcall`| [procedure](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/ProcedureStructure.md) | no       |                                                             | Name of a procedure to call when the command throws an exception or when a given `timeout` expires |
| `errorjump`| [label](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/LabelStructure.md) | no       |                                                             | Name of the label to jump to when the command throws an exception or when a given `timeout` expires |
| `errormessage` | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no       |                                                             | A message that will be shown in case the command throws an exception or when a given `timeout` expires, and no `errorjump` argument is specified |
| `errorresult`  | [variable](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/VariableStructure.md) | no       |                                                             | Name of a variable that will store the returned exception. The variable will be of [error](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/ErrorStructure.md) structure  |

For more information about `if`, `timeout`, `errorcall`, `errorjump`, `errormessage` and `errorresult` arguments, see [Common Arguments](https://manual.g1ant.com/link/G1ANT.Manual/appendices/common-arguments.md) page.

# Sequence of Operation

1. The Robot opens the Medium Application and waits for the user to provide the Login credentials.
2. Once the credentials are accepted, the login will be successful.
3. The robot then prompts the user to search for the topic being provided and then return the articles and story of the same. 
## Example

This simple script searches topics in Medium android application.

```G1ANT
dialog message ‴Testing with Medium Android‴
mediumandroid.open
delay 5
mediumandroid.login email ‴hi@gmail.com‴
delay 300
mediumandroid.search topic ‴AI and RPA‴ 
delay 2
```
