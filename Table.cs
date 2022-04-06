using System;
using System.Linq;
using System.Collections.Generic;
using System.Formats;
using ConsoleTables;

namespace Task3
{
    class Table
    {
        private string[] Names;

        public Table(string[] Name)
        {
            Names = Name;
        }

        public void Help()
        {
            var headerItems = Names.Prepend("Human \\ Computer");
            var table = new ConsoleTable(headerItems.ToArray());
            var referee = new Referee(Names.Length);

            for (int i = 0; i < Names.Length; i++)
            {
                var currentRow = new string[Names.Length + 1];
                currentRow[0] = Names[i];

                for (int j = 0; j < Names.Length; j++)
                {
                    currentRow[j + 1] = Enum.GetName(typeof(Result), referee.Solution(i, j));
                }

                table.AddRow(currentRow.ToArray());
            }

            table.Write(Format.Alternative);
        }

    }
}