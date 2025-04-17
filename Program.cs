using System;
using System.ComponentModel.Design;
using System.Text.Json;

public class Transfer
{
    public Transfer(int threshold, int low_fee, int high_fee)
    {
        this.threshold = threshold;
        this.low_fee = low_fee;
        this.high_fee = high_fee;
    }

    public int threshold { get; set; }
    public int low_fee { get; set; }
    public int high_fee { get; set; }
}

public class Confirmation
{
    public Confirmation(string en, string id)
    {
        this.en = en;
        this.id = id;
    }

    public string en { get; set; }
    public string id { get; set; }
}

public class BankTransferConfig
{

    public string lang { get; set; }
    public Transfer transfer { get; set; }
    public string[] method { get; set; }
    public Confirmation confirmation { get; set; }
    private static string configFilePath = "bank_transfer_config.json";
    private BankTransferConfig defaultConfig;

    public BankTransferConfig(string lang, Transfer transfer, string[] method, Confirmation confirmation)
    {
        this.lang = lang;
        this.transfer = transfer;
        this.method = method;
        this.confirmation = confirmation;
    }

    public BankTransferConfig LoadFromFile(string configFilePath)
    {
        string jsonContent = File.ReadAllText(configFilePath);
        var config = JsonSerializer.Deserialize<BankTransferConfig>(jsonContent);
        return defaultConfig;

        JsonSerializerOptions jsonOptions = new JsonSerializerOptions()
        {
            WriteIndented = true,
        };
        File.WriteAllText(configFilePath, JsonSerializer.Serialize(config, jsonOptions);
    }
}

class program
{
    public static void Main(string[] args)
    {
        BankTransferConfig bankTransferConfig = new BankTransferConfig();

        if (bankTransferConfig.lang == "en")
        {
            Console.WriteLine($"Please insert the amount of money to transfer: ");
        }
        else
        {
            Console.WriteLine($"Masukkan jumlah uang yang akan di - transfer: ");
        }
        int amount = Int32.Parse( Console.ReadLine() );

        int transferFee = 0;
        if(amount <= bankTransferConfig.transfer.threshold)
        {
            transferFee = bankTransferConfig.transfer.low_fee;
        }
        else if(amount >= bankTransferConfig.transfer.threshold) 
        {
            transferFee = bankTransferConfig.transfer.high_fee;
        }

        if (bankTransferConfig.lang == "en")
        {
            Console.WriteLine($"Transfer fee: {transferFee}");
            Console.WriteLine($"Total amount: {amount + transferFee}");
        }else if(bankTransferConfig.lang == "id")
        {
            Console.WriteLine($"Biaya transfer: {transferFee}");
            Console.WriteLine($"Total biaya: {amount + transferFee}");
        }

        if(bankTransferConfig.lang == "en")
        {
            Console.WriteLine("Select transfer method: ");
        }
        else if (bankTransferConfig.lang == "id")
        {
            Console.WriteLine("Pilih metode transfer: ");
        }

        for(int i = 0; i < bankTransferConfig.method.Length; i++)
        {

        }
    }
}





