# Introduction to cloud computing

Cloud computing is the delivery of computing services over the internet.

Computing services include common IT infrastructure such as virtual machines, storage, databases, and networking. Cloud services also expand the traditional IT offerings to include things like Internet of Things (IoT), machine learning (ML), and artificial intelligence (AI).

## Shared responsibility model

Physical security, power, cooling, and network connectivity are the responsibility of the cloud provider. The consumer isn’t collocated with the datacenter, so it wouldn’t make sense for the consumer to have any of those responsibilities. At the same time, the consumer is responsible for the data and information stored in the cloud. (You wouldn’t want the cloud provider to be able to read your information.) The consumer is also responsible for access security, meaning you only give access to those who need it.

With an on-premises datacenter, you’re responsible for everything. With cloud computing, those responsibilities shift.
The shared responsibility model is heavily tied into the cloud service types: 
- infrastructure as a service (IaaS) - places the most responsibility on the consumer, with the cloud provider being responsible for the basics of physical security, power, and connectivity. 
- platform as a service (PaaS) - PaaS, being a middle ground between IaaS and SaaS, rests somewhere in the middle and evenly distributes responsibility between the cloud provider and the consumer.
- software as a service (SaaS) - places most of the responsibility with the cloud provider.

You’ll always be responsible for:
-   The information and data stored in the cloud
-   Devices that are allowed to connect to your cloud (cell phones, computers, and so on)
-   The accounts and identities of the people, services, and devices within your organization

The cloud provider is always responsible for:
-   The physical datacenter
-   The physical network
-   The physical hosts

Your service model will determine responsibility for things like:
-   Operating systems
-   Network controls
-   Applications
-   Identity and infrastructure

![[Pasted image 20230227195920.png]]

## Cloud models

- Private cloud - It’s a cloud (delivering IT services over the internet) that’s used by a single entity. Is the natural evolution from a corporate datacenter.
- Public cloud - A public cloud is built, controlled, and maintained by a third-party cloud provider. The general public availability is a key difference between public and private clouds.
- Hybrid cloud - A hybrid cloud is a computing environment that uses both public and private clouds in an inter-connected environment. Users can flexibly choose which services to keep in public cloud and which to deploy to their private cloud infrastructure.
- Mulit-cloud - In a multi-cloud scenario, you use multiple public cloud providers. Maybe you use different features from different cloud providers.
- Azure Arc - Azure Arc is a set of technologies that helps manage your cloud environment. Azure Arc can help manage your cloud environment, whether it's a public cloud solely on Azure, a private cloud in your datacenter, a hybrid configuration, or even a **multi-cloud environment** running on multiple cloud providers at once.
- Azure VMware Solution - Azure VMware Solution lets you run your VMware workloads in Azure with seamless integration and scalability as in private cloud.

## Consumption-based model

When comparing IT infrastructure models, there are two types of expenses to consider:
- Capital expenditure (CapEx) - is typically a one-time, up-front expenditure to purchase or secure tangible resources. A new building, repaving the parking lot, building a datacenter, or buying a company vehicle are examples of CapEx.
- Operational expenditure (OpEx) - is typically a one-time, up-front expenditure to purchase or secure tangible resources. A new building, repaving the parking lot, building a datacenter, or buying a company vehicle are examples of CapEx.

Cloud computing falls under **OpEx** because cloud computing operates on a consumption-based model. With cloud computing, you don’t pay for the physical infrastructure, the electricity, the security, or anything else associated with maintaining a datacenter. Instead, you pay for the IT resources you use. If you don’t use any IT resources this month, you don’t pay for any IT resources.
This consumption-based model has many benefits, including:
-   No upfront costs.
-   No need to purchase and manage costly infrastructure that users might not use to its fullest potential.
-   The ability to pay for more resources when they're needed.
-   The ability to stop paying for resources that are no longer needed.

Cloud computing is the delivery of computing services over the internet by using a pay-as-you-go pricing model. You typically pay only for the cloud services you use, which helps you:
-   Plan and manage your operating costs.
-   Run your infrastructure more efficiently.
-   Scale as your business needs change.

## Resources:
- [Identify the Benefits of Cloud Computing - AZ-900 Certification Course - YouTube](https://www.youtube.com/watch?v=VaMdHKJQ15c&list=PLlVtbbG169nED0_vMEniWBQjSoxTsBYS3&index=2)
- [CapEx, OpEx and Consumption-based - AZ-900 Certification Course - YouTube](https://www.youtube.com/watch?v=WiwV9wb0GMo&list=PLlVtbbG169nED0_vMEniWBQjSoxTsBYS3&index=3)

# Describe the benefits of using cloud services

## Describe the benefits of high availability and scalability in the cloud

### High availability

High availability focuses on ensuring maximum availability, regardless of disruptions or events that may occur. Azure is a highly available cloud environment with uptime guarantees depending on the service. These guarantees are part of the service-level agreements (SLAs). Availability is also described as "Up Time".

### Scalability

Scalability refers to the ability to adjust resources to meet demand. If you suddenly experience peak traffic and your systems are overwhelmed, the ability to scale means you can add more resources to better handle the increased demand. If you suddenly experience peak traffic and your systems are overwhelmed, the ability to scale means you can add more resources to better handle the increased demand. 

Scaling generally comes in two varieties: vertical and horizontal. Vertical scaling is focused on increasing or decreasing the capabilities of resources. Horizontal scaling is adding or subtracting the number of resources.

## Describe the benefits of reliability and predictability in the cloud

### Reliability

Reliability is the ability of a system to recover from failures and continue to function. The cloud, by virtue of its decentralized design, naturally supports a reliable and resilient infrastructure. With a decentralized design, the cloud enables you to have resources deployed in regions around the world. With this global scale, even if one region has a catastrophic event other regions are still up and running.

### Predictability

Predictability can be focused on **performance predictability** or **cost predictability**. 

Performance predictability focuses on predicting the resources needed to deliver a positive experience for your customers. **Autoscaling, load balancing, and high availability** are just some of the cloud concepts that support performance predictability.

Cost predictability is focused on predicting or forecasting the cost of the cloud spend. With the cloud, you can **track your resource use in real time, monitor resources** to ensure that you’re using them in the **most efficient way**, and **apply data analytics to find patterns** and trends that help better plan resource deployments.

## Describe the benefits of security and governance in the cloud

Whether you’re deploying infrastructure as a service or software as a service, cloud features support governance and compliance. Things like **set templates** help ensure that all your deployed resources **meet corporate standards and government regulatory requirements**. **Cloud-based auditing** helps flag any resource that’s **out of compliance with your corporate standards** and provides mitigation strategies.

Because the cloud is intended as an over-the-internet delivery of IT resources, cloud providers are typically well suited to handle things like distributed denial of service (DDoS) attacks, making your network more robust and secure.

## Describe the benefits of manageability in the cloud

### Management of the cloud

Management of the cloud speaks to managing your cloud resources. In the cloud, you can:

-   Automatically scale resource deployment based on need.
-   Deploy resources based on a preconfigured template, removing the need for manual configuration.
-   Monitor the health of resources and automatically replace failing resources.
-   Receive automatic alerts based on configured metrics, so you’re aware of performance in real time.

### Management in the cloud

Management in the cloud speaks to how you’re able to manage your cloud environment and resources. You can manage these:

-   Through a web portal.
-   Using a command line interface.
-   Using APIs.
-   Using PowerShell.

## Resources: 
- [Reliability and Predictability - AZ-900 Certification Course - May 2022 New - YouTube](https://www.youtube.com/watch?v=kD2YqdDaO1w&list=PLlVtbbG169nED0_vMEniWBQjSoxTsBYS3&index=8)
- [Purpose of Service Level Agreements - AZ-900 Certification Course - YouTube](https://www.youtube.com/watch?v=3QIVbgnNrR0&list=PLlVtbbG169nED0_vMEniWBQjSoxTsBYS3&index=61)

# Describe cloud service types

## Describe Infrastructure as a Service

In an IaaS model, the cloud provider is responsible for maintaining the hardware, network connectivity (to the internet), and physical security. You’re responsible for everything else: operating system installation, configuration, and maintenance; network configuration; database and storage configuration; and so on.
With IaaS, you’re essentially renting the hardware in a cloud datacenter, but what you do with that hardware is up to you.

Some common scenarios where IaaS might make sense include:

-   Lift-and-shift migration: You’re standing up cloud resources similar to your on-prem datacenter, and then simply moving the things running on-prem to running on the IaaS infrastructure.
-   Testing and development: You have established configurations for development and test environments that you need to rapidly replicate. You can stand up or shut down the different environments rapidly with an IaaS structure, while maintaining complete control.

## Describe Platform as a Service

Platform as a service (PaaS) is a middle ground between renting space in a datacenter (infrastructure as a service) and paying for a complete and deployed solution (software as a service). In a PaaS environment, the cloud provider maintains the physical infrastructure, physical security, and connection to the internet. They also maintain the operating systems, middleware, development tools, and business intelligence services that make up a cloud solution. In a PaaS scenario, you don't have to worry about the licensing or patching for operating systems and databases.

Some common scenarios where PaaS might make sense include:

-   Development framework: PaaS provides a framework that developers can build upon to develop or customize cloud-based applications. Similar to the way you create an Excel macro, PaaS lets developers create applications using built-in software components. Cloud features such as scalability, high-availability, and multi-tenant capability are included, reducing the amount of coding that developers must do.
-   Analytics or business intelligence: Tools provided as a service with PaaS allow organizations to analyze and mine their data, finding insights and patterns and predicting outcomes to improve forecasting, product design decisions, investment returns, and other business decisions.

## Describe Software as a Service

In a SaaS environment you’re responsible for the data that you put into the system, the devices that you allow to connect to the system, and the users that have access. Nearly everything else falls to the cloud provider.

Some common scenarios for SaaS are:

-   Email and messaging.
-   Business productivity applications.
-   Finance and expense tracking.

## Resources: 

- [Differences Between Cloud Service Categories - AZ-900 Certification Course - YouTube](https://www.youtube.com/watch?v=IqQC1EOQqeU&list=PLlVtbbG169nED0_vMEniWBQjSoxTsBYS3&index=4)

# The core architectural components of Azure

## Azure physical infrastructure

The physical infrastructure for Azure starts with datacenters. Conceptually, the datacenters are the same as large corporate datacenters. They’re facilities with resources arranged in racks, with dedicated power, cooling, and networking infrastructure. Datacenters are grouped into Azure Regions or Azure Availability Zones that are designed to help you achieve resiliency and reliability for your business-critical workloads. https://infrastructuremap.microsoft.com/

### Regions

A **region is a geographical area on the planet that contains at least one, but potentially multiple datacenters** that are nearby and networked together with a low-latency network. Azure intelligently assigns and controls the resources within each region to ensure workloads are appropriately balanced.

### Availability Zones

**Availability zones are physically separate datacenters within an Azure region**. Each availability zone is made up of one or more datacenters equipped with independent power, cooling, and networking. An availability zone is set up to be an isolation boundary. If one zone goes down, the other continues working. Availability zones are connected through high-speed, private fiber-optic networks. To ensure resiliency, a **minimum of three separate availability zones are present in all availability zone-enabled regions**. However, **not all Azure Regions currently support availability zones**.

Availability zones are **primarily for VMs, managed disks, load balancers, and SQL databases**. Azure services that support availability zones fall into three categories:
-   Zonal services: You pin the resource to a specific zone (for example, VMs, managed disks, IP addresses).
-   Zone-redundant services: The platform replicates automatically across zones (for example, zone-redundant storage, SQL Database).
-   Non-regional services: Services are always available from Azure geographies and are resilient to zone-wide outages as well as region-wide outages.

### Region pairs

Most Azure regions are paired with **another region within the same geography** (such as US, Europe, or Asia) at least 300 miles away. This approach allows for the replication of resources across a geography that helps reduce the likelihood of interruptions because of events such as natural disasters, civil unrest, power outages, or physical network outages that affect an entire region. If a region in a pair was affected by a natural disaster, services would automatically fail over to the other region in its region pair.

Additional advantages of region pairs:
-   If an extensive Azure outage occurs, one region out of every pair is prioritized to make sure at least one is restored as quickly as possible for applications hosted in that region pair.
-   Planned Azure updates are rolled out to paired regions one region at a time to minimize downtime and risk of application outage.
-   Data continues to reside within the same geography as its pair (except for Brazil South) for tax- and law-enforcement jurisdiction purposes.

### Sovereign Regions

Sovereign regions are instances of Azure that are isolated from the main instance of Azure. You may need to use a sovereign region for compliance or legal purposes.

Azure sovereign regions include:
-   US DoD Central, US Gov Virginia, US Gov Iowa and more: These regions are physical and logical network-isolated instances of Azure for U.S. government agencies and partners. These datacenters are operated by screened U.S. personnel and include additional compliance certifications.
-   China East, China North, and more: These regions are available through a unique partnership between Microsoft and 21Vianet, whereby Microsoft doesn't directly maintain the datacenters.

## Azure management infrastructure

The management infrastructure includes Azure resources and resource groups, subscriptions, and accounts.

### Resources and resource groups

A resource is the basic building block of Azure. **Anything you create, provision, deploy, etc. is a resource**. Virtual Machines (VMs), virtual networks, databases, cognitive services, etc. are all considered resources within Azure.

Resource groups are simply groupings of resources. (LOL :)) Resource needs to be placed in resource group. Resource can only be in one resource group at a time. Some resources can be moved between resource groups. Resource groups can't be nested. Action applied to resource group will be applied to all resources in that group. If you delete a resource group, all the resources will be deleted. If you grant or deny access to a resource group, you’ve granted or denied access to all the resources within the resource group.

**There aren’t hard rules about how you use resource groups, so consider how to set up your resource groups to maximize their usefulness for you.**

### Subscriptions

Subscriptions are a unit of management, billing, and scale. Allows you to **logically organize your resource groups and facilitate billing**. A subscription provides you with authenticated and authorized access to Azure products and services. An Azure subscription links to an Azure account, which is an identity in Azure Active Directory (Azure AD) or in a directory that Azure AD trusts. **An account can have multiple subscriptions, but it’s only required to have one.**

You can use Azure subscriptions to define boundaries around Azure products, services, and resources. 
There are two types of subscription boundaries that you can use:
-   **Billing boundary**: This subscription type determines how an Azure account is billed for using Azure. Azure generates separate billing reports and invoices for each subscription so that you can organize and manage costs.
-   **Access control boundary**: Azure applies access-management policies at the subscription level, and you can create separate subscriptions to reflect different organizational structures. This billing model allows you to manage and control access to the resources that users provision with specific subscriptions.

### Management groups

Azure management groups provide a level of scope above subscriptions. **You organize subscriptions into containers called management groups and apply governance conditions to the management groups.** All subscriptions within a management group automatically inherit the conditions applied to the management group. Management groups give you enterprise-grade management at a large scale, no matter what type of subscriptions you might have. Management groups can be nested.

Important facts about management groups:
-   10,000 management groups can be supported in a single directory.
-   A management group tree can support up to six levels of depth. This limit doesn't include the root level or the subscription level.
-   Each management group and subscription can support only one parent.

### Hierarchy

- Management groups
	- Subscriptions
		- Resource groups
			- Resources 

![[Pasted image 20230314152836.png]]

## Resources:
- [Benefits and Usage of Regions and Region Pairs - AZ-900 Certification Course - YouTube](https://www.youtube.com/watch?v=4RjPOAN54AE&list=PLlVtbbG169nED0_vMEniWBQjSoxTsBYS3&index=9)
- [Benefits and Usage of Availability Zones - AZ-900 Certification Course - YouTube](https://www.youtube.com/watch?v=h0enGb17lnw&list=PLlVtbbG169nED0_vMEniWBQjSoxTsBYS3&index=10)
- [Benefits and Usage of Resource Groups - AZ-900 Certification Course - YouTube](https://www.youtube.com/watch?v=g6thrYZhPZY&list=PLlVtbbG169nED0_vMEniWBQjSoxTsBYS3&index=11)
- [Benefits and Usage of Subscriptions - AZ-900 Certification Course - YouTube](https://www.youtube.com/watch?v=9vKAYW_WkLo&list=PLlVtbbG169nED0_vMEniWBQjSoxTsBYS3&index=12)
- [Benefits and Usage of Management Groups - AZ-900 Certification Course - YouTube](https://www.youtube.com/watch?v=bPdDiEtCVhM&list=PLlVtbbG169nED0_vMEniWBQjSoxTsBYS3&index=13)