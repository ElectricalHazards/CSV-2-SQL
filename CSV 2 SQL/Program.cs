// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using System.Runtime.CompilerServices;

string filePath = "C:\\Users\\Ryan\\Desktop\\xport\\customers.csv";

StreamReader sr = new StreamReader(filePath);
List<List<string>> db = new List<List<string>>();
var array = new int[] { 1, 2, 3, 4, 5 };
var slice1 = array[2..^3];    // array[new Range(2, new Index(3, fromEnd: true))]
var slice2 = array[..^3];     // array[Range.EndAt(new Index(3, fromEnd: true))]
var slice3 = array[2..];      // array[Range.StartAt(2)]
var slice4 = array[..];       // array[Range.All]
while (!sr.EndOfStream)
{
    string line = sr.ReadLine();
    db.Add(new List<string>());
    db[db.Count()-1] = line.Split(',').ToList();
    for(int i = 0; i < db[db.Count() - 1].Count; i++)
    {
        var cur = db[db.Count() - 1][i];
        db[db.Count() - 1][i] = cur.Length <=  2 ? "" : cur.Substring(1, cur.Length - 2);
    }
}
Dictionary<string,List<string>> collumedData = new Dictionary<string, List<string>>();
for (int j = 0; j < db[0].Count(); j++)//Cols
{
    collumedData.Add(db[0][j], new List<string>());//Add new labeled col
    for (int i = 1; i < db.Count(); i++)//Rows
    {
        collumedData[db[0][j]].Add(db[i][j]);//Add entry to labeled col
    }
}
