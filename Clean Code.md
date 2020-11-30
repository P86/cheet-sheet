### Classes
* Should be small.
* Class should have one and only one reason to change (SRP rule).
* Should be consistent. Should have as little fields as possible and all methods in class should use as many of this fields as possible.
* Should depend on abstraction not on concrete implementation.

### Exceptions
* Use defensive coding, handle common conditions without throwing exceptions and avoid exceptions (exceptions are for exceptional situations)
* Use try/catch/finally blocks to recover from errors or release resources
* Log exceptions
* Catch more specific exceptions first
* Create custom exceptions when provided by framework exceptions are not sufficient
* Throw exceptions instead of returning error code
* Don't rethrow exceptions just juse `throw`
* Don't use Exception Pockemon handling (catch t'em all!)
* Swallow exceptions only at the highiest layer of application

### SOLID
* Single Responsibility Principle
```
Each class or module should have one and only one reason to change.
```

* Dependency Inversion Principle
```
Classes depend on abstraction not on concrete implementation.
```