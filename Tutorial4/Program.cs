namespace Tutorial3;

public class Program
{
    public static void Main(string[] args)
    {
        var empls = Database.GetEmps();
        var depts = Database.GetDepts();
        var sals = Database.GetSalgrades();
        
        var highestSal = empls.Max(e => e.Sal);
        Console.WriteLine($"Top Salary: {highestSal}");
        Console.WriteLine();
        
        var salesmen = empls.Where(e => e.Job == "SALESMAN").ToList();
        foreach (var emp in salesmen)
            Console.WriteLine($"{emp.EName} - Job: {emp.Job}");
        Console.WriteLine();
        
        var researchEmps = from e in empls join d in depts on e.DeptNo equals d.DeptNo 
                where d.DName == "RESEARCH" select e;
        foreach (var emp in researchEmps)
            Console.WriteLine($"{emp.EName} - Dept: {emp.DeptNo}");
        Console.WriteLine();
        
        var empWithGrades = from e in empls
                            from s in sals
                            where e.Sal >= s.Losal && e.Sal <= s.Hisal
                            select new { e.EName, s.Grade };
        foreach (var item in empWithGrades)
            Console.WriteLine($"{item.EName} - Grade: {item.Grade}");
    }
}