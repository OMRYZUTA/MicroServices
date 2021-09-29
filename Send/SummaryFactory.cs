using System;
using common;

namespace Send
{
    public static class SummaryFactory
    {
        private static readonly string[] Names = new[]
       {
            "Isaura","Donna","Dorothy","Lance","Velva","Cathern","Delilah","Yaeko","Lowell","James"
        };
        private static readonly string[] Professions = new[]
        {
            "Economist","Street entertainer","Lecturer","Pop star","Lifeguard","Flying instructor","Nurse","Party planner","Art dealer","Professor"
        };

        public static Summary CreateRandomSummary()
        {
            var random = new Random();
            return new Summary
            {
                Name = Names[random.Next(Names.Length)],
                Date = DateTime.Now,
                Age = random.Next(18, 100),
                Profession = Professions[random.Next(Professions.Length)]
            };
        }
    }
}
