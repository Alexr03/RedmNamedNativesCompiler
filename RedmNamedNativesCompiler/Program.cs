﻿using System.Diagnostics;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using RedmNamedNativesCompiler.Models;

Console.WriteLine("Compiling RedM named natives...");

var httpClient = new HttpClient();
var response = await httpClient.GetAsync("https://runtime.fivem.net/doc/natives_rdr3.json");
var nativeNamespaces = await response.Content.ReadFromJsonAsync<Rdr3Natives>(new JsonSerializerOptions()
{
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
});

if (nativeNamespaces == null)
{
    Console.WriteLine("Failed to compile RedM named natives.");
    return 1; // Exit with error code
}

Console.WriteLine("Found " + nativeNamespaces.Count + " namespaces.");

StringBuilder hashBuilder = new();
foreach (var (@namespace, natives) in nativeNamespaces)
{
    Console.WriteLine("Compiling namespace " + @namespace + " with " + natives.Count + " natives...");
    foreach (var (nativeHash, nativeData) in natives)
    {
        if (string.IsNullOrEmpty(nativeData.Name))
        {
            Debug.WriteLine($"Skipping native with empty name {nativeHash}");
            continue;
        }
        
        var nativeName = ConvertNameToNativeName(nativeData.Name);
        Debug.WriteLine($"Compiling native {nativeName} with hash {nativeData.Hash}...");
        hashBuilder.AppendLine($"    {nativeName} = {nativeData.Hash}, -- [{@namespace}]");
    }
}

var hashOutput = hashBuilder.ToString();
var fileTemplate = File.ReadAllText("natives_template.lua");
var fileOutput = fileTemplate.Replace("${hash_data}", hashOutput);

File.WriteAllText("natives.lua", fileOutput);
return 0; // Exit with success code

string ConvertNameToNativeName(string name)
{
    return string.Join("",
        name.Split('_')
            .Where(part => !string.IsNullOrEmpty(part)) // Ensure no empty parts are processed
            .Select(part => char.ToUpper(part[0]) + part[1..].ToLower())); // Capitalize the first letter and make the rest lowercase
}