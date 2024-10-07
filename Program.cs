bool continuar = true;

while(continuar){
    Console.Clear();
    Console.WriteLine(@"
    1- Calculadora
    2- Cédula
    3- Gestor de Contactos
    X: Salir del programa
    ");

    string opcion = Utils.LeerString("Digita la opción que deseas utilizar");
    switch(opcion){
        case "1":
        Desarrollo.Calculadora();
        break;
        case "2":
        Desarrollo.Cedula();
        break;
        case "3":
        Gestor.Main();
        break;
        case "X":
        case "x":
        continuar = false;
        Utils.MostrarError("Finalizando programa....");
        break;
        default:
        Utils.MostrarError("Opción no válida");
        break;


    }



}	


	
	