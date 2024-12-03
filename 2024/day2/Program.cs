using System;

class Report {
    public List<int> Levels { get; set; }
    public Report(List<int> input){
        Levels = input;
    }

    public bool CheckSafety() {
        bool? Increasing = null;
        int? Previous = null;

        foreach(int i in Levels) {

            // First Element condition
            if(Previous == null){
                Previous = i;
                continue;
            }

            int difference = i - (int)Previous;

            // First comparison condition
            if(Increasing == null){
                Increasing = difference > 0;
                continue;
            }

            // Fail condition 1
            if(Increasing == true && difference < 0 || Increasing == false && difference > 0){
                return false;
            }
            
            int absoluteValue = Math.abs(difference);
            // Fail condition 2
            if( absoluteValue is 0 or > 3){
                return false;
            }
        }

        return true;
    }
}


class Program
{
    static void Main(string[] args)
    {
        List<Report> reports = new List<Report>();
        var lines = File.ReadLines("./input.txt");
        foreach (var line in lines){
            string[] chunks = line.Split(" ");
            List<int> integers = chunks.ConvertAll(s => Int32.Parse(s)).ToList();
            reports.Add(new Report(integers));
        }

        foreach (var report in reports) {
            bool safe = report.CheckSafety();
            Console.WriteLine(safe);
        }
    }
}