# facebook.makepagepost

## Syntax

```G1ANT
facebook.makepagepost accesstoken ⟦text⟧ message ⟦text⟧ id ⟦text⟧ result ⟦text⟧
```

## Description

This command is used to used to make a post on a Facebook page of which you are an admin

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
| `accesstoken`          | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)      |yes       |                                                             |Enter the page accesstoken           |
|  `message`             | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)      |yes    |                                                            |Enter the message you want to post    |
| `id`                      | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)   |yes    |                                                          | Enter the page id |
|  `result`       | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)  |yes   | ♥result   |Name of a variable where the command's result will be stored |
| `if`             | [bool](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/BooleanStructure.md)     | no       | true                                                        | Executes the command only if a specified condition is true   |
| `timeout`        | [timespan](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TimeSpanStructure.md)  | no       | [♥timeoutcommand]| Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
| `errorcall`      | [procedure](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/ProcedureStructure.md)| no       |                                                             | Name of a procedure to call when the command throws an exception or when a given `timeout` expires |
| `errorjump`      | [label](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/LabelStructure.md)    | no       |                                                             | Name of the label to jump to when the command throws an exception or when a given `timeout` expires |
| `errormessage`   | [text](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/TextStructure.md)     | no       |                                                             | A message that will be shown in case the command throws an exception or when a given `timeout` expires, and no `errorjump` argument is specified |
| `errorresult`    | [variable](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/VariableStructure.md) | no       |                                                             | Name of a variable that will store the returned exception. The variable will be of [error](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Language/Structures/ErrorStructure.md) structure  |

1.To use the makepagepost command, you need the page access token to a page you admin. In the Graph API Explorer, similar to getting the user access token, Click the same dropdown and get the "page access token" option.

2.This command requires both the manage_pages permission and publish_pages. publish_pages can be obtained by clicking on the dropdown and selecting "Request publish_pages".

3.makepagepost requires an additional parameter "ID", this is the ID to your page. You can get your ID from the Graph API inspector by typing "/me/" in the textbox next to the Submit button after you have generated a page access token.

4.makepagepost requires another parameter "message", this specifies the message you want your post to contain.

5.Finally, the result variable contains the ID of the post that was made if the posting was successful.

6.Note that a single page access token gives access only to a specific page, you would need to generate a new token to gain access to a different page.

For more information about `if`, `timeout`, `errorcall`, `errorjump`, `errormessage` and `errorresult` arguments, see [Common Arguments](https://manual.g1ant.com/link/G1ANT.Manual/appendices/common-arguments.md) page.

## Example

In this simple script first user has specified accesstoken and page id and use it in facebook.makepagepost and then giving a message to post and storing its result in variable ♥status and then displayed it.

```G1ANT
♥pageid = 111865273925623
♥pagetoken = ‴EAAD62u5wZBVcBALGMuZBAh62mHuZCpC1tTTAS77pZBeP1K1CmjTQnimJMDbU6kkEMZB5iHmf6qZBTOBpwNY8RYuqWBCCifH4VpflQFYieKMm2qZA43igHdhLaJzVbHBTyUH04999jMTSZCjNsGhEuNLFT8fZCmfnP7AZB3MOLo6gwbozkm3zSvBn08DPj4bPczzPWqdZBAelTGyLMHb3LkmIPeG‴
facebook.makepagepost accesstoken ♥pagetoken message ‴This is an automated message generated on : ♥time‴ id ♥pageid result ♥status
dialog ♥status

```
