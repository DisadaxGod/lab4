using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WindowsFormsApp4
{
    public class Planets : Body
    {
        
        public int Radius = 0; // радиус //
        public bool Atmosphere = false; // наличие атмосферы //
        public int ForceOfGrav = 0; // сила гравитации //
        public override string GetInfo()
        {
            var str = "Планета\n";
            str += base.GetInfo();
            str += String.Format("\nРадиус планеты: {0} км.\n", this.Radius);
            str += String.Format("\nНаличие гравитации: {0}\n", this.Atmosphere);
            str += String.Format("\nСила гравитации: {0} ТH", this.ForceOfGrav);
            
            return str;          
        }
        public static Planets Generate()
        {           
            return new Planets
            {
                DistanceToE = rnd.Next(1, 100),
                Radius = rnd.Next(1000, 100000),
                Atmosphere = rnd.Next() % 2 == 0,
                ForceOfGrav = rnd.Next(200, 1000)
            };
        }
    }
    public enum Colors { красный, белый, голубой, жёлтый };
    public class Stars : Body
    {
        
        public int Density = 0; // плотность звезды //
        public Colors color = Colors.белый; // цвет звезды //
        public int Temp = 0; // температура звезды //
        public override string GetInfo()
        {
            var str = "Звезда\n";
            str += base.GetInfo();
            str += String.Format("\nПлотность звезды: {0} мг/см^3\n", this.Density);
            str += String.Format("\nЦвет: {0}\n", this.color);
            str += String.Format("\nТемпература: {0} K", this.Temp);
            return str;
        }
        public static Stars Generate()
        {
            return new Stars
            {
                DistanceToE = rnd.Next(1, 100),
                Density = rnd.Next(1, 100000),
                color = (Colors)rnd.Next(4),
                Temp = rnd.Next(1000, 60000)
            };
        }
    }
    public enum Names { Astel, Hun, IO }
    public class Comets : Body
    {
        
        public int Period = 0; // период прохождения через солнечную систему //
        public Names name = Names.Astel; // название кометы //
        public override string GetInfo()
        {
            var str = "Комета\n";
            str += base.GetInfo();
            str += String.Format("\nПериод прохождения через солнечную систему: {0} зем. лет\n", this.Period);
            str += String.Format("\nНазвание кометы: {0}", this.name);
            return str;
        }
        public static Comets Generate()
        {
            return new Comets
            {
                DistanceToE = rnd.Next(1, 100),
                Period = rnd.Next(1, 50000),              
                name = (Names)rnd.Next(3)
            };
        }
    }
    public class Body
    {
        public static Random rnd = new Random();
        public int DistanceToE = 0;
        public virtual String GetInfo()
        {
            var str = String.Format("\nРасстояние до Земли: {0} св. лет\n", this.DistanceToE);
            return str;
        }
    }

    

}