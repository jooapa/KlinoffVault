# Klinoff Vault

KlinoffVault is a security-focused operating system based on the Linux kernel.
Works on Windows, macOS and Linux. Made using .NET 7.0.

Now it might seem that this is just another Operating System, but no.. nononno
This is a very special peace of software, because it has the ability to open any folder as a operating system and encrypt it with a password. so you can hide your files from the all mighty klinoff and his friends.

## Features

- [x] Secure
- [x] Fast
- [x] Easy to use
- [x] Open source
- [x] Lightweight
- [x] Portable

## Commands

- `help                   Shows help information about a command`
- `clear                  Clears the screen`
- `exit                   Exits the shell`
- `klinofflang [command]  Runs the Klinofflang interpreter`
- `ls                     Lists the files in the current directory`
- `cd                     Changes the current directory`
- `clear                  Clears the screen`
- `mkdir                  Creates a directory`
- `rmdir                  Removes a directory`
- `pwd                    Prints the current directory`
- `rm                     Removes a file`
- `cat                    Prints the contents of a file`
- `touch                  Creates a file`
- `vim                    Edit a file`
- `console [command] ..   Runs a console app`
- `change                 Change password`
- `hide                   Hide folder`
- `crypt [text] [pass]    Encrypt text`
- `decrypt [text] [pass]  Decrypt text`

## Usage

```bash
dotnet run -- folder
dotnet run -- file.kv
```

## Building

### Windows

```bash
dotnet publish -r win10-x64 -c Release /p:PublishSingleFile=true
```

### macOS

```bash
dotnet publish -r osx-x64 -c Release /p:PublishSingleFile=true
```

### Linux

```bash
dotnet publish -r linux-x64 -c Release /p:PublishSingleFile=true
```

Inside the shell, using hide will encrypt the folder and make it a .kv file. You can then open it with the shell using `dotnet run -- file.kv` and entering the password.

## Contributing

nöfnöf
