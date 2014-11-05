@Echo Off
cls

REM ***************************************************************************
REM **
REM **        Name: InstallDatabases
REM **        Desc: SQL Server Database Setup for Pet Shop 4 Application.
REM **
REM **        Date: 10/24/2005
REM **
REM **************************************************************************/

@Echo.
@Echo *******************************************************************************
@Echo *                                                                             *
@Echo * Pet Shop 4 Database Setup Script                                            *
@Echo *                                                                             *
@Echo *                                                                             *
@Echo * This script will create Pet Shop 4 databases and register them              *
@Echo * for Sql Cache Dependency. You should have SQL Server 2005 installed         *
@Echo * on you local machine as default instance.                                   *
@Echo *                                                                             *
@Echo * Modify this script to reflect the way you connect to the SQL Server         *
@Echo * as well as if location of the .NET 2.0 runtime on your computer             *
@Echo * is different from C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727.            *
@Echo *                                                                             *
@Echo * If you wish to cancel, press [CTRL]-C to terminate the batch job.           *
@Echo *                                                                             *
@Echo *******************************************************************************
@Echo. 
pause

@Echo.
@Echo.
@Echo *******************************************************************************
@Echo * Creating Databases...                                                       *
@Echo *******************************************************************************
@Echo. 

C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_regsql -S . -E -A all -d Mes
@Echo.
@Echo.
@Echo *******************************************************************************
@Echo * Configuring Logins...                                                       *
@Echo *******************************************************************************
@Echo. 



@Echo.
@Echo.
@Echo *******************************************************************************
@Echo * Creating Tables...                                                          *
@Echo *******************************************************************************
@Echo. 


@Echo.
@Echo.
@Echo *******************************************************************************
@Echo * Loading Data...                                                             *
@Echo *******************************************************************************
@Echo. 

osql -E -i LoadTables1.sql

@Echo.
@Echo. 
@Echo *******************************************************************************
@Echo * Registering Databases for SQL Cache Dependency...                           *
@Echo *******************************************************************************
@Echo.



@Echo.
@Echo.
@Echo *******************************************************************************
@Echo *                                                                             *
@Echo * Database Setup Complete                                                     *
@Echo *                                                                             *
@Echo *******************************************************************************
@Echo.
pause