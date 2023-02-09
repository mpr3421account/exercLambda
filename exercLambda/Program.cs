/*Fazer um programa para ler os dados (nome, email e salário)
de funcionários a partir de um arquivo em formato .csv.
Em seguida mostrar, em ordem alfabética, o email dos
funcionários cujo salário seja superior a um dado valor
fornecido pelo usuário.
Mostrar também a soma dos salários dos funcionários cujo
nome começa com a letra 'M'.*/
using exercLambda.Entities;
using System.Globalization;





Console.Write("Enter full file path: ");
string path = Console.ReadLine();
Console.Write("Enter salary: ");
double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

List<Employee> employees = new List<Employee>();
try
{
    using (StreamReader sr = File.OpenText(path))
    {
        while (!sr.EndOfStream)
        {
            string[] fields = sr.ReadLine().Split(',');
            string name = fields[0];
            string email = fields[1];
            double _salary = double.Parse(fields[2], CultureInfo.InvariantCulture);
            employees.Add(new Employee(name, email, _salary));

        }
    }
    var emails = employees.Where(obj => obj.Salary > salary).OrderBy(obj => obj.Email).Select(obj => obj.Email);

    var sum = employees.Where(obj => obj.Name[0] == 'M').Sum(obj => obj.Salary);

    Console.WriteLine("Email of people whose salary is more than " + salary.ToString(CultureInfo.InvariantCulture));
    foreach(string email in emails)
    {
        Console.WriteLine(email);
    }
    Console.Write("Sum of salary of people whose name starts with 'M': " + sum.ToString("F2", CultureInfo.InvariantCulture));
}
catch(IOException e)
{
    Console.Write("An error occurred: " + e.Message);
}