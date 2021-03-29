# SQL

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
