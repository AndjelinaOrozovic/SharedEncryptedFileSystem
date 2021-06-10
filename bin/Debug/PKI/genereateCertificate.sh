openssl req -new -key Users/$1/$1.key -out PKI/requests/$1.csr -config PKI/openssl.cnf -batch 2>> fajl1.txt

openssl ca -in PKI/requests/$1.csr -out PKI/certs/$1.pem -config PKI/openssl.cnf -key sigurnost -batch 2>> fajl2.txt