# Description
This is a simple package, which provides auto mapping of environment variables into a public properties of a derived class.

# Usage
Create class and inherit EnvironmentVariables abstract class.
Add public properties matching the environment variable name.
You must call Init method before using  your class.

Example:
If you want access to ASPNETCORE_ENVIRONMENT environment variable, inherit EnvironmentVariables abstract class and add public property named ASPNETCORE_ENVIRONMENT.
Call Init method and your property will be provided with the environment variable value
