## GiphyApiWrapper (Alpha)

This is a simple wrapper for consuming Giphy endpoints in .NET. GiphyApiWrapper allows you to consume the Giphy API without having to handle the requests yourself.

### Build Status

[![Build Status](https://dev.azure.com/fargherkeegan/GiphyApiWrapper/_apis/build/status/KeeganFargher.GiphyApiWrapper?branchName=master)](https://dev.azure.com/fargherkeegan/GiphyApiWrapper/_build/latest?definitionId=7&branchName=master)
[![CodeFactor](https://www.codefactor.io/repository/github/keeganfargher/giphyapiwrapper/badge)](https://www.codefactor.io/repository/github/keeganfargher/giphyapiwrapper)

### Getting Started

Either `Install-Package GiphyApiWrapper` or just search for `GiphyApiWrapper` in the Nuget package manager.

## Usage

Most methods return a [RootObject](https://developers.giphy.com/docs/#gif-object) unless otherwise specified.

### Search

```c#
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

```c#
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

```c#
using GiphyApiWrapper;
using GiphyApiWrapper.Models.Parameters;

var giphy = new Giphy("YOUR_API_KEY");
var parameter = new TranslateParameter
{
    Query = "Cute kittens", // Required
    Weirdness = 10          // (Optional) Default - 10
};
RootObject result = await giphy.Translate(parameter);
```

### Random

```c#
using GiphyApiWrapper;
using GiphyApiWrapper.Models.Parameters;

var giphy = new Giphy("YOUR_API_KEY");
var parameter = new RandomParameter
{
    Tag = "Cute kittens", // (Optional)
    Rating = Rating.G     // (Optional) Default - G
};
RootObject result = await giphy.Random(parameter);
```

### GIF by ID

```c#
using GiphyApiWrapper;
using GiphyApiWrapper.Models.Parameters;

var giphy = new Giphy("YOUR_API_KEY");
var id = "xT4uQulxzV39haRFjG"
RootObject result = await giphy.GifById(id);
```

### GIFs by IDs

```c#
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

```c#
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

```c#
using GiphyApiWrapper;
using GiphyApiWrapper.Models.Parameters;
using GiphyApiWrapper.Models.Parameters.Stickers;

var giphy = new Giphy("YOUR_API_KEY");
var parameter = new StickerTranslateParameter
{
    Query = "Cute doggies" // Required
};
RootObject result = await giphy.StickerTranslate(parameter);
```

### Sticker Trending

```c#
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

```c#
using GiphyApiWrapper;
using GiphyApiWrapper.Models.Parameters;
using GiphyApiWrapper.Models.Parameters.Stickers;

var giphy = new Giphy("YOUR_API_KEY");
var parameter = new StickerRandomParameter
{
    Tag = "Cute kittens", // (Optional)
    Rating = Rating.G     // (Optional) Default - G
};
RootObject result = await giphy.StickerRandom(parameter);
```
