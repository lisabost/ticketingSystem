using System;
using System.IO;
using System.Collections.Generic;

namespace ticketingSystem
{
    /*
    This class is going to read our file
    */
    class FileReader
    {
        //method to find the total number of lines in the file
        public int TotalLines(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            using (sr)
            {
                int i = 0;
                while (sr.ReadLine() != null) { i++; }
                sr.Close();
                return i;
            }
        }

        //method to read the lines already in the file
        public List<Ticket> ReadAllBugs(string filePath)
        {
            List<Ticket> ticketsFromFile = new List<Ticket>();
            StreamReader sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] arr = line.Split(',');
                string[] watching = arr[6].Split("|");
                List<string> watchers = new List<string>();
                foreach (var item in watching)
                {
                    watchers.Add(item);
                }
                ticketsFromFile.Add(new BugDefect(int.Parse(arr[0]), arr[1], arr[2], arr[3], arr[4], arr[5], watchers, arr[7]));
            }
            sr.Close();
            return ticketsFromFile;
        }

        public List<Ticket> ReadAllEnhancements(string filePath)
        {
            List<Ticket> ticketsFromFile = new List<Ticket>();
            StreamReader sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] arr = line.Split(",");
                string[] watching = arr[6].Split("|");
                List<string> watchers = new List<string>();
                foreach (var item in watching)
                {
                    watchers.Add(item);
                }
                ticketsFromFile.Add(new Enhancement(int.Parse(arr[0]), arr[1], arr[2], arr[3], arr[4], arr[5], watchers, arr[7], double.Parse(arr[8]), arr[9], arr[10]));
            }
            sr.Close();
            return ticketsFromFile;
        }

        public List<Ticket> ReadAllTasks(string filePath)
        {
            List<Ticket> ticketsFromFile = new List<Ticket>();
            StreamReader sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] arr = line.Split(",");
                string[] watching = arr[6].Split("|");
                List<string> watchers = new List<string>();
                foreach (var item in watching)
                {
                    watchers.Add(item);
                }
                ticketsFromFile.Add(new Task(int.Parse(arr[0]), arr[1], arr[2], arr[3], arr[4], arr[5], watchers, arr[7], DateTime.Parse(arr[8])));
            }
            sr.Close();
            return ticketsFromFile;
        }


    }
}