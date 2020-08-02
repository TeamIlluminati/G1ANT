# facebook.makegrouppost

## Syntax

```G1ANT
facebook.makegrouppost accesstoken ⟦text⟧ message ⟦text⟧ id ⟦text⟧ result ⟦text⟧
```

## Description

This command is used to used to make a post on a Facebook group in you the user is.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
| `accesstoken`          | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)     |yes       |                                                             |Enter the accesstoken           |
|  `message`             | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)     |yes    |                                                            |Enter the message you want to post    |
| `id`                      | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)  |yes    |                                                          | Enter the group id |
|  `result`       | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)  |yes   | ♥result   |Name of a variable where the command's result will be stored |
| `if`             | [bool](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/BooleanStructure.md)     | no       | true                                                        | Executes the command only if a specified condition is true   |
| `timeout`        | [timespan](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TimeSpanStructure.md)  | no       | [♥timeoutcommand]| Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
| `errorcall`      | [procedure](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/ProcedureStructure.md)| no       |                                                             | Name of a procedure to call when the command throws an exception or when a given `timeout` expires |
| `errorjump`      | [label](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/LabelStructure.md)    | no       |                                                             | Name of the label to jump to when the command throws an exception or when a given `timeout` expires |
| `errormessage`   | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)     | no       |                                                             | A message that will be shown in case the command throws an exception or when a given `timeout` expires, and no `errorjump` argument is specified |
| `errorresult`    | [variable](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/VariableStructure.md) | no       |                                                             | Name of a variable that will store the returned exception. The variable will be of [error](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/ErrorStructure.md) structure  |

1.makegrouppostcan use the same access token as getfriends and getposts but it requires the "publish_to_groups" permission.

2.It takes three parameters: "accesstoken", "message", "id"; "accesstoken" contains the accesstoken, "message" is the message the post should contain. "id" is the ID of the group. The ID can be obtained from the Graph API inspector by typing in "me/?fields=groups" and clicking submit. It should return the IDs of all the groups you are in.

3.result returns the ID of the post made to the group if it was successful.

For more information about `if`, `timeout`, `errorcall`, `errorjump`, `errormessage` and `errorresult` arguments, see [Common Arguments](https://manual.g1ant.com/link/G1ANT.Manual/appendices/common-arguments.md) page.

## Example

In this simple script first user has specified accesstoken and use it in facebook.makegrouppost and then giving a message to post and also givin it the id and storing its result in variable ♥message and then displayed it.

```G1ANT
♥useraccesstoken=‴EAAD62u5wZBVcBAN8SRh06xm8I1RMdOZAVGpRkzOURfO4AuOwT1HyQHh7grZCH6qCQmapbpO0C5feV6ZCOe2AnhRFhQT2NZAM6lSqpi3hZAwiDwtiaCikcqdanyZCwZCkaq7Xx5hqdw5aN8bPnzxX2c7sHjHX4muGBInCMZAyuEDD2lL1Sm2wIRB284Kav4ZA3WByhL6RMNGBbon2eE2RPFyIZB9UAruEX9TxEzltzDmijG83jE3vPO3q5ti4MEgG1zOKucZD‴
facebook.makegrouppost accesstoken ♥useraccesstoken message ‴This is a trial message‴ id ‴1189569951396196‴ result ♥message
dialog ♥message

```
