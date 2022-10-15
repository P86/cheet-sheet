## It's all about complexity
Writing computer software is one of the purest creative activities in the history of human race. Programmers aren't bound by practical limitaions such as tha laws of physics; [...] All programming requires is a createive mind and tha ability to organize your thoughts. If you can visualize a sustem, you can probably implement it in a computer program. This means that the greatest limitation in writing computer program is our ability to understand the systems we are creating. 

***Complexity is anything realted to the structure of a software system that makes it hard to understand and modify the system.***

Complexity isn't caused by a single catastrophic error; it accumulates in lots of smal jchunks.

## Symptoms of complexity
#### Change amplification
It occures when seemingly simple change requires code modification in many different places. 
One of the goals of good design is to reduce the amount of code that is affected b each design decistion, so design changes don't require very many code modifications.

#### Cognitive load
Cognitive load refers to how much a developer needs to know in order to complete task.

***Sometimes an approach that required a more lines of code is actually simpler, because it reduces cognitive load.***

#### Unknown unknowns
It occures when it not obvious which pieces of code must be modified to complete task, of what information developer must have to carry out the task sucessfuly.


## Different layer, different abstraction
Software systems are composed in layers, where a highier leyer use the facilities provided by lower layers. In a well designed system, each layer provides a different abstraction from the layers above and below it. **If the system contains adjacent layers with similar abstractions, this is a red flas tha suggests a problem with the class decomposition.** If different layers have same abstraction there is a good change that they does not provide enough benefit to compensate for additional infrastructure they represent. 

#### Pass-through method 
Pass-through method is one that does little except invoke another method whose signature is similar or identical to that of te calling method. The important thing is that each new method should contribute functionality.

#### Pass-through variables
This is vairable that is passed down through a long chain of methods. It adds complexity because the force all ot the intermediate methods to be aware of their existence, even though the methods have no use for the variables. 

Eliminating pass-through variables can be challenging. There is a few strategies and one of the best is to introduce context class that will keep all the global variables. The context class can be passed to different classes as parameter in constructor. 

#### Decorators
This is design patterns known also as "wrapper". Decorator takes exiting object and extends it's functionality also it provides API similar or identical to the underlaying object. The decorator pattern by itself is not an anitpattern but decorator classes tend to be  shallow and introduce a large amount of boilerplate for small amount of functionality. 

## Design it twice
Designing software is hard, so it's unlikely that your first thoughts about how to structure module or system will produce the best design. You will end up witch a much better result if you consider multiple options for for each major design decisions. Try to pick approaches that are redically different from each other; you'll learn more that way. Even if you are certain that there is only one resonable approach, consider a second design anyway, no matter how bad you think it will be. It will be instructive to think about the weaknesses of that design and contrast them with the features of other desings. **After you roughed out the designs for the alternatives, make a list of the pros and cons of each one.** The best choice may be one of the alternatives, or you may discover that you can combine features of multiple alternatives into a new design that is better than ant of the orginal choices. 

It isn't that you aren't smart; it's that the problems are really hard! Furthermore, that's a good thing; it's much more fun to work on a difficult problem where you have to think carefully, rather than an easy problem where you don't have to think at all. 

## Why write comments?
In code documentation plays crucial role in software dessing. Comments are essential to help developers understand a system and work efficently. **The process of writing comments, if done correctly, will actually improve a system's desig.** 

> [!INFO]
> The overall idea behind comments is to capture information that was in the mind of designer but couldn't be represented in code.

#### Good code is self documenting
Some people believe that that if code is written well, it is obvious that no comments are needed. This is delicious myth. Only a small part of a class interface, such as the signatures of its methods, can be specified in code. The informal aspects of an interface, such as a high-level description of what each method does or the meaning of its result, can only by described in comments. There aremany other examples of things that can't be described in the code, such as rationale for a particular design decission, or the conditions under which it makes sense to call a particular method. **If user must read the code of a method in order to use it, then there is no abstraction..**

#### I don't have time to write comments.
Good comments makes a huge difference in the maintability of software, so the effort spent on them woll pay for itself quickly. 

#### Benefits of writing comments.
When other developers come along to make modifications, the comments will allow the to work more quickly and acurately. Without documentation the developers will have to rederive ot guess at the developer's orginal aknowledge; this wil take additional time, and there is a risk of bugs if the new developer misunderstands the orginal desingner's intentions. 


## Red Flags 
- **Pass-through methods**: a method that does almost nothing except pass its arguments to another method with similar arguments.
