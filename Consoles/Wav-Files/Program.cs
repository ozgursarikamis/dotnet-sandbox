// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

const string filePath = "BabyElephantWalk60.wav";

using(var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
using (BinaryReader reader = new BinaryReader(fileStream))
{
	// Read the header
	string chunkID = new string(reader.ReadChars(4));
	int chunkSize = reader.ReadInt32();
	string format = new string(reader.ReadChars(4));

	string subChunk1ID = new string(reader.ReadChars(4));
	int subChunk1Size = reader.ReadInt32();
	short audioFormat = reader.ReadInt16();
	short numChannels = reader.ReadInt16();
	int sampleRate = reader.ReadInt32();
	int byteRate = reader.ReadInt32();
	short blockAlign = reader.ReadInt16();
	short bitsPerSample = reader.ReadInt16();

	string subChunk2ID = new string(reader.ReadChars(4));
	int subChunk2Size = reader.ReadInt32();

	// Read the data
	byte[] data = reader.ReadBytes(subChunk2Size);

	// Process the data (this is a simple example that just inverts the audio signal)
	for (int i = 0; i < data.Length; i++)
	{
		data[i] = (byte)(255 - data[i]);
	}

	// Save the processed data to a new file
	using (FileStream fsOut = new FileStream("Output.wav", FileMode.Create, FileAccess.Write))
	using (BinaryWriter writer = new BinaryWriter(fsOut))
	{
		// Write the header
		writer.Write(chunkID.ToCharArray());
		writer.Write(chunkSize);
		writer.Write(format.ToCharArray());
		writer.Write(subChunk1ID.ToCharArray());
		writer.Write(subChunk1Size);
		writer.Write(audioFormat);
		writer.Write(numChannels);
		writer.Write(sampleRate);
		writer.Write(byteRate);
		writer.Write(blockAlign);
		writer.Write(bitsPerSample);
		writer.Write(subChunk2ID.ToCharArray());
		writer.Write(subChunk2Size);

		// Write the processed data
		writer.Write(data);
	}
}

Console.WriteLine("Processing complete.");