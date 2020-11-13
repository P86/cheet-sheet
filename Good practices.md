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