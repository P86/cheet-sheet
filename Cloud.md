# Cloud in general

CapEx (capital Expense):
- spend money upfront eg. buing servers
- not optimal
- not flexible

OpEx - Operating expsense:
- pay for useage eg. pay for cpu in cloud
- Extremly flexible
- Most optimal

Traditional IT is CapEx oriented. 

### IaaS (Infrastructure as a Service):
The cloud provides the underlying platform:
- compute,
- networking,
- storage.

The clent handles, and is responsible for the res.

Example:
- Virtual Machines

### PaaS (Platform as a Service):
The cloud provides platform for running apps:
- IaaS, 
- runtime evnvirnment,
- scaling,
- redundancy,
- scurity,
- updates,
- patching,
- maintenance.

Client just needs to bring the code to run.

Example:
- Web Apps

### SaaS (Software as a Service):
A software running completely in the could.


Examples:
- Office 365, salesforce

!!! IMAGE HERE

## Types of cloud

### Public
Characteristics:
- The cloud is set up in the public network. 
- Managed by large companies. 
- Accessible through the internet. 
- Available to all clients and users. 
- Clients have no access to underlying infrastructure.

Examples: Azure, AWS, GCP

### Private
Characteristics:
- Set up in a organization's premises.
- Managed by the organization's IT team.
- Accessible only in the organization's network.
- Available to users from the organization.
- Ues private cloud infrastructure and engines.
- Contains subset of the public cloud capabilities

Examples: vmware cloud, RedHat Openshift, Azure Stack

### Hybrid
Characteristics:
- A cloud setup in a organization's premises...
- ...but also connected to the public cloud.
- Workload can be separated between two clouds.
- Sensitive data in the organization's premises, public data in the public cloud.
- Usually managed by the public cloud, but not always.

Examples: Azure Arc and AWS Outposts

## Cloud providers
Companies which build datacenters and provide public cloud.

Examples: Microsoft Azure, Amazon AWS, Google GCP

# Azure

### Regions 
Azure have a lot of datacenters and each of this datacenter is called **Rregion**.

What to take under consideration when selectin region:
- Geograpical proximity to system's audience.
- Serivces availability (not all services are availabie in all regions).  
- Availability zones (if there are redundancy requrements, go to region with zoes)
- Pricing (price of services vary between regions)

### Zones
Some of regions have more than on physical datacenter, each data center is called **Zone**. When there are more than one datacenter in a region. that region is said to have **Availability Zone**

### Paired regions
Some regions have deisgnated pait region. When a full region fails - the other one can fill its place. They are set by Azure and cannot be changed.

### Azure Services
Everything that can be done in cloud is called **Cloud Services** ie. creating virtual machine, setup databases.

### Subscription 
Contains the various resources you provsion in cloud ie. virtual machines, databases. On subscription can be attached to multiple accounts ie. company subscrption.

### Account
An identity with access to resources in the subscription. Can be attached to a lot of subscription.

### Resource group 
A container that holds related resources for Azure solution. Is assigned to subscription and region.

### Mangement groups 
A place to manage subscriptions.

### Storage account 
Used to store almost anything in Azure. Is used transparently by various services. Usually is used to store database backups, VM disks, diagnostincs data. Is extreamly cheap so can be used extensivly.

### Service Level Agreement (SLA)
Is uptime % of a cloud service. To get actual SLA of system, multiply the SLAs of the participating services.

### Cost
Always check resource's cost before provinsioning. Use Azure calculator to calculate costs.

Pricing models:
- Per resource (ie. VM)
- Per compsuntion (ie. Function Apps)
- Reservations

### Software architects and the cloud
Cloud systems require in addition (to standard architects knowledge):
- inrastructure knowledge,
- security
- practical knowledge about cloud.

### Azure compute
It is set of cloud services for hosting and running applications. Allows uploading your code and then run it. Offers various leves of control and flexibility.
When taling about azure compute we talk about IaaS nad PaaS.
