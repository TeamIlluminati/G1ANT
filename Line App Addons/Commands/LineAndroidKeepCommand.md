# lineandroid.keep

## Syntax

```G1ANT
lineandroid.keep text ⟦text⟧
```

## Description

This command allows the User to keep control of his MEMO's on LINE Android Application.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|  `result`       | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)  |no   | ♥result   |Name of a variable where the command's result will be stored |
|  `text`       | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)  |yes  |    |Description of the Memo|
| `if`             | [bool](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/BooleanStructure.md)     | no       | true                                                        | Executes the command only if a specified condition is true   |
| `timeout`        | [timespan](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TimeSpanStructure.md)  | no       | [♥timeoutcommand]| Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
| `errorcall`      | [procedure](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/ProcedureStructure.md)| no       |                                                             | Name of a procedure to call when the command throws an exception or when a given `timeout` expires |
| `errorjump`      | [label](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/LabelStructure.md)    | no       |                                                             | Name of the label to jump to when the command throws an exception or when a given `timeout` expires |
| `errormessage`   | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)     | no       |                                                             | A message that will be shown in case the command throws an exception or when a given `timeout` expires, and no `errorjump` argument is specified |
| `errorresult`    | [variable](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/VariableStructure.md) | no       |                                                             | Name of a variable that will store the returned exception. The variable will be of [error](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/ErrorStructure.md) structure  |

For more information about `if`, `timeout`, `errorcall`, `errorjump`, `errormessage` and `errorresult` arguments, see [Common Arguments](https://manual.g1ant.com/link/G1ANT.Manual/appendices/common-arguments.md) page.

# Sequence of Operation
1. The Robot opens the Android Instance and logs in with the phone number.
2. After Successful Authentication, the Robot will take the user to the memo section where he can draft his own memos and store it for future reference. 

## Example

The script opens the LINE Application and helps the user create his own memo on LINE. 

```G1ANT
dialog message ‴Testing LINE Android‴
lineandroid.open
delay 5
lineandroid.login phone ‴1234567892‴
delay 5
lineandroid.keep text ‴My Personal Memo‴ 
```
