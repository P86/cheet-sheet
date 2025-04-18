# SQL

### Create table
```sql
CREATE TABLE <table_name> (
    <first_column_name> <first_column_type>,
    <second_column_name> <second_column_type>,
    ...
)
```

### Inserting data
```sql
INSERT INTO <table_name> (<first_column_name>, <second_column_name>)
VALUES ('first_column_value', 'second_column_value'), 
       ('another_first_column_value', 'another_second_column_value')
```

### Selecting data
```sql
SELECT <first_column_name>, <second_column_name> FROM <table_name>
```

Use `*` instead of column names to select all columns from table.

Also column names can be aliased with `AS` keyword.

```sql
SELECT <first_column_name> AS <new_name> FROM <table_name>
```

[Math operators](https://www.geeksforgeeks.org/arithmetic-operators-in-postgresql/) can be used on values during selection

```sql
SELECT <first_column_name> + <second_column_name> AS addition_result FROM <table_name>
```

[String operators](https://www.postgresql.org/docs/9.1/functions-string.html) allows to manupulate strings during selection

```sql
SELECT <first_column_name> || <second_column_name> AS concatenated_strings FROM <table_name>
```

### Filtering data
```sql
SELECT <first_column_name> AS <new_name> FROM <table_name> WHERE <condition>
```

In `WHERE` condition an [comparision operators](https://www.postgresql.org/docs/8.0/functions-comparison.html) like `<`, `=`, `BETWEEN` can be used.
Also constructs like `IS NULL` or `IS NOT NULL` can be used to check whether a value is or is not null.

Keyword `IN` can be used to check if value is in list
```sql
... WHERE <value> IN (<first_item>, <second_item>)
```

`IN` can be combined with `NOT` keyword also.

Also compound statements are supported.
```sql
WHERE <value> IN (<first_item>, <second_item>) AND NOT <value> = <third_item>
```

### Update data
```sql
UPDATE <table> SET <column> = <new_value> WHERE <column> = <filter_value>
```

Example
```sql
UPDATE users SET name = 'updated name' WHERE id = 1
```

### Delete data
```sql
DELETE FROM <table> WHERE <column> = <filter_value>
```

Example
```sql
DELETE FROM users WHERE id = 1
```

### Relations
Primary key - Uniquely identifies record in table
Foreign key - Identifies a record (usually in another table) that given row is associated with

Create table with autogenerated primary key
```sql
CREATE TABLE <table> (
    id SERIAL PRIMARY KEY,
    ...
)
```
There is no need to set `id` when inserting data to table, database engine will do this automatically.

Create foreign key column
```sql
CREATE TABLE <table> (
    ...
    <relation_table>_id INTEGER REFERENCES <table>(id)
)
```

### Joining records from other table
```sql
SELECT <first_table>.<first_column>, <first_table>.<second_column>, <second_table>.<first_column> FROM <first_table>
JOIN <second_table> ON <frist_table>.<second_table>_id = <second_table>.id
```

Aliases also can be used here  
```sql
SELECT ft.<first_column>, ft.<second_column>, st.<first_column> 
FROM <first_table> as ft 
JOIN <second_table> as st ON ft.<second_table>_id = st.id
```

There is a 4 types of join:
- JOIN (INNER): Returns records that have matching values in both tables
- LEFT JOIN (OUTER): Returns all records from the left table, and the matched records from the right table
- RIGHT JOIN (OUTER): Returns all records from the right table, and the matched records from the left table
- FULL JOIN (OUTER): Returns all records when there is a match in either left or right table

Join statements can contain additional, even complex conditions
```sql
SELECT *
FROM <first_table> ft
LEFT JOIN <second_table> st ON st.id = ft.<second_table>_id AND st.<second_column> IS NOT NULL;
```

### Grouping and aggregation
Grouping reduces many rows down to fewer rows, done by `GROUP BY` keyword. Aggregation reduces many values down to one, done by using aggregate functions like `SUM`, `MAX`.

```sql
SELECT <column>
FROM <table>
GROUP BY <column>
```
Column that is not used in `GROUP BY` statement or aggregate function can't be used in `SELECT` statement. 

Combining grouping and aggregation
```sql
SELECT <column>, COUNT(<second_column>)
FROM <table>
GROUP BY <column>
```

Filtering on groups 
`HAVING` is used to filter grouped results. Given example will group results by <column> and count values <second_column> but return only results that have <second_column> count larger than given value.
```sql
SELECT <column>, COUNT(<second_column>)
FROM <table>
GROUP BY <column>
HAVING COUNT(<second_column>) > <value>
```

### Sorting records
To sort records use `ORDER BY` keyword with optional keyword `asc` (ascending) or `desc` (descending). Sorting by multiple columns is supported.
```sql
SELECT <column>
FROM <table>
ORDER BY <second_column> [<asc | desc>], <third_column> [<asc | desc>], ...
```

### Limiting and skipping results
To skip some records from the begining of results use `OFFSET`. To limit number of results use `LIMIT`.
Given example will take 5 records and skip first 10 records
```sql
SELECT <column>
FROM <table>
LIMIT 5
OFFSET 10
```

It is usefull when you want to select one record from ordered set.
```sql
SELECT *
FROM <table>
ORDER BY <column>
LIMIT 1
```

### Unions, intersections and sets
The UNION operator is used to combine the result-set of two or more SELECT statements. Every SELECT statement within UNION must have the same number of columns. The columns must also have similar data types. 
```sql
(
    SELECT ...
)
UNION
(
    SELECT ...
)
```
If both sets contains same row the duplicated row will deduplicated.

Other similar keywords (with same syntax to `UNION`):
- `UNION ALL` - Join together results of two queries.
- `INTERSECT ALL` - Find the rows common in the results of two queries. Remove duplicates.
- `INTERSECT ALL` - Find the rows common in the results of two queries.
- `EXCEPT` - Find the rows that are present in first query but not second query. Remove duplicates.
- `EXCEPT ALL` - Find the rows that are present in first query but not second query.

### Subqueries
Subquery is an query nested in query.

Subquery can be source of:
- values
- rows
- columns

Subquery in `SELECT` statement.
```sql
SELECT <column>, (SELECT ...)
FROM <table>
```

Subquery in `FROM` statement.
```sql
SELECT <column>
FROM (SELECT ...) as <alias> --subquery must have allias applied to it
```

Subquery in `JOIN` statement.
```sql
SELECT <column>
FROM <table>
JOIN (SELECT ...) as <alias>
```

Subquery in `WHERE` statement.
```sql
SELECT <column>
FROM <table>
WHERE <second_column> IN (SELECT ...)
```

Subqueries with `WHERE` can be combined with `ALL` and `ANY` keywords.

Return records that <second_column> value is greater that ALL values returned from subquery.
```sql
SELECT <column>
FROM <table>
WHERE <second_column> > ALL (SELECT ...)
```

Return records that <second_column> value is greater than ANY values returned from subquery.
```sql
SELECT <column>
FROM <table>
WHERE <second_column> > ANY (SELECT ...)
```
* `SOME` is alias for `ANY`

Subqueries can be correlated, nested query can use data from outer query. In given example it selects data based on value of <column> from outer query
```sql
SELECT <column>
FROM <table>
WHERE <second_column> = (select <second_column> from <second_table> where <table>.<column> = <second_table>.<second_column>)
```

### Distinct values
Distinct allow to returns set of distincted values. `DISTINCT` can be perfomed on multiple columns then is returns unique combination of given columns.
```sql
SELECT DISTINCT <column>, <another_column>
FROM <table>
```

### Greatest and least value
`GREATEST` allows to return greatest value from multiple columns for each row (don't confuse with `MAX` which is aggregate function).
```sql
SELECT GREATEST(<column>, <another_column>) 
FROM <table>
```
Oposite for `GREATEST` is `LEAST` it returns least value from multiple columns for each row.

### Case
`CASE` allows to introduce logic in select statement.
```sql
SELECT <column>, 
CASE 
   WHEN <another_column> > <value> THEN 'HIGH'
   WHEN <another_column> < <another value> THEN 'MEDIUM'
   else 'CHEAP' 
FROM <table>
```

### Create index 
```sql
CREATE INDEX <name> ON <table> (<column>)
```
This creates standard B-Tree index on column in table.
Name of index should be in format "table_name_column_name_idx".

Index can be created on multiple columns
```sql
CREATE INDEX <name> ON <table> (<column1>, <column2>)
```

Also there can be unique index that allows to guarantee that column or columns have unique values 
```sql
CREATE UNIQUE INDEX <name> ON <table> (<column>)
```

Index can be also created on some subset of columns
```sql
CREATE UNIQUE INDEX <name> ON <table> (<column>) WHERE <condition>
```

Most database engines like PostgreSQL automatically creates indexes for primary key columns and columns with `unique` constraint. So there is no need to create indexes for those columns.  

### Removing index 
```sql
DROP INDEX <name>
```

### Query indexes in DB
```sql
SELECT relname, relkind
FROM pg_class
WHERE relkind = 'i'
```

### Benchmarking query
```sql
EXPLAIN ANALYZE <actual query>
```
It returns query plan, planing time and execution time

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

## Views
Basically view is query converted to a table. There are two types of views: standard view and materialized view. Standard view execute underlaying query every time when is accessed. Data in materalized view must me refreshed manually. 

### Create view
```sql
CREATE VIEW <name> AS (<query>)
```

### Updating view
```sql
CREATE OR REPLACE VIEW <name> AS (<query>)
```

### Create materialized view
```sql
CREATE MATERIALIZED VIEW <name> AS (<query>)
```

### Refresh materialized view
```sql
REFRESH MATERIALIZED VIEW <name>
```

### Deleting view
```sql
DROP VIEW <name>
```

##

### List stored procedures 
```sql
SELECT * FROM [XV8122017_June_Smoke].INFORMATION_SCHEMA.ROUTINES
 WHERE ROUTINE_TYPE = 'PROCEDURE' AND SPECIFIC_NAME LIKE '%arrangement%'
 AND LEFT(ROUTINE_NAME, 3) NOT IN ('sp_', 'xp_', 'ms_')
```

### Analytical/Window functions
**A window function performs a calculation across a set of table rows that are somehow related to the current row**, is comparable to the type of calculation that can be done with an aggregate function. However, window functions do not cause rows to become grouped into a single output row like non-window aggregate calls would. Instead, the rows retain their separate identities. Behind the scenes, the window function is able to access more than just the current row of the query result.
```sql
SELECT avg(<column>) OVER ([PARTITION BY <columns>] [ORDER BY <columns>]) from <table>;
```

If no parition is defined in `OVER()` clausule then whole table is an parition (see SQL Pagination section).

### SQL pagination
If you application need to return rows in portions aka paginated then followed query can be used to fetch portion of rows and count of all rows
```sql
SELECT <alias>.*, COUNT(*) OVER() as total_rows
FROM (<query returns all data>) as <alias>
LIMIT <page size>
OFFSET <page size * page index>
```

## JSONB in PostgreSQL 
JSONB columns in PostgreSQL allows to store and query JSON (JavaScript Object Notation) data efficiently. PostgreSQL provides various functions and operators to interact with JSONB data. 

Creating a Table with JSONB Column
```sql
CREATE TABLE my_table (
    id SERIAL PRIMARY KEY,
    data JSONB
);
```

Inserting data
```sql
INSERT INTO my_table (data) VALUES 
('{"name": "John", "age": 30, "address": {"city": "New York", "zip": "10001"}}'),
('{"name": "Jane", "age": 25, "address": {"city": "San Francisco", "zip": "94105"}}');
```

Selecting a Specific JSON Field
```sql
SELECT data->'name' AS name FROM my_table;
```

Selecting a Nested JSON Field
```sql
SELECT data->'address'->>'city' AS city FROM my_table;
```

Filtering rows
```sql
SELECT * FROM my_table WHERE data->>'name' = 'John';
```

Updating a Specific JSON Field
```sql
UPDATE my_table SET data = jsonb_set(data, '{age}', '31') WHERE data->>'name' = 'John';
```

Removing a JSON Field
```sql
UPDATE my_table SET data = data - 'phone';
```

Grouping by JSON Field
```sql
SELECT data->>'city' AS city, COUNT(*) FROM my_table GROUP BY data->>'city';
```

Unnesting JSON Arrays (convert each item in array to single row)
```sql
SELECT jsonb_array_elements(order_data->'items') AS item FROM orders;
```

Converting JSONB to Text
```sql
SELECT data::TEXT FROM my_table;
```

### Clear table
The TRUNCATE command is used to delete the complete data from the table. Is the fastest way to clear a table is to execute the TRUNCATE statement TABLE. Because this is a very low operation level (at the level of data blocks, not table rows), it is impossible to indicate the rows to be deleted. WITH for the same reason, it is impossible to truncate a related table with other tables, even if they are empty, which is for sure they do not contain references to the primary keys being deleted.

```sql
TRUNCATE TABLE [<table>];
```

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
