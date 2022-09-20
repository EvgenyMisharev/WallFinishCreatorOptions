using System.IO;
using System.Xml.Serialization;

namespace WallFinishCreatorOptions
{
    public class WallFinishCreatorOptionsSettings
    {
        public string FloorCreationOptionValue { get; set; }
        public static WallFinishCreatorOptionsSettings GetSettings()
        {
            WallFinishCreatorOptionsSettings wallFinishCreatorOptionsSettings = null;
            string assemblyPathAll = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string fileName = "WallFinishCreatorOptionsSettings.xml";
            string assemblyPath = assemblyPathAll.Replace("WallFinishCreatorOptions.dll", fileName);

            if (File.Exists(assemblyPath))
            {
                using (FileStream fs = new FileStream(assemblyPath, FileMode.Open))
                {
                    XmlSerializer xSer = new XmlSerializer(typeof(WallFinishCreatorOptionsSettings));
                    wallFinishCreatorOptionsSettings = xSer.Deserialize(fs) as WallFinishCreatorOptionsSettings;
                    fs.Close();
                }
            }
            else
            {
                wallFinishCreatorOptionsSettings = new WallFinishCreatorOptionsSettings();
            }

            return wallFinishCreatorOptionsSettings;
        }

        public void SaveSettings()
        {
            string assemblyPathAll = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string fileName = "WallFinishCreatorOptionsSettings.xml";
            string assemblyPath = assemblyPathAll.Replace("WallFinishCreatorOptions.dll", fileName);

            if (File.Exists(assemblyPath))
            {
                File.Delete(assemblyPath);
            }

            using (FileStream fs = new FileStream(assemblyPath, FileMode.Create))
            {
                XmlSerializer xSer = new XmlSerializer(typeof(WallFinishCreatorOptionsSettings));
                xSer.Serialize(fs, this);
                fs.Close();
            }
        }
    }
}
