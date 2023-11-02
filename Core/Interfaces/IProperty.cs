using Core.Enums;

namespace Core.Interfaces;
public interface IProperty:IUtilityName,IUtilityShowDetails,IConsoleUtility{
    bool IsRequired { get; }
    int Maxlength {get; }
    
    PropertyType GetPropertyType();
    PropertyType SetPropertyType();
    PropertyType SetPropertyType(PropertyType type);
}
