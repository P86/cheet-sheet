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

### Fault domain
Logical group of physical hardware that share a common power source and network switch. Basically can be a rack in traditional data center. So ***servers should be spread across more than one fault domain***

### Update domain 
Logical group of physical hardware that can undergo maintenance and be rebooted at the same time. Maintenance is done by Azure and we don't have control over it. So ***servers should be spread across more than one update domain***

### Availability domain
Collection of Fault Domains and Update Domains your VMs will be spread across. Can contains up to 3 Fault Domains and up to 20 Update Domains. All domains are located in the same.

### Availability zone
A physically separate zone within an Azure region (datacenter). Technically a building containing an autonomous data center. Each zone functions as fasult and update domain. Provides protection agains a complete zone shutdown. It is free, you don't pay for availability zone

**How to take advantage of availability zone**:
- deploy indentical VVMs into separate zones in the same region
- ensure they won't be shut down in the same time when zone shuts down
- deply load balancer to route between the VMs

### App Serivce
It is a PaaS service that allows to deply application and don't care about infrastructure. 

App Service Plan it effectively hosting option and also pricing model. You can deply many apps in the same app service plan.  
App Service Plan allows to chose between pricing tiers. Performance of each tier is described in Azure Compute Units (ACU). ACU is like an index that tells how fast this tier is comparing to other tiers.

### Function App
Typically used to run small piecies of code, not complete applications.

### Azure functions
Characteristics:
- serverless design, 
- simple,
- stateless,
- short-lived - start, do work, stop,
- triggered by timer, http request, blob event or message queue,
- best designed to work asynchronously with other code.

Have timeout about 30 minutes.

### Azure durable functions
Are designed as extension to existing functions and supprt long running functions.
Characteristics:
- statefull,
- could be long running
- could be multi step process
- can be "suspended" while waiting form a long-running API to return (checkpoints)
- supports complex design patterns,
- functions can call other functions,
- make up of a client, orchestrator and activieties

Client - the orginal triggered function.
Orchestrator - the traffic cop.
Activity - basic unit of work of a function.

Architecture patterns:
- Function Chaining pattern.
- Fan out/fan in pattern.
- Asynchronous API pattern.
- Monitor pattern.
- Human interaction pattern. 

### Storage Account

An Azure storage account contains all of your Azure Storage data objects, including blobs, file shares, queues, tables, and disks. The storage account provides a unique namespace for your Azure Storage data that's accessible from anywhere in the world over HTTP or HTTPS. Data in your storage account is durable and highly available, secure, and massively scalable.

Blob storage is container option for store files. Usually it is the cheapest option to store files.  

GPv2 stands form General Purpose v2 Storage.

Hot storage - is used to store files that are used on day to day basis
Cold storage - it is used for rarely used files like backups
Archive storage - it is used for achived files

Redundancy:
- **Locally redundant storage (LRS)** - replicates your storage account three times within a single data center in the primary region
- **Zone-redundant storage (ZRS)** -  replicates your storage account synchronously across three Azure availability zones in the primary region. Each availability zone is a separate physical location with independent power, cooling, and networking.
- **Geo-redundant storage (GRS)** -  copies your data synchronously three times within a single physical location in the primary region using LRS. It then copies your data asynchronously to a single physical location in a secondary region that is hundreds of miles away from the primary region.
- **Geo-zone-redundant storage (GZRS)** - combines the high availability provided by redundancy across availability zones with protection from regional outages provided by geo-replication. Data in a GZRS storage account is copied across three [Azure availability zones](https://learn.microsoft.com/en-us/azure/availability-zones/az-overview) in the primary region and is also replicated to a secondary geographic region for protection from regional disasters.


### Cosmos DB
Cosmos DB is NOSQL and non realtional database. Is really good for storing data that are not relational.
Types of supported databases:
- core - document database to store json files and query using SQL queries to work with data.
- mongo db - compatible with existing mongo db database.
- cassandra - compatible with existing cassandra database.
- azure table storage - table in cosmos db, dedicated for migrations from azure table storage to cosmos db.
- gremlin - graph database.

Database have max RU/s (request units per second). Microsoft defines RU/s as amount of compute to read 1 KB per second.

Container - place that holds may files
Partition key - key by which cosmos DB will split data physically across different partitions. Need to choose key that will allow to split data evenly between partitions. 

Data consistency:
- strong - data are copied righ away, so are always consistent across all regions.
- bounded stalness - strong consistency with max accepted lag.
- session (default) - provides strong consitency in regions where same user session is active, in other there is eventual consistency.
- consistent prefix - ensure that data will be written in the correct order but might be delayed in time.
- eventual - wickiest one, there is no guarantee that data will be write in the same order, so should only be used when order of writes is not required. 

Change feed - allows to trigger serverless function when document in cosmos db has changed (don't work on deletion!).

### Blob storage
Is basically container option to store files.


### Azure Active Directory

Active directory is central service in azure that deals with authentication and access control. Azure AD is not the same thing as Windows AD. 

Azure AD sync - is an service that allows to sync Azure AD in clound and Windows AD used on premise.

Definitions:
- User - this is user id and passowrd that is using to login azure portal. User is assignet to at least one tenant.
- Tenant - unit of azure active directory and its security context

Tenant types:
- Standard - just normal azure active directory. Security is managed by Microsoft.
- B2C - business to consumer, used to log in by social media accounts. Scurity is managed by third party.

By default tenants use default domain that is `onmicrosoft.com`. Is possible to custom domain for tenant.

> [!INFO] 
> Is better to create my own tenant and be  global administrator of that tenant when I'm playing with azure ad

Microsoft Identity Platform 
This is a platform that uses open-sourde authenitation libraries to sign in users with Azure AD accounts.

Guest user: ???

Microsoft Graph is set of REST API's and client libraries that Microsoft exposes to users that allow to access data in many Microsoft's services. 

### Secure Data
One way of securing data is to store keys and other sensitive informations in deployment slot variables that can be read by appliaction lika an application configuration.

Azure Key Vault is service specifically designed to keep secrets. You can keep secrets like keys, certificates, passwords. It generates ulr for each secret that it's store and those secrets can be obtained progamatically during application execution.
Also Azure Kay Vault can be limited to specific virtual network. So only applications working in certain virtual networks can access secrets in given key vault.

### Caching
Azure basically offers two ways of caching redis cache and CDN (content delivery network)
CDN is designed to provide static files audios, videos, css, js. It stores files on different server than web service, closer to end users. CDN is global service so it is not tied to any azure region.
Redis is distrubuted cache that is mainly used on backend. Thanks to redis backend don't have to query database every time when data are needed it might keep this in redis and read it very quickly. Reids is in memory database so operations on redis are faster then operations on standard, peristed datbase.
CDN endpoint is endpoint that will be used to access files. When CDN server don't contain requested file, then it will go to web app provided as source of files, load that file and store locally for later use. 
If file that is caches as been changed, you have to **purge** cdn server and allow it load new version of file from application. Other solution is put to version in file name. Then when file was changed, the version and name also are changed so it is completely different file for cdn server.
Of course application have to use CDN url for files that have to be loaded from CDN.

### Monitoring
Depending on type of resource there is different diagnostics settings and way of collecting logs.
Azure monitor is central location where log files, alerts & metrics are stored.
For virtual machine utuliation of disk, network and cpu usage are monitored. This have to be enabled manually and is deisabled by default.
Azure funtions also supports monitoring, this also needs to be manually turned on. This is called `Application Insights`.
Whenever there will be question on exam about providing logs, visibility and obervability to solitions in azure then Azure Monitor is answer or that.

### API Management
API Management is basically API Gateway that azure is configuring for me. It allows to:
- provide API documentation,
- monitor health
- setup rate limiting and throttle
- bring modern formats like JSON and REST to exisitng APIs
- connect to APIs hosted on premise end expose them to internet
- gain analytics insights

It also provides option to use Open API aka swagger to import API definition from external API and use it as definition for gateway.

Event system
When creating application for azure usually aplication is divided into smaller pieces. Small applications, functions etc. Thus you have to use events to allow to talk this piecies to each other.
Event systems in azure:
- event hub - service that allows external sources to push events to serwices working in azure.
- event grid -  service for managing routing events from any source to any destination.

### Application messaging
Azure Storage Queue

Queues in azure storage can be used for messaging between applications. Azure storage queues are place to store small piecies of data that will be read by another application.
Messages are short and can have expiry data set. Queues in azure storage are very basic and you can't expect a high performance from it. This is not an enterprise grade solution. If high performance is required then azure service bus should be used.

Azure Service Bus


### To excersise

- Virtual machines:
    - [ ] sizes,
    - [ ] disk & network options
    - [ ] connection to machine,
    - [ ] ARM Template,
    - [ ] powershell & bash command
- Azure App Service:
    - [X] app service plan,
    - [X] deployment options
	    - [X] deploy with Visual Studio
	    - [X] deploy with GitHub action
    - [ ] scaling & autoscaling,
    - [X] deployment slots,
    - [X] application settings,
    - [X] diagnostics,
    - [ ] scripting
	    - [X] powershell
	    - [ ] bash
- Containers:
    - [ ] container instance,
    - [ ] container registry,
    - [ ] deply to azure web app
    - [ ] deployment,
- Functions app:
    - [ ] standard functions,
	    - [X] parameters from url
	    - [X] access configuration
	    - [X] unit tests of function
	    - [x] use dependency injection
	    - [ ] access secrets from key vault
	    - [ ] scalability
	    - [ ] in/out integrations
	    - [ ] using cosmos db to store and fetch data
	    - [ ] using visual studio code to work with functions
    - [X] durable functions
	    - [X] use trigger function,
	    - [X] create orchestrator function,
	    - [X] create durable function with many activites,
	    - [X] create durable function with events,
	    - [X] create durable function in Visual Studio,
	- [X] Cosmos DB
		- [X] create instance of cosmos db,
		- [X] use cosmos db from web app or function
    - [ ] excercise in sandbox (https://learn.microsoft.com/en-us/training/modules/create-serverless-logic-with-azure-functions/5-add-logic-to-the-function-app?pivots=javascript)   

### Certificates:
- AZ-900 - [Azure Fundamentals](https://learn.microsoft.com/en-us/certifications/exams/az-900)
- AZ-204 - [Azure Developer Associate](https://learn.microsoft.com/pl-pl/certifications/azure-developer/)

### Sources:
- [Udemy - AZ-204 Developing Solutions for Microsoft Azure](https://www.udemy.com/course/70532-azure/learn/lecture/)
- [Udemy - Microsoft Azure: From Zero to Hero - The Complete Guide](https://www.udemy.com/course/microsoft-azure-from-zero-to-hero-the-complete-guide/)
- [YouTube - Microsoft Azure Fundamentals Full Course, Free Practice Tests, Website and Study Guides](https://www.youtube.com/watch?v=NPEsD6n9A_I&list=PLGjZwEtPN7j-Q59JYso3L4_yoCjj2syrM)
