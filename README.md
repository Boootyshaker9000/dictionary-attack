# Dictionary attack
## Program's purpose
This application serves for dictionary attack. It checks for a match between a password from a list of commonly used passwords and a hash value from a list of leaked hash values.  
This can greatly narrow the number of passwords needed for a successful brute force attack.
## How it works
### Configuration
The app loads file paths from *config.json*, which is located in *bin/Debug/net8.0/*
The content of the file may look something like this:
```json
{
    "passwords": "Data/passwords.txt",
    "hashes": "Data/hashes.txt",
    "matches": "Data/matches.txt"
}
```
Do not change the location of this config file or it's name.  
You may change the values of the json body, but do not change the keys. If you do, the program will end with an error.  
### Input
#### Passwords
The most commonly used passwords are loaded from a text file, which's location was declared as the value of *"passswords"*.  
To separate individual passwords, use a new line. Do not use white spaces, commas, dots or any other character.  
The content of the file may look something like this:  
```plaintext
password
13245
ILoveMyDog
...
```
#### Hashes
The leaked hashes are loaded from a text file, which's location was declared as the value of *"hashes"*.  
To separate individual passwords, use new line. Do not use white spaces, commas, dots or any other character.  
The content of the file may look something like this:
```plaintext
1234561 -> 45c4771dcd1cbd65babf3dd8cd70fed56d428fe708183ba1d146f0ad153773d7
dragon69 -> cd26b35b473b475ed553e7b512e9a29f51f25db903c9d365decb9e2785f2782f
password123 -> ef92b778bafe771e89245b89ecbc08a44a4e166c06659911881f383d4473e94f
hello123 -> 27cc6994fc1c01ce6659c6bddca9b69c4c6a9418065e612c69d110b3f7b11f8a
...
```
### Output
#### Errors
If the text files are removed or renamed, the program will print *The **tempered file.txt** file was not found.*
#### No errors
If everything is ok, the program will print the following information:  
<ul>
  <li>Number of passwords matched.</li>
  <li>How long did it tak to check all combinations</li>
</ul> <br>
Additionally, every password, which found it's match, will be written in the file located as configured in the value for key <em>"matches"</em>.
<h2 id="requirements">Requirements</h2>
<ul>
    <li>Code editor, which can run C# code (Jetbrains Rider, Visual Studio, Visual Studio Code, ...)</li>
    <li>.Net SDK 8.0</li>
</ul>
<h2>How to run program</h2>
<ul>
    <li>Open your code editor.<br>
    Run the *Main* method in file <em>Program.cs</em></li>
    <li>Alternatively, you can go to <em>/bin/Debug/net8.0/</em> and run the <em>PasswordCracker</em> binary file. This method does not need the <a href="#requirements">requirements</a> above.</li>
    <li>If you are using <a href="https://github.com/Boootyshaker9000/dictionary-attack/tags">release</a>, go to the <em>/win-x64/</em> and run <em>dictionary-attack.exe</em></li>
</ul>
Open your code editor.<br>
Run the *Main* method in file <em>Program.cs</em><br>
Alternatively, you can go to <em>/bin/Debug/net8.0/</em> and run the <em>PasswordCracker</em> binary file. This method does not need the <a href="#requirements">requirements</a> above.<br>
If you are using 
<h2> Legal disclaimer </h2>  
The program is not intended for illegal activity. The author is not responsible for any legal issues.
<h2>Contact</h2>  
If you have any questions regarding this project or you'd like to contribute, do not hesitate to contact me.
<ul>
    <li>e-mail address: relich@post.cz</li>
    <li>discord id: 697353234465030184</li>
</ul>
