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

## Different layer, different abstraction

Software systems are composed in layers, where a highier leyer use the facilities provided by lower layers. In a well designed system, each layer provides a different abstraction from the layers above and below it. **If the system contains adjacent layers with similar abstractions, this is a red flas tha suggests a problem with the class decomposition.** If different layers have same abstraction there is a good change that they does not provide enough benefit to compensate for additional infrastructure they represent. 

### Pass-through method 
Pass-through method is one that does little except invoke another method whose signature is similar or identical to that of te calling method. The important thing is that each new method should contribute functionality.

### Pass-through variables
This is vairable that is passed down through a long chain of methods. It adds complexity because the force all ot the intermediate methods to be aware of their existence, even though the methods have no use for the variables. 

Eliminating pass-through variables can be challenging. There is a few strategies and one of the best is to introduce context class that will keep all the global variables. The context class can be passed to different classes as parameter in constructor. 

### Decorators
This is design patterns known also as "wrapper". Decorator takes exiting object and extends it's functionality also it provides API similar or identical to the underlaying object. The decorator pattern by itself is not an anitpattern but decorator classes tend to be  shallow and introduce a large amount of boilerplate for small amount of functionality. 

# Red Flags 
- **Pass-through methods**: a method that does almost nothing except pass its arguments to another method with similar arguments.