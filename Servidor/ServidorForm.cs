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
        static List<String> msgs_nuevos = new List<String>();
        private Socket handler;
        private bool salir = false, send = false;
        private DateTime now = DateTime.Now, last = DateTime.MinValue;

        public ServidorForm()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            IniciarServidor();
            buttonStart.Enabled = false;
            listBoxMsgs.Enabled = true;
            labelMsgs.Enabled = true;
            textBoxInput.Enabled = true;
            buttonSend.Enabled = true;

            IntercambiarMensajes();

            DetenerServidor();

            //handler.Shutdown(SocketShutdown.Both);
            //handler.Close();

            AgregarAMensajes("Servidor apagado.");

        }

        public void IniciarServidor()
        {
            try
            {
                //Thread listener_thread = new Thread(new ThreadStart(ListenForClientes));
                //listener_thread.Start();
                //ListenForClientes();

                Socket listener = new Socket(ip_addr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                listener.Bind(localEndPoint);

                listener.Listen(10);
                AgregarAMensajes("Esperando conexi�n...");

                handler = listener.Accept();
                AgregarAMensajes("Conexi�n exitosa");

                //listener.Shutdown(SocketShutdown.Both);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
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
                MessageBox.Show("Esperando conexi�n...");
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

            return;
        }

        private void EnviarMensaje()
        {
            Thread.Sleep(5000);
            AgregarAMensajes("End enviar");
            byte[] response_bytes = Encoding.UTF8.GetBytes(textBoxInput.Text);
            handler.Send(response_bytes);
            return;
        }

        private void RecibirMensajes()
        {

            Thread.Sleep(7000);
            AgregarAMensajes("End recibir");

            //string msg_recvd;
            //byte[] bytes_recvd = new byte[MAX_BYTES];
            //int num_bytes_recvd;


            //while (true)
            //{
            //    num_bytes_recvd = handler.Receive(bytes_recvd);
            //    msg_recvd = Encoding.ASCII.GetString(bytes_recvd, 0, num_bytes_recvd);

            //    if (msg_recvd.IndexOf("<EOF>") > -1)
            //        break;
            //}
            //string msg = msg_recvd[..^5];
            //msg = "Cliente: " + msg;
            //listBoxMsgs.Items.Add(msg);


            return;
        }
        private void buttonSend_Click(object sender, EventArgs e)
        {
            Task sendTask = new Task(EnviarMensaje);
            sendTask.Start();
        }

        private void DetenerServidor()
        {
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }

        private void AgregarAMensajes(string msg)
        {
            int diff = last.CompareTo(now);
            if (diff > 1)
            {
                listBoxMsgs.Items.Add("------ " + now + " ------");
            }
            listBoxMsgs.Items.Add(msg);
        }
    }
}