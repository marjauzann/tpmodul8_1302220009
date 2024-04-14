using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.IO;

namespace tpmodul8_1302220009
{
    internal class CovidConfig
    {
        public string SatuanSuhu { get; set; }
        public double BatasHariDeman { get; set; }
        public string PesanDitolak { get; set; }
        public string PesanDiterima { get; set; }

        internal static CovidConfig LoadConfig()
        {
            string configFilePath = "covid_config.json";

            // Mengecek apakah file konfigurasi ada
            if (File.Exists(configFilePath))
            {
                // Memuat nilai konfigurasi dari file JSON
                string json = File.ReadAllText(configFilePath);
                return JsonConvert.DeserializeObject<CovidConfig>(json);
            }
            else
            {
                return new CovidConfig
                {
                    SatuanSuhu = "celcius",
                    BatasHariDeman = 14,
                    PesanDitolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini",
                    PesanDiterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini"
                };
            }
        }

        internal void UbahSatuan()
        {
            if (SatuanSuhu == "celcius")
            {
                SatuanSuhu = "fahrenheit";
            }
            else
            {
                SatuanSuhu = "celcius";
            }
        }
    }
}