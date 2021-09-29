# MicroServices
A list of People that is being transferred between micro services
MicroServices Task
 
In this solution there is data transfer between 2 micro services.
The message Queue chosen is RabbitMQ.
I used 3 projects in one solution in visual studio.

common project:
Decryptor.cs and Encryptor.cs – encrypt and decrypt a single summary, both contain an EncryptionContext.cs – responsible for getting the key and IV from a local file named “secrets.txt”.
the encryption is done by KEY and IV that need to be in the same folder of Recieve.dll and Send.dll

Send project:
Sumamry.cs -a summary contains name, date, age, and profession
SummaryFactory.cs – a factory that creates random summaries, one at a time.
Send.cs- sends a random list of summaries (a summary contains name, date, age, and profession).
in each message the age is being removed before launch- it is done with annotation above the field.
 
Receive project:
Recieve.cs - receive the data from send.
 
Each message is encrypted before launch and decrypted after launch.
I validated that the project works during the development using docker to launch RabbitMQ.
The summaries are being printed after each stage for ease of use and check.
Libraries I used:
RabbitMQ.Client;
Newtonsoft.Json;
 
 
 
 
 
Below are demos of executing the executable.

