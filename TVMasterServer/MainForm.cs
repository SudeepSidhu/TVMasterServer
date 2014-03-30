using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TVMasterServer
{
    public partial class MainForm : Form
    {

        private static UdpClient udpServer;
        private static TcpListener tcpListener;

        private bool udpON;
        private bool tcpON;
        Thread udpThread;
        Thread tcpThread;
        
        private readonly object ioObj = new object();
        private readonly object logObj = new object();
        private readonly object listObj = new object();

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refreshList();

            udpON = true;
            tcpON = true;

            udpServer = new UdpClient(27900);

            udpThread = new Thread(new ThreadStart(startUDPServer));
            udpThread.Start();

            tcpThread = new Thread(new ThreadStart(startTCPServer));
            tcpThread.Start();
        }

        private void log(String message, TextBox logBox)
        {
            try
            {
                lock (logObj)
                {
                    logBox.Invoke((MethodInvoker)delegate
                    {
                        String timeStamp = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString();

                        logBox.AppendText(timeStamp + ": " + message + "\r\n");
                    });
                }
            }
            catch (Exception e)
            {
                log("In log():" + e.ToString(), logBox);
            }
        }


        public void clean()
        {
            try
            {
                lock (ioObj)
                {
                    String strServers = Properties.Settings.Default.Servers;
                    Array sList = strServers.Split('|');

                    String newServers = "";

                    foreach (String s in sList)
                    {
                        if (s.Trim().Length > 0)
                        {
                            newServers += s.Trim() + "|";
                        }
                    }

                    Properties.Settings.Default.Servers = newServers;
                    Properties.Settings.Default.Save();
                }
            }
            catch (Exception e)
            {
                log("In clean():" + e.ToString(), txtDebug);
            }
        }


        public String getServers()
        {
            String strServers = "";

            try
            {
                clean();

                lock (ioObj)
                {
                    strServers = Properties.Settings.Default.Servers;
                }
            }
            catch (Exception e){
                log("In getServers():" + e.ToString(), txtDebug);
            }

            return strServers;
        }

        public void refreshList(){

            try
            {
                String strServers = getServers();

                Array sList = strServers.Split('|');

                lock (listObj)
                {
                    lstServers.Invoke((MethodInvoker)delegate
                    {
                        lstServers.Items.Clear();

                        foreach (String s in sList)
                        {
                            if (s.Trim().Length > 0)
                            {
                                lstServers.Items.Add(s.Trim());
                            }
                        }
                    });
                }
            }
            catch (Exception e){
                log("In refreshList():" + e.ToString(), txtDebug);
            }
        }

        public void addServer(String server)
        {
            try{
                String strServers = getServers();

                lock (ioObj)
                {
                    String newServer = server.Trim();

                    if (newServer.Length > 0 && !strServers.Contains(newServer))
                    {
                        log("'" + newServer + "' added", txtServerInfoLog);

                        strServers += newServer + "|";
                        Properties.Settings.Default.Servers = strServers;
                        Properties.Settings.Default.Save();
                    }
                }

                clean();
                refreshList();
            }
            catch (Exception e)
            {
                log("In addServer():" + e.ToString(), txtDebug);
            }
        }

        public void removeServer(String server)
        {
            try
            {
                String strServers = getServers();

                lock (ioObj)
                {
                    strServers = strServers.Replace(server.Trim(), "");
                    Properties.Settings.Default.Servers = strServers;
                    Properties.Settings.Default.Save();
                    log("'" + server.Trim() + "' removed", txtServerInfoLog);
                }

                clean();
                refreshList();
            }
            catch (Exception e)
            {
                log("In removeServer():" + e.ToString(), txtDebug);
            }
        }

        private void startUDPServer()
        {
            while (udpON)
            {
                try
                {
                    IPEndPoint tvServer = new IPEndPoint(IPAddress.Any, 0);
                    byte[] receiveBytesUDP = udpServer.Receive(ref tvServer);

                    if (receiveBytesUDP != null)
                    {
                        String addr = tvServer.Address.ToString();
                        log("'" + addr + "' just came online", txtServerInfoLog);
                        addServer(addr);
                    }
                }
                catch (Exception e){
                    log("In startUDPServer():" + e.ToString(), txtDebug);
                }

            }
        }

        private void startTCPServer()
        {
            tcpListener = new TcpListener(IPAddress.Any, 27900);
            tcpListener.Start();
            ASCIIEncoding asen = new ASCIIEncoding();
           
            while (tcpON)
            {
                try
                {
                    Socket client = tcpListener.AcceptSocket();

                    byte[] b = new byte[100];
                    int k = client.Receive(b);

                    String message = asen.GetString(b).Replace("\0", "");

                    if (message.StartsWith("serversPlz"))
                    {

                        log("'" + client.RemoteEndPoint.ToString() + "' is asking for servers", txtServerLog);

                        String servers = getServers();
                        client.Send(asen.GetBytes(servers));

                        log("Sent '" + servers + "' to '" + client.RemoteEndPoint.ToString() + "'", txtServerLog);
                    }

                    client.Close();
                }
                catch (Exception e){
                    log("In startTCPServer():" + e.ToString(), txtDebug);                
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstServers.SelectedItems.Count > 0)
            {
                for (int i= lstServers.SelectedItems.Count - 1; i >= 0; i--)
                {
                    String server = (String)lstServers.SelectedItems[i];
                    removeServer(server);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int childLeft = (this.Left + this.Width/4);
            int childTop = (this.Top + this.Height/4);

            String input = Microsoft.VisualBasic.Interaction.InputBox("Enter server's IP address", "Add a server", "", childLeft, childTop).Trim();

            IPAddress address;

            if (IPAddress.TryParse(input, out address))
            {
                switch (address.AddressFamily)
                {
                    case System.Net.Sockets.AddressFamily.InterNetwork:
                    case System.Net.Sockets.AddressFamily.InterNetworkV6:
                        addServer(input);
                        break;
                    default:
                        MessageBoxEx.Show(this, "The address you entered is not a valid IPv4 or IPv6 address", "Whoops", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        break;
                }
            }
            else if (input.Length > 0)
            {
                MessageBoxEx.Show(this, "The address you entered is not a valid IPv4 or IPv6 address", "Whoops", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnClearDebugLog_Click_1(object sender, EventArgs e)
        {
            lock (logObj)
            {
                txtDebug.Clear();
            }
        }

        private void btnClearGeneralLog_Click(object sender, EventArgs e)
        {
            lock (logObj)
            {
                txtServerLog.Clear();
            }
        }

        private void btnClearInfoLog_Click(object sender, EventArgs e)
        {
            lock (logObj)
            {
                txtServerInfoLog.Clear();
            }
        }
    }
}
