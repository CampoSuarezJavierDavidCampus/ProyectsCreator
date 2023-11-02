using Core.Interfaces;

namespace Core.Model.Util;
public static class ConsoleUtility{
    static public void ShowConsoleMenu(string opts, Func<int,bool> ValidateOption){
        while(true){
            Console.WriteLine($"""
            -----------------            
            {opts}
            precione X para salir
            """);
            
            string? Input = Console.ReadLine();
            if(Input?.Trim().ToLower() == "x")break;
            if(!int.TryParse(Input, out int OP )){
                Console.WriteLine("No se registro ninguna operacion.");
                continue;
            }

            if(ValidateOption(OP)){
                Console.WriteLine("No esta definida esa opcion.");
                continue;
            }
        }
    }
    
}


