# FerzuSharp
ferzu api wrapper (i want to die) 

# usage

### First
#### You
##### gotta
## authenticate

ferzu does some weird basic auth hackery where things are b64 encoded twice.  before using the `FurryFucker` static class, call the `Init` method, passing in your username and password.

e.g.

```cs
FurryFucker.Init("dad", "nice");

// now you can make API calls
var statuses = await FurryFucker.GetNewsFeed();
```

add the .csproj or a compiled .dll to your project because i'm not putting this shit on NuGet.

Currently only supports `GetNewsFeed` for `Global` and `Local`.

# why

idk

## commerical products

please dont do that

this code is messy as sshit
