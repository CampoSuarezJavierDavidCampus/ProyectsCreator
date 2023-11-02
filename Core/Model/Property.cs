using Core.Enums;
using Core.Interfaces;
using Core.Interfaces.Util;
using Core.Model.Util;

namespace Core.Model;
public class Property : IProperty{    
    private IUtilityName Name { get; set; }
    private IUtilityPropertyType Type { get; set;}
    
    
    public Property(){
        Name = new UtilityName();
        Type = new UtilityPropertyType();
    }

    #region Name
        public string GetName()=>Name.GetName();
        public void SetName()=>Name.SetName();
        public void SetName(string name)=> Name.SetName(name);
    #endregion

    #region Type    
        public bool IsRequired => Type.IsRequired;
        public int Maxlength => Type.Maxlength;
        public PropertyType GetPropertyType() => Type.GetPropertyType();
        public PropertyType SetPropertyType() => Type.SetPropertyType();
        public PropertyType SetPropertyType(PropertyType type) => Type.SetPropertyType(type);
    #endregion

    #region Menu
        public void ShowConsoleMenu(){           
            string options = """
            Seleccione opcion a realizar
            1) Cambiar el nombre de la propiedad.
            2) Cambiar el tipo de la propiedad
            """;
            Console.WriteLine("Estado Actual:");
            ShowDetails();
            ConsoleUtility.ShowConsoleMenu(options,ValidateOperation);
        }    

        private bool ValidateOperation(int OP){
            switch (OP){
                case 1:
                    SetName();
                    break;
                case 2:
                    SetPropertyType();
                    break;
                default:
                    return false;                
            }
            return true;
        }    
    #endregion
    public void ShowDetails(){        
        string name = GetName();
        PropertyType type = GetPropertyType();
        Console.WriteLine($"{name,-20}: {type, -8} // Is Required {IsRequired}; Max Length {Maxlength}");
    }

    
}
