# mediumandroid.viewnoti


## Syntax

```G1ANT
mediumandroid.viewnoti
```

## Description

This command helps you to show user notfications on Medium Android Application interface. 

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
| `email` | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)     |yes       |                                                             |Enter the user email           |
|  `result`       | [text]  |no   | ♥result   |Name of a variable where the command's result will be stored |
|  `result`  | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)  |no   | ♥result   |Name of a variable where the command's result will be stored |
| `if`  | [bool](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/BooleanStructure.md) | no       | true                                                        | Executes the command only if a specified condition is true   |
| `timeout` | [timespan](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TimeSpanStructure.md) | no       | [♥timeoutcommand](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Addon.Core/Variables/TimeoutCommandVariable.md) | Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
| `errorcall`| [procedure](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/ProcedureStructure.md) | no       |                                                             | Name of a procedure to call when the command throws an exception or when a given `timeout` expires |
| `errorjump`| [label](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/LabelStructure.md) | no       |                                                             | Name of the label to jump to when the command throws an exception or when a given `timeout` expires |
| `errormessage` | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no       |                                                             | A message that will be shown in case the command throws an exception or when a given `timeout` expires, and no `errorjump` argument is specified |
| `errorresult`  | [variable](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/VariableStructure.md) | no       |                                                             | Name of a variable that will store the returned exception. The variable will be of [error](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/ErrorStructure.md) structure  |

For more information about `if`, `timeout`, `errorcall`, `errorjump`, `errormessage` and `errorresult` arguments, see [Common Arguments](https://manual.g1ant.com/link/G1ANT.Manual/appendices/common-arguments.md) page.

# Sequence of Operation
1. The Robot opens the Android Application Medium and waits for the user to provide credentials for logging in.
2. After successful authentication, the robot views the notifications to the user.
3. The Robot then later performs other tasks given by the user and finally terminates the session.

## Example

This simple script opens medium application and then logs into the account with provided credentials in app and then performs a series of tasks including displaying User notification with the help of G1ANT Studio. 

```G1ANT
dialog message ‴Testing with Medium Android‴
mediumandroid.open
delay 5
mediumandroid.login email ‴hi@gmail.com‴
delay 300
mediumandroid.viewnoti
delay 5
mediumandroid.viewinterests
delay 7
mediumandroid.stories story ‴Aeroplanes are massive fleet bodies. The Wright brothers discovered the concept of flying back then. Humans have then been inspired to fly over the skies and across the continents. I love flying!!‴
delay 2
mediumandroid.storysettings 
delay 5
mediumandroid.close 
```
