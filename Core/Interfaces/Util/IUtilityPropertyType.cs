using Core.Enums;

namespace Core.Interfaces.Util;
public interface IUtilityPropertyType{
    bool IsRequired { get; }
    int Maxlength {get; }
    PropertyType GetPropertyType();
    PropertyType SetPropertyType();
    PropertyType SetPropertyType(PropertyType type);
}
