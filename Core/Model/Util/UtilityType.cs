using Core.Enums;
using Core.Interfaces.Util;

namespace Core.Model.Util;
public class UtilityPropertyType: IUtilityPropertyType{
    public bool IsRequired { get; private set; } = false;
    public int Maxlength {get; private set;} = -1;
    private PropertyType? Type {get; set;}
        
    public PropertyType GetPropertyType(){//* Entrega La propiedad type
        if(Type is null) SetPropertyType();
        return (PropertyType) Type!;
    }

    public PropertyType SetPropertyType(){ //*Define la propiedad.
        Type = null;
        string options ="""
        Seleccione el tipo de dato
            1) String
            2) Int
            3) Double
            4) Bool
            5) DateTime
        """;
        ConsoleUtility.ShowConsoleMenu(options,SelectProperty);

        SetIsRequired();
        return (PropertyType) Type!;
    }            
    public PropertyType SetPropertyType(PropertyType type) => (PropertyType)(Type = type);

    private bool SelectProperty(int OP){ //* Selecciona el tipo de dato.
        Type = OP switch{
            1 => PropertyType.String,
            2 => PropertyType.Int,
            3 => PropertyType.Double,
            4 => PropertyType.Bool,
            5 => PropertyType.DateTime,
            _ => null
        };

        if(Type is null)return false;   

        if(
            OP == 1 ||
            OP == 2 ||
            OP == 3 
        )SetMaxLength();

        return true;
    }
    
    private void SetIsRequired(){ //* Valida si es requerida.
    Console.WriteLine("El dato es requerido?");
        if(Console.ReadLine()?.Trim().ToLower() == "si") IsRequired = true;            
    }

    private void SetMaxLength(){ //* Valida el tamaño maximo.
        while(Maxlength == -1){
            Console.WriteLine("Cual es el tamaño maximo?");
            if(!int.TryParse(Console.ReadLine(),out int Length))continue;
            if(Length < 1) continue;
            Maxlength = Length;            
        }
    }    
}
