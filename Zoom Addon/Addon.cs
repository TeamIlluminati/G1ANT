using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using G1ANT.Language;
using System.IO;
using G1ANT.Addon.Zoom.Properties;
// Please remember to refresh G1ANT.Language.dll in references

namespace G1ANT.Addon.Zoom
{
    [Addon(Name = "zoom", Tooltip = "Addon to automate zoom website")]
    [Copyright(Author = "G1ANT Ltd", Copyright = "G1ant Ltd", Email = "hi@g1ant.com", Website = "www.g1ant.com")]
    [License(Type = "LGPL", ResourceName = "License.txt")]
    public class Addon : Language.Addon
    {
        public override void LoadDlls()
        {
            UnpackDrivers();
            base.LoadDlls();
        }

        private void UnpackDrivers()
        {
            var unpackFolder = AbstractSettingsContainer.Instance.UserDocsAddonFolder.FullName;
            var embeddedResourceDictionary = new Dictionary<string, byte[]>()
            {
                { "chromedriver.exe", Resources.chromedriver },
                { "geckodriver.exe", Resources.geckodriver },
                { "IEDriverServer.exe", Resources.IEDriverServer },
                { "MicrosoftWebDriver.exe", Resources.MicrosoftWebDriver }
            };
            foreach (var embededResource in embeddedResourceDictionary.Where(e => !DoesFileExist(unpackFolder, e.Key) || !AreFilesOfTheSameLength(e.Value.Length, unpackFolder, e.Key)))
            {
                try
                {
                    using (FileStream stream = File.Create(Path.Combine(unpackFolder, embededResource.Key)))
                    {
                        stream.Write(embededResource.Value, 0, embededResource.Value.Length);
                    }
                }
                catch (Exception ex) { RobotMessageBox.Show(ex.Message); }
            }
        }

        private bool DoesFileExist(string folder, string fileName)
        {
            return File.Exists(Path.Combine(folder, fileName));
        }

        private bool AreFilesOfTheSameLength(int length, string folder, string fileName)
        {
            return length == new FileInfo(Path.Combine(folder, fileName)).Length;
        }
    }
}