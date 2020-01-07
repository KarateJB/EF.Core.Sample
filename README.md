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