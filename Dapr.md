# Distributed Application Runtime

The Distributed Application Runtime (Dapr) provides APIs that simplify microservice connectivity. Whether your communication pattern is service to service invocation or pub/sub messaging, Dapr helps you write resilient and secured microservices.

API provides by DAPR:
- Service invocation - Using service invocation, your application can reliably and securely communicate with other applications using the standard gRPC or HTTP protocols.
- Publish and subscribe - The publish and subscribe pattern (pub/sub) enables microservices to communicate with each other using messages for event-driven architectures.
- Secrets management - It’s common for applications to store sensitive information such as connection strings, keys and tokens that are used to authenticate with databases, services and external systems in secrets by using a dedicated secret store.
- Bindings - Using Dapr’s bindings API, you can trigger your app with events coming in from external systems and interface with external systems.
- State management - Your application can use Dapr’s state management API to save, read, and query key/value pairs in the state stores.
- Actors  - The actor pattern describes actors as the lowest-level “unit of computation”. In other words, you write your code in a self-contained unit (called an actor) that receives messages and processes them one at a time, without any kind of concurrency or threading.

