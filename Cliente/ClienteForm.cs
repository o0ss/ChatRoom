using System.Net;
using System.Net.Sockets;

namespace Cliente
{
    public partial class ClienteForm : Form
    {
        static IPHostEntry host = Dns.GetHostEntry("localhost");
        static IPAddress local_ip = host.AddressList[0];
        static IPEndPoint localEndPoint = new IPEndPoint(local_ip, 11200), remoteEP;
        private Socket handler;
        private bool activo = false, connected = false, last_conn_st = false, bind = false;
        private DateTime now = DateTime.Now, last = DateTime.MinValue;

        public ClienteForm()
        {
            InitializeComponent();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (!activo)
            {
                //string input_ip = textBoxIPAddress.Text;
                //if (input_ip.Equals(""))
                //{
                //    MessageBox.Show("Escribe la dirección IP del servidor.");
                //    return;
                //}
                //IPAddress serv_ip;
                //if ( ! IPAddress.TryParse(input_ip, out serv_ip))
                //{
                //    MessageBox.Show("La dirección IP no es válida.");
                //    return;
                //}
                //else
                //{
                //    //MessageBox.Show(serv_ip.ToString());
                //    ConectarAServidor(serv_ip);
                //}

                ConectarAServidor(local_ip);

                listBoxMsgs.Enabled = true;
                buttonSend.Enabled = true;
                textBoxInput.Enabled = true;
                buttonConnect.Text = "Desconectar";
                activo = true;
            }
            else
            {
                //Desconectar de servidor
                DesconectarServidor();
                listBoxMsgs.Enabled=false;
                buttonSend.Enabled=false;
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
                remoteEP = new IPEndPoint(server_ip, 11200);
                handler.Connect(remoteEP);

                //Activar timers



                return;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
            
        }

        private void DesconectarServidor()
        {
            // Desactivar timers

            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
            labelConnStatus.Text = "Desconectado";
            return;
        }
    }
}