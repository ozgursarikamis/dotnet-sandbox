namespace FilesAndStreams.Streams;

public static class HandlingBinaryData
{
    public static void Run()
    {
        // WritingBinaryData();
        ReadingBinaryData();
    }

    private static void ReadingBinaryData()
    {
        using (var fs = new FileStream("binary.dat", FileMode.Open))
        using (var reader = new BinaryReader(fs))
        {
            int num = reader.ReadInt32();
            double pi = reader.ReadDouble();
            string text = reader.ReadString();

            Console.WriteLine($"Binary Read (int): {num}");
            Console.WriteLine($"Binary Read (pi): {pi}");
            Console.WriteLine($"Binary Read (text): {text}");
        }
    }

    private static void WritingBinaryData()
    {
        using (var fs = new FileStream("binary.dat", FileMode.Create))
        using (var writer = new BinaryWriter(fs))
        {
            writer.Write(42);
            writer.Write(3.14);
            writer.Write("Hello World!");
        }

        Console.WriteLine("Binary data written");
    }
}