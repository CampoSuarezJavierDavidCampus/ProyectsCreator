using Core.Enums;
using Core.Interfaces;
using Core.Model.Util;

namespace Core.Model;
public class Entity : IEntity{
    private UtilityName Name { get; set; }
    private ICollection<IProperty> Properties { get; set; } = new HashSet<IProperty>();    
    public Entity(){
        //definir Id
        IProperty prop = new Property();        
        prop.SetPropertyType(PropertyType.String);
        prop.SetName("ID");
        Properties.Add(prop);

        //definir la variable nombre
        Name = new UtilityName();             
    }

    #region Name
        public string GetName() => Name.GetName();
        public void SetName() => Name.SetName();
        public void SetName(string name) => Name.SetName(name);
    #endregion

    #region CRUD Property
        public IProperty AddProperty(){
            IProperty prop = new Property();
            prop.ShowConsoleMenu();
            Properties.Add(prop);
            return prop;
        }

        public void RemoveProperty(string name) {            
            IProperty? prop = GetByName(name);        
            if(prop is not null && prop.GetName() != "ID") Properties.Remove(prop);
        }
        
        public void UpdateProperty(string name){
            IProperty? prop = GetByName(name);
            prop?.ShowConsoleMenu();
        }
        public IProperty? GetByName(string name)=> Properties.FirstOrDefault(x => x.GetName() == name);
        public ICollection<IProperty> GetAll() => Properties;        

    #endregion

    #region Menu
        public void ShowConsoleMenu(){
            string options = $"""
            ------------------------
            Entidad: {Name}
            1) Agregar propiedad.
            2) Remover propiedad.
            3) Actualizar propiedad.
            4) Mostrar propiedades.
            5) Buscar propiedad
            6) cambiar nombre de entidad.
            """;
            ConsoleUtility.ShowConsoleMenu(options, ValidateOption);
        }

        private bool ValidateOption(int OP){
            string? name = null;
            if(OP == 2 || OP == 3 || OP == 5){
                Console.WriteLine("Ingrese el nombre de la propiedad a buscar");
                name = Console.ReadLine();
                if(name is null && UtilityName.Validate(name!)){
                    Console.WriteLine("Propiedad no encontrada");
                    return true;
                }                        
            }

            switch(OP){
                case 1: AddProperty(); break;
                case 2: RemoveProperty(name!); break;
                case 3: UpdateProperty(name!); break;
                case 4: ShowDetails(); break;
                case 5: GetByName(name!)?.ShowDetails(); break;
                case 6: SetName(); break;
                default: return false;
            }
            return true;
        }
    #endregion

    public void ShowDetails(){
        string Name = GetName();        
        Console.WriteLine("------------------------");
        Console.WriteLine($"Table: {Name}");
        Console.WriteLine($"{"Nombre",-20}: {"Tipo", -8}");
        foreach (IProperty prop in Properties){
            prop.ShowDetails();
        }
    }
    
}
