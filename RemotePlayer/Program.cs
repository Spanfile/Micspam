using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Lidgren.Network;
using System.Net;

namespace RemotePlayer
{
	class Program
	{
		static void Main(string[] args)
		{
			int songID;
			if (!int.TryParse(args[0], out songID))
			{
				Console.WriteLine("Invalid ID: {0}", args[0]);
				Console.ReadLine();
				return;
			}

			NetPeerConfiguration conf = new NetPeerConfiguration("Micspam");

			IPEndPoint endPoint = new IPEndPoint(NetUtility.Resolve("localhost"), 1337);

			NetClient client = new NetClient(conf);
			client.Start();

			NetOutgoingMessage msg = client.CreateMessage();
			msg.Write("play");
			msg.Write(songID);

			client.SendUnconnectedMessage(msg, endPoint);

			Console.WriteLine("{0} sent. Press enter to close", songID);
			Console.ReadLine();
		}
	}
}
