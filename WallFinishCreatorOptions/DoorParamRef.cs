using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallFinishCreatorOptions
{
    [Serializable]
    public class DoorParamRef
    {
        public string Name { get; set; }
        public bool IsShared { get; set; }
        public Guid SharedGuid { get; set; }          // если IsShared == true
        public BuiltInParameter BuiltIn { get; set; } // если IsShared == false

        // для удобства сравнения в HashSet
        public override bool Equals(object obj) =>
            obj is DoorParamRef other && Name == other.Name;
        public override int GetHashCode() => Name.GetHashCode();
    }
}
