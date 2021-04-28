/* Drop function */
DO $function$
BEGIN
DROP FUNCTION IF EXISTS system.get_secret;
END;
$function$

/* (Optional) Drop user */
--DO $user$
--BEGIN

--REVOKE ALL PRIVILEGES ON DATABASE "postgres" from my_user; 
--DROP USER IF EXISTS my_user;

--END
--$user$;

/* Drop table */
DO $table$
BEGIN

IF EXISTS(
		SELECT table_name
		FROM   information_schema.tables
		WHERE  table_schema = 'system'
		AND    table_name = 'Secrets'
    )
THEN
	DROP TABLE system.Secrets;
END IF;
END
$table$;

/* Drop schema */
DO $schema$
BEGIN

DROP SCHEMA IF EXISTS system;

END

$schema$;								 																									  
