using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

String myJsonString = File.ReadAllText("DataTest.json");
var jsonObject = JToken.Parse(myJsonString);
Console.WriteLine(jsonObject.SelectToken("userName").Value<string>());
Console.WriteLine(jsonObject.SelectToken("password").Value<string>());
