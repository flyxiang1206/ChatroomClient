using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatroomClient
{
    public partial class Form1 : Form
    {
        public static RichTextBox message;
        public static TextBox sendText;
        public static TextBox myName;
        public static ListBox userList;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            message = rtMessage;
            sendText = txtMessage;
            myName = txtName;
            userList = listUser;
            NetManager.client = new Client();
            lookConnection.Start();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            NetManager.client.DisConnection();
            base.OnClosing(e);
        }

        private void btnConnection_Click(object sender, EventArgs e)
        {
            if (myName.Text == "")
            {
                writeline("Please enter your name!!!!");
                return;
            }
            NetManager.client.Connection();
            connectionLoop.Enabled = true;
        }

        public static void writeline(string st)
        {
            message.AppendText(st + "\n");
        }

        private void lookConnection_Tick(object sender, EventArgs e)
        {
            if (NetManager.client.isConnection)
            {
                btnSecret.Enabled = true;
                btnSend.Enabled = true;
                btnConnection.Enabled = false;
                myName.Enabled = false;
                writeline("Connection successful !!!!!\n");
                lookConnection.Enabled = false;
                return;
            }
            if (NetManager.client.isOpen)
            {
                clsLogin login = new clsLogin(0, Form1.myName.Text);
                Package data = new Package((uint)Protocol.LOGIN, login.ToBytes());
                NetManager.toServer.Enqueue(data);
            }
        }

        private void connectionLoop_Tick(object sender, EventArgs e)
        {
            NetManager.client.HandleMessage();
            NetManager.client.SendToServer();
        }

        private void mainLoop_Tick(object sender, EventArgs e)
        {
            if (NetManager.toClient.Count != 0)
            {
                Package package = NetManager.toClient.Dequeue();
                switch (package.protocol)
                {
                    case (uint)Protocol.SECRET:
                        Message secret = new Message();
                        clsSecret clsecret = new clsSecret();
                        clsecret = clsecret.FromBytes(package.data);
                        User fromUser = new User();

                        if (clsecret.forUid != NetManager.me.uid)
                        {
                            foreach (User getUser in NetManager.onlineUser.Values)
                            {
                                if (getUser.uid == clsecret.forUid)
                                {
                                    fromUser = getUser;
                                    break;
                                }
                            }
                        }
                        else
                            fromUser = NetManager.me;

                        writeline("[" + clsecret.message.hour + "：" + clsecret.message.min + "] "
                            + clsecret.message.user.name + " send DM to "+fromUser.name + "：\n"
                            + clsecret.message.message + "\n");
                        break;
                    case (uint)Protocol.SEND:
                        Message message = new Message(NetManager.me, "");
                        clsSend clsSend = new clsSend(message);
                        clsSend = clsSend.FromBytes(package.data);
                        writeline("[" + clsSend.message.hour + "：" + clsSend.message.min + "] " + clsSend.message.user.name + "：\n"
                            + clsSend.message.message + "\n");
                        break;
                    case (uint)Protocol.ADDUSER:
                        clsChangeUser addUser = new clsChangeUser(0, "");
                        addUser = addUser.FromBytes(package.data);
                        User user = new User() { uid = addUser.uid, name = addUser.userName };
                        if (!NetManager.onlineUser.ContainsKey(user.uid) && user.uid != NetManager.me.uid)
                        {
                            NetManager.onlineUser.Add(user.uid, user);
                            userList.Items.Add(user.name);
                        }
                        break;
                    case (uint)Protocol.KILLUSER:
                        clsChangeUser killUser = new clsChangeUser(0, "");
                        addUser = killUser.FromBytes(package.data);
                        User kUser = new User() { uid = addUser.uid, name = addUser.userName };
                        if (NetManager.onlineUser.ContainsKey(kUser.uid))
                        {
                            NetManager.onlineUser.Remove(kUser.uid);
                            userList.Items.Remove(kUser.name);
                        }
                        break;
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Message message = new Message(NetManager.me, sendText.Text.ToString());
            clsSend clsSend = new clsSend(message);
            Package package = new Package((uint)Protocol.SEND, clsSend.ToBytes());
            NetManager.toServer.Enqueue(package);
            sendText.Text = "";
        }

        private void btnSecret_Click(object sender, EventArgs e)
        {
            string forName = userList.Text;
            User forUser = new User();

            foreach (User user in NetManager.onlineUser.Values)
            {
                if(user.name == forName)
                {
                    forUser = user;
                    break;
                }
            }

            Message message = new Message(NetManager.me, sendText.Text.ToString());

            clsSecret clsSecret = new clsSecret(message,forUser.uid);
            Package package = new Package((uint)Protocol.SECRET, clsSecret.ToBytes());
            NetManager.toServer.Enqueue(package);
            sendText.Text = "";
        }
    }
}
