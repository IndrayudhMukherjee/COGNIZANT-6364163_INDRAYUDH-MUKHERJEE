# Git Hands-On Labs 

This repository contains step-by-step Git hands-on exercises adapted from the COGNIZANT Git HOL series.  
All commands are updated  use `main` instead of `master`.

---

## Prerequisites
- VS Code installed and configured with `code` command in PATH
- Git installed (`brew install git`)
- GitHub account

---

## Lab 1 — Setup and Basic Git Commands

1. **Check Git installation**
   ```bash
   git --version
   ```

2. **Configure Git identity**
   ```bash
   git config --global user.name "Your Name"
   git config --global user.email "your.email@example.com"
   ```

3. **Set VS Code as Git editor**
   ```bash
   git config --global core.editor "code --wait"
   ```

4. **Create a new local repo**
   ```bash
   mkdir GitDemo
   cd GitDemo
   git init
   ```

5. **Create and commit a file**
   ```bash
   echo "Hello Git" > welcome.txt
   git add welcome.txt
   git commit -m "Add welcome.txt"
   ```

6. **Push to remote**
   ```bash
   git remote add origin https://github.com/<username>/GitDemo.git
   git branch -M main
   git push -u origin main
   ```

---

## Lab 2 — Using .gitignore

1. **Create ignored files**
   ```bash
   mkdir logs
   touch error.log logs/debug.txt
   ```

2. **Create `.gitignore`**
   ```
   *.log
   logs/
   ```

3. **Stage & commit**
   ```bash
   git add .gitignore
   git commit -m "Add .gitignore to ignore .log files and logs/ folder"
   ```

---

## Lab 3 — Branching and Merging

1. **Create and switch to a branch**
   ```bash
   git checkout -b GitNewBranch
   echo "New branch content" > branch.txt
   git add branch.txt
   git commit -m "Add branch.txt in GitNewBranch"
   ```

2. **Merge back to main**
   ```bash
   git checkout main
   git merge GitNewBranch
   git branch -d GitNewBranch
   ```

---

## Lab 4 — Merge Conflict Resolution

1. **Simulate a conflict**
   ```bash
   git checkout -b GitWork
   echo "Branch version" > hello.xml
   git add hello.xml
   git commit -m "Add hello.xml in branch"

   git checkout main
   echo "Main version" > hello.xml
   git add hello.xml
   git commit -m "Add hello.xml in main"
   ```

2. **Merge (will cause conflict)**
   ```bash
   git merge GitWork
   ```

3. **Resolve in VS Code** — edit `hello.xml` to desired final state.

4. **Stage and commit resolution**
   ```bash
   git add hello.xml
   git commit -m "Resolve merge conflict in hello.xml"
   ```

---

## Lab 5 — Cleanup and Push

1. **Delete merged branch**
   ```bash
   git branch -d GitWork
   ```

2. **Pull and push**
   ```bash
   git pull origin main
   git push origin main
   ```

---

## Notes
- Always verify current branch with `git branch`.
- Replace `master` with `main` in all commands.
