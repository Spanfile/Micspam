using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Lidgren.Network;

namespace Micspam
{
	public class CommandEventArgs : EventArgs
	{
		public string Action { get; private set; }
		public int ID { get; private set; }

		public CommandEventArgs(string action, int id)
		{
			this.Action = action;
			this.ID = id;
		}
	}

	public class ExtCommandListener
	{
		NetPeerConfiguration conf;

		public event EventHandler<CommandEventArgs> CommandReceived;

		public ExtCommandListener(int port)
		{
			conf = new NetPeerConfiguration("Micspam");
			conf.EnableMessageType(NetIncomingMessageType.UnconnectedData);
			conf.Port = port;
		}

		public void Start()
		{
			NetServer server = new NetServer(conf);
			server.Start();

			server.RegisterReceivedCallback(new SendOrPostCallback(MessageReceived), SynchronizationContext.Current);

			Console.WriteLine("External command listener started on port {0}", server.Port);
		}

		void MessageReceived(object peer)
		{
			NetPeer client = peer as NetPeer;

			NetIncomingMessage msg = client.ReadMessage();
			Console.WriteLine("Incoming message from {0}", msg.SenderEndPoint);

			string action = msg.ReadString();
			int id = msg.ReadInt32();

			Console.WriteLine("{0} {1}", action, id);

			if (CommandReceived != null)
				CommandReceived(this, new CommandEventArgs(action, id));
		}
	}
}
