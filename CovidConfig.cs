using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace tpmod08_103022300144
{
    class CovidConfig
    {
        [JsonPropertyName("satuan_suhu")]
        public string satuan_suhu { get; set; }

        [JsonPropertyName("batas_hari_demam")]
        public string batas_hari_demam { get; set; }

        [JsonPropertyName("pesan_ditolak")]
        public string pesan_ditolak { get; set; }

        [JsonPropertyName("pesan_diterima")]
        public string pesan_diterima { get; set; }

        public static string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "covid_config.json");


        public CovidConfig()
        {
            satuan_suhu = "celcius";
            batas_hari_demam = "14";
            pesan_ditolak = "Anda dilarang masuk ke dalam gedung ini";
            pesan_diterima = "Anda diperbolehkan masuk ke dalam gedung ini";
        }

        public void NewSaveConfig()
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
                    var jsonString = JsonSerializer.Serialize(this, jsonOptions);

                    Console.WriteLine("Berhasil membuat file config baru!");
                }else
                {
                    Console.WriteLine("File ditemukan!");
                }
            }catch (Exception e)
            {
                Console.WriteLine("Gagal membuat file config baru!" + e.Message);
            }
        }

        public void LoadCovidConfig()
        {
            if (File.Exists(FilePath))
            {
                try
                {
                    var configJson = File.ReadAllText(FilePath);
                    var configCovid = JsonSerializer.Deserialize<CovidConfig>(configJson);

                    satuan_suhu = configCovid!.satuan_suhu;
                    batas_hari_demam = configCovid!.batas_hari_demam;
                    pesan_ditolak = configCovid!.pesan_ditolak;
                    pesan_diterima = configCovid!.pesan_diterima;
                }catch(Exception e)
                {
                    Console.WriteLine("Terjadi kesalahan saat mengambil data" + e.Message);
                }
            }else
            {
                Console.WriteLine("File tidak ditemukan, membuat file baru!");
            }
        }

        public void ChangeMetric()
        {
            satuan_suhu = satuan_suhu?.ToLower() == "celcius" ? "fahrenheit" : "celcius";
            NewSaveConfig();
        }
    }
}
