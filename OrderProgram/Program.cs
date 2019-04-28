using System;
using System.Text.RegularExpressions;


namespace OrderProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Employee employee = new Employee();
            Client client = new Client();
            Product product = new Product();
            Order order = new Order();
            StartProgram(employee, client, product,order);
        }

        // Recursive program function
        public static void StartProgram(Employee employee, Client client,Product product,Order order)
        {
            Console.WriteLine("Xahis edirik secim edin\n i - işçi yaratmaq \n m - müşteri yaratmaq \n p - Mehsul yaratmaq \n o - sifariş yaratmaq");
            bool correct = false;
             
            do
            {
                string variant = Console.ReadLine();
                switch (variant)
                {
                    case "i":

                        Console.WriteLine("İşçi elavesi bölmesi\n");

                        employee.Name = GetInput("Ad", "Ishcinin adini yazin", "onlyString");
                        employee.Surname = GetInput("Soyad", "Soyadini daxil edin", "onlyString");
                        employee.Birthday = GetInput("Dogum tarixi", "Dogum tarixini yazin (ISO formatta 1993.05.25)", "dataType");
                        employee.Card_ID = Convert.ToInt32(GetInput("Vesiqe kodu", "Vesiqesinin kodunu daxil edin", "onlyNumber"));
                        employee.Position = GetInput("Vesife", "Vesifesini qeyd edin", "any");
                        employee.Salary = Convert.ToInt32(GetInput("Maash", "Maashini daxil edin", "onlyNumber"));
                        Employee.ID++;
                        Console.WriteLine("Ishci yaradildi: " + Employee.ID + " " + employee.Name + " " + employee.Surname + " " + employee.getAge() + "\n");
                        StartProgram(employee,client,product,order);
                        
                        break;
                    case "m":
                     
                        Console.WriteLine("Mushteri bolmesi\n");

                        client.Name = GetInput("Ad", "Mushterinin adini yazin", "onlyString");
                        client.Surname = GetInput("Soyad", "Mushterinin Soyadini daxil edin", "onlyString");
                        client.Birthday = GetInput("Dogum tarixi", "Mushterinin Dogum tarixini yazin (ISO formatta 1993.05.25)", "dataType");
                        client.Card_ID = Convert.ToInt32(GetInput("Vesiqe kodu", "Mushterinin vesiqe kodunu daxil edin", "onlyNumber"));
                        client.Client_ID =  GetInput("Client ID","Musterinin Id-sini elave edin","any");
                        client.Address = GetInput("Unvan", "Musterinin unvanini qeyd edin", "any");
                        client.Phone = GetInput("Mobil", "Musterinin mobil nomresini yazin ( Format: 055-555-55-55 )", "phoneNumber");
                        Client.ID++;
                        Console.WriteLine("Mushteri yaradildi: " + Client.ID + " - " + client.Name + " " + client.Surname + "\n");
                        StartProgram(employee, client, product, order);

                        break;
                    case "p":

                        Console.WriteLine("Mehsul yaratma bolmesi\n");

                        product.Name =  GetInput("Ad", "Mehsulun adini qeyd edin", "any");
                        product.Color = GetInput("Reng", "Mehsulun rengini yazin", "onlyString");
                        product.Price = Convert.ToInt32( GetInput("Qiymet", "Mehsulun qiymetini yazin", "onlyNumber") );
                        Product.ID++;
                        Console.WriteLine("Mehsul yaradildi" +Product.ID+ " - " +product.Name+ " " +product.Color+ " " +product.Price+ "\n");
                        StartProgram(employee, client, product, order);

                        break;
                    case "o":

                        Console.WriteLine("Sifarish yaratma bolmesi\n");

                        order.Count = Convert.ToInt32(GetInput("Say", "Mehsulun sayini qeyd edin", "onlyNumber"));
                        order.client = client;
                        order.product = product;
                        Order.ID++;
                        Console.WriteLine("Sifarish yaradildi: " +Order.ID+ " " +order.product.Name+ " " + order.client.Name+ " Terefinden sifarish edildi. Sayi: " +order.Count+ " Cemi mebleg: " +order.Count * order.product.Price + " AZN");
                        Console.WriteLine("Sifarishi qebul eden ishci: " + employee.Name+ " " +employee.Surname+ " " +employee.Position);
                        break;
                    default:
                        Console.WriteLine("Düzgün seçim etmediniz, xahiş edirik siyahıdakılardan birini seçiniz");
                        break;
                }

                if (variant == "i" || variant == "m" || variant == "p" || variant == "o")
                {
                    correct = true;
                }
            }
            while (!correct);
            Console.ReadKey();
        }




        // Add items to objects
        static string GetInput(string header, string message, string pattern)
        {
            Console.WriteLine(message);
            string inp;
            bool find = false;
            string error = "";

            // Getting error name
            switch (pattern)
            {
                case "dataType":
                    error = " duzgun formatta tarix yazin";
                    break;
                case "onlyString":
                    error = " yalniz herf yazin";
                    break;
                case "onlyNumber":
                    error = " yalniz reqem yazin";
                    break;
                case "any":
                    error = "";
                    break;
                case "phoneNumber":
                    error = "duzgun formatta nomre yazin";
                    break;
            }

            do
            {
                // genereting input
               inp  = Console.ReadLine();
               if(Validation(inp, pattern))
                {
                    find = true;
                }
               else
                {
                    Console.WriteLine(header + " bolmesine " + error);
                }
            }
            while ( !Validation(inp, pattern) );

            // reutrning input if correct validation
            if (find == true) return inp;
            else return "Xeta! " + header + " Duzgun yazilmadi";
        }



        // validation inputs
        static bool Validation(string input, string pattern)
        {
            string patrn;
            switch (pattern)
            {
                case "dataType":
                    patrn = @"^([\d]{4})-([0-9]){2}-([0-9]){2}$";
                    break;
                case "onlyString":
                    patrn = @"^[A-Za-z]+$";
                    break;
                case "onlyNumber":
                    patrn = @"^\d+$";
                    break;
                case "any":
                    patrn = @"(.*?)";
                    break;
                case "phoneNumber":
                    patrn = @"^([\d]){3}-([\d]){3}-([\d]){2}-([\d]){2}$";
                    break;
                default:
                    patrn = @"^[A-Za-z0-9]+$";
                    break;
            }
            if (Regex.IsMatch(input, patrn, RegexOptions.IgnoreCase))
            {
                return true;
            }
            else return false;
        }

    }
}
