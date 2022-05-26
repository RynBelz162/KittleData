using System;

namespace KittleData.Maui.Models;

public record RandomCatGif
(
    Uri? SourceUrl,
    byte[]? Gif
);