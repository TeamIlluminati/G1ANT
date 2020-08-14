# microsoftteamsandroid.jointeams

## Syntax

```G1ANT
microsoftteamsandroid.jointeams id ⟦text⟧
```

## Description

This command allows the user to join teams (groups) on Microsoft Teams with unique team code. Ensure the user is logged into Teams before executing this command. 

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|  `result`       | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)  |no   | ♥result   |Name of a variable where the command's result will be stored |
|  `email`       | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)  |yes   |    |Email ID of the user|
|  `id`       | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)  |yes   |    |Unique team joining ID|
|  `password`       | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)  |yes  |    |Enter the password |
| `if`             | [bool](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/BooleanStructure.md)     | no       | true                                                        | Executes the command only if a specified condition is true   |
| `timeout`        | [timespan](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TimeSpanStructure.md)  | no       | [♥timeoutcommand]| Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
| `errorcall`      | [procedure](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/ProcedureStructure.md)| no       |                                                             | Name of a procedure to call when the command throws an exception or when a given `timeout` expires |
| `errorjump`      | [label](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/LabelStructure.md)    | no       |                                                             | Name of the label to jump to when the command throws an exception or when a given `timeout` expires |
| `errormessage`   | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)     | no       |                                                             | A message that will be shown in case the command throws an exception or when a given `timeout` expires, and no `errorjump` argument is specified |
| `errorresult`    | [variable](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/VariableStructure.md) | no       |                                                             | Name of a variable that will store the returned exception. The variable will be of [error](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/ErrorStructure.md) structure  |

For more information about `if`, `timeout`, `errorcall`, `errorjump`, `errormessage` and `errorresult` arguments, see [Common Arguments](https://manual.g1ant.com/link/G1ANT.Manual/appendices/common-arguments.md) page.

# Sequence of Operation
1. The robot opens Microsoft Teams Android Instance in Mobile Application and waits for the user to enter the login credentials.
2. After Successful authentication, the robot guides the user to join a team by feeding the group ID shared by the user that is recieved personally.

## Example

This simple script demonstrates how users can be added on Microsoft Teams with unique entry ID by G1ANT Studio. 

```G1ANT
dialog message ‴Opening Microsoft Teams‴
microsoftteamsandroid.open
delay 5
microsoftteamsandroid.login email ‴<enter your email>‴ password ‴password‴ 
delay 3
microsoftteamsandroid.jointeams id ‴a123abds‴
delay 3
microsoftteamsandroid.close 



```
