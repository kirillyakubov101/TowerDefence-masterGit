using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SavingSystem
{
	public static int level = 1;
	public static string path = Application.persistentDataPath + "/SaveFile.sav";

	public static void SavePlayer(PlayerData data)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		
		Debug.Log(path);
		FileStream stream = new FileStream(path,FileMode.Create);

		formatter.Serialize(stream, data);
		stream.Close();
	}

	public static PlayerData LoadPlayer()
	{
	
		if(File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);

			PlayerData data = formatter.Deserialize(stream) as PlayerData;
			stream.Close();

			return data;

		}
		else
		{
			Debug.LogError("not found" + path);
			return null;
		}
	}

	public static void DeleteFile(string path)
	{
		File.Delete(path);
	}

	public static bool IsFileExist()
	{
		return File.Exists(path);
	}
}
