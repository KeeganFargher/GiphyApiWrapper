## GiphyApiWrapper (Alpha)
This is a simple wrapper for consuming Giphy endpoints in .NET. GiphyApiWrapper allows you to consume the Giphy API without having to handle the requests yourself.

### Build Status
[![Build Status](https://dev.azure.com/fargherkeegan/GiphyApiWrapper/_apis/build/status/KeeganFargher.GiphyApiWrapper?branchName=master)](https://dev.azure.com/fargherkeegan/GiphyApiWrapper/_build/latest?definitionId=7&branchName=master)

### Getting Started
Either `Install-Package GiphyApiWrapper` or just search for `GiphyApiWrapper` in the Nuget package manager.

## Usage

Most endpoints return a [RootObject](https://developers.giphy.com/docs/#gif-object)  unless otherwise specified.

### Search
```c#
var giphy = new Giphy("YOUR_API_KEY");
var paramter = new SearchParameter
{
    Query = "GIF vs JIF", // Query is required
    Limit = 5
    // ...
};
RootObject result = await giphy.Search(parameter);
```

### Trending
```c#
var giphy = new Giphy("YOUR_API_KEY");
var paramter = new TrendingParameter
{
    Limit = 25,
    Offset = 0
    // ...
};
RootObject result = await giphy.Trending(paramter);
```

### Translate
```c#
var giphy = new Giphy("YOUR_API_KEY");
var paramter = new TranslateParameter
{
    Query = "Cute kittens", // Query is required
    Weirdness = 10
    // ...
};
RootObject result = await giphy.Translate(paramter);
```
