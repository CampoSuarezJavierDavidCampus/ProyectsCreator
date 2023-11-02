namespace Core.Interfaces;
public interface IDataBase: IUtilityName, IConsoleUtility, IUtilityShowDetails{
    #region Entity CRUD
        IEntity AddEntity();
        void RemoveEntity(string name);
        void UpdateEntity(string name);
        IEntity GetByName(string name);
        ICollection<IEntity> GetAll();
    #endregion        
}
