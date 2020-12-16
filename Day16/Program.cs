using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

string[] lines = File.ReadAllText("../../../Input.txt").Split("\r\n\r\n");

string[] rules = lines[0].Split("\r\n");

string myTicket = lines[1]
    .Split("\r\n")
    .Skip(1)
    .First();

string[] tickets = lines[2]
    .Split("\r\n")
    .Skip(1)
    .ToArray();

// Part One
//Console.WriteLine(FindInvalidTickets(rules, tickets));

// Part Two
string[] validTickets = tickets
    .Where(t => IsValidTicket(rules, t))
    .ToArray();

var ranges = Regex.Matches(string.Join(",", rules), "\\d+");

var length = validTickets[0].Split(",").Length;

// Four numbers per rule;
for(int i = 0; i < ranges.Count; i += 4)
{
    int ruleIndex = i / 4;
    Console.WriteLine($"Checking rule {rules[ruleIndex]}");

    for (int ticketIndex = 0; ticketIndex < length; ticketIndex++)
    {
        bool ruleValidForColumn = true;
        foreach (var ticket in validTickets.Select(s => Array.ConvertAll(s.Split(","), int.Parse).ToArray()))
        {
            int lower1 = int.Parse(ranges[i].Value);
            int upper1 = int.Parse(ranges[i + 1].Value);

            int lower2 = int.Parse(ranges[i + 2].Value);
            int upper2 = int.Parse(ranges[i + 3].Value);

            if ((ticket[ticketIndex] < lower1 || ticket[ticketIndex] > upper1) && (ticket[ticketIndex] < lower2 || ticket[ticketIndex] > upper2))
            {
                ruleValidForColumn = false;
                break;
            }
        }

        if(ruleValidForColumn)
            Console.WriteLine($"Rule {rules[ruleIndex]} is valid for column {ticketIndex}");
    }
}


static int FindInvalidTickets(string[] rules, string[] tickets)
{
    var ranges = Regex.Matches(string.Join(",", rules), "\\d+");
    int totalInvalidValue = 0;


    foreach(var ticket in tickets)
    {
        int[] ticketValues = Array.ConvertAll(ticket.Split(","), int.Parse);

        foreach (int ticketValue in ticketValues)
        {
            bool isValid = false;
            for (int i = 0; i < ranges.Count; i += 2)
            {
                int lower = int.Parse(ranges[i].Value);
                int upper = int.Parse(ranges[i + 1].Value);

                if(ticketValue >= lower && ticketValue <= upper)
                {
                    isValid = true;
                    break;
                }    
            }

            if (!isValid)
                totalInvalidValue += ticketValue;
        }
    }

    return totalInvalidValue;
}

static bool IsValidTicket(string[] rules, string ticket)
{
    var ranges = Regex.Matches(string.Join(",", rules), "\\d+");

    int[] ticketValues = Array.ConvertAll(ticket.Split(","), int.Parse);

    foreach (int ticketValue in ticketValues)
    {
        bool isValid = false;
        for (int i = 0; i < ranges.Count; i += 2)
        {
            int lower = int.Parse(ranges[i].Value);
            int upper = int.Parse(ranges[i + 1].Value);

            if (ticketValue >= lower && ticketValue <= upper)
            {
                isValid = true;
                break;
            }
        }

        if (!isValid)
            return false;
    }

    return true;
}