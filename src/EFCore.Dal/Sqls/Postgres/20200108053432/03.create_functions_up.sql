/* HASH */
--Hash							 
CREATE OR REPLACE FUNCTION public.my_hash(t text) RETURNS text  AS $function$
BEGIN
   RETURN crypt(t, gen_salt('md5'));
END;
$function$ LANGUAGE plpgsql;

--Is Match
CREATE OR REPLACE FUNCTION public.my_hash_match(t text, hashed text) RETURNS boolean  AS $function$
BEGIN
   RETURN (hashed = crypt(t, hashed)) AS IsMatch;
END;
$function$ LANGUAGE plpgsql;

/* PGP: Symmetric */
--Encrypt
--CREATE OR REPLACE FUNCTION public.my_sym_encrypt(t text, secret text) RETURNS bytea AS $function$
--BEGIN
--   RETURN pgp_sym_encrypt(t, secret);
--END;
--$function$ LANGUAGE plpgsql;
						  
--Decrypt
--CREATE OR REPLACE FUNCTION public.my_sym_decrypt(t bytea, secret text) RETURNS text AS $function$
--BEGIN
--   RETURN pgp_sym_decrypt(t, secret);
--END;
--$function$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION public.my_sym_encrypt(t text) RETURNS bytea AS $function$
BEGIN
   RETURN pgp_sym_encrypt(t, system.get_secret());
END;
$function$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION public.my_sym_decrypt(t bytea) RETURNS text AS $function$
BEGIN
   RETURN pgp_sym_decrypt(t, system.get_secret());
END;
$function$ LANGUAGE plpgsql;
						  
--SELECT my_sym_decrypt(my_sym_encrypt('AWESOME1234'))
						  

/* PGP: Asymmetric */
--Encrypt
CREATE OR REPLACE FUNCTION public.my_pub_encrypt(t text) RETURNS bytea AS $function$
BEGIN
   RETURN pgp_pub_encrypt(t, dearmor(pg_read_file('keys/public.key')));
END;
$function$ LANGUAGE plpgsql;
						  

--Decrypt
CREATE OR REPLACE FUNCTION public.my_pvt_decrypt(t bytea) RETURNS text AS $function$
BEGIN
   RETURN pgp_pub_decrypt(t,dearmor(pg_read_file('keys/private.key')));
END;
$function$ LANGUAGE plpgsql;