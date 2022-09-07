using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mir3DClientEditor.Services
{
    public static class Crypto
    {
        public const string API_ENDPOINT = "https://mir3d-editor-api.herokuapp.com/";

        public static MethodInfo? EncryptMethod { get; }
        public static MethodInfo? DecryptMethod { get; }

        static Crypto()
        {
            // if exists mir3dcrypto dll use this instead of api
            if (File.Exists("Mir3DCrypto.dll"))
            {
                var asm = Assembly.LoadFile(Path.GetFullPath("Mir3DCrypto.dll"));
                var classType = asm.GetType("Mir3DCrypto.Crypto");
                var methods = classType?.GetMethods(BindingFlags.Static | BindingFlags.Public);
                EncryptMethod = methods?.FirstOrDefault(x => x.Name == "Encrypt" && x.GetParameters().Length == 1);
                DecryptMethod = methods?.FirstOrDefault(x => x.Name == "Decrypt" && x.GetParameters().Length == 1);
            }
        }

        internal static byte[] Encrypt(byte[] buffer)
        {
            if (EncryptMethod != null) 
                return (byte[])EncryptMethod.Invoke(null, new object[] { buffer });

            using var http = new HttpClient();
            using var multipart = new MultipartFormDataContent();
            using var fileStreamContent = new StreamContent(new MemoryStream(buffer));
            using var outputStream = new MemoryStream();

            http.BaseAddress = new Uri(API_ENDPOINT);

            multipart.Add(fileStreamContent, "file", "unknown");

            var request = new HttpRequestMessage(HttpMethod.Post, "crypto/encrypt");
            request.Content = multipart;

            var response = http.Send(request);

            var responseStream = response.Content.ReadAsStream();

            responseStream.CopyTo(outputStream);
            var output = outputStream.ToArray();

            if (!response.IsSuccessStatusCode)
            {
                var text = Encoding.UTF8.GetString(output);
                throw new ApplicationException(text);
            }

            return output;
        }

        internal static byte[] Decrypt(byte[] buffer)
        {
            if (DecryptMethod != null)
                return (byte[])DecryptMethod.Invoke(null, new object[] { buffer });

            using var http = new HttpClient();
            using var multipart = new MultipartFormDataContent();
            using var fileStreamContent = new StreamContent(new MemoryStream(buffer));
            using var outputStream = new MemoryStream();

            http.BaseAddress = new Uri(API_ENDPOINT);
            multipart.Add(fileStreamContent, "file", "unknown");

            var request = new HttpRequestMessage(HttpMethod.Post, "crypto/decrypt");
            request.Content = multipart;

            var response = http.Send(request);

            var responseStream = response.Content.ReadAsStream();

            responseStream.CopyTo(outputStream);
            var output = outputStream.ToArray();

            if (!response.IsSuccessStatusCode)
            {
                var text = Encoding.UTF8.GetString(output);
                throw new ApplicationException(text);
            }

            return output;
        }
    }
}
