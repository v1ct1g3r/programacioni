namespace Centralita;

public class Practica2
{
    public static void Main(string[] args)
    {
        Centralita centralita = new Centralita();

        Console.WriteLine("=== CENTRALITA TELEFONICA ===");
        Console.WriteLine("--- Llamadas registradas ---");

        LLamadaLocal local1 = new LLamadaLocal("600111222", "600333444", 60);
        centralita.registrarLLamada(local1);

        LLamadaLocal local2 = new LLamadaLocal("600555666", "600777888", 120);
        centralita.registrarLLamada(local2);

        LLamadaProvincial prov1 = new LLamadaProvincial("911000001", "911000002", 45, 1);
        centralita.registrarLLamada(prov1);

        LLamadaProvincial prov2 = new LLamadaProvincial("911000003", "911000004", 90, 2);
        centralita.registrarLLamada(prov2);

        LLamadaProvincial prov3 = new LLamadaProvincial("911000005", "911000006", 30, 3);
        centralita.registrarLLamada(prov3);

        Console.WriteLine();
        Console.WriteLine("=== INFORME FINAL ===");
        Console.WriteLine("Total de llamadas registradas : " + centralita.getTotalLLamadas());
        Console.WriteLine("Facturacion total             : " + centralita.getTotalFacturado().ToString("F2") + " eur");
    }
}
