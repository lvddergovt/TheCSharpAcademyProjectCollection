using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using ConsoleTableExt;
using Newtonsoft.Json;
using RestSharp;


namespace DrinksInfo
{
    public class TableVisualisationEngine
    {
        public void ShowTable<T>(List<T> tableData, [AllowNull] string tableName) where T : class
        {
            Console.Clear();

            if (tableName == null)
            {
                tableName = "";
            }

            Console.WriteLine("\n\n");
            
            ConsoleTableBuilder
                .From(tableData)
                .WithColumn(tableName)
                .ExportAndWriteLine();

            Console.WriteLine("\n\n");
        }
    }
}