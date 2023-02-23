# SQL

## Locks
### Exclusive lock (X)
This lock type, when imposed, will ensure that a page or row will be reserved exclusively for the transaction that imposed the exclusive lock, as long as the transaction holds the lock.
The exclusive lock will be imposed by the transaction when it wants to modify the page or row data, which is in the case of DML statements DELETE, INSERT and UPDATE. An exclusive lock can be imposed to a page or row only if there is no other shared or exclusive lock imposed already on the target. **This practically means that only one exclusive lock can be imposed to a page or row, and once imposed no other lock can be imposed on locked resources**

### Shared lock (S)
This lock type, when imposed, will reserve a page or row to be available only for reading, which means that any other transaction will be prevented to modify the locked record as long as the lock is active. However, a shared lock can be imposed by several transactions at the same time over the same page or row and in that way several transactions can share the ability for data reading since the reading process itself will not affect anyhow the actual page or row data. In addition, a shared lock will allow write operations, but no DDL changes will be allowed

### Scope of locks 
Locks can be placed at the level of individual rows, index keys, pages, ranges or entire tables. These objects create natural hierarchy: the table consists of many pages, on each page many rows are written on the page, and so on. For this reason database servers must analyze all existing locks, before creating a new one - if at least one row of the table exists locked in X mode, you can't put another one on the whole table locks.

## Transactions isolation levels
Most of the sql servers allows to set level of transactions isolation. It can be set on server level, on database level and on session level.
There are four isolation levels:

### Read Uncommited
This is the lowest isolation level. In this level, dirty reads are allowed, so one transaction may see not-yet-committed changes made by other transactions.

In this mode (often enforced at level individual instructions using specific instructions database server optimizer directives) you can read data that we know will not be in the same modified over time.

### Read Commited
Is default level of isolation. Read committed is an isolation level that guarantees that any data read is committed at the moment it is read. It simply restricts the reader from seeing any intermediate, uncommitted, 'dirty' read. **It makes no promise whatsoever that if the transaction re-issues the read, it will find the same data; data is free to change after it is read.**

In this isolation level, a lock-based concurrency control DBMS implementation keeps write locks (acquired on selected data) until the end of the transaction, but read locks are released as soon as the SELECT operation is performed.

### Repeatable reads
In this isolation level, a lock-based concurrency control DBMS implementation **keeps read and write locks (acquired on selected data) until the end of the transaction.** However, range-locks are not managed, so phantom reads can occur.

In the REPEATABLE READ mode, you should read the data that in within the transaction are read several times and may be changed at the same time by other users.
Such a situation takes place, for example, in various types of statements and summary reports, in which reading the same data, each time together we must get the same results, otherwise collation or the report will be inconsistent.

### Serializable
**This is the highest isolation level.**

In SERIALIZATION mode, **transactions referencing the same tables are executed one after the other**. Lock entire objects (or index key ranges), not just the data read, for the duration of the transaction allows you to eliminate phantom reads, but causes that by reading even one row of the table, we can prevent other users from modifying it data stored in it.

In SERIALIZATION mode, we are guaranteed to read within transaction, the data will always be the same - the database server will not it will allow not only their change, but also the emergence of new ones data. However, during this time, other users will not be able to modify locked tables. In most cases this increases the server response time so much that it's better is to copy the read data.

### Clear table
The fastest way to clear a table is to execute the TRUNCATE statement TABLE. Because this is a very low operation level (at the level of data blocks, not table rows),
it is impossible to indicate the rows to be deleted. WITH for the same reason, it is impossible to truncate a related table with other tables, even if they are empty, which is for sure they do not contain references to the primary keys being deleted.

```sql
TRUNCATE TABLE [<table>];
```

### Create table backup
```sql
select * into [<source table>] from [<dest table>]
```

### Alter column type
```sql
ALTER TABLE [<table>] ALTER COLUMN <column name> <new type>
```

### Select column metadata
```sql
SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = '<column name>' AND TABLE_NAME = '<table name>'
```

### Delete table
```sql
DROP TABLE [<table name>]
```

### List stored procedures 
```sql
SELECT * FROM [XV8122017_June_Smoke].INFORMATION_SCHEMA.ROUTINES
 WHERE ROUTINE_TYPE = 'PROCEDURE' AND SPECIFIC_NAME LIKE '%arrangement%'
 AND LEFT(ROUTINE_NAME, 3) NOT IN ('sp_', 'xp_', 'ms_')
```
