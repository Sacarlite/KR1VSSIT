using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KR1VSSIT
{
    public interface IFileManager
    {
        (string, string, string) getCssTuple( string path);
        public string GetHexviev(List<bool> binaryBools);
        void ExportData(List<bool> HorizontalCS, List<bool> VerticalCS, List<bool> CyclicCS, IMessageService messageService);
        byte[] ImortData(ref FileStream
            fileStream);

    }
    public class FileManager: IFileManager
    {
        public  string GetHexviev(List<bool> binaryBools)
        {
            StringBuilder newBuilder=new StringBuilder();
            StringBuilder hexBuilder = new StringBuilder();
            for (int i = 1; i < binaryBools.Count+1; i++)
            {
                
                if (binaryBools[i -1])
                {
                    newBuilder.Append("1");
                }
                else
                {
                    newBuilder.Append("0");
                }
                if (i % 8 == 0)
                {
                    int decimalValue = Convert.ToInt32(newBuilder.ToString(), 2);
                    newBuilder.Clear();
                    hexBuilder.Append(decimalValue.ToString("X"));
                }
            }
            return hexBuilder.ToString();
        }

        public (string, string, string) getCssTuple(string path)
        {
            var Lines=File.ReadAllLines(path).ToList();
            return (Lines[1], Lines[3], Lines[5]);
        }

        public void ExportData(List<bool> HorizontalCS, List<bool> VerticalCS, List<bool> CyclicCS, IMessageService messageService)
        {
            string FilePath="";
            while (true)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.OverwritePrompt = true;
                dialog.Filter = "Css|*.css";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FilePath = dialog.FileName;
                    break;
                }
                else
                {
                    FilePath = "";
                    DialogResult d= messageService.ShowExitMessage("Не верно указан путь для сохранения файла, повторите попытку");
                    if (d != DialogResult.OK)
                    {
                        return;
                    }
                }
            }

            Stream stream = new FileStream(FilePath, FileMode.Create);
            StreamWriter sw = new StreamWriter(stream);
            sw.Write("H\n");
            var HexViev=GetHexviev(HorizontalCS);
            sw.Write(HexViev);
            sw.Write("\n");
            sw.Write("V \n");
            HexViev = GetHexviev(VerticalCS);
            sw.Write(HexViev);
            sw.Write("\n");
            sw.Write("C \n");
            HexViev = GetHexviev(CyclicCS);
            sw.Write(HexViev);
            sw.Flush();
            sw.Close();
        }

        public byte[] ImortData(ref FileStream
            fileStream)
        {
            byte[] bArray = new byte[8];
            int iBytes = fileStream.Read(bArray, 0, bArray.Length);
            if (iBytes == 0) return null;
            return bArray;
        }

    }
}
