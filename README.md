# EF Core Samples

## DB Migration

1. Create migration file

```s
$ cd src/EFCore.Ap
$ dotnet ef  --project ../EFCore.Dal --startup-project . migrations add InitCreate
```

2. Update database

```s
$ dotnet ef  --project ../EFCore.Dal --startup-project . database update
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