/* HASH */
DO $function$
BEGIN
DROP FUNCTION IF EXISTS public.my_hash;
DROP FUNCTION IF EXISTS public.my_hash_match;
END;
$function$

/* PGP: Symmetric */
DO $function$
BEGIN
DROP FUNCTION IF EXISTS public.my_sym_encrypt;
DROP FUNCTION IF EXISTS public.my_sym_decrypt;
END;
$function$


/* PGP: Asymmetric */
DO $function$
BEGIN
DROP FUNCTION IF EXISTS public.my_pub_encrypt;
DROP FUNCTION IF EXISTS public.my_pvt_decrypt;
END;
$function$
