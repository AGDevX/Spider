# About Spider

Spider is meant to be a starter / educational RESTful Web Api with a few bells and whistles built in. It is slightly opinionated, but there's nothing that can't be changed to get the desired behavior.

This Api can be used out of the box for demo purposes, but if it's used as a basis for a new Api then there's a little customization that needs to happen. This README will get you going.

<br />

# Features

- Many platform-agnostic utilities and extensions
- Custom Api responses to convey request status beyond HTTP statuses
- Automatic Dependency Injection
- Easy configuration per environment
- Automapper integration
- Api versioning
- Simple CORS configuration
- Auth
	- JWT Bearer authorization via OAuth 2.0 with Auth0 as a provider
	- Api agnostic OAuth 2.0 handling and configuration
	- Authorized Roles and Scopes attributes to abstract away authZ from endpoints
	- Custom Claims Identity hydration
	- User authorization middleware
		- Kick users out before they get to the controller
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
	- Publish crofiles
	- Schema comparisons
	- Seed script

<br />

## Owl

The [Owl](https://github.com/AGDevX/Owl) application is a companion React SPA that can be used to demo SPA integration with Spider. It is by no means necessary to use Owl to call this API.

<br />
<br />

# Customizing Spider

If you like the behavior of the Api then most of the customization only needs to happen in the `appSettings` files. Otherwise, feel free to remove or change the functionality to your liking.

## Authentication & Authorization

Spider leverages the Auth0 platform to authorize users and to request access tokens using the Client Credentials flow for calling downstream Apis.

<br />

### AuthN (are you who you say you are?)

Spider uses the OAuth 2.0 protocol (upon which OIDC is based) to authorize users calling the Api, but it does not do anything specifically for authentication. Spider relies on user claims being added to access tokens after Auth0 creates an access token for clients. By having an access token, Spider knows that the authentication process has happened. Auth0 is configured to add claims to the access token via a custom action and Login Flow.

### AuthZ (are you allowed to do what you're trying to do?)

**Auth0 Setup**

The values used for the configuration should be changed to match your Api and application. Settings not explicitly called out were kept at their default value.

1. Create a free account at [auth0.com](https://auth0.com/)
2. Create a new Api
   - Name: _Spider Web Api - Dev_
   - Identifier: _api://agdevx/spider-web-Api/dev_
   - Enable RBAC: _true_
   - Add Permissions in the Access Token: _true_
   - Allow Skipping User Consent: _true_
   - Allow Offline Access: _true_
   - Permissions
		- Permission: _Api:access_
		- Description: _Permission to call the Api_
3. Configure the associated Machine to Machine application
	- This will be used for the Swagger config. Swagger is treated as if it were a client just like an SPA. This is because Swagger _is_ a client making a call to the Api.
	- Name: _Spider Web Api - Dev (Api Client)_
	- Allowed Callback URLs: _https://localhost:7264/swagger/oauth2-redirect.html_
	- Advanced Settings:
     - Grant Types: _Authorization Code_, _Client Credentials_
4. Use your Auth0 configuration to update the `appSettings` files.

4. Create a custom action and add it to the Login Flow

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

# Tech Debt

- Unit Tests
- Validation
- Improve Exception handling
	- Difficult to not log StackFrames when they are undesired
	- Decide if custom exceptions are the best way to go
- Improve config model
	- Throw exception if required config not found
- Improve logging
	- Automatically log method name
	- Log CorrelationId
	- Log app bulid version
	- DB logging