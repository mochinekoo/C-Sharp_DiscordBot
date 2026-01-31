using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace C_Shape_DiscordBot.API {

    internal class WeatherAPI {
        const string API_URL = "https://weather.tsukumijima.net/api/forecast/city/%s";

        public static WeatherAPI GetWeather(string cityCode) {
            using (HttpClient client = new HttpClient()) {
                string url = API_URL.Replace("%s", cityCode);
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode) {
                    string json = response.Content.ReadAsStringAsync().Result;
                    WeatherAPI? weather = JsonConvert.DeserializeObject<WeatherAPI>(json);
                    return weather;
                }
                else {
                    throw new Exception("Failed to get weather data");
                }
            }

        }

        [JsonProperty("forecasts")]
        public Forecast[] forecast { get; set; }
        internal class Forecast {
            public string date { get; set; }
            public string telop { get; set; }
            public Detail detail { get; set; }

            internal class Detail {
                public string weather { get; set; }
                public string wind { get; set; }
                public string wave { get; set; }
            }
        }
    }
}
