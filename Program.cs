using tpmod08_103022300144;

public class Program
{
    public static void Main(string[] args)
    {
        CovidConfig config = new CovidConfig();
        config.LoadCovidConfig();

        Console.WriteLine("Welcome!");
        Console.WriteLine("Satuan suhu saat ini: " + config.satuan_suhu);

        Console.Write("Apakah kamu ingin mengubah satuan suhu? (y/n)");
        string inputSuhu = Console.ReadLine()!.ToLower();

        if (inputSuhu.ToLower() == "y")
        {
            config.ChangeMetric();
            Console.WriteLine("Satuan suhu saat ini setelah dirubah: " + " " + config.satuan_suhu + " ");
        }

        Console.Write("Berapa suhu badan kamu saat ini? Dalam satuan" + " " + config.satuan_suhu + " ");
        double suhu = Convert.ToDouble(Console.ReadLine());

        if (config.satuan_suhu!.ToLower() == "fahrenheit") suhu = (suhu-32) *5 / 9;

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir demam? ");
        int daysOfFever = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine(suhu >= 37.5 && daysOfFever <= Convert.ToInt32(config.batas_hari_demam) ? config.pesan_ditolak : config.pesan_diterima);
    }
}