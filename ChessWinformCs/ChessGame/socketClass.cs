using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public class socketClass
    {
        #region Properties
        string IP = "127.0.0.1";
        Socket server = null;
        Socket client = null;
        #endregion

        public socketClass()
        {

        }


        #region Methods
        /// <summary>
        /// Khởi tạo socket server / tạo phòng
        /// </summary>
        public void CreateServer()
        {
            IPEndPoint IEP = new IPEndPoint(IPAddress.Any, Constant.PORT);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                server.Bind(IEP);
                server.Listen(10);
                MessageBox.Show("Tạo phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Không thể tạo phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                server = null;
                return;
            }

            // accept and listen client
            Thread acceptClient = new Thread(() =>
            {
                client = server.Accept();
                MessageBox.Show("Có một client vừa truy cập vào server!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
            acceptClient.IsBackground = true;
            acceptClient.Start();

            //// listen message from client
            //Listen();
        }

        /// <summary>
        /// Kết nối client với server / vào phòng
        /// </summary>
        /// <returns></returns>
        public bool ConnectServer()
        {
            IPEndPoint IEP = new IPEndPoint(IPAddress.Parse(IP), Constant.PORT);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                client.Connect(IEP);
                MessageBox.Show("Vào phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Không thể vào phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //// listen server
            //Listen();

            return true;
        }

        /// <summary>
        /// Đóng kết nối của socket
        /// </summary>
        public void CloseSocket()
        {
            if (server != null)
            {
                server.Close();
            }
            else if (client != null)
            {
                client.Close();
            }
        }



        /// <summary>
        /// Nhận dữ liệu từ đối phương
        /// </summary>
        public dataClass ReceiveData()
        {
            byte[] data = new byte[Constant.BUFFER];

            try
            {
                client.Receive(data);
                //MessageBox.Show("Nhận được thông điệp từ người chơi đối diện\n");
            }
            catch
            {
                MessageBox.Show("Không thể nhận được đữ liệu từ server");
                Application.Exit();
            }

            return Deserialize(data) as dataClass;
        }

        /// <summary>
        /// Gửi dữ liệu cho đối phương
        /// </summary>
        /// <param name="obj"></param>
        public void SendData(object obj)
        {
            try
            {
                client.Send(Serialize(obj));
            }
            catch
            {
                MessageBox.Show("Client đã rời khỏi phòng!");
                client.Close();
            }
        }

        /// <summary>
        /// Mã hoá/phân mảnh dữ liệu thành mảng byte
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);

            return stream.ToArray();
        }

        /// <summary>
        /// Giải mã/gom mảnh dữ liệu thành kiểu dữ liệu object
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            stream.Position = 0;

            return formatter.Deserialize(stream);
        }
        #endregion
    }
}
