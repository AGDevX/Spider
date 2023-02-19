# Tech Debt

- Automatically add given_name and family_name to users in Auth0
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