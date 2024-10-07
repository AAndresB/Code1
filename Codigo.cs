
class Desarrollo{


   public static void Calculadora(){
    bool continuar = true;

    while (continuar){
        Console.Clear();
        double num1 = 0;
        double num2 = 0;
        double res = 0;

        Console.WriteLine(@"
----------------------------------------------------------        
|  __             __                  __   __   __       |
| /  `  /\  |    /  ` |  | |     /\  |  \ /  \ |__)  /\  |
| \__, /~~\ |___ \__, \__/ |___ /~~\ |__/ \__/ |  \ /~~\ |
----------------------------------------------------------
                                                                                                                                                                                                                                           
    ");

        Console.Write("Ingresar primer dígito: ");
        while (!double.TryParse(Console.ReadLine(), out num1))
        {
            Console.WriteLine("Por favor, ingresa un número");
            Console.Write("Ingresar primer dígito: ");
        }

        Console.Write("Ingresar segundo dígito: ");
        while (!double.TryParse(Console.ReadLine(), out num2))
        {
            Console.WriteLine("Por favor, ingresa un número");
            Console.Write("Ingresar segundo dígito: ");
        }

        Console.WriteLine("Selecciona una opción: ");
        Console.WriteLine("\t+ : Suma");
        Console.WriteLine("\t- : Resta");
        Console.WriteLine("\t* : Multiplicación");
        Console.WriteLine("\t/ : División");
        Console.Write("Selecciona una: ");

        switch (Console.ReadLine())
        {
            case "+":
                res = num1 + num2;
                Console.WriteLine($"Suma: {num1} + {num2} = " + res);
                break;
            case "-":
                res = num1 - num2;
                Console.WriteLine($"Resta: {num1} - {num2} = " + res);
                break;
            case "*":
                res = num1 * num2;
                Console.WriteLine($"Multiplicación: {num1} * {num2} = " + res);
                break;
            case "/":
                if (num2 != 0)
                {
                    res = num1 / num2;
                    Console.WriteLine($"División: {num1} / {num2} = " + res);
                }
                else
                {
                    Console.WriteLine("No se puede dividir entre cero.");
                }
                break;
            default:
                Console.WriteLine("Opción no válida");
                break;
        }

        Console.Write("Deseas continuar? (S/N): ");
        string respuesta = Console.ReadLine().ToUpper(); // Convertir la respuesta a mayúsculas

        if (respuesta != "S")
        {
            continuar = false;
        }
    }
}
// ----------------------------------------------------------------------------------------------------
// ----------------------------------------------------------------------------------------------------
// ----------------------------------------------------------------------------------------------------
// ----------------------------------------------------------------------------------------------------

      public static void Cedula(){
    bool continuar = true;

    while (continuar)
    {
        Console.Clear();
        string url;
        string cedula = Utils.LeerString("Digite la cedula");
        url = "https://api.adamix.net/apec/cedula/" + cedula;

        System.Net.WebClient client = new System.Net.WebClient();
        string datos = client.DownloadString(url);

        var respuesta = Newtonsoft.Json.JsonConvert.DeserializeObject<Persona>(datos);

// La propiedad "ok" es utilizada para indicar si el proceso fue realizado con éxito o no
        if (respuesta.ok)
        {
            Console.WriteLine("Nombre: " + respuesta.Nombres);
            Console.WriteLine("Apellido: " + respuesta.Apellido1);
            Console.WriteLine("Fecha de nacimiento: " + respuesta.FechaNacimiento);
            Console.WriteLine("Lugar de Nacimiento: " + respuesta.LugarNacimiento);
            Console.WriteLine("Sexo: " + respuesta.IdSexo);
            Console.WriteLine("Estado civil: " + respuesta.IdEstadoCivil);

            string plantilla = System.IO.File.ReadAllText("PlantillaPersona.html");

            plantilla = plantilla.Replace("{Nombres}", respuesta.Nombres);
            plantilla = plantilla.Replace("{Apellidos}", respuesta.Apellido1 + " " + respuesta.Apellido2);
            plantilla = plantilla.Replace("{Fecha_Nacimiento}", respuesta.FechaNacimiento);
            plantilla = plantilla.Replace("{Lugar_Nacimiento}", respuesta.LugarNacimiento);
            plantilla = plantilla.Replace("{Id_Sexo}", respuesta.IdSexo);
            plantilla = plantilla.Replace("{Id_Estado_Civil}", respuesta.IdEstadoCivil);
            plantilla = plantilla.Replace("{edad}", respuesta.edad().ToString());
            plantilla = plantilla.Replace("{url_foto}", respuesta.foto);

            System.IO.File.WriteAllText("cedula.html", plantilla);
            var uri = "cedula.html";
            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = uri;
            System.Diagnostics.Process.Start(psi);


            Console.Write("¿Desea continuar usando el programa? (S/N): ");
            string respuestaUsuario = Console.ReadLine().ToUpper(); // Convertir la respuesta a mayúsculas

            if (respuestaUsuario != "S")
            {
                continuar = false;
            }
        }
        else
        {
            Utils.MostrarError("Cedula no valida");

            Console.Write("¿Desea ingresar otra cédula? (S/N): ");
            string respuestaUsuario = Console.ReadLine().ToUpper(); // Convertir la respuesta a mayúsculas

            if (respuestaUsuario != "S")
            {
                continuar = false;
            }
        }
    }

    
}


public class Persona{

public string Cedula { get; set; }
public string Nombres { get; set; }
public string Apellido1 { get; set; }
public string Apellido2 { get; set; }
public string FechaNacimiento { get; set; }

public string LugarNacimiento { get; set; }

public string IdSexo { get; set; }

public string IdEstadoCivil { get; set; }
public bool ok { get; set; }
public string foto { get; set; }

public double edad(){

DateTime fechaNacimiento = DateTime.Parse(FechaNacimiento);
DateTime fechaActual = DateTime.Now;
int edad = fechaActual.Year - fechaNacimiento.Year;
return edad;
}
}
}



        



