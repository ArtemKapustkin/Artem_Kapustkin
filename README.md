# Artem_Kapustkin
The repository contains WebAPI homework assignment on the subject of "Software development technologies"

About the project: a primitive Dropbox cloud manager was implemented, which allows you to upload / delete files, as well as request file metadata. All three functions are covered by unit tests that check their functionality. The SOLID principles and Factory design pattern are used in the work. The /obj directory contains the WebAPI_BDD.feature file, which describes three test cases.

NuGet packages needed to work:
![image](https://github.com/ArtemKapustkin/Artem_Kapustkin/assets/95918784/13846d50-fb1a-4af6-bfb8-21a484f96d8c)

Also, for work, you need to create an application on the site https://www.dropbox.com/developers/apps , after creating it, you will need to give the necessary permissions to the application, and then we only need two values from it - the app key and the generated access token (I note that the token needs to be generated again from time to time, as it ceases to be valid)
