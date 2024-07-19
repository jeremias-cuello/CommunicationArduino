using System;
using System.ComponentModel.DataAnnotations;
using System.IO.Ports;

using SerialPort serialPort = new("COM3", 9600)
{
    Parity = Parity.None,
    StopBits = StopBits.One,
    DataBits = 8,
    Handshake = Handshake.None
};

const string CENTINELA = "OK"; 
string dataToSend;
string receivedData;
string[] arrOpts = ["OFF", "ON", "DISABLE"];
bool validated;

serialPort.Open();
Console.WriteLine("El programa finaliza con CENTINELA = {0}", CENTINELA);

while (serialPort.IsOpen)
{
    do
    {
        Console.WriteLine("Ingrese una dato a enviar al Arduino:");
        foreach (var opt in arrOpts)
        {
            Console.WriteLine("\t[{0}]", opt);
        }
        Console.Write("Eleccion: ");
        dataToSend = Console.ReadLine();

        validated = arrOpts.Contains(dataToSend) || dataToSend.Equals(CENTINELA, StringComparison.OrdinalIgnoreCase);

        if (!validated) Console.WriteLine("Error. Opcion invalida.");
    } while (!validated);

    if (dataToSend.Equals(CENTINELA, StringComparison.OrdinalIgnoreCase))
    {
        serialPort.Close();
        break;
    }

    try
    {
        serialPort.WriteLine(dataToSend);

        // Lee los datos del puerto serie
        Console.WriteLine("Datos recibidos del Arduino: ");
        receivedData = serialPort.ReadLine();
        while (!receivedData.Trim().Equals("FIN"))
        {
            Console.WriteLine(receivedData); 
            receivedData = serialPort.ReadLine();
        }
    }
    catch (TimeoutException err) { 
        Console.WriteLine("ERROR: " + err.Message);
    }
}
