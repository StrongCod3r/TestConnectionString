using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace TestConnectionString
{
	class Program
	{
		private enum Status { CONNECTED, DISCONNECTED};
		static void Main(string[] args)
		{

			bool con = ConectionString1();
			Status status = con ? Status.CONNECTED: Status.DISCONNECTED;

			Console.WriteLine(status);
			Console.ReadLine();
		}
		public static bool ConectionString1()
		{
			string host = "1.1.1.1";
			string port = "1234";
			string sid = "sid";
			string user = "user";
			string pass = "pass";

			String connectionString = $"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={host})(PORT={port})) (CONNECT_DATA=(SID={sid}))); User Id={user};Password={pass};";

			using (OracleConnection connection = new OracleConnection(connectionString))
			{
				try
				{
					connection.Open();
					connection.Close();
					return true;
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex);
					return false;
				}
			}
		}
	}
}
