using Core.Enums;

namespace Core.Interfaces;
public interface IPrinter{
    void SetDatabase(IDataBase db);
    void SetProyectType(ProyectType proyect);
    void SetPrinter(IPrinterUtility printer);
    void Print(); 
}
