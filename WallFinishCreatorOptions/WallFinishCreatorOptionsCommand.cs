using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.IO;
using System.Reflection;

namespace WallFinishCreatorOptions
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    class WallFinishCreatorOptionsCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                GetPluginStartInfo();
            }
            catch { }

            WallFinishCreatorOptionsWPF wallFinishCreatorOptionsWPF = new WallFinishCreatorOptionsWPF();
            wallFinishCreatorOptionsWPF.ShowDialog();
            if (wallFinishCreatorOptionsWPF.DialogResult != true)
            {
                return Result.Cancelled;
            }
            return Result.Succeeded;
        }
        private static void GetPluginStartInfo()
        {
            // Получаем сборку, в которой выполняется текущий код
            Assembly thisAssembly = Assembly.GetExecutingAssembly();
            string assemblyName = "WallFinishCreatorOptions";
            string assemblyNameRus = "Свойства отделки стен";
            string assemblyFolderPath = Path.GetDirectoryName(thisAssembly.Location);

            int lastBackslashIndex = assemblyFolderPath.LastIndexOf("\\");
            string dllPath = assemblyFolderPath.Substring(0, lastBackslashIndex + 1) + "PluginInfoCollector\\PluginInfoCollector.dll";

            Assembly assembly = Assembly.LoadFrom(dllPath);
            Type type = assembly.GetType("PluginInfoCollector.InfoCollector");
            var constructor = type.GetConstructor(new Type[] { typeof(string), typeof(string) });

            if (type != null)
            {
                // Создание экземпляра класса
                object instance = Activator.CreateInstance(type, new object[] { assemblyName, assemblyNameRus });
            }
        }
    }
}
