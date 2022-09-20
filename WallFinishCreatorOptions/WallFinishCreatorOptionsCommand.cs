using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace WallFinishCreatorOptions
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    class WallFinishCreatorOptionsCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            WallFinishCreatorOptionsWPF wallFinishCreatorOptionsWPF = new WallFinishCreatorOptionsWPF();
            wallFinishCreatorOptionsWPF.ShowDialog();
            if (wallFinishCreatorOptionsWPF.DialogResult != true)
            {
                return Result.Cancelled;
            }
            return Result.Succeeded;
        }
    }
}
