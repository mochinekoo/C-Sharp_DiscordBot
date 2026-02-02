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

        /// <summary> 都道府県天気予報を返す関数 </summary>
        /// <returns> 配列として返します </returns>
        [JsonProperty("forecasts")]
        public Forecast[] forecast { get; set; }
        internal class Forecast {
            /// <summary> 予報日を返す関数 </summary>
            /// <returns> 例：2026-01-01（yyyy-MM-dd） </returns>
            public string date { get; set; }

            /// <summary> 天気を返す関数 </summary>
            /// <returns> 例：晴れ （晴れ/曇り/雨から返す）</returns>
            public string telop { get; set; }

            /// <summary> 天気の詳細を返す関数 </summary>
            public Detail detail { get; set; }

            internal class Detail {
                /// <summary> 詳細の天気情報を返す関数 </summary>
                /// <returns> 例：くもり　所により　雨 </returns>
                public string weather { get; set; }

                /// <summary> 風の強さを返す関数 </summary>
                /// <returns> 例：西の風 後 北西の風</returns>
                public string wind { get; set; }

                /// <summary> 波の高さを返す関数 </summary>
                /// <returns> 例：0.5メートル </returns>
                public string wave { get; set; }
            }
        }
    }
}
