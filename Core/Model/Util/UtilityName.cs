using System.Text.RegularExpressions;
using Core.Interfaces;
namespace Core.Model.Util;
public class UtilityName: IUtilityName{
    protected string? Name = null; 
    
    public static bool Validate(string name){
        string pattern = "^[a-zA-Z_][a-zA-Z0-9_]{2,19}$";
        if(Regex.IsMatch(name,pattern))return true;
        return false;
    } 

    #region Name
        public string GetName(){
            if(Name is null) SetName();
            return Name!;
        }
        public void SetName(){
            while(true){
                Console.WriteLine("Ingresa el nombre");
                string? name = Console.ReadLine();
                if(name is null)continue;
                if(!Validate(name.Trim())){
                    Console.WriteLine("El nombre ingresado no es valido o supera los 20 caracteres.");
                    continue;                
                }

                Console.WriteLine($"El nombre es \"{name}\".\n Desea guardar cambios (Si/No).");
                if(Console.ReadLine()?.Trim().ToLower() == "si" ){
                    Name = name;
                    break;
                }                    
            }
        }
        public void SetName(string name){
            if(!Validate(name)){
                SetName();
            }
            Name = name;            
        }
    #endregion    
}
