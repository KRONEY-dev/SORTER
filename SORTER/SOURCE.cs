using System.IO;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using WinForms = System.Windows.Forms;

namespace SORTER
{
    class SOURCE
    {
        readonly MainWindow MW = (MainWindow)System.Windows.Application.Current.MainWindow;
        public SOURCE(ItemCollection InputList, string Output_Directory, string type, bool repeat)
        {
            //controller
            switch (repeat)
            {
                case false:
                    foreach (var DirectoryList_Items in InputList)
                    {
                        SourseTOP((string)DirectoryList_Items, Output_Directory, type);
                    }
                    break;
                case true:
                    foreach (var DirectoryList_Items in InputList)
                    {
                        SourceAsync((string)DirectoryList_Items, Output_Directory, type);
                    }
                    break;
            }
            //controller
        }

        private void SourseTOP(string Input_DirectoryList_Items, string Output_Directory, string type)
        {
            //sourse.justsort
            string[] Input_list = Directory.GetFiles($@"{Input_DirectoryList_Items}");
            foreach (var item in Input_list)
            {
                if (item.Contains(type))
                {
                    FileInfo Input_list_FileInfo = new FileInfo($@"{item}");
                    string FileName = Input_list_FileInfo.Name;
                    //Catch&Move
                    if (File.Exists($@"{Output_Directory}\{FileName}") == true)
                    {
                        DialogResult Сhoice = WinForms.MessageBox.Show($"{FileName} already exists. \nDo you want to replace it?", "Move error", MessageBoxButtons.YesNo);
                        if (Сhoice == DialogResult.Yes)
                        {
                            File.Delete($@"{Output_Directory}\{FileName}");
                            File.Move(item, $@"{Output_Directory}\{FileName}");
                        }
                        else if (Сhoice == DialogResult.No) { }
                    }
                    else
                    {
                        File.Move(item, $@"{Output_Directory}\{FileName}");
                    }
                    //Catch&Move
                }
            }
            //sourse.justsort
        }

        private async void SourceAsync(string Input_DirectoryList_Items, string Output_Directory, string type)
        {
            //sourse.async
            while (MW.Constantly_sort.IsChecked == true)
            {
                MW.SORTED.IsEnabled = false;
                string[] Input_list = Directory.GetFiles($@"{Input_DirectoryList_Items}");
                foreach (var item in Input_list)
                {
                    if (item.Contains(type))
                    {
                        FileInfo Input_list_FileInfo = new FileInfo($@"{item}");
                        string FileName = Input_list_FileInfo.Name;
                        //Catch&Move
                        if (File.Exists($@"{Output_Directory}\{FileName}") == true)
                        {
                            DialogResult Сhoice = WinForms.MessageBox.Show($"{FileName} already exists. \nDo you want to replace it?", "Move error", MessageBoxButtons.YesNo);
                            if (Сhoice == DialogResult.Yes)
                            {
                                File.Delete($@"{Output_Directory}\{FileName}");
                                File.Move(item, $@"{Output_Directory}\{FileName}");
                            }
                            else if (Сhoice == DialogResult.No) { }
                        }
                        else
                        {
                            File.Move(item, $@"{Output_Directory}\{FileName}");
                        }
                        //Catch&Move
                    }
                }
                await Task.Delay(1000);
            }
            //sourse.async
        }
    }
}
