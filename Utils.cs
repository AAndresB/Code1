class Utils{
    public static string LeerString(string mensaje){
    Console.WriteLine(mensaje);
    return Console.ReadLine();
}

    public static void MostrarError(string mensaje){
    Console.WriteLine(mensaje);
    Console.ReadKey();
}
}