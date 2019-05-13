using System.Collections;
using System.Collections.Generic;
using Lidgren.Network;
using System.Threading;
using System;

namespace ChatroomClient
{
    public class Client
    {
        public NetClient client;
        public NetPeerConfiguration config = new NetPeerConfiguration("game_server");
        public bool isConnection = false;
        public bool isOpen = false;

        public void Connection()
        {
            if (isConnection)
                return;
            config.AutoFlushSendQueue = false;
            config.PingInterval = 0.9f;
            config.ConnectionTimeout = 9f;
            client = new NetClient(config);
            SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());

            NetOutgoingMessage hail = client.CreateMessage();
            hail.Write("i_want_chat");
            client.Start();
            client.Connect("127.0.0.1", 14200, hail);
        }

        public void DisConnection()
        {
            if (!isConnection)
                return;
            client.Shutdown("OUT");
            isConnection = false;
        }

        public void HandleMessage()
        {
            try
            {
                NetIncomingMessage im;
                string message = string.Empty;
                Byte[] Bymessage;

                if ((im = client.ReadMessage()) == null)
                    return;
                //Form1.writeline("GET");

                config.EnableMessageType(NetIncomingMessageType.ConnectionApproval);

                // handle incoming message
                switch (im.MessageType)
                {
                    case NetIncomingMessageType.ConnectionApproval:
                    case NetIncomingMessageType.DebugMessage:
                    case NetIncomingMessageType.ErrorMessage:
                    case NetIncomingMessageType.WarningMessage:
                    case NetIncomingMessageType.VerboseDebugMessage:
                        break;
                    case NetIncomingMessageType.StatusChanged:
                        NetConnectionStatus status = (NetConnectionStatus)im.ReadByte();

                        //Form1.writeline(status.ToString());
                        if (status == NetConnectionStatus.Connected )
                        {
                            isOpen = true;
                        }
                        
                        if (status == NetConnectionStatus.Disconnected)
                        {

                        }
                        break;
                    case NetIncomingMessageType.Data:
                        Bymessage = im.ReadBytes(4);
                        Package package = new Package(BitConverter.ToUInt32(Bymessage, 0));
                        //Form1.writeline("[C<--S] " + (Protocol)package.protocol + "[" + (package.protocol).ToString() + "]");
                        int _length = BitConverter.ToInt32(im.ReadBytes(4), 0);
                        List<byte> _data = new List<byte>();
                        for (int i = 0; i < _length; i++)
                            _data.AddRange(im.ReadBytes(1));
                        package.data = _data.ToArray();
                        if(package.protocol == (uint)Protocol.LOGIN)
                        {
                            clsLogin login = new clsLogin(0, "");
                            login = login.FromBytes(package.data);
                            User user = new User(login.uid, login.userName, null);
                            NetManager.me = user;
                            isConnection = true;
                        }
                        else
                        {
                            NetManager.toClient.Enqueue(package);
                        }
                        break;
                    default:
                        Form1.writeline("Unhandled type: " + im.MessageType + " " + im.LengthBytes + " bytes");
                        break;
                }
                client.Recycle(im);
            }
            catch (Exception e)
            {
                Form1.writeline(e.ToString());
            }
        }

        public void SendToServer()
        {
            try
            {
                if (NetManager.toServer.Count == 0)
                    return;

                Package data = (Package)NetManager.toServer.Dequeue();

                List<byte> da = new List<byte>();
                da.AddRange(BitConverter.GetBytes(data.protocol));
                da.AddRange(BitConverter.GetBytes(data.data.Length));
                da.AddRange(data.data);
                //送資料出去
                NetOutgoingMessage om = client.CreateMessage();

                foreach (byte d in da)
                {
                    om.Write(d);
                }
                client.SendMessage(om, NetDeliveryMethod.ReliableOrdered);
                client.FlushSendQueue();
            }
            catch (Exception e)
            {
                Form1.writeline(e.ToString());
            }
        }

    }

}