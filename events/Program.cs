using static System.Console;
namespace Події
{
    public delegate void ДелегатІспита(string завдання);
    class Студент
    {
        public int? номер { get; set; }
        public string? імйа { get; set; }
        public string? прізвище { get; set; }
        public DateTime дата_народження { get; set; }
        public void іспит(string завдання)
        {
            if (номер % 2 != 0)
            WriteLine($"Студент {прізвище} отримав 1 {завдання}");
            else
            WriteLine($"Студент {прізвище} отримав 2 {завдання}");
        }
    }
    class Викладач
    {
        public event ДелегатІспита? подія;
        public void Іспит(string завдання)
        {
            if (подія != null)
            {
                подія(завдання);
            }
        }
    }
    class Програма
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            List<Студент> група = new List<Студент>
            {
                  new Студент
                  {
                      номер = 1,
                      імйа = "Іван",
                      прізвище = "Дертьник",
                      дата_народження = new DateTime(1997,3,12)
                  },
                  new Студент
                  {
                      номер = 2,
                      імйа = "Катя",
                      прізвище = "Елемент",
                      дата_народження = new DateTime(1998,7,22)
                  },
                  new Студент
                  {
                      номер = 3,
                      імйа = "Джура",
                      прізвище = "Фіртань",
                      дата_народження = new DateTime(1996,11,30)
                  },
                  new Студент
                  {
                      номер = 4,
                      імйа = "Микола",
                      прізвище = "Кравець",
                      дата_народження = new DateTime(1996,5,10)
                  }
            };
            Викладач викладач = new Викладач();
            foreach (Студент студент in група)
            {
                викладач.подія += студент.іспит;
            }
            викладач.Іспит("завдання іспита");
        }
    }
}
