# linkedin.makeconnection

## Syntax

```G1ANT
linkedin.makeconnection connect ⟦text⟧
```

## Description


This command allows user to follow a specific company or person on Linkedin.

| Argument        | Type | Required | Default Value | Description |
| --------        | ---- | -------- | ------------- | ----------- |
| `email`       | [text] |yes  |                  |Enter email-id |
| `pword`      | [text] |yes   |                 |Enter password |
|  `connect`    | [text]  |yes|              |  Enter person's name and id here separated each word by '-' |
|  `result`       | [text]  |no   | ♥result   |Name of a variable where the command's result will be stored |
|`if`             |bool|	no	    |true	        |Executes the command only if a specified condition is true|
| `timeout`       | [timespan  | no                 | [♥timeoutcommand]| Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
| `errorcall`     | [procedure]| no       |         | Name of a procedure to call when the command throws an exception or when a given `timeout` expires |
| `errorjump`     | [label]    | no       |         | Name of the label to jump to when the command throws an exception or when a given `timeout` expires |
| `errormessage`  | [text]     | no       |         | A message that will be shown in case the command throws an exception or when a given `timeout` expires, and no `errorjump` argument is specified |
| `errorresult`   | [variable] | no       |         | Name of a variable that will store the returned exception. The variable will be of [error](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/ErrorStructure.md) structure  |

Also in this command, it is important to end nameid by a slash i.e., /


For more information about `if`, `timeout`, `errorcall`, `errorjump`, `errormessage` and `errorresult` arguments, see [Common Arguments](https://manual.g1ant.com/link/G1ANT.Manual/appendices/common-arguments.md) page.

## Example

This simple script opens linkedin and login with the credential which user will give and then will send connection to the person of which user will give name and id, like here-

```G1ANT
linkedin.login email <Enter your email-id here> pword <Enter your password here>
delay 8
linkedin.makeconnection connect rahul-rai-3790029/
```
