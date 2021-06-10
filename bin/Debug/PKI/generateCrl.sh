imeListe="lista1.pem"
openssl ca -gencrl -out PKI/crl/$imeListe -config PKI/openssl.cnf -key sigurnost 2>> listerror.txt