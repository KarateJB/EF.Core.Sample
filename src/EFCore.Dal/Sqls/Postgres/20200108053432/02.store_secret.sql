DO $schema$
BEGIN

IF NOT EXISTS(
		SELECT schema_name
        FROM information_schema.schemata
        WHERE schema_name = 'system'
    )
THEN
    /* Create schema */
	CREATE schema system;
	REVOKE CREATE ON schema system FROM public;

END IF;
END
$schema$;

DO $table$
BEGIN

IF NOT EXISTS(
		SELECT table_name
		FROM   information_schema.tables 
		WHERE  table_schema = 'system'
		AND    table_name = 'Secrets'
    )
THEN
	/* Create table */
	CREATE TABLE system."Secrets" (
		"Cipher" bytea NOT NULL
	);

END IF;
END
$table$;

DO $user$
BEGIN

IF NOT EXISTS(
		SELECT "rolname" FROM pg_roles WHERE rolname='sa'
    )
THEN
	/* Create sa and grant permissions */
	CREATE USER sa WITH PASSWORD '12qwaszx';
	GRANT CONNECT ON DATABASE "MiniTis" TO sa;
	--GRANT SELECT, INSERT, UPDATE, DELETE ON ALL TABLES IN SCHEMA system TO sa;
	GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA system TO sa;
	--ALTER DEFAULT PRIVILEGES FOR USER postgres IN SCHEMA system REVOKE ALL ON TABLES FROM postgres;
END IF;
END
$user$;

DO $secret$
BEGIN

IF NOT EXISTS(
		SELECT "Cipher" FROM system."Secrets" limit 1
    )
THEN
	/* Insert a cipher as a secret */
	INSERT INTO system."Secrets"("Cipher") VALUES(pgp_pub_encrypt('You should replace your secret here', dearmor(pg_read_file('keys/public.key'))));
	--SELECT "Cipher" FROM system."Secrets" limit 1	 								
END IF;
END
$secret$;
																	   
																									  
/* Create a function to get the secret */
CREATE OR REPLACE FUNCTION system.get_secret() RETURNS text AS $function$
BEGIN
	RETURN pgp_pub_decrypt((SELECT "Cipher" FROM system."Secrets" limit 1), dearmor(pg_read_file('keys/private.key')));
END;
$function$ LANGUAGE plpgsql;

--SELECT get_secret()
									
	
	
