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

Predictability can be focused on performance predictability or cost predictability. 

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
