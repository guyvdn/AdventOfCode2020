using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day13
{
    public class BusSchedule
    {
        private readonly List<Bus> _buses = new();

        public BusSchedule(string buses)
        {
            var split = buses.Split(',');
            for (var i = 0; i < split.Length; i++)
            {
                if (split[i] != "x")
                {
                    _buses.Add(new Bus { Id = int.Parse(split[i]), Delay = i });
                }
            }
        }

        public Departure GetNextDeparture(int timestamp)
        {
            return _buses
                .Select(bus => new Departure { Bus = bus.Id, Timestamp = GetNextDeparture(timestamp, bus.Id) })
                .OrderBy(x => x.Timestamp).First();
        }

        private static double GetNextDeparture(int timestamp, int bus)
        {
            return Math.Ceiling((double)timestamp / bus) * bus;
        }

        public long GetAnswerForContestWithForce()
        {
            long answer = 0;
            var slowestBus = _buses.OrderBy(bus => bus.Id).Last();
            long departure = -slowestBus.Delay;
            var increment = slowestBus.Id;

            while (answer == 0)
            {
                departure += increment;

                if (_buses.All(bus => ((departure + bus.Delay) % bus.Id) == 0))
                    answer = departure;
            }

            return answer;
        }

        public long GetAnswerForContestWithSpeed()
        {
            long departure = 0;
            long increment = _buses[0].Id;

            foreach (var bus in _buses)
            {
                while (((departure + bus.Delay) % bus.Id) != 0)
                {
                    departure += increment;
                }

                increment = Calculate.LeastCommonMultiple(increment, bus.Id);
            }

            return departure;
        }
    }
}