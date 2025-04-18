## Data structure in MongoDB

- Database
  - Collections (like tables in SQL)
    - Documents (like datapiecies or rows in SQL)

All those structures are created implicitly (automatically) when you start work with them. So no prior schema definition is needed.

All commands in this document refers to mongodb shell `mongosh`. Syntax for diver in particular programming language may be different but usually keeep the convention.

Documents are in fact JSON documents. So any valid JSON can be inserted into collection. Under the hood MongoDB keeps it in BSON format, but this is technical details that user dont have to care of.

Mongo DB also adds some special types to document like autogenerated id for each document. It is like `ObjectId('...')`, you can add your own id for document. When inserting document add `_id` key to document (underscore is required).

The quotation marks around keys in JSON documents can be ommited as long as it does not contains space.

Documents in the same collection don't have to have same schema.

### Filters

Filter in examples below is JSON object that allows to specify object to find, update or delete. So for example there can be an object

```JSON
{"name":"John", "age":30, "car":null}
```

So filter, in case you need to find "John" will be

```JSON
{"name": "John"}
```

If you want match all documents in collection use empty filter `{}`

Filters albo can be conditional. For example you want to find documents where `age` is greater than `25`. Then filter will looks like `{age: {$gt: 25}}`

### List databases

```
show dbs
```

### Switch to database (database does not have to exist)

```
use <database name>
```

To refer to current database use `db`

### Use collection

```
db.<collection>
```

### Insert document into collection

```
db.<collection>.insertOne({...})
```

### Insert many documents into collection (it accepts array as an argument)

```
db.<collection>.insertMany([...])
```

### Get documents in collection

```
db.<collection>.find(<filter>, <options>)
```

Find does not return all documents it returns a cursor to collection that can be iterated. So in JS it can be `db.<collection>.find().forEach((document) => {...})`

### Get single document from collection

```
db.<collection>.findOne(<filter>, <options>)
```

### Update document

```
db.<collection>.updateOne(<filter>, <data>, <options>)
```

Document update require to use special convention to instruct MongoDB how exactly update data.
So If you want set field in document the `data` param must contain special operator `$set` that will contain document to update.

```
db.<collection>.updateOne(<filter>, {$set: {<key>: <value>}})
```

### Update many documents

```
db.<collection>.updateMany(<filter>, <data>, <options>)
```

### Replace document

```
db.<collection>.replaceOne(<filter>, <data>, <options>)
```

### Delete document

```
db.<collection>.deleteOne(<filter>, <options>)
```

### Delete many documents

```
db.<collection>.deleteMany(<filter>, <options>)
```

### Limit data returned to client

As in SQL query can specify which data should be returned MongoDB uses `Projection` to select subset of fields from document.

```
db.<collection>.findOne(<filter>, {<field> : 1})
```

0 - don't include data
1 - include data

Projection happens in MongoDB serwer so should be used to limit data send over the wire

### Accessing structured data

```
db.<collection>.findOne(<filter>).<nested property>
```

### Filter by nested field

```
db.<collection>.find({ "<field>.<nested field>": "<value>"})
```

### Comparision operators (https://www.mongodb.com/docs/manual/reference/operator/query-comparison/)
Comparision operators like `$eq`, `$ne`, `$gt`, `$lt` can be used in `find` and `findOne` to filter results.
```
db.<collection>.findOne({ <field>: {$eq <value>}})
```

### Logical operators 
Logical operators like `$and`, `$or` etc. allows to join conditions 
```
db.<collection>.findOne({ $and: [ { <field>: { $ne: <value> } }, { <field>: { $exists: <value> } } ])
```

### Element operators (https://www.mongodb.com/docs/manual/reference/operator/query-element/)
Element operators: `$exists`, `$type` element operators return data based on field existence or data types.

### Remove database

```
use <database name>
db.dropDatabase()
```

### Remove collection

```
db.<collection>.drop()
```

### Data Types

- `Text` eg. "Test"
- `Boolean` eg. `true` or `false`
- `Nmber`
  - `Integer` - 32 bits integer values
  - `NumberLong` - 64 bits integer values
  - `NumberDecimal` - store high precision decimal values
- `ObjectId` eg. ObjectId('...')
- `ISODate` - date, time and timestamps
- `Array` - just JSON array
- `Object` - just JSON Object

### Relations

- For strong one-to-one relation is recommended to use nested (embeded) document not separate collection.
- For one-to-many relations is also recommended to use nested (embeded) document. But there are cases when data should be in separate collections.
  For example if there is a need to load documents from one collection only (without related documents) or collections are huge and from performance reasons document with all related data canot be loaded.
- For many-to-many relations both ways can be used. When related data can be duplicated and are basically a snapshot of data that never change then can be embeded but when related data always should be up to date then reference approach is recommended.

For more details see https://www.udemy.com/course/mongodb-the-complete-developers-guide/learn/lecture/11758286#overview

Two collections can be joined using `$lookup` operator. It oerforms a left outer join to a collection in the same database to filter in documents from the "joined" collection for processing. The `$lookup` stage adds a new array field to each input document. The new array field contains the matching documents from the "joined" collection.

```json
{
   $lookup:
     {
       from: <collection to join>,
       localField: <field from the input documents>,
       foreignField: <field from the documents of the "from" collection>,
       as: <output array field>
     }
}
```

### Cursor
Cursor is returned by `find()`function. Cursor is basically a pointer that has query stored and allows to get quickly next portion of data.