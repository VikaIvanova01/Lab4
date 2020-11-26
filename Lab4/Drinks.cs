using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Drinks  //Создание класса напитков
    {
        public int Volume = 0;  //общее свойство - Объём
        public static Random rnd = new Random();
        public virtual String GetInfo()
        {
           var str = String.Format("\nОбъём: {0} мл ", this.Volume);
            return str;
        }

    }
    public enum Fruit {Яблоко, Апельсин, Персик};  //Перечисление фруктов для сока
    public class Juice : Drinks  //Класс для сока
    {
        public Fruit fruittype = Fruit.Яблоко;  //Используемый фрукт
        public bool Pulp = false;  //наличие мякоти
        public override String GetInfo()  //Составление и вывод информации об объекте класса
        {
            string pulp;
            if (this.Pulp)
            {
                pulp = "есть";
            }
            else
            {
                pulp = "отсутствует";
            }
            var str = "Сок";
            str += base.GetInfo();
            str += String.Format("\nИспользуемый фрукт: {0}", this.fruittype);
            str += String.Format("\nМякоть: {0}", pulp);
            return str;
        }
        
        public static Juice Generate()  //Создание свойств класса
        {
            return new Juice
            {
                Volume = rnd.Next() % 100, // объём от 0 до 100
                fruittype = (Fruit)rnd.Next(3), // используемый фрукт
                Pulp = rnd.Next() % 2 == 0 // наличие мякоти true или false
            };
        }
    }
    public enum SodaType {Cola, Pepsi, Fanta};  //Перечисление типов газировки
    public class Soda : Drinks  //Класс для газировки
    {
        public SodaType sodatype = SodaType.Cola;  //Тип газировки
        public int Bubbles = 0;  //Количество пузыриков
        public override String GetInfo()  //Составление и вывод информации об объекте класса
        {
            var str = "Газировка";
            str += base.GetInfo();
            str += String.Format("\nВид: {0}", this.sodatype);
            str += String.Format("\nКоличество пузыриков: {0}", this.Bubbles);
            return str;
        }
        public static Soda Generate()  //Создание свойств класса
        {
            return new Soda
            {
                Volume = rnd.Next() % 100, // объём от 0 до 100
                sodatype = (SodaType)rnd.Next(3), // Вид газировки
                Bubbles = rnd.Next() % 500  // количество пузыриков от 0 до 500
            };
        }
    }
    public enum AlcoholType {Ром, Коньяк, Виски}  //Перечисление типов алкоголя
    public class Alcohol : Drinks  //Класс для алкоголя
    {
        public int Strength = 0;  //Крепость 
        public AlcoholType alcoholtype = AlcoholType.Виски;  //Тип алкоголя
        public override String GetInfo()  //Составление и вывод информации об объекте класса
        {
            var str = "Алкоголь";
            str += base.GetInfo();
            str += String.Format("\nКрепость: {0} %", this.Strength);
            str += String.Format("\nТип: {0}", this.alcoholtype);
            return str;
        }
        public static Alcohol Generate()  //Создание свойств класса
        {
            return new Alcohol
            {
                Volume = rnd.Next() % 100, // объём от 0 до 100
                Strength = rnd.Next() % 50, // крепость алкоголя от 0 до 50
                alcoholtype = (AlcoholType)rnd.Next(3) // тип алкоголя
            };
        }
    }
    
}