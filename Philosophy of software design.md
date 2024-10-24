## It's all about complexity
Writing computer software is one of the purest creative activities in the history of human race. Programmers aren't bound by practical limitaions such as tha laws of physics; [...] All programming requires is a createive mind and tha ability to organize your thoughts. If you can visualize a sustem, you can probably implement it in a computer program. This means that the greatest limitation in writing computer program is our ability to understand the systems we are creating. 

***Complexity is anything realted to the structure of a software system that makes it hard to understand and modify the system.***

Complexity isn't caused by a single catastrophic error; it accumulates in lots of smal chunks.

## Symptoms of complexity
#### Change amplification
It occures when seemingly simple change requires code modification in many different places. 
One of the goals of good design is to reduce the amount of code that is affected b each design decistion, so design changes don't require very many code modifications.

#### Cognitive load
Cognitive load refers to how much a developer needs to know in order to complete task.

***Sometimes an approach that required a more lines of code is actually simpler, because it reduces cognitive load.***

#### Unknown unknowns
It occures when it not obvious which pieces of code must be modified to complete task, of what information developer must have to carry out the task sucessfuly.

## Causes of complexity
### Dependencies
Dependency exists when one piece of code canno't be understood and modified in isolation eg. the code relates in some way to other code and the other code must be considered and/or modified when code is changed. 
Dependencies are fundamental part of software and can't be completelty eliminated. In fact, we intentionaly introduce depencencies as part of the software design process. 

### Obscurity
Obscurity occurs when iportant information is not obvious. A simple example is a variable name that is so generic that it dosen't carry much usefull information. 

## Working code Isn't Enough
#### Tactical programming 
In tactical programming, your main focus is to get something working, such as new feature or bug fix. Problem with tactical programming is that it is short-sighted. In this approach you don't spend time looking for the best design; you just wany to get something working soon. This approach usually leads to add another complexity to code within each task completed.

#### Strategic programming
The first step towards becoming a good software designer is to realize that **working code isn't enought**. It is not acceptable to introduce unneccessary complexities in order to finish your current task faster. The most important thing is the long-term structure of the system. your primary goal must be to produce **a great design, which also happens to work** Strategic programming requires an investment mindset. A huge up-front investments, such as trying to design the enitre system, won't be effective. Thus the best approach is to make lots of small investments on a continual basis. You can spend about 10-20% of your total developemnt time in investments. The extra time will result in a better software design, and you will start experiencing the benefits within a few months.  

## Modules Should Be Deep
#### Modular Design
In modular design, a software system is decomposed into a colleciton of modules that are relatively independent. MOdules can take many forms, such as classes, subsystems, or services. Modules have to work with each other. **The goal of modular design is to minimize the dependencies between modules.** In order to identify and manage dependencies, we think of each module in two parts: an `interface` and an `implementation`. Interface should provide `abstraction` over implementation. **An abstraction is a simplified view of an entity, which imits unimportant details.** 
#### Deep Modules
The best modules are those that provide powerful functionality yet have simple interfaces. The therm `deep` is used to describe that modules. A deep module is good abstraction because only small fraction of its internal complecxity is visible to its users. 
#### Shallow Modules
On the other hand, a shallow module is one whose interface is relatively complex in comparision to the functionality that it provides. 
#### Shallow Classes
The value of deep classes is not widely appreciated today. The conventional wisdom in programming it that classes should be small not deep. We were taught that classes are good and the more classes then better. **That is not good idea.** Classes should group similar functiality and hide its complexity after relatively simple interface. You don't want spread same functionality between many classes, because then realatively small change can require to modify a lot of files. 

> [!INFO] 
> Interfaces shold be designed to make the common case as simple as possible.


## Information Hiding
One of the most important techiquest for acheving deep modules is information hiding. The knowledge is embedden in module's implementation but does not appear in it's interface. So is not visible to other modules. The hidden infromation usually consist details how given functionality was implemented. This includes algorithms, data structures and low level details. It reduces complecity in two ways. First, simplifies module interface. Second, make easier to evolve system. 

The oposite of information hidding is information leackage. Information leackage occurs when design decision is reflected in multiple modules. This creates dependency between the modules: any change to that decision will require changes to all of the involved modules. One common casue of information leackage is is design style called `temporal decomposition`. In temporal decomposition, the structure of a system coresponds to the time order in which operations will occur. ** When designing modules, focues on the knowledge that's needed to perform each task, not the order in which tasks occur.**
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
- **Shallow Module**: the interface for a class or method isn't much simpler that its implementation.
- **Imformation Leakage**: a desing decistion is reflected in multiple modules.
- **Temporal Decomposition**: the code structure is basen on the order in which operations are executed, not on information hiding.
- **Everexposure**: An API forces callers to be aware of rarely used features in order to use commonly used features.
- **Pass-through methods**: a method that does almost nothing except pass its arguments to another method with similar arguments.
- **Repetition**: nontrivial piece of code repeated over and over.
- **Special-General Mixture**: special-purpose code is not cleanly separated from general purpose code.
- **Conjoined Methods**: two methods have so many dependencies that is hard to understand the implementation of one without understansing the implementation of the other. 
- **Comments Repeats Code**: all fo the information in a comment is immediately obvious from the code next to the comment.
- **Implementation Documentation Contaimnates Interface**: an interface comment describes implementation details not needed by users of the thing being documented.
- **Vague Name**: the name of a variable or method is so imprecise that it dosen't convey much usefull information.
- **Hard to Pick Name**: it is difficult to come up with a precise and intuitive name for an entity.
- **Hard to Describe**: in order to be complete, the documentation for a variable or method must be long.
- **Nonobvious Code**: the behaviour or meaning of a piece of code cannot be understood easily.
