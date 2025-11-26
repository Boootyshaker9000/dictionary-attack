# Dictionary attack
## Program's purpose
This application takes two text file inputs: *passwords.txt* and *hash.txt*, which are located at */bin/Debug/net8.0/Data/*.  
*passwords.txt*: Holds most common passwords. Change the content as you like. Note that every password must be on a seperate line.  
The content may look something like this:  
```plaintext
password
13245
ILoveMyDog
...
```
*hash.txt*: Holds hash values. You may change the content of the file. Again, every hash value must be on a seperate line. Also, the hash must be created using <a href="https://en.wikipedia.org/wiki/SHA-2">SHA256</a>, otherwise it will be ignored.  
The content may look something like this
```plaintext
1df70cf2264c5b0029c1d8763858c073ef81a1a2309d0062983ec49036cd7a4a
6b69637e5d2f86a304eeecdbc34854d8499b887049095156d027f16a3838c97b
996c7fd8002501979b9a61b3bda06890c20511be56ac4d29d135e2c106f341d2
...
```
**If the files are renamed or removed, program will not work.**  
## How to run program
Open code in a code editor, which can run C# code (Jetbrains Rider, Visual Studio, Visual Studio Code, ...).  
Run the *Main* method in file *Program.cs*
## Output
### Errors
If the text files are removed or renamed, the program will print *The **tempered file.txt** file was not found.*
### No errors
If everything is ok, the program will print the following information:  
<ul>
  <li>Every password matched with a hash and it's hash</li>
  <li>Number of passwords tested.</li>
  <li>Number of passwords matched.</li>
  <li>How long did it tak to check all combinations</li>
</ul>  
<h2> Legal disclaimer </h2>  
The program is not intended for illegal activity. The author is not responsible for any legal issues.
