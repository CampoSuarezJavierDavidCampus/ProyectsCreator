namespace Core.Interfaces;
public interface IEntity:IUtilityName,IConsoleUtility,IUtilityShowDetails{

    #region CRUD Property 
        IProperty AddProperty();
        void RemoveProperty(string name);
        void UpdateProperty(string name);
        IProperty? GetByName(string name);
        ICollection<IProperty> GetAll();
    #endregion   
}
