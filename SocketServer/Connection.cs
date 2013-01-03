using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using CodeToast;
using System.Threading;
using GSocketLib;
using System.IO;
using System.CodeDom.Compiler;
using System.CodeDom;
using System.Speech.Synthesis;

namespace SocketServer
{
    public partial class Connection : Form
    {
        public event GSocketListener.ClientArrivedHandler OnNewClient;
        public event GSocket.ClosedHandler OnClosedClient;
        public event GSocket.DataArrivedHandler OnDataArrived;

        Thread _openListenerThread = null;

        List<GSocketListener> _lListener = new List<GSocketListener>();

        public SpeechSynthesizer speaker;

        public List<GSocketListener> LListener {
            get { return _lListener; }
        }
    	
        public Connection()
        {
            InitializeComponent();
            tbLocal.Text = Dns.GetHostAddresses(Dns.GetHostName())[0].ToString();

            speaker = new SpeechSynthesizer();
            //In dem Fall unnötig, aber falls zB vorher OutputToWav eingestellt war
            speaker.SetOutputToDefaultAudioDevice();
            //Geschwindigkeit (-10 - 10)
            speaker.Rate = 1;
            //Lautstärke (0-100)
            speaker.Volume = 100;
            //Such passende Stimme zu angegebenen Argumenten
            speaker.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
            //Text wird ausgegeben (abbrechen mit speaker.CancelAsync())

            try{
                if (File.Exists("Lib\\lastIP.txt")) {
                    StreamReader sr = new StreamReader("Lib\\lastIP.txt");
                    this.tbClientIP.Text = sr.ReadLine();
                    this.tbClientPort.Text = sr.ReadLine();
                    sr.Close();
                }
            }catch(Exception ex){
                MessageBox.Show(ex.ToString());
            }
        }
		#region USELESS
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        void TbClientPortTextChanged(object sender, EventArgs e)
        {

        }
        
        void TbLocalTextChanged(object sender, EventArgs e)
        {

        }
        
        void TbServerPortTextChanged(object sender, EventArgs e)
        {

        }
        
        void TbSendTextChanged(object sender, EventArgs e)
        {

        }
        

		#endregion
		
        private void btnClientConnect_Click(object sender, EventArgs e)
        {
        	try
        	{
			TcpClient tcpclnt = new TcpClient();
			tcpclnt.Connect(tbClientIP.Text, int.Parse(tbClientPort.Text));
			_listener_ClientArrived(null,new GSocket(tcpclnt));//,10));
        	}
        	catch(Exception ex)
        	{
        		MessageBox.Show(ex.Message);
        	}
        }

        private void btnServerListen_Click(object sender, EventArgs e)
        {
        	try
        	{
        		if(_lListener.Count == 0)
        		{
                    _openListenerThread = new Thread(() => {
                        List<int> ports = new List<int>();
                        string[] portParts = tbServerPort.Text.Split(',');
                        foreach (string portPart in portParts) {
                            string[] fromto = portPart.Split('-');
                            if (fromto.Length == 1) {
                                ports.Add(int.Parse(fromto[0]));
                            } else if (fromto.Length == 2) {
                                for (int n = int.Parse(fromto[0]); n <= int.Parse(fromto[1]); n++) {
                                    ports.Add(n);
                                }
                            } else {
                                throw new Exception("Multible '-'");
                            }
                        }

                        IPAddress ipAd = IPAddress.Parse(tbLocal.Text);
                        foreach (int port in ports) {
                            try {
                                _lListener.Add(new GSocketListener(ipAd, port, new GSocketListener.ClientArrivedHandler(_listener_ClientArrived)));
                                Log("[SERVER]: Start listening on Port " + port.ToString() + "\n", Color.DarkGreen);
                            } catch (Exception ex) {
                                Log("[SERVER]: Error while start listening on Port " + port.ToString() + " : " + ex.Message + "\n", Color.DarkRed);
                            }
                        }
                    });

                    _openListenerThread.Start();
					
					btnServerListen.Text = "Stop Listening";
        		}
        		else
        		{
                    if (_openListenerThread != null) {
                        if (_openListenerThread.ThreadState == ThreadState.Running)
                            _openListenerThread.Abort();
                        _openListenerThread = null;
                    }

                    foreach(GSocketListener listener in _lListener)
                    {
                        listener.Kill();
                        Log("[SERVER]: Stop listening on Port " + listener.Port.ToString() + "\n",Color.DarkRed);
                    }
        			_lListener.Clear();
        			btnServerListen.Text = "Listen";
        		}
        	}
        	catch(Exception ex)
        	{
        		MessageBox.Show(ex.Message);
        	}
        }

        void _listener_ClientArrived(GSocketListener sender, GSocket Client)
        {
	        if (InvokeRequired)
	        {
	            // We're not in the UI thread, so we need to call BeginInvoke
	            BeginInvoke(new GSocketListener.ClientArrivedHandler(_listener_ClientArrived), new object[]{sender, Client});
	            return;
	        }
        	            
        	string name = sender != null ? "S:" : "C:";
        	
        	name += Client.TCP_Client.Client.RemoteEndPoint.ToString();
        	Client.Name = name;
        	
        	Client.DataArrived += new GSocket.DataArrivedHandler(Client_DataArrived);
        	Client.Closed += new GSocket.ClosedHandler(Client_Closed);
        	
        	lvConnections.Items.Add(new ListViewItem(name) { Tag = Client });
        	
        	Log("[" + Client.Name + "]: New Connection\n",Color.DarkGreen);

            if (this.cbNotification.Checked)
                Console.Beep(2000, 200);

            if (this.OnNewClient != null)
                this.OnNewClient(sender, Client);
        }

        void Client_Closed(GSocket sender)
        {
        	if (InvokeRequired)
	        {
	            // We're not in the UI thread, so we need to call BeginInvoke
	            BeginInvoke(new GSocket.ClosedHandler(Client_Closed), new object[]{sender});
	            return;
	        }
        		        
        	List<ListViewItem> toDelete = new List<ListViewItem>();
        	foreach(ListViewItem item in lvConnections.Items)
        		if(item.Tag == sender)
        			toDelete.Add(item);
        	
        	foreach(ListViewItem item in toDelete)
        		lvConnections.Items.Remove(item);
        	
        	Log("[" + sender.Name + "]: Closed Connection\n",Color.DarkRed);

            if (this.cbNotification.Checked)
                Console.Beep(50, 200);

            if (this.OnClosedClient != null)
                this.OnClosedClient(sender);
        }

        void Client_DataArrived(GSocket sender, byte[] Data)
        {
        	if (InvokeRequired)
	        {
	            // We're not in the UI thread, so we need to call BeginInvoke
	            BeginInvoke(new GSocket.DataArrivedHandler(Client_DataArrived), new object[]{sender, Data});
	            return;
	        }
        	Log("[" + sender.Name + "]:",Color.DarkBlue);
        	Log(ToLiteral(new System.Text.ASCIIEncoding().GetString(Data)) + "\n",Color.LightBlue);

            if (this.cbNotification.Checked)
                Console.Beep(500, 200);

            if (this.OnDataArrived != null)
                this.OnDataArrived(sender, Data);

            if (this.cbSpeech.Checked)
                this.speaker.SpeakAsync(new System.Text.ASCIIEncoding().GetString(Data));
        }

        private void btnCloseConn_Click(object sender, EventArgs e)
        {

			foreach(ListViewItem item in lvConnections.SelectedItems)
				(item.Tag as GSocket).Kill();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
			richTextBox1.Text = "";
        }
        
        public static bool IsLocalIpAddress(string host)
		{
		  try
		  { // get host IP addresses
		    IPAddress[] hostIPs = Dns.GetHostAddresses(host);
		    // get local IP addresses
		    IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
		
		    // test if any host IP equals to any local IP or to localhost
		    foreach (IPAddress hostIP in hostIPs)
		    {
		      // is localhost
		      if (IPAddress.IsLoopback(hostIP)) return true;
		      // is local address
		      foreach (IPAddress localIP in localIPs)
		      {
		        if (hostIP.Equals(localIP)) return true;
		      }
		    }
		  }
		  catch { }
		  return false;
		}

        public void Log(string text) { this.Log(text + "\n", Color.Black); }
        public void Log(string text, Color color)
        {
            Dlg dlg = new Dlg(() =>{
                int selSt = richTextBox1.SelectionStart;
                int selLen = richTextBox1.SelectionLength;
        	
                richTextBox1.SelectionStart = richTextBox1.TextLength;
                richTextBox1.SelectionLength = 0;
	
                richTextBox1.SelectionColor = color;
                richTextBox1.AppendText(text);
                richTextBox1.SelectionColor = richTextBox1.ForeColor;
	        
                if(cbAutoscroll.Checked)
                richTextBox1.ScrollToCaret();
	        
	        
                richTextBox1.SelectionStart = selSt;
                richTextBox1.SelectionLength = selLen;
            });

            Async.UI(dlg, richTextBox1, true);
        }
        
        void BtnSendClick(object sender, EventArgs e)
        {
        	foreach(ListViewItem item in lvConnections.SelectedItems)
        	{
        		try
        		{
	        		GSocket sock = item.Tag as GSocket;
	        		sock.Send(new System.Text.ASCIIEncoding().GetBytes(tbSend.Text));
	        		Log("[" + sock.Name + "]:",Color.DarkGray); Log(tbSend.Text + "\n",Color.LightGray);
        		}
        		catch(Exception ex)
        		{
        			MessageBox.Show(ex.Message);
        		}
        	}
        }
        
        void ConnectionFormClosing(object sender, FormClosingEventArgs e)
        {
        	foreach(ListViewItem item in lvConnections.Items)
        	{
        		try
        		{
	        		GSocket sock = item.Tag as GSocket;
	        		sock.Kill();
        		}
	                		
        		catch(Exception ex)
        		{
        			MessageBox.Show(ex.Message);
        		}
        	}

            if (_openListenerThread != null) {
                if (_openListenerThread.ThreadState == ThreadState.Running)
                    _openListenerThread.Abort();
                _openListenerThread = null;
            }

            foreach (GSocketListener listener in _lListener) {
                listener.Kill();
                Log("[SERVER]: Stop listening on Port " + listener.Port.ToString() + "\n", Color.DarkRed);
            }
            _lListener.Clear();
            try {
                StreamWriter sw = new StreamWriter("Lib\\lastIP.txt");
                sw.WriteLine(this.tbClientIP.Text);
                sw.WriteLine(this.tbClientPort.Text);
                sw.Close();
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }
        
        void TbClientIPKeyPress(object sender, KeyPressEventArgs e)
        {
        	if(e.KeyChar == '\r')
        		this.btnClientConnect_Click(null,null);
        }
        void TbClientPortKeyPress(object sender, KeyPressEventArgs e)
        {
        	if(e.KeyChar == '\r')
        		this.btnClientConnect_Click(null,null);
        }

        
        void TbSendKeyPress(object sender, KeyPressEventArgs e)
        {
        	if(e.KeyChar == '\r')
        		this.BtnSendClick(null,null);
        }

        public  static string ToLiteral(string input) {
            using (var writer = new StringWriter()) {
                using (var provider = CodeDomProvider.CreateProvider("CSharp")) {
                    provider.GenerateCodeFromExpression(new CodePrimitiveExpression(input), writer, null);
                    return writer.ToString();
                }
            }
        }

        public GSocket[] GetSelectedConnections() {
            List<GSocket> tmpList = new List<GSocket>();

            foreach (ListViewItem item in lvConnections.SelectedItems) {
                try {
                    GSocket sock = item.Tag as GSocket;
                    tmpList.Add(sock);
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
            return tmpList.ToArray();
        }
        public GSocket[] GetConnections() {
            List<GSocket> tmpList = new List<GSocket>();

            foreach (ListViewItem item in lvConnections.Items) {
                try {
                    GSocket sock = item.Tag as GSocket;
                    tmpList.Add(sock);
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
            return tmpList.ToArray();
        }

        public void AddClient(GSocket client) {
            this._listener_ClientArrived(null, client);
        }

        public string Help() {
            return @"
Server.GetConnections() #returns all active connections
Server.GetSelectedConnections() #return all active connections wich are selected
Server.Log(string text, Color color)
Server.AddClient(GSocket client)
Server.OnNewClient += lambda GSocketListener_Sender, GSocket_Client: log('New Client')
Server.OnClosedClient += lambda GSocket_Client: log('Closed Client')
Server.OnDataArrived += lambda GSocket_sender, bytearray_Data: log('Data Arrived')

for con in Server.GetSelectedConnections():
    con.Send('Hello World!')

".Replace("\r", "");
        }

        private void ironTextBoxControl1_Load(object sender, EventArgs e) {
            ironTextBoxControl1.scope.SetVariable("Server", this);
            ironTextBoxControl1.WriteText("log = Server.Log\r\n");
            ironTextBoxControl1.SimEnter();
            ironTextBoxControl1.WriteText("help\r\n");
            ironTextBoxControl1.SimEnter();
            ironTextBoxControl1.WriteText("Server.Help()\r\n");
            ironTextBoxControl1.SimEnter();
            try {
                if (File.Exists("Lib\\startup.py"))
                    //ironTextBoxControl1.WalkPythonFile("Lib\\startup.py");
                    ironTextBoxControl1.scope.Engine.ExecuteFile("Lib\\startup.py", ironTextBoxControl1.scope);
            } catch (Exception ex) {
                MessageBox.Show("Lib\\startup.py -> " + ex.Message);
            }
        }
    }

}