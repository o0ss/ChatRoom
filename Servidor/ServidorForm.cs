using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

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

        public ServidorForm()
        {
            InitializeComponent();
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

                listBoxMsgs.Items.Add("Test from initserver");

                listener.Listen(10);
                MessageBox.Show("Esperando conexión...");
                handler = listener.Accept();
                MessageBox.Show("handler accept");

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

        private void button1_Click(object sender, EventArgs e)
        {
            Thread test = new Thread(new ThreadStart(TestProc));
            test.Start();
            while(true)
            {
                while(msgs_nuevos.Count  > 0)
                {
                    listBoxMsgs.Items.Add(msgs_nuevos[0]);
                    msgs_nuevos.RemoveAt(0);
                    Thread.Sleep(100);
                }
            }
        }

        private void TestProc()
        {
            for (int i = 0; i < 10; i++)
            {
                msgs_nuevos.Add($"Msg num {i}");
                Thread.Sleep(1000);
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            IniciarServidor();
            buttonStart.Enabled = false;
            listBoxMsgs.Enabled = true;
            labelMsgs.Enabled = true;
            richTextBoxInput.Enabled = true;
            buttonSend.Enabled = true;

            while(!salir)
            {
                await RecibirMensajes();
                if(send)
                {
                    await EnviarMensaje();
                }
            }

            handler.Shutdown(SocketShutdown.Both);
            handler.Close();

            MessageBox.Show("Server closed");

        }

        private void RecibirMensajes()
        {
            string msg_recvd;
            byte[] bytes_recvd = new byte[MAX_BYTES];
            int num_bytes_recvd;


            while (true)
            {
                num_bytes_recvd = handler.Receive(bytes_recvd);
                msg_recvd = Encoding.ASCII.GetString(bytes_recvd, 0, num_bytes_recvd);

                if (msg_recvd.IndexOf("<EOF>") > -1)
                    break;
            }
            string clean_query = msg_recvd[..^5];

            listBoxMsgs.Items.Add("Cliente: " + clean_query);

        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            EnviarMensaje();
        }

        private void EnviarMensaje()
        {
            byte[] response_bytes = Encoding.UTF8.GetBytes(richTextBoxInput.Text);
            handler.Send(response_bytes);
            return;
        }
    }
}