# EnvKey for .net Framework

Integrate [EnvKey](https://www.envkey.com) with your .net projects to keep api keys, credentials, and other configuration securely and automatically in sync for developers and servers.

## Installation

envkey-dotnet is distributed as a [NuGet Package](https://www.nuget.org/packages/EnvKey). Please refer to the [NuGet Documentation](https://docs.microsoft.com/en-us/nuget/consume-packages/overview-and-workflow) for instructions on installing a package through the Visual Studio Package Manager UI or the command line.

## Usage

First, generate an `ENVKEY` in the [EnvKey App](https://github.com/envkey/envkey-app). Then set `ENVKEY=...`, either in a gitignored `.env` file in the root of your project (in development) or in an environment variable (on servers).

Next, initialize the envkey package at the start of your project's `Main` method.

```cs
var envKey = new EnvKeyConfig();
var success = envKey.Load();
```

Now you can access your EnvKey config anywhere you need it using `Environment.GetEnvironmentVariable` and these values will always be up-to-date.

```cs
Stripe.ApiKey = Environment.GetEnvironmentVariable("STRIPE_SECRET_KEY");
```

### Errors

The package will throw an error if an `ENVKEY` is missing or invalid.

### Overriding Vars

This package will not overwrite existing environment variables or additional variables set in a `.env` file. This can be convenient for customizing environments that otherwise share the same configuration. You can also use [sub-environments](https://blog.envkey.com/development-staging-production-and-beyond-85f26f65edd6) in the EnvKey app for this purpose.

### Working Offline

This package caches your encrypted config when in `DEBUG` mode so that you can still use it while offline. Your config will still be available (though possibly not up-to-date) the next time you lose your internet connection. If you do have a connection available, envkey-dotnet will always load the latest config. Your cached encrypted config is stored in `$HOME/.envkey/cache`

## envkey-fetch binaries

If you look at the `NuGet/download_envkey.bat` script, you'll find that a number of `envkey-fetch` binaries for various platforms are pulled into the package before release. These are output by the [envkey-fetch Go library](https://github.com/envkey/envkey-fetch). It contains EnvKey's core cross-platform fetching, decryption, verification, web of trust, redundancy, and caching logic. It is completely open source.

## Further Reading

For more on EnvKey in general:

Read the [docs](https://docs.envkey.com).

Read the [integration quickstart](https://docs.envkey.com/integration-quickstart.html).

Read the [security and cryptography overview](https://security.envkey.com).

## Need help? Have questions, feedback, or ideas?

Post an [issue](https://github.com/envkey/envkey-ruby/issues) or email us: [support@envkey.com](mailto:support@envkey.com).

## For Contributors - Build Instructions

### Preface

Versions of envkey should go hand in hand with the nuget package version to keep things tidy.  
That means that a envkey version 1.2.4 should be downloaded (via `download_envkey.bat`) and a package should be generated with version 1.2.4 (via `build.bat` and `pack.bat`).  
To release library changes that refer to a certain version of envkey, the package should get a build-version extension, eg. 1.2.4.**3**.

### Requirements

To keep things simple you need to install Visual Studio 2017.

Run `NuGet\download_envkey.bat`. This will download the envkey executable. You'll asked for a version number of envkey.

### Build

Run `NuGet\build.bat`. This will restore all packages and creates a clean release build.

### Run Tests

Run `NuGet\runtests.bat "YOUR_KEY"`. This will execute all the test console applications in various .net configurations.  
Be aware that the tests use the nuget packages to be sure that they're working.

To ease the process of testing, the NuGet folder is marked as nuget source folder so you can create a nuget package (via `pack.bat`) and update the packages via VisualStudio using the `Local EnvKey Nuget Folder` source.

### Nuget Publish

run `NuGet\pack.bat` to create a package. You'll be asked to provide a version number.  
"1.0.2" will create a package with the version 1.0.2  
"1.2.0-??" where "??" can be everything from a name to other version numers to mark the package as prerelease.

Run `NuGet\push.bat` to upload the package to nuget. You'll be asked to provide an api key to identify yourself als owner of the package.  
Please refere to [the documentation](https://www.nuget.org/account/apikeys) how to obtain an api key.
