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

### To sort branches by commit date (to see latest branches)
```
git branch --sort=-committerdate
```

### Create tag
```
git tag <tag name>
```
Then push tag 
```
git push origin <tag name>
```

### Display changes
```
git log
```
Options:
* -- <file> - changes for single file
* --pretty=oneline - pretty log 

### Aliases
Aliases for commands can be added to .gitconfig in user directory (C:\Users\<user nmae\.gitconfig on windows).
```
alias.l=log --pretty=oneline --abbrev-commit -30
alias.lg=log --pretty=oneline --abbrev-commit --graph -30
alias.s=status --short --branch --ahead-behind
```

### Cherry pick
Copy commit or set of commits to current branch.
```
git cherry-pick <commit sha>
git cherry-pick <start commit sha>..<end commit sha>
```
  
## Worktree
Git worktree lets you check out multiple branches simultaneously in different directories, all sharing the same repository. It allows to review PRs or work on hotfixes without disrupting your current work — no need to stash or commit incomplete changes. Each worktree is isolated, allowing you to run tests, review code, or fix bugs in one directory while continuing development in another, eliminating context switching.

### Add a new worktree
```
git worktree add <path> <branch-name>
```

### Add a new worktree with a new branch
```
git worktree add <path> -b <new-branch-name>
```

### Add a new worktree from remote branch
```
git worktree add <path> <remote>/<branch-name>
```

### List all worktrees
```
git worktree list
```

### Remove a worktree
```
git worktree remove <path>
```

### Force remove a worktree
```
git worktree remove --force <path>
```

### Clean up deleted worktrees
```
git worktree prune
```

If worktree folder was deleted git still keep it as worktree but it is stale, this command will cleanup stale worktrees.

### Worktree workflow
Checkout bare repo:
```
git clone --bare https://github.com/P86/<my-project>.git <my-project>/.git
```

Cd into <my-project> folder and start creaing worktrees as normal. Bare repo contains only git database not acutal code. Code will be in worktree folder. This apporach allows to mantain clean main folder with worktree folders inside.

Source: https://www.youtube.com/watch?v=99v51wRl7zE

