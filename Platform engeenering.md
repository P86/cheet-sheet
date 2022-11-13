Platform engineering is the discipline of designing and building toolchains and workflows that enable self-service capabilities for software engineering organizations in the cloud-native era. Platform engineers provide an integrated product most often referred to as an “Internal Developer Platform” covering the operational necessities of the entire lifecycle of an application.

Platform engeenering is going to replace DevOps soon. 

## What was wrong with devops 
While cloud native drove huge improvements in areas like scalability, availability and operability, it also meant **setups became a lot more complex.** **Suddenly, engineers had to master 10 different tools, Helm charts, Terraform modules, etc. just to deploy and test a simple code change** to one of multiple environments in your multi-cluster microservice setup.

True DevOps mean that **developers should be able to deploy and run their apps and services end to end. “You build it, you run it”.**  The issue with this approach is that for most companies, **this is actually rather unrealistic**. While the above works for very advanced organizations like Google, Amazon or Airbnb, it is very far from trivial to replicate true DevOps in practice for most other teams. The main reason being it is unlikely most companies have access to the same talent pool and the same level of resources they can invest into just optimizing their developer workflows and experience.Instead, what tends to happen when a regular engineering organization tries to implement true DevOps, is that a series of antipatterns emerge. For example developers (usually the more senior ones) end up taking responsibility for managing environments, infrastructure, etc. This leads to a setup where “shadow operations” are performed by the same engineers whose input in terms of coding and product development is most valuable. Everyone loses.

So what is the key difference between low and top performing organizations? How do the best teams ensure their developers can run their apps and services, without the constant need for help by senior colleagues? They have a **platform team building an Internal Developer Platform**.

## What is Platform engeneering
When using these IDPs, developers can pick the right level of abstraction to run their apps and services, depending on their preference, i.e. do they like messing around with Helm charts, YAML files and Terraform modules? Great, they can do so. Internal Development Platform is like a glue that connects all hard thing that appears during application deployment like:
-   Adding environment variables and changing configurations
-   Adding services and dependencies
-   Rolling back and debugging 
-   Spinning up a new environment
-   Refactoring 
-   Adding/changing resources
-   Enforcing RBAC

In other words internal development platform is a "self-service layer that allows developers to interact independently with their organization’s delivery setup, enabling them to self-serve environments, deployments, databases, logs and anything else they need to run their applications".

Sources:
- [What is platform engineering?](https://platformengineering.org/blog/what-is-platform-engineering)
- [DevOps Topologies](https://web.devopstopologies.com/#anti-types)
- [What Is an Internal Developer Platform? | Humanitec](https://humanitec.com/blog/what-is-an-internal-developer-platform)

