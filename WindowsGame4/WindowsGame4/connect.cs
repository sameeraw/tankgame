using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace WindowsGame4
{
    class connect
    {
        private string ip = "127.0.0.1";
        private int cli_port = 7000;
        private int ser_port = 6000;
        private TcpClient client = null; //tcp socket
        private TcpListener cli_listener;
        private NetworkStream network_stream; //severstream

 

        private Thread first_msge;
        private Thread cli_ser;
        private String data;
        public connect()
        {
            this.data = "";
        }


        public void write_to_server(String message)
        {
            this.client = new TcpClient();
            try
            {
                client.Connect(ip, ser_port); // connect the sever
                if (this.client.Connected)
                {
                    //if the input text doesn't equal to null, then writing processed
                    if (message != null)
                    {
                        NetworkStream cli_stream = client.GetStream();
                        BinaryWriter printer = new BinaryWriter(cli_stream);
                        Byte[] byteMsg = Encoding.ASCII.GetBytes(message); //convert message to a byte array
                        printer.Write(byteMsg); // print the byte message to server

                        //close all
                        printer.Close();
                        cli_stream.Close();

                    }
                    else
                    {
                        //if the input message is empty
                    }
                }
                else
                {
                    //if the client not connected
                }
            }
            catch (Exception ex)
            {
                //any exception happens while connecting
            }

        }
        /*listener method..............*/
        public void  listener()
        {
            Socket conn_socket = null;
            try
            {
                //initiate the listining socket
                this.cli_listener = new TcpListener(IPAddress.Parse(ip), cli_port);
                this.cli_listener.Start();
                while (true)
                {
                    conn_socket = cli_listener.AcceptSocket();
                    if (conn_socket.Connected)
                    {
                        this.network_stream = new NetworkStream(conn_socket);
                        List<Byte> from_server = new List<byte>();
                        int get = 0;
                        while (get != -1)
                        {
                            get = this.network_stream.ReadByte();
                            from_server.Add((Byte)get);
                        }
                        String reading = Encoding.UTF8.GetString(from_server.ToArray()); // get the the input reading to a string 
                        //wht to do with the reading.....
                        Console.WriteLine("*******************nuwan**********");
                        Console.WriteLine(reading);
                        Console.WriteLine("******************end here************");
                        //this.screan.show_messages(reading);
                        //Console.Write(this.test.map_parser(reading));
                        this.data= reading;
                        Thread.Sleep(500);
                    }
                    else
                    {
                        //if the conn_socket didn't connect
                        
                    }
                }
            }
            catch (Exception e)
            {
                //exception code here
                
            }
            finally
            {
                // conn_socket.Close();
                if (conn_socket != null)
                {
                    conn_socket.Close();
                }
            }
        }

        public void cli_start()
        {
            this.first_msge = new Thread(() => this.write_to_server("JOIN#")); // to check the availability of the server
            this.cli_ser = new Thread(new ThreadStart(this.listener));
            this.first_msge.IsBackground = true;
            this.cli_ser.IsBackground = true;
            this.first_msge.Start();
            this.cli_ser.Start();
        }

        public String getData()
        {
            return this.data;
        }

    }
}
