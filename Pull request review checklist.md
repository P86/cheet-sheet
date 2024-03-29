# Pull Request checklist

### Author

Before creating Pull Request:
- [ ] Do review of your own code and fix problems.
- [ ] Run tests and don't create PR if tests are not green.
- [ ] Fix build warrnings and linter errors.
- [ ] Format code properly (use built in formatting tools).

### Reviewer

Initial review:
- [ ] Read description of PBI/Task connected with pull request and understand subject of changes.
- [ ] Read pull request description and comments created by author.
- [ ] Review changes and try to figure out if provided changes are in scope of PBI/Task.
- [ ] Run code and use it. If feature is not working don't continue review.

Code review

Tests:
- [ ] Tests are implemented and actually check behaviour not implementation details.
- [ ] Tests check negative scenarios and egde cases.
- [ ] API tests also check authorization.
- [ ] All tests pass.

General:
- [ ] Code follows standards accepted by team members.
- [ ] Code follows [SOLID](https://en.wikipedia.org/wiki/SOLID) principles and [KISS](https://en.wikipedia.org/wiki/KISS_principle) principles.
- [ ] Exceptions are used properly (used in exceptional situations, handled and logged properly)
- [ ] Code is written in defensive way eg. possible nulls are checked.
- [ ] Code is not repeted ([DRY](https://en.wikipedia.org/wiki/Don%27t_repeat_yourself)).
- [ ] There is no unused, dead or commented code.
- [ ] There is no unnecessary comments.
- [ ] Code is consistent, similar things should be done in smiilar way.
- [ ] Implementation not overcomplicate something for the sake of 'making it future-proof'. ([YAGNI](https://en.wikipedia.org/wiki/You_aren%27t_gonna_need_it)).
- [ ] Names of methods, varialbes are descriptive and informs what they actualy do.
- [ ] Variables and methods should be defined close to usage.
- [ ] Code is self-explanatory.
- [ ] Magic number are assigned to constants with descriptive name.
- [ ] Code is in proper layer eg. no database access code in service or presentation layer.
- [ ] Classes, modules are loosely coupled and dependencies between calsses are minimized.
- [ ] Methods don't return nulls if it is not neccessary eg. instead of empty collection.
- [ ] Methods don't have too many arguments or out arguments.
- [ ] There is no nested `if's` instructions when possible - [guard clauses](https://refactoring.guru/replace-nested-conditional-with-guard-clauses) are used instead

API:
- [ ] Controllers and methods are properly secured.
- [ ] Proper HTTP response codes are returned.
- [ ] Parameters are validated, not only query parameters but models also.
- [ ] Model validation is done using [attributes](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-6.0#validation-attributes)
- [ ] Correct HTTP method is used.
- [ ] Follows REST API standards.
- [ ] Sensitive data is not passed in query string eg. passwords.
- [ ] Async/Await is used and execution will not block thread.

Angular:
- [ ] Unsubscribe is always called on infinite observables.
- [ ] Types are placed in proper folders (services, models, commands etc.).
- [ ] Types shared between modules are in `Shared` module.
- [ ] Types shared between components inside module are `shared` folder.
- [ ] Use `index.ts` to export types from module and use it when importing types from other module.
- [ ] Try to keep flat folder structure.
