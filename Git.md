![logo](./assets/git.png)

### Commit
```
git commit 
```
Options:
* -a - all unstaged changes
* -m - commit message

### Show status 
```
git status 
```
Options:
* -sb - short version

### Git revert local changes
```
git checkout -f
```

### Clean recusively untracked files
```
git clean -df
```

### Git remove last commit
```
git reset --hard HEAD^
```

### Switch to branch
```
git checkout <branch>
```

### Checkout previous branch
```
git checkout -
```

### Checkout single file 
```
git checkout <branch> -- <file>
```

### Create branch from other branch
```
git checkout -b <new branch> <source branch> 
```

### Create branch fron current branch
```
git checkout -b <name>
```

### Push local branch to remote
```
git push -u origin <name>
```

### List branches along with commit ID, commit message and remote
```
git branch -vv
```

### Delete branch
```
git branch -d <name>
```

### To sort branches by commit date
```
git branch --sort=-committerdate
```

### Display changes
```
git log
```
Options:
* -- <file> - changes for single file
* --pretty=oneline - pretty log 
