using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR1VSSIT
{
    public class MainformPresenter
    {
        List<bool> HorizontalCS = new List<bool>();
        List<bool> VerticalCS = new List<bool>();
        List<bool> CyclicCS= new List<bool>();
        private (string, string, string) comparisonTuple;
        private readonly IAlgoritm algoritm;
        private readonly IFileManager fileManager;
        private readonly IMainForm mainform1;
        private readonly IMessageService messageService;
        public MainformPresenter(IMainForm mainform,IAlgoritm algoritm, IFileManager fileManager, IMessageService messageService)
        {
            this.mainform1 = mainform;
            this.algoritm = algoritm;
            this.fileManager = fileManager;
            mainform1.GetControlSum += new EventHandler<GetCSEventArgs>(Mainform_GetControlSum);
            mainform1.Сomparison += Mainform_Comparison;
            this.messageService = messageService;
        }
        private void Mainform_Comparison(object? sender, EventArgs e)
        {
            HorizontalCS.Clear(); VerticalCS.Clear();this.CyclicCS.Clear();
            MessageBox.Show("Выберете файл");
            OpenFileDialog cssDialog = new OpenFileDialog();
            string firstFilePath = "";
            if (cssDialog.ShowDialog() == DialogResult.OK)
            {
               firstFilePath = cssDialog.FileName;
            }
            else
            {
                MessageBox.Show("Ошибка повторите попытку");
                return;
            }
            MessageBox.Show("Выберете контрольную сумму");
            OpenFileDialog comparisonDialog = new OpenFileDialog();
            string SecondFilePath = "";
            if (cssDialog.ShowDialog() == DialogResult.OK)
            {
                SecondFilePath = cssDialog.FileName;
            }
            else
            {
                MessageBox.Show("Ошибка повторите попытку");
                return;
            }
            List<bool> CyclicCS = Enumerable.Repeat(false, 32).ToList(); ;
            FileInfo fileinfo = new FileInfo(firstFilePath);
            FileStream fileStream = fileinfo.OpenRead();
            while (true)
            {
                byte[] firstBytes = fileManager.ImortData(ref fileStream);
                if (firstBytes == null)
                {
                    break;
                }
                HorizontalCS = HorizontalCS.Concat(algoritm.HorizontalControl(firstBytes.ToList())).ToList();
                VerticalCS = VerticalCS.Concat(algoritm.VerticalControl(firstBytes.ToList())).ToList();
                CyclicCS = algoritm.CyclicControl(firstBytes.ToList(), CyclicCS);
            }
            fileStream.Close();
            try
            {
                comparisonTuple = fileManager.getCssTuple(SecondFilePath);
            }
            catch (Exception exeption)
            {
                MessageBox.Show(exeption.Message);
                return;
            }
            
            
            StringBuilder message = new StringBuilder();
            if (fileManager.GetHexviev(HorizontalCS) == comparisonTuple.Item1 )
            {
                message.Append("Контрольные суммы, вычисленные методом горизонтального контроля совпадают\n");
            }
            else
            {
                message.Append("Контрольные суммы, вычисленные методом горизонтального контроля не совпадают\n");
            }
            if (fileManager.GetHexviev(VerticalCS) == comparisonTuple.Item2)
            {
                message.Append("Контрольные суммы, вычисленные методом вертикального контроля совпадают\n");
            }
            else
            {
                message.Append("Контрольные суммы, вычисленные методом вертикального контроля не совпадают\n");
            }
            if (fileManager.GetHexviev(CyclicCS) == comparisonTuple.Item3)
            {
                message.Append("Контрольные суммы, вычисленные методом циклического контроля совпадают\n");
            }
            else
            {
                message.Append("Контрольные суммы, вычисленные методом циклического контроля не совпадают\n");
            }
            messageService.ShowMessage(message.ToString());
        }
        private void Mainform_GetControlSum(object? sender, GetCSEventArgs e)
        {
            List<bool> CyclicCS = Enumerable.Repeat(false, 32).ToList(); ;
            FileInfo fileinfo = new FileInfo(e.filePath);
            FileStream fileStream = fileinfo.OpenRead();
            while (true)
            {
                byte[] firstBytes = fileManager.ImortData(ref fileStream);
                if (firstBytes == null)
                {
                    break;
                }
                HorizontalCS = HorizontalCS.Concat(algoritm.HorizontalControl(firstBytes.ToList())).ToList();
                VerticalCS = VerticalCS.Concat(algoritm.VerticalControl(firstBytes.ToList())).ToList();
                CyclicCS = algoritm.CyclicControl(firstBytes.ToList(), CyclicCS);
            }
            fileStream.Close();
            fileManager.ExportData(HorizontalCS, VerticalCS, CyclicCS, messageService);
        }

       
    }
}
