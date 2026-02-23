using System.Text.Json;

namespace ButorokJSON
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string file = File.ReadAllText("butorok.json", System.Text.Encoding.Latin1);
                Gyoker gy = JsonSerializer.Deserialize<Gyoker>(file);

                foreach (var t in gy.targyak)
                {
                    if (t.anyag.ToLower().Contains ("fa"))
                        Console.WriteLine(t);
                }
                Targyak max = gy.targyak[0];
                foreach (var targy in gy.targyak);
                {
                    if (targy.terfogat() > max.terfogat())
                        max = targy;
                }
                Console.WriteLine("Legnagyobb:"+ max);
            }
            int osszeg = 0;
            foreach (var targy in gy.targyak)
                {
                    if (targy.keszleten)
                    osszeg += targy.ar;
                }
            Console.WriteLine($"Készleten lévők összára: {osszeg}Ft.");

            catch (JsonException ex)
            {
                Console.WriteLine("Elérésiút hiba :" + ex.Message);

            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Elérésiút hiba :" + ex.Message);

            }
            catch (FileNotFoundException ex) 
            {
                Console.WriteLine("Fájl elérési hiba :" + ex.Message);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fájlkezelési hiba :" + ex.Message);

            }
           
        }

    }
}
