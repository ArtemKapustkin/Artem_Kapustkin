Feature: Scenarios for WebAPI Homework

Scenario Outline: Is the file loading correctly after the corresponding request??
  Given local file "<file>" and function "<function>"
  When function is called
  Then file should be uploaded to the folder /Documents on my Dropbox cloud

Examples:
	|file		|function				|
	|file.txt	|UploadFileToDropbox	|

Scenario Outline: Is the correct metadata returned after a request to get it?
  Given File "<file>" on the Dropbox cloud and function "<function>"
  When function is called
  Then metadata must be returned

Examples:
	|file		|function			|
	|file.txt	|GetFileMetadata	|

Scenario Outline: Is the file deleted correctly after the corresponding request??
  Given file "<file>" on the Dropbox cloud and function "<function>"
  When function is called
  Then file from the Dropbox cloud must be deleted from the folder /Documents

Examples:
	|file		|function	|
	|file.txt	|DeleteFile	|