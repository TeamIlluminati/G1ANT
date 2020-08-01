# facebook.getgroupposts

## Syntax

```G1ANT
facebook.getgroupposts accesstoken ⟦text⟧ numberofposts ⟦integer⟧ id ⟦text⟧ result ⟦text⟧
```

## Description

This command is used to used to get posts from a Facebook group of which you are a member

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
| `accesstoken`          | [text]     |yes       |                                                             |Enter the accesstoken           |
|  `numberofposts`             | [text]     |yes    |                                                            |Enter the number of posts you want    |
| `id`                      | [text]  |yes    |                                                          | Enter the group id |
| `result`           | [text]     |yes       |                                                             |Name of a variable where the command's result will be stored   |
| `if`             | [bool]     | no       | true                                                        | Executes the command only if a specified condition is true   |
| `timeout`        | [timespan  | no       | [♥timeoutcommand]| Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
| `errorcall`      | [procedure]| no       |                                                             | Name of a procedure to call when the command throws an exception or when a given `timeout` expires |
| `errorjump`      | [label]    | no       |                                                             | Name of the label to jump to when the command throws an exception or when a given `timeout` expires |
| `errormessage`   | [text]     | no       |                                                             | A message that will be shown in case the command throws an exception or when a given `timeout` expires, and no `errorjump` argument is specified |
| `errorresult`    | [variable] | no       |                                                             | Name of a variable that will store the returned exception. The variable will be of [error](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/ErrorStructure.md) structure  |

getgrouposts command takes three parameters: "accesstoken", "id", "numberofposts"; "accesstoken" is the User access token that can be used with getfriends, getposts commands etc., "id" specifies the ID of the group to retrieve posts from, "numberofposts" specifies the number of posts to retrive.

For more information about `if`, `timeout`, `errorcall`, `errorjump`, `errormessage` and `errorresult` arguments, see [Common Arguments](https://manual.g1ant.com/link/G1ANT.Manual/appendices/common-arguments.md) page.

## Example

In this simple script first user has specified accesstoken and use it in facebook.getgrouposts and then giving a the number of posts we want and storing its result in variable ♥json and then displayed it.

```G1ANT
facebook.getgroupposts accesstoken ♥useraccesstoken numberofposts 10 id ‴1189569951396196‴ result ♥json
dialog ♥json

```
