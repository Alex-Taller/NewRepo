using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleTextStream
{
    class Program
    {
        static void Main(string[] args)
        {
            Wrapper();
        }
        static void CreateFile()
        {
            string fileNameCreate;
            Console.WriteLine("Введите имя файла создаваемого в директории D:\\Климуть ");
            fileNameCreate = Console.ReadLine();
            File.Create(@"D:\\Климуть" + fileNameCreate + ".txt");
        }
        static void OpenFile()
        {
            string fileNameOpen;
            Console.WriteLine("Че надо хозяин?");
            fileNameOpen = Console.ReadLine();
            FileStream file = new FileStream(@"D:\\Климуть" + fileNameOpen + ".txt", FileMode.Open, FileAccess.Read);
            Console.ReadKey();
            StreamReader nr = new StreamReader(@"D:\\Климуть" + fileNameOpen + ".txt");
            string n;
            while (nr.EndOfStream != true)
            {
                n = nr.ReadLine();
                Console.WriteLine(n);
                Console.ReadKey();
            }
        }
        static void DeleteFile()
        {
            string fileNameDelete;
            Console.WriteLine("Введите имя того кого хотите убрать и он исчезнет, возможно навсегда.");
            fileNameDelete = Console.ReadLine();
            string path = @"D:\\Климуть" + fileNameDelete + ".txt";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.Delete();
                Console.WriteLine("Цель устранена");
            }
            else
            {
                Console.WriteLine("Цель скрылась");
            }
            Console.ReadKey();

        }
        static void CopyFile()
        {
            string path = @"D:\\Климуть\\Copy.txt";
            string FileNameCopy;
            Console.WriteLine("Введите имя того, кто отправится на клонирование");
            FileNameCopy = Console.ReadLine();
            string newPath = @"D:\\Климуть" + FileNameCopy + ".txt";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.CopyTo(newPath, true);
                Console.WriteLine("200 тысяч едениц готовы еще миллион на подходе");
            }
            Console.ReadKey();

        }
        static void MoveFile()
        {
            string path = @"D:\\Климуть\\Copy.txt";
            string FileNameMove;
            Console.WriteLine("Введите имя того, кого отправите в пешее путешествие");
            FileNameMove = Console.ReadLine();
            string newPath = @"D:\\Климуть" + FileNameMove + ".txt";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.MoveTo(newPath);
                Console.WriteLine("Телепортация завершена");
            }
            Console.ReadKey();
            System.IO.File.Move(@"D:\\Климуть" + FileNameMove + ".txt", @"D:\\Климуть\\Copy.txt");
        }
        static void ReadFile()
        {
            string fileNameOpen;
            Console.WriteLine("Чего читать изволите барин?");
            fileNameOpen = Console.ReadLine();
            FileStream file = new FileStream(@"D:\\Климуть" + fileNameOpen + ".txt", FileMode.Open, FileAccess.Read);
            Console.ReadKey();
            StreamReader sr = new StreamReader(@"D:\\Климуть" + fileNameOpen + ".txt");
            string s;
            while (sr.EndOfStream != true)
            {
                s = sr.ReadLine();
                Console.WriteLine(s);
                Console.ReadKey();
                sr.Close();
                file.Close();

            }
        }
        static void RewriteFile()
        {
            string fileNameRewrite, textRewrite;
            Console.WriteLine("Историю переписываем барин?");
            fileNameRewrite = Console.ReadLine();
            FileInfo fileInf = new FileInfo(@"D:\\Климуть" + fileNameRewrite + ".txt");
            if (fileInf.Exists)
            {
                Console.WriteLine("Внимаю и пишу.");
                textRewrite = Console.ReadLine();
                FileStream afile = new FileStream(@"D:\\Климуть" + fileNameRewrite + ".txt", FileMode.Truncate);
                StreamWriter sw = new StreamWriter(afile);
                sw.WriteLine(textRewrite);
                Console.WriteLine("Вродь все записал!");
                sw.Close();
                afile.Close();
            }
            else
            {
                Console.WriteLine("Бред городите, как извольте!");
            }
            Console.ReadKey();

        }
        static void WriteFile()
        {
            string FileNameWrite, textWrite, s;
            long length;
            Console.WriteLine("Куда ваши извояния писать будем?");
            FileNameWrite = Console.ReadLine();
            FileInfo fileInf = new FileInfo(@"D:\\Климуть" + FileNameWrite + ".txt");
            if (fileInf.Exists)
            {
                Console.WriteLine("Делаем вид что пишем...");
                textWrite = Console.ReadLine();
                FileStream aFile = new FileStream(@"D:\\Климуть" + FileNameWrite + ".txt", FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(aFile);
                Console.WriteLine("Куда записывать ваш бред будем?");
                s = Console.ReadLine();
                switch (s)
                {
                    case "1":
                        aFile.Seek(0, SeekOrigin.Begin);
                        sw.WriteLine(textWrite);
                        break;
                    case "2":
                        length = fileInf.Length;
                        length = length / 2;
                        aFile.Seek(length, SeekOrigin.Begin);
                        sw.WriteLine(textWrite);
                        break;
                    case "3":
                        aFile.Seek(0, SeekOrigin.End);
                        sw.WriteLine(textWrite);
                        break;
                    default:
                        Console.WriteLine("Нет такой цифры, по крайней мереу нас");
                        break;
                }
                Console.WriteLine("Текст запісалі");
                sw.Close();
                aFile.Close();
            }
        }

        static void Wrapper()
        {
            string s;
            Console.WriteLine("1 - создать файл, 2 - Открыть, 3 - удалить, 4 -Копировать, 5 - Переместить, 6 - Прочитать, 7 - Перезаписать, 8 - дописать");
            s = Console.ReadLine();
            switch (s)
            {
                case "1":
                    CreateFile();
                    break;
                case "2":
                    OpenFile();
                    break;
                case "3":
                    DeleteFile();
                    break;
                case "4":
                    CopyFile();
                    break;
                case "5":
                    MoveFile();
                    break;
                case "6":
                    ReadFile();
                    break;
                case "7":
                    RewriteFile();
                    break;
                case "8":
                    WriteFile();
                    break;
            }

        }
    }
}


