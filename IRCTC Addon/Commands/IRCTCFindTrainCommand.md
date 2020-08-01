# irctc.findtrain

## Syntax

```G1ANT
irctc.findtrain from ⟦text⟧ to ⟦text⟧ date ⟦text⟧
```

## Description


This command will find train in irctc website.

| Argument        | Type | Required | Default Value | Description |
| --------        | ---- | -------- | ------------- | ----------- |
| `from`       | [text] |yes  |                  |Enter the station name from where you want to depart |
| `to`      | [text] |yes   |                 |Enter the station name where you want to arive |
| `date`      | [text] |yes   |                 |Enter date in formate (dd-mm-yyyy) |
|  `result`       | [text]  |no   | ♥result   |Name of a variable where the command's result will be stored |
|`if`             |bool|	no	    |true	        |Executes the command only if a specified condition is true|
| `timeout`       | [timespan  | no                 | [♥timeoutcommand]| Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
| `errorcall`     | [procedure]| no       |         | Name of a procedure to call when the command throws an exception or when a given `timeout` expires |
| `errorjump`     | [label]    | no       |         | Name of the label to jump to when the command throws an exception or when a given `timeout` expires |
| `errormessage`  | [text]     | no       |         | A message that will be shown in case the command throws an exception or when a given `timeout` expires, and no `errorjump` argument is specified |
| `errorresult`   | [variable] | no       |         | Name of a variable that will store the returned exception. The variable will be of [error](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/ErrorStructure.md) structure  |

For more information about `if`, `timeout`, `errorcall`, `errorjump`, `errormessage` and `errorresult` arguments, see [Common Arguments](https://manual.g1ant.com/link/G1ANT.Manual/appendices/common-arguments.md) page.

## Example

This simple script open IRCTC website and then find train according to user.
```G1ANT
irctc.open Type ‴chrome‴ 
delay 10
irctc.findtrain from ‴Delhi‴ to ‴Ranchi‴ date ‴15-08-2020‴
```
