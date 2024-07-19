# CommunicationArduino

Este repositorio trata de como se puede establecer una comunicación con un Arduino a traves de algún puerto COM1 o COM2, etc.
Puede ser realmente potente esta funcionalidad ya que el arduino puede brindarnos información del exterior hacia la computadora (sensor) y de la computadora hacia el arduino (actuador), por ejemplo, si esta lloviendo y si le mandamos cerrar la ventana respectivamente. Este repo usa la API de Windows System.IO.Ports, con esto se obtiene un objeto SerialPort cual es interfaz de comunicación con el Arduino con las dependencias de el puerto y el número de baudios.
Visual Studio 2022 | .Net 8.0 | C# | Arduino
