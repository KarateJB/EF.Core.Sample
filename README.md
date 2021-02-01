# EF Core Samples

## DB Migration

1. Create migration file

```s
$ cd src/EFCore.Ap
$ dotnet ef  --project ../EFCore.Dal --startup-project . migrations add InitCreate [--context PgDbContext]
```

2. Update database

```s
$ cd src/EFCore.Ap
$ dotnet ef  --project ../EFCore.Dal --startup-project . database update [--context PgDbContext]
```

## Revert migration

```s
$ cd src/EFCore.Ap
$ dotnet ef  --project ../EFCore.Dal --startup-project . database update <last_migration_name> [--context PgDbContext]
```

## Migrate DB container

```s
$ cd "src/EFCore.Ap"
$ dotnet ef --project "../efcore.dal" --startup-project . migrations script --idempotent [--context PgDbContext] --output "../../build/migration.sql"
```


## run sql script file in docker (postgresql container)

1. copy file from host

```
$ docker cp ./migration.sql <container_name>:tmp
```


2. execute sql

```
$ cd $root/tmp
$ psql -h localhost -p 5432 -U postgres -d Demo -f "migration.sql"
```



## DB query

```sql
SELECT
"Id",
"Name",
"Password",
my_sym_decrypt("Phone") as Phone,
my_sym_decrypt("CardNo") as CardNo 
FROM public."Users"
```