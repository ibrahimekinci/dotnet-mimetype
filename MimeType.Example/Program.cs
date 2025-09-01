using MimeType.Core.Models;
using MimeType.Services;


// Detect MIME types from a file extension
#region MimeTypeDetector
var mimeDetector = new MimeTypeDetector();

Console.WriteLine("\n=== MIME Type Detection from Extension ===");
string sampleExtension = ".jpg";
try
{
    var mimeTypes = mimeDetector.Detect(sampleExtension);
    Console.WriteLine($"Extension: {sampleExtension}");
    foreach (var mime in mimeTypes)
    {
        Console.WriteLine($"MIME Type: {mime}");
    }
    if (mimeTypes.IsEmpty)
    {
        Console.WriteLine("No MIME types found for the extension.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error detecting MIME for {sampleExtension}: {ex.Message}");
}

Console.WriteLine("\n=== ************************************* ===");
#endregion

// Detect file extensions from a MIME type
#region FileExtensionDetector
var extensionDetector = new FileExtensionDetector();

Console.WriteLine("\n=== Extension Detection from MIME Type ===");
string sampleMime = "image/jpeg";
try
{
    var extensions = extensionDetector.Detect(sampleMime);
    Console.WriteLine($"MIME Type: {sampleMime}");
    Console.WriteLine($"Extensions: {string.Join(", ", extensions)}");
    if (extensions.IsEmpty)
    {
        Console.WriteLine("No extensions found for the MIME type.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error detecting extensions for {sampleMime}: {ex.Message}");
}


Console.WriteLine("\n=== ************************************* ===");
#endregion

// Detect file types using file signatures from file path, stream, and byte array
#region FileSignatureDetector

var signatureDetector = new FileSignatureDetector();

// Define the path to the Files folder relative to the project root
// Assumes Files folder is in the project directory (adjust as needed)
string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Files");
basePath = Path.GetFullPath(basePath); // Resolve to absolute path

// Define sample files for testing
string[] sampleFiles =
{
                Path.Combine(basePath, "valid_file (1).png"),
                Path.Combine(basePath, "valid_file (1).jpg"),
                Path.Combine(basePath, "valid_file (1).webp")
            };
// Detect file types using file signatures from file path
Console.WriteLine("\n=== File Signature Detection from File Path ===");
foreach (var filePath in sampleFiles)
{
    try
    {
        if (File.Exists(filePath))
        {
            var fileTypes = signatureDetector.Detect(filePath);
            DisplayFileTypes(filePath, fileTypes);
        }
        else
        {
            Console.WriteLine($"File not found: {filePath}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error processing {filePath}: {ex.Message}");
    }
}

Console.WriteLine("\n=== ************************************* ===");

// Detect file types using file signatures from stream
Console.WriteLine("\n=== File Signature Detection from Stream ===");
foreach (var filePath in sampleFiles)
{
    try
    {
        if (File.Exists(filePath))
        {
            using var stream = File.OpenRead(filePath);
            var fileTypes = signatureDetector.Detect(stream);
            DisplayFileTypes(filePath, fileTypes);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error processing stream for {filePath}: {ex.Message}");
    }
}

Console.WriteLine("\n=== ************************************* ===");

// Detect file types using file signatures from byte array
Console.WriteLine("\n=== File Signature Detection from Byte Array ===");
foreach (var filePath in sampleFiles)
{
    try
    {
        if (File.Exists(filePath))
        {
            byte[] fileBytes = File.ReadAllBytes(filePath);
            var fileTypes = signatureDetector.Detect(fileBytes);
            DisplayFileTypes(filePath, fileTypes);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error processing bytes for {filePath}: {ex.Message}");
    }
}

Console.WriteLine("\n=== ************************************* ===");
#endregion

// Helper method to display detected file types
#region Helpers
static void DisplayFileTypes(string filePath, System.Collections.Immutable.ImmutableHashSet<FileTypeModel> fileTypes)
{
    Console.WriteLine($"File: {filePath}");
    if (fileTypes.IsEmpty)
    {
        Console.WriteLine("No file types detected.");
        return;
    }
    foreach (var fileType in fileTypes)
    {
        Console.WriteLine($"MIME: {fileType.Mime}, Extensions: {string.Join(", ", fileType.Extensions)}");
    }
}
#endregion

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();