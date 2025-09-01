# File Type Detector

A .NET library for detecting MIME types and file extensions based on file signatures (magic bytes) and predefined mappings. This project provides a robust way to identify file types from byte arrays, streams, or file paths, supporting both signature-based detection and extension-to-MIME type mappings.

## Overview

The `File Type Detector` library is designed to help developers identify file types and MIME types accurately in .NET applications. It supports detection through file signatures (magic bytes) for precise identification and includes a comprehensive mapping of MIME types to file extensions. The library is built with extensibility in mind, allowing developers to add support for additional file formats.


## NuGet Package Information

- **Package Name**: File Type Detector
- **Version**: 1.0.0
- **NuGet Link**: [https://www.nuget.org/packages/FileTypeDetector](https://www.nuget.org/packages/FileTypeDetector)

- **Installation Command**:
  ```bash
  dotnet add package FileTypeDetector
  ```

## Features

- **File Signature Detection**: Detects file types by analyzing magic bytes from files, streams, or byte arrays.
- **MIME Type Detection**: Maps file extensions to their corresponding MIME types.
- **Extensible Architecture**: Easily extendable to support additional file formats through custom signature checkers.
- **Thread-Safe Lazy Loading**: Uses lazy-initialized collections for efficient and thread-safe access to file type and MIME type data.
- **Exception Handling**: Provides clear error messages for invalid or non-readable inputs.

## Installation
   Add the `FileTypeDetector` package using the .NET CLI:
   ```bash
   dotnet add package FileTypeDetector
   ```

## Usage

### Detecting File Types by Signature

```csharp
using MimeType.Services;
using MimeType.Core.Models;

var detector = new FileSignatureDetector();
byte[] fileBytes = File.ReadAllBytes("sample.png");
var fileTypes = detector.Detect(fileBytes);

foreach (var fileType in fileTypes)
{
    Console.WriteLine($"MIME: {fileType.Mime}, Extensions: {string.Join(", ", fileType.Extensions)}");
}
```
#### Supported File Signatures

The library currently supports signature-based detection for the following image formats:

- **BMP** (.bmp): Starts with "BM".
- **GIF** (.gif): Starts with "GIF87a" or "GIF89a".
- **PNG** (.png): Starts with `0x89 0x50 0x4E 0x47 0x0D 0x0A 0x1A 0x0A`.
- **TIFF** (.tiff, .tif): Starts with `0x49 0x49 0x2A 0x00` (II*) or `0x4D 0x4D 0x00 0x2A` (MM*).
- **WebP** (.webp): Starts with "RIFF" followed by "WEBP" at offset 8.
- **JPEG** (.jpg, .jpeg, .jpe, .jfif): Starts with `0xFF 0xD8 0xFF`.
- **JPEG XL** (.jxl): Starts with `0xFF 0x0A` (raw codestream) or a 12-byte container signature.
- **DWG** (.dwg): Starts with "AC" followed by version strings like "1.40", "1002", etc.

Additional file formats (e.g., audio, video, and archive formats) are supported for MIME type-to-extension mappings but lack signature detection at this time. Support for these formats will be added in future updates.

### Detecting MIME Types by Extension

```csharp
using MimeType.Services;

var mimeDetector = new MimeTypeDetector();
var mimeTypes = mimeDetector.Detect(".png");

foreach (var mime in mimeTypes)
{
    Console.WriteLine($"MIME Type: {mime}");
}
```

### Detecting File Extensions by MIME Type

```csharp
using MimeType.Services;

var extensionDetector = new FileExtensionDetector();
var extensions = extensionDetector.Detect("image/png");

foreach (var ext in extensions)
{
    Console.WriteLine($"Extension: {ext}");
}
```

## Example project
#### Project link
[https://github.com/ibrahimekinci/FileType Detector/tree/develop/MimeType.Example](https://github.com/ibrahimekinci/FileType Detector/tree/develop/MimeType.Example)
#### Project Output

```plaintext
=== DotNetMimeType Example Console Application ===

=== MIME Type Detection from Extension ===
Extension: .jpg
MIME Type: image/jpeg

=== ************************************* ===

=== Extension Detection from MIME Type ===
MIME Type: image/jpeg
Extensions: jpg, jpeg, jpe, jfif

=== ************************************* ===

=== File Signature Detection from File Path ===
File: [absolute-path]\Files\valid_file (1).png
MIME: image/png, Extensions: png
File: [absolute-path]\Files\valid_file (1).jpg
MIME: image/jpeg, Extensions: jpg, jpeg, jpe, jfif
File: [absolute-path]\Files\valid_file (1).webp
MIME: image/webp, Extensions: webp

=== ************************************* ===

=== File Signature Detection from Stream ===
File: [absolute-path]\Files\valid_file (1).png
MIME: image/png, Extensions: png
File: [absolute-path]\Files\valid_file (1).jpg
MIME: image/jpeg, Extensions: jpg, jpeg, jpe, jfif
File: [absolute-path]\Files\valid_file (1).webp
MIME: image/webp, Extensions: webp

=== ************************************* ===

=== File Signature Detection from Byte Array ===
File: [absolute-path]\Files\valid_file (1).png
MIME: image/png, Extensions: png
File: [absolute-path]\Files\valid_file (1).jpg
MIME: image/jpeg, Extensions: jpg, jpeg, jpe, jfif
File: [absolute-path]\Files\valid_file (1).webp
MIME: image/webp, Extensions: webp

=== ************************************* ===

Press any key to exit...
```

## Contributing

We welcome contributions to expand the supported file formats and improve the library! To contribute:

1. Fork the repository: [https://github.com/ibrahimekinci/dotnet-FileTypeDetector](https://github.com/ibrahimekinci/dotnet-FileTypeDetector)
2. Add new file signature checkers or enhance existing ones in the `MimeType.Infrastructure.FileSignatureCheckers` namespace.
3. Update the `BuiltInFileTypes` class to include new file signatures and mappings.
4. Submit a pull request with a clear description of your changes.

Please ensure your code follows the existing structure and includes appropriate tests.

## References

- [IANA Media Types](https://www.iana.org/assignments/media-types/media-types.xhtml)
- [MIME Type Reference](https://mimetype.io/all-types)

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Author

Developed by [Ibrahim Ekinci](https://github.com/ibrahimekinci).