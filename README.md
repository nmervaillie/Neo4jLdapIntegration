Simple Neo4j LDAP integration example

This project contains :

- a docker compose file declaring
  - an openldap container
  - a phpLdapAdmin container
  - a neo4j container plugged on the openldap

- the ldap configuration with different users (`ldap-data` directory)

- a simple C# client example to test authentication 
