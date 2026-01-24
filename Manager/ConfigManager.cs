using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

internal class ConfigManager  {
    public ConfigManager() { }

    public static void CreateConfig() {
        if (!File.Exists("config.json")) {
            ConfigJson configJson = new ConfigJson();
            configJson.DiscordToken = "";

            var jsonWriteData = JsonConvert.SerializeObject(configJson);
            using (var sw = new StreamWriter(@"config.json", false, System.Text.Encoding.UTF8)) {
                sw.Write(jsonWriteData);
                Console.WriteLine(sw.ToString());
            }
        }
    }

    public static ConfigJson GetConfig() {
        ConfigJson configJson;
        using (var sr = new StreamReader(@"config.json", System.Text.Encoding.UTF8)) {
            var jsonReadData = sr.ReadToEnd();
            configJson = JsonConvert.DeserializeObject<ConfigJson>(jsonReadData);
        }
        return configJson;
    }
}

[JsonObject("ConfigJson")]
internal class ConfigJson {
    [JsonProperty("DiscordToken")]
    public string DiscordToken { get; set; }
}
