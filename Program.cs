using System;
using modul8_103022330026;

namespace modul8_103022330026
{
    class Program
    {
        public static void Main(string[] args)
        {
            var config = new BankTransferConfig();
            config.loadConfig();
            int amount;

            if (config.lang == "en")
            {
                Console.Write("Please insert the amount of money to transfer : ");
                amount = Console.Read();

                if (amount <= config.threshold)
                {
                    amount = amount + config.low_fee;
                    Console.WriteLine("Transfer fee = " + config.low_fee + " dan Total Amount = " + amount);
                }
                else if (amount > config.threshold)
                {
                    amount = amount + config.high_fee;
                    Console.WriteLine("Transfer fee = " + config.high_fee + " dan Total Amount = " + amount);
                }

                Console.WriteLine("Transfer method : ");
                Console.WriteLine("1. RTO");
                Console.Write("Select transfer method : ");
                int method = Console.Read();

                Console.WriteLine("Please Type " + config.en + " to confirm the transaction");
                string verif = Console.ReadLine();
                if (verif == config.en)
                {
                    Console.WriteLine("Transfer is completed");
                }
                else
                {
                    Console.WriteLine("Transfer is canceled");
                }
            }

            else if (config.lang == "id")
            {
                Console.Write("Masukkan jumlah uang yang akan di-transfer : ");
                amount = Console.Read();

                if (amount <= config.threshold)
                {
                    amount = amount + config.low_fee;
                    Console.WriteLine("Biaya Transfer = " + config.low_fee + " dan Total Biaya = " + amount);
                }
                else if (amount > config.threshold)
                {
                    amount = amount + config.high_fee;
                    Console.WriteLine("Biaya Transfer = " + config.low_fee + " dan Total Biaya = " + amount);
                }

                Console.WriteLine("Metode Transfer : ");
                Console.WriteLine("1. RTO");
                Console.Write("Pilih metode transfer : ");
                int method = Console.Read();

                Console.WriteLine("Ketik " + config.id + " untuk mengkonfirmasi transaksi:");
                String verif = Console.ReadLine();
                if (verif == config.id)
                {
                    Console.WriteLine("Proses transfer berhasil");
                }
                else
                {
                    Console.WriteLine("Transfer dibatalkan");
                }
            }
        }
    }
}