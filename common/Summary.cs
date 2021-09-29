using System;
using System.Text;
using Newtonsoft.Json;
namespace common
{
    public class Summary
    {
        public String Name { get; set; }
        public DateTime Date { get; set; }

        [JsonIgnore]
        public int Age { get; set; }
        public string Profession { get; set; }

        public override string ToString()
        {
            string representation = Age == 0 ? ageLessToString() : FullyToString();
            return representation;
        }

        private string FullyToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Name: " + Name);
            stringBuilder.Append(", Date: " + Date);
            stringBuilder.Append(", Age: " + Age);
            stringBuilder.Append(", Profession: " + Profession);
            return stringBuilder.ToString();
        }

        private string ageLessToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Name: " + Name);
            stringBuilder.Append(", Date: " + Date);
            stringBuilder.Append(", Age: ----");
            stringBuilder.Append(", Profession: " + Profession);
            return stringBuilder.ToString();
        }
    }
}
