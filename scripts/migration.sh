#!/bin/bash
/opt/mssql-tools/bin/sqlcmd -S db -U sa -P $MSSQL_SA_PASSWORD -d master -i /tmp/db_creation.sql