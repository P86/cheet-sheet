# Architecture 

### CQRS
CQRS stands for Command and Query Responsibility Segregation, a pattern that separates read and update operations for a data store.
At its heart is the notion that you can use a different model to update information than the model you use to read information.
Implementing CQRS in your application **can maximize its performance, scalability, and security**. The flexibility created by migrating to CQRS allows a system to better evolve over time and **prevents update commands from causing merge conflicts at the domain level**.
For some situations, this separation can be valuable, but **beware that for most systems CQRS adds risky complexity**.
For example, on the read side, the application may perform many different queries, returning data transfer objects (DTOs) with different shapes. Object mapping can become complicated. On the write side, the model may implement complex validation and business logic. As a result, you can end up with an overly complex model that does too much.

When to use:
- In more complicated domains, where having the same conceptual model for commands and queries leads to a more complex model that does neither well. CQRS is suited to complex domains, the kind that also benefit from Domain-Driven Design.
- In high performance applications. CQRS allows you to separate the load from reads and writes allowing you to scale each independently.

Benefits:
- Independent scaling. CQRS allows the read and write workloads to scale independently.
- Optimized data schemas. The read side can use a schema that is optimized for queries, while the write side uses a schema that is optimized for updates.
- Security. It's easier to ensure that only the right domain entities are performing writes on the data.
- Separation of concerns. Segregating the read and write sides can result in models that are more maintainable and flexible. Most of the complex business logic goes into the write model. The read model can be relatively simple.
- Simpler queries. By storing a materialized view in the read database, the application can avoid complex joins when querying.

issues and considerations:
- Using CQRS on a domain that doesn't match it will add complexity, thus reducing productivity and increasing risk.
- Eventual consistency. If you separate the read and write databases, the read data may be stale.

Sources:
- https://martinfowler.com/bliki/CQRS.html
- https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs

### Modular Monolith
### Materialized View
### Event Sourcing
### Domain-Driven Design
### Onion
### Hexagonal
### Ports and adapters


Sources:
- https://docs.microsoft.com/en-us/azure/architecture/patterns/
- https://martinfowler.com/architecture/
