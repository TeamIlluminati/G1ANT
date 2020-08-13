# ciscowebexandroid.schedulemeetings

## Syntax

```G1ANT
ciscowebexandroid.schedulemeetings email ⟦text⟧ hrs ⟦text⟧ mins ⟦text⟧ 
```

## Description

This command allows the user to schedule meetings on CiscoWebEx Android Applications

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`email`| [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | yes |  | Enter the email id of the members attending the meeting |
|`hrs`| [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | yes |  | Clock time in Hours (24 hours) |
|`mins`| [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | yes |  | Clock time Minutes |
|`devicename`| [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no | Android | Name of your device to be automated |
|`platformname`| [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no |Android | Name of the automated platform |
|`platformversion`| [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no | | Version of the automated platform |
|  `result`  | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)  |no   | ♥result   |Name of a variable where the command's result will be stored |
| `if`  | [bool](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/BooleanStructure.md) | no       | true                                                        | Executes the command only if a specified condition is true   |
| `timeout` | [timespan](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TimeSpanStructure.md) | no       | [♥timeoutcommand](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Addon.Core/Variables/TimeoutCommandVariable.md) | Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
| `errorcall`| [procedure](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/ProcedureStructure.md) | no       |                                                             | Name of a procedure to call when the command throws an exception or when a given `timeout` expires |
| `errorjump`| [label](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/LabelStructure.md) | no       |                                                             | Name of the label to jump to when the command throws an exception or when a given `timeout` expires |
| `errormessage` | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md) | no       |                                                             | A message that will be shown in case the command throws an exception or when a given `timeout` expires, and no `errorjump` argument is specified |
| `errorresult`  | [variable](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/VariableStructure.md) | no       |                                                             | Name of a variable that will store the returned exception. The variable will be of [error](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/ErrorStructure.md) structure  |

For more information about `if`, `timeout`, `errorcall`, `errorjump`, `errormessage` and `errorresult` arguments, see [Common Arguments](https://manual.g1ant.com/link/G1ANT.Manual/appendices/common-arguments.md) page.

# Sequence of Operation
With the android device being connected and configured, based on the app activity and app package defined, CiscoWebEx opens on the user's device and would be ready for using in phone.
1. Once the appplication starts up, the user will then be prompted to schedule meeting section.
2. The required data is filled provided by the user and the robot will then schedule the meeting for the user. 

## Example

This simple script allows users to first opens CiscoWebEx and waits for 5 seconds. The robot then logs into the android application and schedules the meeting for the user. 

```G1ANT
ciscowebexandroid.open
delay 5
ciscowebexandroid.login email ‴hi@gmail.com‴ pass ‴tbmf123‴
delay 2
ciscowebexandroid.schedulemeetings email ‴tom123@gmail.com‴ ⋘ENTER⋙ ‴trian123@gmail.com‴ hrs ‴14‴ mins ‴30‴ 
dialog message ‴Meeting Set‴
```
