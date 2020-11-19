# Pull request review checklist

Initial review:
* Read description of PBI/Task connected with pull request and understand subject of changes.
* Read pull request description and comments created by author.
* Review changes and try to figure out if provided changes are in scope of PBI/Task.
* Run code and use it. If feature is not working don't continue review.

Code review:

General:
* Exceptions are used properly (used in exceptional situations, logged properly, handler properly)
* Code is written in defensive way eg. possible nulls are checked.
* Methods don't return nulls if it is not neccessary eg. instead of empty collection.
* Code is not repeated (DRY).
* Not overcomplicating something for the sake of 'making it future-proof'. (YAGNI)
* Code does not contains old, invalid commments.
* There aren't unused methods, classes, commented code.
* Methods don't have too many arguments or out arguments.
* Variables and methods should be defined close to usage.
* Code is self-explanatory.
* Names of methods, varialbes are descriptive and informs what they actualy do.
* Code follows standards accepted by team members.
* Magic number are assigned to constants with descriptive name.
* Code is consistent, similar things should be done in smiilar way.
* Added or modified files are organized correctly.
* Code is in proper layer eg. no data base access code in service layer.
* Functions are doing single thing.
* Logic in method is on same abstraction level.
* Classes, modules are loosely coupled, and dependencies between calsses are minimized.
* Any part of code can't be replaced by library function.
* Code follows SOLID principles.
* Is written with performance in mind (if that's a real concern for your application).
* Unit test are written, works and actually check something valuable.

API:
* Controllers and methods are properly secured.
* Proper HTTP response codes are returned.
* Input parameters are validated, not only query parameters but models also.
* Correct HTTP method is used.
* URL follows REST API standards.
* Sensitive data is not passed in query string eg. passwords.
* Async/Await is used and execution will not block thread.

Angular:
* Unsubscribe is always called on infinite observables.
