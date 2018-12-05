using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace Solutions
{
    public class Day4 : BaseSolution
    {
        string[] input;
        public Day4(string fileName, string name) : base(fileName, name)
        {
            input = utils.ReadFileAsStringArray();
        }

        public override string PartOne()
        {
            var guards = GetGuardsWithDetails();

            var mostSleepyGuard = guards[0];

            foreach (Guard guard in guards)
            {
                if (guard.AmountOfTimesAsleep() > mostSleepyGuard.AmountOfTimesAsleep())
                {
                    mostSleepyGuard = guard;
                }
            }


            return (mostSleepyGuard.GetMostSleepyMinute().minute * mostSleepyGuard.id).ToString(); ;
        }

        public override string PartTwo()
        {
            var guards = GetGuardsWithDetails();

            Guard mostNappingGuard = guards[0];

            foreach (var guard in guards)
            {
                if (guard.GetMostSleepyMinute().minutesSlept > mostNappingGuard.GetMostSleepyMinute().minutesSlept)
                {
                    mostNappingGuard = guard;
                }
            }

            var res = mostNappingGuard.id * mostNappingGuard.GetMostSleepyMinute().minute;

            return res.ToString();
        }

        //Get a list of ordered shifts
        private List<Shift> GetOrderedShifts()
        {

            List<Shift> shifts = new List<Shift>();
            foreach (var detail in input)
            {
                var workingDetail = detail.Replace("[", string.Empty);
                var workingDetails = workingDetail.Split(']');

                Shift shift = new Shift();

                shift.timestamp = DateTime.Parse(workingDetails[0]);
                if (workingDetails[1].Contains("#"))
                {
                    string[] tempId = workingDetails[1].Split(" ");
                    shift.id = int.Parse(tempId[2].Substring(1));
                    shift.description = string.Empty;
                }
                else
                {
                    shift.id = -1;
                    shift.description = workingDetails[1].Trim();
                }

                shifts.Add(shift);
            }

            shifts = shifts.OrderBy(s => s.timestamp).ToList();

            return shifts;
        }

        private List<Guard> GetGuardsWithDetails()
        {

            var shifts = GetOrderedShifts();

            //utils.WriteArrayToFile<Shift>(shifts.ToArray(), "dwarves.txt");

            Dictionary<int, Guard> guardSet = new Dictionary<int, Guard>();

            int currentGuardId = -1;
            DateTime fellAsleep = new DateTime();
            DateTime wokeUp = new DateTime();
            DateTime met = new DateTime();
            foreach (var shift in shifts)
            {
                //add guard to set if he doesnt exist
                if (shift.id > 0 && !guardSet.ContainsKey(shift.id))
                {

                    met = shift.timestamp;
                    wokeUp = new DateTime();
                    currentGuardId = shift.id;
                    guardSet.Add(shift.id, new Guard()
                    {
                        id = currentGuardId
                    });
                }

                if (shift.id > 0)
                {

                    currentGuardId = shift.id;
                    met = shift.timestamp;
                    wokeUp = new DateTime();
                }

                if (shift.description.Contains("falls"))
                {
                    fellAsleep = shift.timestamp;


                }
                else if (shift.description.Contains("wakes"))
                {
                    wokeUp = shift.timestamp;

                    if (wokeUp > met)
                    {
                        for (int i = fellAsleep.Minute; i < wokeUp.Minute; i++)
                        {
                            guardSet[currentGuardId].sleepyMinutes[i]++;
                        }
                    }
                }
            }

            return guardSet.Values.ToList();
        }

        public class Guard
        {
            public int id;
            public Dictionary<int, int> sleepyMinutes = new Dictionary<int, int>();

            public Guard()
            {
                //populate the active minutes dictionary
                for (int i = 0; i < 60; i++)
                {
                    sleepyMinutes.Add(i, 0);
                }
            }

            //get the minute where the guard sleeps the most
            public (int minute, int minutesSlept) GetMostSleepyMinute()
            {
                var mostSleepyMinute = sleepyMinutes.First();

                foreach (var item in sleepyMinutes)
                {
                    if (item.Value > mostSleepyMinute.Value)
                    {
                        mostSleepyMinute = item;
                    }
                }

                return (mostSleepyMinute.Key, mostSleepyMinute.Value);
            }

            public int AmountOfTimesAsleep()
            {
                return sleepyMinutes.Values.Sum();
            }
        }

        public struct Shift
    {
        public int id;
        public DateTime timestamp;
        public string description;

        public override string ToString()
        {
            return $"{timestamp} {description} {id}";
        }
    }
    }
}
