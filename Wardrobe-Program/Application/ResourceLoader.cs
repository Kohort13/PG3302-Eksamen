using System.IO;
using System.Linq;
using System.Reflection;

namespace Wardrobe_Program
{
    public class ResourceLoader
    {
        /// <summary>
        /// Helper method for reading resources from a file. File has to be marked as
        /// 'Embedded resource' under properties
        ///
        /// Implementation from https://stackoverflow.com/a/3314213
        /// </summary>
        /// <param name="name">The file name you wish to load</param>
        /// <returns>File contents as a string</returns>
        public static string ReadResource(string name) {
            // Determine path
            var assembly = Assembly.GetExecutingAssembly();
            string resourcePath = name;
            // Format: "{Namespace}.{Folder}.{filename}.{Extension}"
            resourcePath = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith(name));

            using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}