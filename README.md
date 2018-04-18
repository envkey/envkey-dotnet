# EnvKey for .net Framework

[NuGet Package](https://www.nuget.org/packages/EnvKey)  
[EnvKey Releases](https://github.com/envkey/envkey-fetch/releases)

# Usage

```cs
var envKey = new EnvKeyConfig();
var success = envKey.TryLoadIntoEnvironment();

Stripe.ApiKey = Environment.GetEnvironmentVariable("STRIPE_SECRET_KEY");
```

## Building

### Preface

Versions of envkey should go hand in hand with the nuget package version to keep things tidy.  
That means that a envkey version 1.2.0 should be downlaoded (via `download_envkey.bat`) and a package should be generated with version 1.2.0 (via `build.bat` and `pack.bat`).  
To release library changes that refer to a certain version of envkey, the package should get a build-version extension, eg. 1.2.0.**3**.

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
