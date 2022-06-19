# OAuth Workflow
This project is a simplified implementation of an authentication flow in the oauth2 pattern, several important details to ensure security in a real world scenario were purposely hidden to make it easier to understand.

## Project Configuration
Open a terminal or command prompt and run the following commands to clone the repository
```
    git clone https://github.com/lucasfts/oauth-workflow.git
```
After cloning the repository, enter the root folder and run the following command to create the encryption keys
```
    cd oauth-workflow
    openssl genrsa -out private-key.pem 4096
    openssl rsa -in private-key.pem -pubout -out public-key.pem
```
Move the private key to the project folder that generates the authentication tokens (On linux use mv instead of move)
```
    move private-key.pem AuthorizationServer/private-key.pem
```
Move the public key to the project folder that needs to validate the token (On linux use mv instead of move)
```
    move public-key.pem ResourceServer/public-key.pem
```

### Running the project
To run the project in a simple way, you will need to have docker installed and run the following command:
```
    docker compose up
```
After executing the command, the application will be available at http://localhost:8080
