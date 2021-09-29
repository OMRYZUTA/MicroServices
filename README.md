# MicroServices
A list of People that is being transferred between micro services
MicroServices Task

In this solution there is data transfer between 2 micro services.
the message Queue chosen is RabbitMQ
Send.cs- sends a random list of summaries (a summary contains name, date, age, and profession).
Recieve.cs - receive the data from send.

in each message the age is being removed before launch- it is done with annotation above the field.
each message is encrypted before launch and decrypted after launch.
the encryption is done by KEY and IV that need to be in the same folder of Recieve.dll and Send.dll
I validated that the project works during the development using docker to launch RabbitMQ.
The summaries are being printed after each stage for ease of use and check.


made by:
Omry Zuta
omryzuta@gmail.com
