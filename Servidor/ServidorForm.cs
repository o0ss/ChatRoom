using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Servidor
{
    public partial class ServidorForm : Form
    {
        private static readonly int MAX_BYTES = 10240, MAX_CLIENTES = 5;
        static IPHostEntry host = Dns.GetHostEntry("localhost");
        static IPAddress ip_addr = host.AddressList[0];
        static IPEndPoint localEndPoint = new IPEndPoint(ip_addr, 11200);


        public ServidorForm()
        {
            InitializeComponent();
        }

        public void IniciarServidor()
        {
            

            try
            {
                
                Thread listener_thread = new Thread(new ThreadStart(ListenForClientes));
                listener_thread.Start();
                
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

            listBoxMsgs.Items.Add("Added from thread");

            List<Socket> handlers = new List<Socket>();

            for (int i = 0; i < MAX_CLIENTES; i++)
            {
                listener.Listen(10);
                MessageBox.Show("Esperando conexión...");
                Socket nuevo_handler = listener.Accept();
                handlers.Add(nuevo_handler);
                MessageBox.Show(String.Concat("Cliente num ", i.ToString()));
            }





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
            handler.Send(response_bytes);



            handler.Shutdown(SocketShutdown.Both);
            handler.Close();

            MessageBox.Show("Thread exited");
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            IniciarServidor();
            buttonStart.Enabled = false;
        }
    }
}