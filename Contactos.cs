public class Contacto
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string NumeroTelefono { get; set; }
}

public class GestorContactos
{
    private List<Contacto> contactos;

    public GestorContactos()
    {
        contactos = new List<Contacto>();
    }

    public void AgregarContacto(string nombre, string apellido, string numeroTelefono)
    {
        // Validar que el número de teléfono solo contiene dígitos
        if (numeroTelefono.All(char.IsDigit))
        {
            Contacto nuevoContacto = new Contacto { Nombre = nombre, Apellido = apellido, NumeroTelefono = numeroTelefono };
            contactos.Add(nuevoContacto);
            Console.WriteLine("Contacto agregado exitosamente.");
        }
        else
        {
            Console.WriteLine("Número de teléfono no válido. Debe contener solo dígitos.");
        }
    }


    public void EditarContacto(string nombreAntiguo, string nuevoNombre, string nuevoApellido, string nuevoNumeroTelefono){
        Contacto contactoAEditar = contactos.Find(c => c.Nombre.Equals(nombreAntiguo, StringComparison.OrdinalIgnoreCase));

        if (contactoAEditar != null){
            contactoAEditar.Nombre = nuevoNombre;
            contactoAEditar.Apellido = nuevoApellido;
            contactoAEditar.NumeroTelefono = nuevoNumeroTelefono;
            Console.WriteLine("Contacto editado exitosamente.");
        }else{
            Console.WriteLine("Contacto no encontrado.");
        }
    }

    public void EliminarContacto(string nombre){
        Contacto contactoAEliminar = contactos.Find(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

        if (contactoAEliminar != null){
            contactos.Remove(contactoAEliminar);
            Console.WriteLine("Contacto eliminado exitosamente.");
        }else{
            Console.WriteLine("Contacto no encontrado.");
        }
    }

    public void BuscarContacto(string nombre){
        Contacto contactoEncontrado = contactos.Find(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

        if (contactoEncontrado != null){
            Console.WriteLine($"Contacto encontrado: {contactoEncontrado.Nombre}, Apellido: {contactoEncontrado.Apellido} Teléfono: {contactoEncontrado.NumeroTelefono}");
        }else{
            Console.WriteLine("Contacto no encontrado.");
        }
    }

    public void MostrarContactos(){
        Console.WriteLine("Contactos:");
        foreach (var contacto in contactos){
            Console.WriteLine($"Nombre: {contacto.Nombre}, Apellido: {contacto.Apellido} Teléfono: {contacto.NumeroTelefono}");
        }
        
    }
}

public class Gestor{
    public static void Main(){
        bool continuar = true;

        GestorContactos gestorContactos = new GestorContactos();

        while(continuar){
            Console.Clear();

            Console.WriteLine("Menú del Gestor de Contactos:");
            Console.WriteLine("1. Agregar Contacto");
            Console.WriteLine("2. Editar Contacto");
            Console.WriteLine("3. Eliminar Contacto");
            Console.WriteLine("4. Buscar Contacto");
            Console.WriteLine("5. Mostrar Contactos");
            Console.WriteLine("6. Volver al Menú");
            Console.WriteLine("Ingrese su opción (1-6): ");

            string opcion = Console.ReadLine();

            switch (opcion){
                case "1":
                    Console.WriteLine("Ingrese el nombre del contacto: ");
                    string agregarNombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el apellido del contacto: ");
                    string agregarApellido = Console.ReadLine();
                    Console.WriteLine("Ingrese el número de teléfono del contacto: ");
                    string agregarNumeroTelefono = Console.ReadLine();
                    gestorContactos.AgregarContacto(agregarNombre, agregarApellido, agregarNumeroTelefono);
                    break;

                case "2":
                    Console.WriteLine("Ingrese el nombre del contacto existente: ");
                    string nombreAntiguo = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo nombre del contacto: ");
                    string nuevoNombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo apellido del contacto: ");
                    string nuevoApellido = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo número de teléfono del contacto: ");
                    string nuevoNumeroTelefono = Console.ReadLine();
                    gestorContactos.EditarContacto(nombreAntiguo, nuevoNombre, nuevoApellido, nuevoNumeroTelefono);
                    Utils.MostrarError("");
                    break;

                case "3":
                    Console.Write("Ingrese el nombre del contacto a eliminar: ");
                    string eliminarNombre = Console.ReadLine();
                    gestorContactos.EliminarContacto(eliminarNombre);
                    Utils.MostrarError("");
                    break;

                case "4":
                    Console.Write("Ingrese el nombre del contacto a buscar: ");
                    string buscarNombre = Console.ReadLine();
                    gestorContactos.BuscarContacto(buscarNombre);
                    Utils.MostrarError("");
                    Console.Clear();
                    break;

                case "5":
                    Console.Clear();
                    gestorContactos.MostrarContactos();
                    Utils.MostrarError("");
                    break;

                case "6":
                    continuar = false;
                    break;

                default:
                    Utils.MostrarError("Opción inválida. Por favor ingrese un número entre 1 y 6.");
                    break;
            }

            Console.WriteLine("");
        }
    }
}
