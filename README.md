# About Spider

Spider is meant to be a starter / educational / inspirational RESTful Web API with a few bells and whistles built in. It is kind of opinionated, but there's nothing that can't be changed to get the desired behavior.

If this is used as a basis for a new API then there's a little customization that needs to happen. This README will get you going.

<br />

## Demo

You can see this API running at [https://spider-netcore.azurewebsites.net/swagger](https://spider-netcore.azurewebsites.net/swagger). This API isn't hitting a database when hosted in Azure. It may be a little slow to load because it's running on an Azure App Service free tier.

- Auth0 test credentials
  - Email: august.geier@reddwarfjmcagdx.com
  - Password: Itscoldoutside1

<br />
<br />

# Features

- Many platform-agnostic utilities and extensions
- Custom API responses to convey request status beyond HTTP statuses
- Automatic Dependency Injection
- Easy configuration per environment
- Automapper integration
- API versioning
- Simple CORS configuration
- Auth
  - JWT Bearer authorization via OAuth 2.0 with Auth0 as a provider
  - API agnostic OAuth 2.0 handling and configuration
  - Authorized Roles and Scopes attributes to abstract away authZ from endpoints
  - Custom Claims Identity hydration
  - User authorization middleware
    - Authorize users before they get to the controller
  - Machine to machine access token requests for calling downstream Apis
- Exceptions
  - Custom exceptions to differentiate .NET and library exceptions from Spider exceptions
  - Global unhandled exception handler
  - Easily consumable and readable exception information
- Swagger
  - OAuth 2.0 schema definition
  - Enable/Disable per environment
  - Versioning support
  - XML comments support
- Logging
  - Serilog via Microsoft.Extensions.Logging
    - Console sink installed
    - A number of enrichers are also installed
- Database
  - Dapper integration w/ extension methods
  - Companion database with User and Role tables and sprocs
  - Publish profiles
  - Schema comparisons
  - Seed script
- Hosting deployment instructions

<br />

## Owl

The [Owl](https://github.com/AGDevX/Owl) application is a companion React SPA that can be used to demo SPA integration with Spider. It is by no means necessary to use Owl to call this API.

<br />
<br />

# Customizing Spider

If you like the behavior of the API then most of the customization only needs to happen in the `appSettings` files. Otherwise, feel free to remove or change the functionality to your liking.

<br />

## Authentication & Authorization

Spider leverages the Auth0 platform to authorize users and to request access tokens using the Client Credentials flow for calling downstream Apis.

<br />

### AuthN (are you who you say you are?)

Spider uses the OAuth 2.0 protocol (upon which OIDC is based) to authorize users calling the API, but it does not do anything specifically for authentication. Spider relies on user claims being added to access tokens after Auth0 creates an access token for clients. By having an access token, Spider knows that the authentication process has happened. Auth0 is configured to add claims to the access token via a custom action and Login Flow.

### AuthZ (are you allowed to do what you're trying to do?)

**Auth0 Setup**

The values used for the configuration should be changed to match your API and application. Settings not explicitly called out were kept at their default value.

1. Create a free account at [auth0.com](https://auth0.com/)

2. Create a new API

   - Name: _Spider Web API - Dev_
   - Identifier: _api://agdevx/spider-web-API/dev_
   - Enable RBAC: _true_
   - Add Permissions in the Access Token: _true_
   - Allow Skipping User Consent: _true_
   - Allow Offline Access: _true_
   - Permissions
     - Permission: _api:access_
     - Description: _Permission to call the API_

3. Configure the associated Machine to Machine application

   - This will be used for the Swagger config. Swagger is treated as if it were a client just like an SPA. This is because Swagger _is_ a client making a call to the API.
   - Name: _Spider Web API - Dev (API Client)_
   - Allowed Callback URLs: _https://localhost:7264/swagger/oauth2-redirect.html_
   - Advanced Settings:
   - Grant Types: _Authorization Code_, _Client Credentials_

4. Create a user in Auth0

   - Assign to the user the _api:access_ scope
   - Assign to the user the _Employee_ role (this role is pre-defined by Auth0)
   - Use Auth0's API Explorer to set the user's `given_name` and `family_name`

5. Use your Auth0 configuration to update the `appSettings` files.

6. Create a custom action and add it to the Login Flow
   - This will add user claims to the id and access tokens

```
/**
* Handler that will be called during the execution of a PostLogin flow.
*
* @param {Event} event - Details about the user and the context in which they are logging in.
* @param {PostLoginAPI} api - Interface whose methods can be used to change the behavior of the login.
*/
exports.onExecutePostLogin = async (event, api) => {
  api.accessToken.setCustomClaim("request_ip", event.request.ip)
  api.accessToken.setCustomClaim("app_metadata", event.user.app_metadata)
  api.accessToken.setCustomClaim("created_at", event.user.created_at)
  api.accessToken.setCustomClaim("updated_at", event.user.updated_at)

  api.accessToken.setCustomClaim("email", event.user.email)
  api.accessToken.setCustomClaim("email_verified", event.user.email_verified)
  api.accessToken.setCustomClaim("phone_number", event.user.phone_number)
  api.accessToken.setCustomClaim("phone_verified", event.user.phone_verified)

  api.accessToken.setCustomClaim("family_name", event.user.family_name)
  api.accessToken.setCustomClaim("given_name", event.user.given_name)
  api.accessToken.setCustomClaim("nickname", event.user.nickname)
  api.accessToken.setCustomClaim("name", event.user.name)

  api.accessToken.setCustomClaim("sub", event.user.user_id)
  api.accessToken.setCustomClaim("user_id", event.user.user_id)
  api.accessToken.setCustomClaim("picture", event.user.picture)

  api.idToken.setCustomClaim("request_ip", event.request.ip)
  api.idToken.setCustomClaim("app_metadata", event.user.app_metadata)
  api.idToken.setCustomClaim("created_at", event.user.created_at)
  api.idToken.setCustomClaim("updated_at", event.user.updated_at)

  api.idToken.setCustomClaim("email", event.user.email)
  api.idToken.setCustomClaim("email_verified", event.user.email_verified)
  api.idToken.setCustomClaim("phone_number", event.user.phone_number)
  api.idToken.setCustomClaim("phone_verified", event.user.phone_verified)

  api.idToken.setCustomClaim("family_name", event.user.family_name)
  api.idToken.setCustomClaim("given_name", event.user.given_name)
  api.idToken.setCustomClaim("nickname", event.user.nickname)
  api.idToken.setCustomClaim("name", event.user.name)

  api.idToken.setCustomClaim("sub", event.user.user_id)
  api.idToken.setCustomClaim("user_id", event.user.user_id)
  api.idToken.setCustomClaim("picture", event.user.picture)
};


/**
* Handler that will be invoked when this action is resuming after an external redirect. If your
* onExecutePostLogin function does not perform a redirect, this function can be safely ignored.
*
* @param {Event} event - Details about the user and the context in which they are logging in.
* @param {PostLoginAPI} api - Interface whose methods can be used to change the behavior of the login.
*/
// exports.onContinuePostLogin = async (event, api) => {
// };

```

<br />
<br />

# Start the application

- Hit the play button

<br />
<br />

# Deployment

<br />

## Microsoft Azure - App Service

Microsoft offers are free tier for App Services. Custom domains are not supported with the free tier.

- Set up an Azure account (these are free; the services incur the costs)
- Create an Azure Subscription (these are free; the services incur the costs)
- Create an App Service Plan (there is a free tier)
- Create an App Service
- Create a Publish Profile for the web application project
  - Add `<EnvironmentName>ENV_NAME</EnvironmentName>` to the `.pubxml` file to set the `ASPNETCORE_ENVIRONMENT`
    - This can be set in the existing `PropertyGroup` tag
    - If this does not work, in the App Service `Configuration` blade, add a new application setting
      - Name: `ASPNETCORE_ENVIRONMENT`
      - Value: `ENV_NAME`
- Run the Publish Profile to deploy
  - View deployment information by looking at the `Deployment Center` blade in the App Service for the API
- Create a prod app registration with Auth0 using your custom URLs or the URLs provided by Azure

<br />
<br />

# Tech Debt

- More unit tests
- Auto create user in Auth0
  - Set `given_name` and `family_name`
  - Set _api:access_ permission
- Validation
- Improve Exception handling
  - Difficult to not log StackFrames when they are undesired
- Improve config model
  - Throw exception if required config not found
- Improve logging
  - Automatically log method name
  - Log CorrelationId
  - Log app build version
  - DB logging
- Create DateTimeProvider
- Return custom ForbiddenResponse in AuthZ attributes
