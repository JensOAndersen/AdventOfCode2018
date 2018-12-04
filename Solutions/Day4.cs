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
        List<Stamp> timestamps = new List<Stamp>();
        public Day4(string fileName, string name) : base(fileName, name)
        {
            //get input for day
            input = utils.ReadFileAsStringArray();

            //format stamps to ready them for sorting;
            foreach (var s in input)
            {
                var curString = s.Replace("Guard", string.Empty);
                curString = s.Replace("[", string.Empty);

                var splitted = curString.Split(']');
                Stamp stamp = new Stamp()
                {
                    timeStamp = DateTime.Parse(splitted[0]),
                    desc = splitted[1].Trim()
                };

                timestamps.Add(stamp);
            }

            //sort timestamps
            timestamps = timestamps.OrderBy(o => o.timeStamp).ToList();

        }

        public override string PartOne()
        {
            var awakeMinutes = CalculateGuardsAwakeMinutes();

            var shiftNapTimes = GetShiftNapTimes();

            foreach (var range in shiftNapTimes)
            {
                foreach (var item in range)
                {

                }
            }


            return base.ToString();
        }

        public List<List<Stamp>> GetShiftNapTimes()
        {
            var returnList = new List<List<Stamp>>();


            for (int i = 0; i < timestamps.Count; i++)
            {
                var curStamp = timestamps[i];
                //find the end of the shift, get a range, the # starts a shift
                if (curStamp.desc.Contains('#'))
                {
                    int startIndex = i;
                    int endIndex = 0;
                    i++; //increment i, to stop j from hitting the current stamp again. might fail if the list ends with a guard going on duty

                    //this goes until the next item contains a #
                    for (int j = i; j < timestamps.Count; j++)
                    {
                        var endStamp = timestamps[j];
                        if (endStamp.desc.Contains('#'))
                        {
                            endIndex = j;
                            i = j - 1; //exits to the outermost for loop, to make start on a new shift cycle.
                            break;
                        }
                    }
                    List<Stamp> range;
                    if (endIndex != 0)
                    {
                        range = timestamps.GetRange(startIndex, endIndex - startIndex);
                    }
                    else
                    {
                        range = timestamps.GetRange(startIndex, timestamps.Count - startIndex);
                    }

                    returnList.Add(range);
                }
            }

            return returnList;
        }

        public Dictionary<string, int> CalculateGuardsAwakeMinutes()
        {
            Dictionary<string, int> awakeMinutes = new Dictionary<string, int>();
            var naptimes = GetShiftNapTimes();

            foreach (var range in naptimes)
            {
                //calculate the minutes the guard spent awake, after the foreach there will be calculations to calcuate the rest of the shift, if it ends before the hour
                DateTime meet = new DateTime();
                DateTime fellAsleep = new DateTime();
                DateTime wokeUp = new DateTime();
                string guardId = "";

                foreach (var item in range)
                {

                    if (item.desc.Contains('#'))
                    {
                        guardId = item.desc.Split(" ")[1];
                        if (!awakeMinutes.ContainsKey(guardId))
                        {
                            awakeMinutes.Add(guardId, 0);
                        }
                        meet = item.timeStamp;

                    } else if (item.desc.Contains("falls"))
                    {
                        fellAsleep = item.timeStamp;

                        if (wokeUp > meet)
                        {
                            awakeMinutes[guardId] += (wokeUp-fellAsleep).Minutes;
                        } else
                        {
                            awakeMinutes[guardId] += fellAsleep.Minute-1;
                        }
                    }
                    else
                    {
                        wokeUp = item.timeStamp;
                    }
                }

                //add the rest of the day to the minutes awake;
                if (wokeUp.Minute < 60)
                {
                    awakeMinutes[guardId] += 60 - wokeUp.Minute;
                }
            }
            
            return awakeMinutes;
        }
    }

    public class Guard
    {
        public Dictionary<int, int> awakeMinutes = new Dictionary<int, int>();
        public string id;
        public Guard(string id)
        {
            this.id = id;

            for (int i = 0; i < 60; i++)
            {
                awakeMinutes.Add(i, 0);
            }
        }

        public int GetMostSleepyMinute()
        {
            KeyValuePair<int, int> minute = new KeyValuePair<int, int>();

            foreach (var item in awakeMinutes)
            {
                if (item.Value > minute.Value)
                {
                    minute = item;
                }
            }

            return minute.Key;
        }
    }

    public struct Stamp
    {
        public DateTime timeStamp;
        public string desc;

        public override string ToString()
        {
            return $"{timeStamp.ToLongTimeString()} {desc}";
        }
    }
}
