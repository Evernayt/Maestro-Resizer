using Maestro_Resizer.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;

namespace Maestro_Resizer
{
    public partial class fmMain : Form
    {
        private interface IData
        {
            string SectionName { get; set; }
            string CommandName { get; set; }
            string Width { get; set; }
            string Height { get; set; }
            bool IsCrop { get; set; }
            bool IsDisabled { get; set; }
        }

        private class CommandData : IData
        {
            public string SectionName { get; set; }
            public string CommandName { get; set; }
            public string Width { get; set; }
            public string Height { get; set; }
            public bool IsCrop { get; set; }
            public bool IsDisabled { get; set; }
        }

        static readonly string appPath = Assembly.GetExecutingAssembly().Location;
        private List<IData> datas = new List<IData>();
        private bool isContextMenuCreated = false;

        public fmMain()
        {
            InitializeComponent();
            dgwData.Columns["Disabled"].DefaultCellStyle.NullValue = null;

            LoadData();
            InitializeAdminSettings();
        }

        private void fmMain_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void LoadTable()
        {
            dgwData.Rows.Clear();
            foreach (IData data in datas)
            {
                AddTableRow(data);
            }
        }

        private void AddTableRow(IData data)
        {
            int rowIndex = dgwData.Rows.Add();
            dgwData.Rows[rowIndex].Cells["CommandName"].Value = data.IsCrop ? data.CommandName + " + обрезать" : data.CommandName;
            dgwData.Rows[rowIndex].Cells["Disabled"].Value = data.IsDisabled ? Resources.off : Resources.on;
            dgwData.Rows[rowIndex].Cells["IsDisabled"].Value = data.IsDisabled;
        }

        private void InitializeAdminSettings()
        {
            if (!IsAdministrator())
            {
                RunAsAdministrator();
            }
            else
            {
                if (Settings.Default.FirstRun)
                {
                    CreateAllContextMenu();
                    Settings.Default.FirstRun = false;
                    Settings.Default.Save();
                }
                else
                {
                    isContextMenuCreated = IsContextMenuCreated();

                    if (isContextMenuCreated)
                    {
                        ShowDeleteButton();
                    }
                    else
                    {
                        ShowCreateButton();
                    }
                }
            }
        }

        private bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void RunAsAdministrator()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                UseShellExecute = true,
                WorkingDirectory = Environment.CurrentDirectory,
                FileName = appPath,
                Verb = "runas"
            };
            try
            {
                Process.Start(startInfo);
            }
            catch
            {
                DialogResult dialogResult = MessageBox.Show("Для изменения настроек приложелия требуются права администратора.", "Maestro Resizer", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Retry)
                {
                    RunAsAdministrator();
                    return;
                }
            }
            Environment.Exit(0);
        }

        private bool IsContextMenuCreated()
        {
            string subMenuKey = $@"SystemFileAssociations\.jpg\Shell\MaestroResizer";
            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(subMenuKey))
            {
                return key != null;
            }
        }

        private void CreateAllContextMenu()
        {
            CreateContextMenu(".jpg");
            CreateContextMenu(".jpeg");
            CreateContextMenu(".png");
            CreateContextMenu(".bmp");
            CreateContextMenu(".tiff");

            isContextMenuCreated = true;
            ShowDeleteButton();
        }

        private void CreateContextMenu(string extension)
        {
            string subMenuKey = $@"SystemFileAssociations\{extension}\Shell\MaestroResizer";
            using (RegistryKey subMenu = Registry.ClassesRoot.CreateSubKey(subMenuKey))
            {
                subMenu.SetValue("MUIVerb", "Изменить размер");
                subMenu.SetValue("Icon", appPath);

                string subCommands = "";
                bool separatorAdded = false;
                foreach (IData data in datas)
                {
                    CreateCommand(data, !separatorAdded && data.IsCrop && !data.IsDisabled);

                    if (!data.IsDisabled)
                    {
                        subCommands += data.IsCrop ? $"MaestroResizer.{data.SectionName}.crop;" : $"MaestroResizer.{data.SectionName};";

                        if (data.IsCrop)
                        {
                            separatorAdded = true;
                        }
                    }
                }
                subMenu.SetValue("SubCommands", subCommands);
            }
        }

        private void CreateCommand(IData data, bool addSeparator)
        {
            if (data.IsCrop)
            {
                string commandKey = $@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\Shell\MaestroResizer.{data.SectionName}.crop";
                using (RegistryKey command = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(commandKey, RegistryKeyPermissionCheck.ReadWriteSubTree) ?? RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).CreateSubKey(commandKey))
                {
                    command.SetValue("MUIVerb", data.CommandName + " + обрезать");

                    if (addSeparator)
                    {
                        command.SetValue("CommandFlags", 0x00000020, RegistryValueKind.DWord);
                    }
                    else
                    {
                        if (command.GetValue("CommandFlags") != null)
                        {
                            command.DeleteValue("CommandFlags");

                        }
                    }
                }

                string commandPath = $@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\Shell\MaestroResizer.{data.SectionName}.crop\command";
                using (RegistryKey commandExec = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(commandPath, RegistryKeyPermissionCheck.ReadWriteSubTree) ?? RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).CreateSubKey(commandPath))
                {
                    commandExec.SetValue("", $"\"{appPath}\" \"{data.Width}\" \"{data.Height}\" \"crop\" \"%1\"");
                }
            }
            else
            {
                string commandKey = $@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\Shell\MaestroResizer.{data.SectionName}";
                using (RegistryKey command = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(commandKey, RegistryKeyPermissionCheck.ReadWriteSubTree) ?? RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).CreateSubKey(commandKey))
                {
                    command.SetValue("MUIVerb", data.CommandName);
                }

                string commandPath = $@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\Shell\MaestroResizer.{data.SectionName}\command";
                using (RegistryKey commandExec = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(commandPath, RegistryKeyPermissionCheck.ReadWriteSubTree) ?? RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).CreateSubKey(commandPath))
                {
                    commandExec.SetValue("", $"\"{appPath}\" \"{data.Width}\" \"{data.Height}\" \"%1\"");
                }
            }
        }

        private void DeleteAllContextMenu()
        {
            DeleteContextMenu(".jpg");
            DeleteContextMenu(".jpeg");
            DeleteContextMenu(".png");
            DeleteContextMenu(".bmp");
            DeleteContextMenu(".tiff");

            isContextMenuCreated = false;
            ShowCreateButton();
        }

        private void DeleteContextMenu(string extension)
        {
            string subMenuKey = $@"SystemFileAssociations\{extension}\Shell";
            using (RegistryKey subMenu = Registry.ClassesRoot.OpenSubKey(subMenuKey, true))
            {
                if (subMenu != null && subMenu.SubKeyCount > 0)
                {
                    subMenu.DeleteSubKeyTree("MaestroResizer", false);
                }
            }

            foreach (IData data in datas)
            {
                string commandKey = $@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\Shell";

                using (RegistryKey command = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(commandKey, true))
                {
                    if (command != null && command.SubKeyCount > 0)
                    {
                        command.DeleteSubKeyTree($"MaestroResizer.{data.SectionName}", false);
                    }
                }

                string commandCropKey = $@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\Shell";

                using (RegistryKey commandCrop = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(commandCropKey, true))
                {
                    if (commandCrop != null && commandCrop.SubKeyCount > 0)
                    {
                        commandCrop.DeleteSubKeyTree($"MaestroResizer.{data.SectionName}.crop", false);
                    }
                }
            }
        }

        private void LoadData()
        {
            string[] items = Settings.Default.Data.Split(';');
            foreach (string item in items)
            {
                string[] values = item.Split(',');
                datas.Add(new CommandData
                {
                    SectionName = values[0],
                    CommandName = values[1],
                    Width = values[2],
                    Height = values[3],
                    IsCrop = bool.Parse(values[4]),
                    IsDisabled = bool.Parse(values[5])
                });
            }
        }

        private void SaveData()
        {
            try
            {
                CreateAllContextMenu();

                string stringData = string.Join(";", datas.Select(d => $"{d.SectionName},{d.CommandName},{d.Width},{d.Height},{d.IsCrop},{d.IsDisabled}"));
                Settings.Default.Data = stringData;
                Settings.Default.Save();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка сохранения.", "Maestro Resizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgwData_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (e.ColumnIndex == 1)
            {
                DataGridViewRow row = dgwData.Rows[e.RowIndex];
                row.Cells[1].Value = (bool)row.Cells[2].Value ? Resources.on : Resources.off;
            }
        }

        private void dgwData_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (e.ColumnIndex == 1)
            {
                DataGridViewRow row = dgwData.Rows[e.RowIndex];
                row.Cells[1].Value = (bool)row.Cells[2].Value ? Resources.off : Resources.on;
            }
        }

        private void dgwData_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (e.ColumnIndex == 1)
            {
                DataGridViewRow row = dgwData.Rows[e.RowIndex];
                IData data = datas[e.RowIndex];
                if (data != null)
                {
                    data.IsDisabled = !data.IsDisabled;
                    row.Cells[1].Value = data.IsDisabled ? Resources.on : Resources.off;
                    row.Cells[2].Value = data.IsDisabled;
                    SaveData();
                }
            }
        }

        private void btnCreateToggle_Click(object sender, EventArgs e)
        {
            if (isContextMenuCreated)
            {
                DeleteAllContextMenu();
            }
            else
            {
                CreateAllContextMenu();
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            pInstalled.Visible = false;
        }

        private void btnBackToInstalled_Click(object sender, EventArgs e)
        {
            pInstalled.Visible = true;
        }

        private void ShowDeleteButton()
        {
            btnCreateToggle.Text = "Убрать пункт меню";
            btnCreateToggle.BackColor = Color.Firebrick;
            btnSettings.Enabled = true;
            pbxInfo.Image = Resources.success;
            lblInfo.Text = "Пункт меню «Изменить размер» добавлен";
        }

        private void ShowCreateButton()
        {
            btnCreateToggle.Text = "Создать пункт меню";
            btnCreateToggle.BackColor = Color.ForestGreen;
            btnSettings.Enabled = false;
            pbxInfo.Image = Resources.disabled;
            lblInfo.Text = "Пункт меню «Изменить размер» не добавлен";
        }
    }
}
