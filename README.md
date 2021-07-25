# vexil-dotnet

*Vexil is still a work in progress and not ready for use. You can star/watch the project to follow along!*

Vexil makes feature flags better by decoupling providers from the client. Check if a feature flag is enabled by simply calling 

```csharp
if (_vexil.IsEnabled("my-feature-flag"))
{
  // code
}
else
{
  // code
}
```

At startup, wire up a feature flag provider of your choosing. Right now, we plan on supporting Unleash, IConfiguration, Google Sheets, and a generic REST API - or make your own! 

Vexil was created because we wanted a lightweight feature flag system (we were hoping to just use Google Sheets), but were worried that we would need a more robust solution later. Vexil lets us start out with a feature flag provider that fits our needs, and swap out that provider when we've outgrown it.  

## Installation

The planned installation will include two Nuget packages, one for the Vexil Client and one for the provider of your choosing.

## Usage

The planned usage path includes some configuration at Startup (registering the Vexil client and choosing a provider), some information sharing with a Vexil Context (things like current user id, etc.), and injection of the Vexil Client wherever it's needed.

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.
