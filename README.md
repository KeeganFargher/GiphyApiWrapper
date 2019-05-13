# GiphyApiWrapper

This is a simple wrapper for consuming Giphy endpoints in .NET. GiphyApiWrapper allows you to consume the Giphy API without having to handle the requests yourself.

## Build Status

[![Build Status](https://dev.azure.com/fargherkeegan/GiphyApiWrapper/_apis/build/status/KeeganFargher.GiphyApiWrapper?branchName=master)](https://dev.azure.com/fargherkeegan/GiphyApiWrapper/_build/latest?definitionId=7&branchName=master)
[![CodeFactor](https://www.codefactor.io/repository/github/keeganfargher/giphyapiwrapper/badge)](https://www.codefactor.io/repository/github/keeganfargher/giphyapiwrapper)

## Getting Started

### Prerequisites

-   .NET Standard 2.0
-   Preferably Visual Studio / VS Code

### Nuget

`Install-Package GiphyApiWrapper`  
Head over to [Nuget](https://www.nuget.org/packages/GiphyApiWrapper/) to view more download options.

### Clone

```batch
git clone https://github.com/KeeganFargher/GiphyApiWrapper.git
cd GiphyApiWrapper
dotnet publish
dotnet test
```

## Contributing

Pull requests are definitely welcome.

## Usage

You can head over to [Giphy Developers](https://developers.giphy.com) to view more information
about the various API endpoints.  
Most methods below will return a [RootObject](https://developers.giphy.com/docs/#gif-object).

### Search

```csharp
using GiphyApiWrapper;
using GiphyApiWrapper.Models.Parameters;

var giphy = new Giphy("YOUR_API_KEY");
var parameter = new SearchParameter
{
    Query = "GIF vs JIF",   // Required
    Limit = 5,              // (Optional) Default - 25
    Offset = 2,             // (Optional) Default - 0
    Rating = Rating.G,      // (Optional) Default - G
    Language = "en"         // (Optional) Default - "en"
};
RootObject result = await giphy.Search(parameter);
```

### Trending

```csharp
using GiphyApiWrapper;
using GiphyApiWrapper.Models.Parameters;

var giphy = new Giphy("YOUR_API_KEY");
var parameter = new TrendingParameter
{
    Limit = 25,             // (Optional) Default - 25
    Offset = 2,             // (Optional) Default - 0
    Rating = Rating.G       // (Optional) Default - G
};
RootObject result = await giphy.Trending(parameter);
```

### Translate

```csharp
using GiphyApiWrapper;
using GiphyApiWrapper.Models.Parameters;

var giphy = new Giphy("YOUR_API_KEY");
var parameter = new TranslateParameter
{
    Query = "Cute kittens", // Required
    Weirdness = 10          // (Optional) Default - 10
};
GiphySingle result = await giphy.Translate(parameter);
```

### Random

```csharp
using GiphyApiWrapper;
using GiphyApiWrapper.Models.Parameters;

var giphy = new Giphy("YOUR_API_KEY");
var parameter = new RandomParameter
{
    Tag = "Cute kittens", // (Optional)
    Rating = Rating.G     // (Optional) Default - G
};
GiphySingle result = await giphy.Random(parameter);
```

### GIF by ID

```csharp
using GiphyApiWrapper;
using GiphyApiWrapper.Models.Parameters;

var giphy = new Giphy("YOUR_API_KEY");
var id = "xT4uQulxzV39haRFjG";
GiphySingle result = await giphy.GifById(id);
```

### GIFs by IDs

```csharp
using GiphyApiWrapper;
using GiphyApiWrapper.Models.Parameters;

var giphy = new Giphy("YOUR_API_KEY");
var ids = new List<string>
{
    "xT4uQulxzV39haRFjG",
    "d89jAdjnfg5JmdaIea"
};
RootObject result = await giphy.GifsById(ids);
```

## Stickers

### Sticker Search

```csharp
using GiphyApiWrapper;
using GiphyApiWrapper.Models.Parameters;
using GiphyApiWrapper.Models.Parameters.Stickers;

var giphy = new Giphy("YOUR_API_KEY");
var parameter = new StickerSearchParameter
{
    Query = "Cute doggies", // Required
    Limit = 5,              // (Optional) Default - 25
    Offset = 2,             // (Optional) Default - 0
    Rating = Rating.G,      // (Optional) Default - G
    Language = "en"         // (Optional) Default - "en"
};
RootObject result = await giphy.StickerSearch(parameter);
```

### Sticker Translate

```csharp
using GiphyApiWrapper;
using GiphyApiWrapper.Models.Parameters;
using GiphyApiWrapper.Models.Parameters.Stickers;

var giphy = new Giphy("YOUR_API_KEY");
var parameter = new StickerTranslateParameter
{
    Query = "Cute doggies" // Required
};
GiphySingle result = await giphy.StickerTranslate(parameter);
```

### Sticker Trending

```csharp
using GiphyApiWrapper;
using GiphyApiWrapper.Models.Parameters;
using GiphyApiWrapper.Models.Parameters.Stickers;

var giphy = new Giphy("YOUR_API_KEY");
var parameter = new StickerTrendingParameter
{
    Limit = 5,              // (Optional) Default - 25
    Rating = Rating.G       // (Optional) Default - G
};
RootObject result = await giphy.StickerTrending(parameter);
```

### Sticker Random

```csharp
using GiphyApiWrapper;
using GiphyApiWrapper.Models.Parameters;
using GiphyApiWrapper.Models.Parameters.Stickers;

var giphy = new Giphy("YOUR_API_KEY");
var parameter = new StickerRandomParameter
{
    Tag = "Cute kittens", // (Optional)
    Rating = Rating.G     // (Optional) Default - G
};
GiphySingle result = await giphy.StickerRandom(parameter);
```
