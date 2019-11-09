Clear console
```bash
Ctrl + L
```

Go back in console
```bash
 cd - 
```

Login as root
```bash
su -
```

Display size on disk
```bash
du
```
Options:
* -h - display sizes in human redable form
* --total - display grand total
* --max-depth - level of depth below cwd

Display file system disk space usage
```bash
df
```
Options:
* -h - display sizes in human redable form

Display service logs 
```bash
journalctl -u <name>
```

Display service status
```bash
systemctl status <name>
```

Switch between terminals
```bash
Ctrl + Alt + F1/F2/etc.
```

Show free memory
```bash
free
```
Options:
-m - display in megabytes
- h - display in human redable form

Show devices connected to USB port or PBI port
```bash
lsusb or lspci
```

Show general hardware info
```bash
hwinfo
```

Run command in background
```
<command> &
```

Bring command to foreground
```
fg
```

Display background commands
```bash
jobs
```

Restart system
```bash
shutdown -r
```