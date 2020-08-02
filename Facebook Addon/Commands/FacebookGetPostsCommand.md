# facebook.getposts

## Syntax

```G1ANT
facebook.getposts accesstoken ⟦text⟧ result ⟦text⟧ numberofposts ⟦integer⟧
```

## Description

This command is used to log into the user's facebook account.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
| `accesstoken`          | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)     |yes       |                                                             |Enter the accesstoken           |
|  `numberofposts`             | [integer](https://manual.g1ant.com/G1ANT.Addons/G1ANT.Language/Structures/IntegerStructure.md)     |yes    |                                                            |Enter the number of posts you want    |
|  `result`       | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)  |no   | ♥result   |Name of a variable where the command's result will be stored |
| `if`             | [bool](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/BooleanStructure.md)     | no       | true                                                        | Executes the command only if a specified condition is true   |
| `timeout`        | [timespan](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TimeSpanStructure.md)  | no       | [♥timeoutcommand]| Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
| `errorcall`      | [procedure](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/ProcedureStructure.md)| no       |                                                             | Name of a procedure to call when the command throws an exception or when a given `timeout` expires |
| `errorjump`      | [label](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/LabelStructure.md)    | no       |                                                             | Name of the label to jump to when the command throws an exception or when a given `timeout` expires |
| `errormessage`   | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)     | no       |                                                             | A message that will be shown in case the command throws an exception or when a given `timeout` expires, and no `errorjump` argument is specified |
| `errorresult`    | [variable](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/VariableStructure.md) | no       |                                                             | Name of a variable that will store the returned exception. The variable will be of [error](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/ErrorStructure.md) structure  |

1.First, you need a Facebook Developer Account.

2.Next, create a Facebook App from the "My Apps" dropdown at the https://developers.facebook.com/ site.

3.After you have created your app, Go to the Graph API Explorer page.

4.Click the "Get Token Button" and then Click "Get User User Access Token".

5.Click the "user_posts" checkbox in the "Select Permissions" menu and click "Get Access Token".

6.Click the "Continue As" button to allow access.

7.Copy the string in "Access Token" text box.

8.In G1ANT Studio, use the command facebook.getposts to get the last 10 posts of the user.

9.The command should return a JSON response which can be displayed using the dialog command.

For more information about `if`, `timeout`, `errorcall`, `errorjump`, `errormessage` and `errorresult` arguments, see [Common Arguments](https://manual.g1ant.com/link/G1ANT.Manual/appendices/common-arguments.md) page.

## Example

In this simple script first user has specified accesstoken and use it in facebook.getposts command and set number of posts to 5 and then dispalyed them using a for loop.

```G1ANT
♥useraccesstoken=‴EAAD62u5wZBVcBAN8SRh06xm8I1RMdOZAVGpRkzOURfO4AuOwT1HyQHh7grZCH6qCQmapbpO0C5feV6ZCOe2AnhRFhQT2NZAM6lSqpi3hZAwiDwtiaCikcqdanyZCwZCkaq7Xx5hqdw5aN8bPnzxX2c7sHjHX4muGBInCMZAyuEDD2lL1Sm2wIRB284Kav4ZA3WByhL6RMNGBbon2eE2RPFyIZB9UAruEX9TxEzltzDmijG83jE3vPO3q5ti4MEgG1zOKucZD‴
facebook.getposts accesstoken ♥useraccesstoken result ♥json1 numberofposts 5
dialog ♥json1
♥json=⟦json⟧♥json1
for ♥i from 0 to 4
    dialog ♥json⟦posts.data[♥i].message⟧
end
```
