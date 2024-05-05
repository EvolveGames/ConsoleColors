using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleColors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string gui = @"
    ┌──── {WH}MAIN{R} ────────────────────┐ ┌─────────── {GR}BRAWL{R} ──────────┐ ┌─────────── {RD}COC{R} ────────────┐
    │ [>] HIT:      >>:[7]         │ │ [>] 0-5000         >>:[7]  │ │ [>] TH 0-10        >>:[7]  │
    │ [>] CHM:      >>:[32]        │ │ [>] 5000-10000     >>:[7]  │ │ [>] TH 11          >>:[7]  │
    │ [>] BAD:      >>:[100]       │ │ [>] 10000-20000    >>:[7]  │ │ [>] TH 12          >>:[7]  │
    └──────────────────────────────┘ │ [>] 20000-30000    >>:[7]  │ │ [>] TH 13          >>:[7]  │
    ┌──── {YE}PROXY{R} ───────────────────┐ │ [>] 30000-40000    >>:[7]  │ │ [>] TH 14          >>:[7]  │
    │ [>] TOTAL:    >>:[7]         │ │ [>] 40000-50000    >>:[7]  │ │ [>] TH 15          >>:[7]  │
    │ [>] ALIVE:    >>:[32]        │ │ [>] 50000+         >>:[7]  │ │ [>] TH 16          >>:[7]  │
    │ [>] RETRIES:  >>:[100]       │ │ [>] TOTAL:         >>:[7]  │ │ [>] TOTAL:         >>:[7]  │
    └──────────────────────────────┘ └────────────────────────────┘ └────────────────────────────┘
    ┌──── {OR}COMBO{R} ───────────────────┐ ┌───────────────────────────────────────────────────────────┐ 
    │ [>] TOTAL:    >>:[1000000]   │ │ [>] ETA: STARTED 05:24 MINUTES AGO                        │
    │ [>] CHECKED:  >>:[32]        │ │ [>] ESTIMED REMAINING TIME: 10:56 MINUTES                 │
    └──────────────────────────────┘ └───────────────────────────────────────────────────────────┘";

            WriteWithColors(gui);
            for (; ; );
        }
        static void WriteWithColors(string text)
        {
            Dictionary<string, ConsoleColor> clrs = new Dictionary<string, ConsoleColor>()
            {
                {"WH", ConsoleColor.White },
                {"GR", ConsoleColor.Green },
                {"RD", ConsoleColor.Red },
                {"OR", ConsoleColor.DarkYellow },
                {"BV", ConsoleColor.Magenta },
                {"YE", ConsoleColor.Yellow },
            };

            var pieces = Regex.Split(text, $@"(\{{(?:{string.Join("|", clrs.Keys)})\}}.*?\{{R\}})");

            for (int i = 0; i < pieces.Length; i++)
            {
                string piece = pieces[i];

                foreach (var c in clrs)
                {
                    if (piece.StartsWith($"{{{c.Key}}}") && piece.EndsWith("{R}"))
                    {
                        Console.ForegroundColor = c.Value;
                        piece = piece.Replace($"{{{c.Key}}}", "");
                        piece = piece.Replace("{R}", "");
                    }
                }

                Console.Write(piece);
                Console.ResetColor();
            }

            Console.WriteLine();
        }
    }
}
