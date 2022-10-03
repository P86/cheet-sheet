# Notes from "Philosophy of software design" 

## It's all about complexity

Writing computer software is one of the purest creative activities in the history of human race. Programmers aren't bound by practical limitaions such as tha laws of physics; [...] All programming requires is a createive mind and tha ability to organize your thoughts. If you can visualize a sustem, you can probably implement it in a computer program. This means that the greatest limitation in writing computer program is our ability to understand the systems we are creating. 

***Complexity is anything realted to the structure of a software system that makes it hard to understand and modify the system.***

Complexity isn't caused by a single catastrophic error; it accumulates in lots of smal jchunks.

## Symptoms of complexity

### Change amplification
It occures when seemingly simple change requires code modification in many different places. 
One of the goals of good design is to reduce the amount of code that is affected b each design decistion, so design changes don't require very many code modifications.

### Cognitive load
Cognitive load refers to how much a developer needs to know in order to complete task.

***Sometimes an approach that required a more lines of code is actually simpler, because it reduces cognitive load.***

### Unknown unknowns
It occures when it not obvious which pieces of code must be modified to complete task, of what information developer must have to carry out the task sucessfuly.

