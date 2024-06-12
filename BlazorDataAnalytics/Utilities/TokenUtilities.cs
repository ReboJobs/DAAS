using System.IO;
using System.Text.Json;
using Xero.NetStandard.OAuth2.Token;

public static class TokenUtilities
{
    [Serializable]
    public struct State
    {
        public string state { get; set; }
        public State(string state)
        {
            this.state = state;
        }
    }

    public static void StoreToken(XeroOAuth2Token xeroToken)
    {
        string serializedXeroToken = JsonSerializer.Serialize(xeroToken);
        System.IO.File.WriteAllText("./xerotoken.json", serializedXeroToken);
    }

    public static XeroOAuth2Token GetStoredToken()
    {
        string serializedXeroToken = System.IO.File.ReadAllText("./xerotoken.json");
        var xeroToken = JsonSerializer.Deserialize<XeroOAuth2Token>(serializedXeroToken);

        return xeroToken;
    }
    
    public static bool TokenExists()
    {
        string serializedXeroTokenPath = "./xerotoken.json";
        bool fileExist = File.Exists(serializedXeroTokenPath);

        return fileExist;
    }

    public static void DestroyToken()
    {
        string serializedXeroTokenPath = "./xerotoken.json";
        File.Delete(serializedXeroTokenPath);

        return;
    }

    public static void StoreCodeVerifier(string codeVerifier)
    {
        string serializedXeroToken = JsonSerializer.Serialize(codeVerifier);
        System.IO.File.WriteAllText("./codeverifier.json", serializedXeroToken);
    }

    public static string GetCodeVerifier()
    {
        string serializedXeroToken = System.IO.File.ReadAllText("./codeverifier.json");
        var codeVerifier = JsonSerializer.Deserialize<string>(serializedXeroToken);

        return codeVerifier;
    }

    public static bool CodeVerifierExists()
    {
        string serializedXeroTokenPath = "./codeverifier.json";
        bool fileExist = File.Exists(serializedXeroTokenPath);

        return fileExist;
    }

    public static void DestroyCodeVerifier()
    {
        string serializedXeroTokenPath = "./codeverifier.json";
        File.Delete(serializedXeroTokenPath);

        return;
    }

    public static string GetCurrentState()
    {
        string state;
        try
        {
            string serializedIndexFile = System.IO.File.ReadAllText("./state.json");
            state = JsonSerializer.Deserialize<State>(serializedIndexFile).state;
        }
        catch (IOException)
        {
            state = null;
        }

        return state;
    }

    public static string GenerateCodeVerifier()
    {
        var validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-._~";
        Random random = new Random();
        int charsLength = random.Next(43, 128);
        char[] randomChars = new char[charsLength];
        for (int i = 0; i < charsLength; i++)
        {
            randomChars[i] = validChars[random.Next(0, validChars.Length)];
        }
        string codeVerifier = new String(randomChars);

        return codeVerifier;
    }

}