using System.CodeDom.Compiler;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Servidor
{
    public partial class ServidorForm : Form
    {
        private static readonly int MAX_BYTES = 10240, MAX_CLIENTES = 5;
        static IPHostEntry host = Dns.GetHostEntry("localhost");
        static IPAddress ip_addr = host.AddressList[0];
        static IPEndPoint localEndPoint = new IPEndPoint(ip_addr, 11200);
        private Socket listener, handler;
        private bool salir = false, send = false, activo = false, connected = false, last_conn_st = false, bind = false;
        private DateTime now = DateTime.Now, last = DateTime.MinValue;

        public ServidorForm()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!activo)
            {

                //Task inicServTask = new Task(IniciarServidor);
                //inicServTask.Start();
                IniciarServidor();

                listBoxMsgs.Enabled = true;
                labelMsgs.Enabled = true;
                textBoxInput.Enabled = true;
                buttonSend.Enabled = true;
                buttonStart.Text = "Detener servidor";
                labelServidorStatus.Text = "El servidor está activo.";
                activo = true;
            }
            else
            {
                DetenerServidor();
                listBoxMsgs.Enabled = false;
                labelMsgs.Enabled = false;
                textBoxInput.Enabled = false;
                buttonSend.Enabled = false;
                buttonStart.Text = "Iniciar servidor";
                labelServidorStatus.Text = "El servidor está desactivado.";
                activo = false;
            }

        }

        public void IniciarServidor()
        {
            try
            {
                //Thread listener_thread = new Thread(new ThreadStart(ListenForClientes));
                //listener_thread.Start();
                //ListenForClientes();

                if (!bind)
                {
                    listener = new Socket(ip_addr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    listener.Bind(localEndPoint);

                    listener.Listen(10);
                    bind = true;
                }

                handler = listener.Accept();
                timerCheckConnection.Enabled = true;
                timerCheckMsgs.Enabled = true;

                //AgregarAMensajes("Conexión exitosa");

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
        }

        private void Idle()
        {
            //IntercambiarMensajes();

            //DetenerServidor();

            //handler.Shutdown(SocketShutdown.Both);
            //handler.Close();

            //AgregarAMensajes("Servidor apagado.");
        }

        public void ListenForClientes()
        {
            Socket listener = new Socket(ip_addr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);
            listener.Blocking = false;

            listBoxMsgs.Items.Add("Test from ListenForClientes");

            List<Socket> handlers = new List<Socket>();

            for (int i = 0; i < MAX_CLIENTES; i++)
            {
                listener.Listen(10);
                MessageBox.Show("Esperando conexión...");
                Socket nuevo_handler = listener.Accept();
                handlers.Add(nuevo_handler);
                MessageBox.Show(String.Concat("Cliente num ", i.ToString()));
            }

            MessageBox.Show("Fuera de ciclo for handlrers");

            string msg_recvd;
            byte[] bytes_recvd = new byte[MAX_BYTES];
            int num_bytes_recvd;


            while (true)
            {
                num_bytes_recvd = handlers[0].Receive(bytes_recvd);
                msg_recvd = Encoding.ASCII.GetString(bytes_recvd, 0, num_bytes_recvd);

                if (msg_recvd.IndexOf("<EOF>") > -1)
                    break;
            }
            string clean_query = msg_recvd[..^5];

            MessageBox.Show("Cliente: " + clean_query);

            byte[] response_bytes = Encoding.UTF8.GetBytes("Bye!");
            handlers[0].Send(response_bytes);


            handlers[0].Shutdown(SocketShutdown.Both);
            handlers[0].Close();

            MessageBox.Show("Thread exited");
        }

        private void IntercambiarMensajes()
        {
            Task taskRecibir = new Task(RecibirMensajes);
            Task taskEnviar = new Task(EnviarMensaje);

            taskRecibir.Start();
            taskEnviar.Start();

            //do
            //{
            //    if(msgs_nuevos.Count > 0)
            //    {
            //        if (msgs_nuevos.ElementAt(0).Equals("exit!"))
            //        {
            //            salir = true;
            //        }
            //        else
            //        {
            //            AgregarAMensajes(msgs_nuevos.ElementAt(0));
            //            msgs_nuevos.RemoveAt(0);
            //        }
            //    }
            //} while (!salir);

            return;
        }

        private void EnviarMensaje()
        {
            //MessageBox.Show("test from enviar");
            //msgs_nuevos.Add("msg from enviar");

            string msg = textBoxInput.Text;
            byte[] response_bytes = Encoding.UTF8.GetBytes(msg);
            handler.Send(response_bytes);
            AgregarAMensajes("Servidor: " + msg);
            textBoxInput.Clear();

            //do
            //{
            //    if(send)
            //    {
            //        byte[] response_bytes = Encoding.UTF8.GetBytes(textBoxInput.Text);
            //        handler.Send(response_bytes);
            //        textBoxInput.Clear();
            //        send = false;
            //    }
            //} while (!salir);

            return;
        }

        private void RecibirMensajes()
        {
            //MessageBox.Show("test from recibir");
            //msgs_nuevos.Add("msg from recibir");
            //AgregarAMensajes("test from recibir");

            int buffer_size = handler.Available;

            if (buffer_size > 0)
            {
                string msg_recvd;
                byte[] bytes_recvd = new byte[MAX_BYTES];
                int num_bytes_recvd;

                num_bytes_recvd = handler.Receive(bytes_recvd);
                msg_recvd = Encoding.ASCII.GetString(bytes_recvd, 0, num_bytes_recvd);

                string msg = msg_recvd[..^5];
                AgregarAMensajes("Cliente: " + msg);
            }

            //while (true) //maybe remove while
            //{
            //    num_bytes_recvd = handler.Receive(bytes_recvd);
            //    msg_recvd = Encoding.ASCII.GetString(bytes_recvd, 0, num_bytes_recvd);

            //    if (msg_recvd.IndexOf("<EOF>") > -1)
            //        break;
            //}

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

        private void timerCheckMsgs_Tick(object sender, EventArgs e)
        {
            RecibirMensajes();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            EnviarMensaje();
        }

        private void DetenerServidor()
        {
            timerCheckMsgs.Enabled = false;
            timerCheckConnection.Enabled = false;
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
            labelConnStatus.Text = "Desconectado.";
            last_conn_st = false;
        }

        private void AgregarAMensajes(string msg)
        {
            now = DateTime.Now;
            TimeSpan diff = now - last;
            if (diff.Seconds > 10)
            {
                string time = now.Hour + ":" + now.Minute + ":" + now.Second;
                listBoxMsgs.Items.Add("        " + time + "        ");
            }
            listBoxMsgs.Items.Add(msg);
            last = now;
        }
    }
}