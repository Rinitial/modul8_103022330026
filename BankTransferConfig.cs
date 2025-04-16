using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace modul8_103022330026
{
    class BankTransferConfig
    {
        public static string filePath = Path.Combine(Directory.GetCurrentDirectory(), "bank_transfer_config.json");

        [JsonPropertyName("lang")]
        public string lang { get; set; }
        [JsonPropertyName("threshold")]
        public int threshold { get; set; }
        [JsonPropertyName("low_fee")]
        public int low_fee { get; set; }
        [JsonPropertyName("high_fee")]
        public int high_fee { get; set; }
        [JsonPropertyName("methods")]
        public string[] methods { get; set; }
        [JsonPropertyName("en")]
        public string en { get; set; }
        [JsonPropertyName("id")]
        public string id { get; set; }

        public BankTransferConfig()
        {
            setDefault();
        }
        public BankTransferConfig(string lang, int threshold, int low_fee, int high_fee, string[] methods, string en, string id)
        {
            this.lang = lang;
            this.threshold = threshold;
            this.low_fee = low_fee;
            this.high_fee = high_fee;
            this.methods = methods;
            this.en = en;
            this.id = id;
        }

        public void UbahBahasa()
        {
            if (lang == "en")
            {
                lang = "id";
            }
            else
            {
                lang = "en";
            }
            SaveNewConfig();
        }
        public void loadConfig()
        // Method untuk memuat konfigurasi dari file
        {
            // pengecekan file
            if (File.Exists(filePath))
            {
                try
                {
                    // Membaca file JSON
                    string config_json = File.ReadAllText(filePath);
                    // Menggunakan JsonSerializer untuk mendeserialisasi JSON ke objek BankTransferConfig
                    BankTransferConfig configFromFile = JsonSerializer.Deserialize<BankTransferConfig>(config_json);

                    // Perbarui nilai properti dengan hasil dari file
                    lang = configFromFile.lang;
                    threshold = configFromFile.threshold;
                    low_fee = configFromFile.low_fee;
                    high_fee = configFromFile.high_fee;
                    methods = configFromFile.methods;
                    en = configFromFile.en;
                    id = configFromFile.id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Terjadi kesalahan: " + ex.Message);
                }
            }
            else
            {
                // Jika file tidak ditemukan, simpan objek yang sudah memiliki default ke file
                SaveNewConfig();
                Console.WriteLine("File tidak ditemukan, membuat file baru");
            }
        }

        public void SaveNewConfig()
        {
            try
            {
                // Menggunakan JsonSerializer untuk serialisasi objek ke JSON
                var options = new JsonSerializerOptions { WriteIndented = true };
                // Menyimpan JSON ke file
                string jsonString = JsonSerializer.Serialize(this, options);
                // Menulis JSON ke file
                File.WriteAllText(filePath, jsonString);
                Console.WriteLine("Berhasil menyimpan konfigurasi baru");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Gagal menyimpan konfigurasi baru: " + ex.Message);
            }
        }

        private void setDefault()
        // Method untuk mengatur nilai default
        {
            this.lang = "en";
            this.threshold = 25000000;
            this.low_fee = 6500;
            this.high_fee = 15000;
            this.en = "yes";
            this.id = "ya";
        }
    }
}
