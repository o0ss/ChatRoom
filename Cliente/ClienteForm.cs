using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Cliente
{
    public partial class ClienteForm : Form
    {
        private static readonly int MAX_BYTES = 10240, PORT = 11244;
        static IPHostEntry host = Dns.GetHostEntry("localhost");
        static IPAddress local_ip = host.AddressList[0];
        static IPEndPoint remoteEP;
        private Socket handler;
        private bool activo = false, connected = false, last_conn_st = false;
        private string EXIT_SIG = "____EXIT____";
        private DateTime now = DateTime.Now, last = DateTime.MinValue;

        public ClienteForm()
        {
            InitializeComponent();
        }
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (!activo)
            {
                string input_ip = textBoxIPAddress.Text;
                if (input_ip.Equals(""))
                {
                    MessageBox.Show("Escribe la dirección IP del servidor.");
                    return;
                }
                IPAddress serv_ip;
                if (!IPAddress.TryParse(input_ip, out serv_ip))
                {
                    MessageBox.Show("La dirección IP no es válida.");
                    return;
                }
                else
                {
                    //MessageBox.Show(serv_ip.ToString());
                    //ConectarAServidor(serv_ip);
                    ConectarAServidor(local_ip);
                    listBoxMsgs.Enabled = true;
                    buttonSend.Enabled = true;
                    textBoxInput.Enabled = true;
                    buttonConnect.Text = "Desconectar";
                    activo = true;
                }

                //ConectarAServidor(local_ip);

                //listBoxMsgs.Enabled = true;
                //buttonSend.Enabled = true;
                //textBoxInput.Enabled = true;
                //buttonConnect.Text = "Desconectar";
                //activo = true;
            }
            else
            {
                //Desconectar de servidor
                DesconectarDeServidor();
                listBoxMsgs.Enabled = false;
                buttonSend.Enabled = false;
                textBoxInput.Enabled = false;
                buttonConnect.Text = "Conectar";
                activo = false;
            }
            return;
        }

        private void ConectarAServidor(IPAddress server_ip)
        {
            try
            {
                handler = new Socket(server_ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                remoteEP = new IPEndPoint(server_ip, PORT);
                handler.Connect(remoteEP);

                //Activar timers
                timerCheckConnection.Enabled = true;   
                timerCheckMsgs.Enabled = true;


                return;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }

        }

        private void timerCheckMsgs_Tick(object sender, EventArgs e)
        {
            RecibirMensajes();
            return;
        }

        private void timerCheckConnection_Tick(object sender, EventArgs e)
        {
            connected = handler.Connected;
            if (last_conn_st != connected)
            {
                //IPAddress.Parse(((IPEndPoint)handler.RemoteEndPoint).Address.ToString())
                string rem_ip = ((IPEndPoint)handler.RemoteEndPoint).Address.ToString();
                labelConnStatus.Text = connected ?
                    "Conectado a " + rem_ip : "Desconectado";
                last_conn_st = connected;
            }
        }

        private void RecibirMensajes()
        {
            int buffer_size = handler.Available;

            if (buffer_size > 0)
            {
                string msg_recvd;
                byte[] bytes_recvd = new byte[MAX_BYTES];
                int num_bytes_recvd;

                num_bytes_recvd = handler.Receive(bytes_recvd);
                msg_recvd = Encoding.UTF32.GetString(bytes_recvd, 0, num_bytes_recvd);

                //string msg = msg_recvd[..^5];
                string msg = msg_recvd;

                if (msg.Equals(EXIT_SIG))
                {
                    buttonConnect_Click(new object(), new EventArgs());
                    AgregarAMensajes("---- El servidor se desconectó. ----");
                    return;
                }

                AgregarAMensajes("Servidor: " + msg);
            }

            return;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            EnviarMensaje();
        }

        private void EnviarMensaje()
        {
            string msg = textBoxInput.Text;
            byte[] response_bytes = Encoding.UTF32.GetBytes(msg);
            handler.Send(response_bytes);
            AgregarAMensajes("Cliente: " + msg);
            textBoxInput.Clear();

            return;
        }

        private void DesconectarDeServidor()
        {
            handler.Send(Encoding.UTF32.GetBytes(EXIT_SIG));

            // Desactivar timers
            timerCheckConnection.Enabled = false;
            timerCheckMsgs.Enabled = false;

            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
            labelConnStatus.Text = "Desconectado";
            last_conn_st = false;
            return;
        }

        private void AgregarAMensajes(string msg)
        {
            now = DateTime.Now;
            TimeSpan diff = now - last;
            if (diff.Seconds > 10)
            {
                string time = String.Format("{0,15}", now.TimeOfDay.ToString()[..^8]);
                listBoxMsgs.Items.Add("");
                listBoxMsgs.Items.Add(time);
            }
            listBoxMsgs.Items.Add(msg);
            last = now;
        }
    }
}