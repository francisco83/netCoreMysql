using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using coreNetMysql.Models;
using System.Net.Sockets;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using MongoDB.Driver;

namespace coreNetMysql
{


    public class Startup
    {
        Socket clientsock;
        byte[] MsgRecvBuff = new byte[1024];

        string sql = "";
        string[] sql_aux;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //services.AddMvc();
            services.Add(new ServiceDescriptor(typeof(SensoresContext), new SensoresContext(Configuration.GetConnectionString("DefaultConnection"))));
            services.Add(new ServiceDescriptor(typeof(MongoContext), new MongoContext(Configuration.GetConnectionString("DefaultConnection"))));


            string strIP;
            string strport;
            int port;

            // Get the IP text value
            strIP = "192.168.0.40";
            // Get the port text value
            strport = "23";
            port = Int32.Parse(strport);


            IPAddress peerIP = IPAddress.Parse(strIP);
            // There are IP or port information in the localEP
            IPEndPoint peerEP = new IPEndPoint(peerIP, port);

            // Client socket memory allocation
            clientsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            Console.Write("Connecting.. \n");

            try
            {
                // Send the signal for connect with server 
                // This application will be run asynchronously by this function.
                // If the client accept the socekt, this function called a ConnectCallback function.
                clientsock.BeginConnect(peerEP, new AsyncCallback(ConnectCallback), clientsock);

            }
            catch (SocketException er)
            {
                // If the socket exception is occurrence, the application display a error message.  
                Console.WriteLine(er.Message);
            }


        }

        public void ConnectCallback(IAsyncResult ar)
        {
            byte[] a = new byte[1024];
            try
            {
                // If the client socket connect with the server, return the socket
                clientsock = (Socket)ar.AsyncState;
                clientsock.EndConnect(ar);
                clientsock.ReceiveTimeout = 5000;

                Console.WriteLine("Conectado");

                //Inicializo para que comience a leer los datos
                clientsock.Send(a);


                // If the client transmitted the messages, this function called a Callback_ReceiveMsg function.
                clientsock.BeginReceive(MsgRecvBuff, 0, MsgRecvBuff.Length, SocketFlags.None, new AsyncCallback(CallBack_ReceiveMsg), clientsock);
            }
            catch (SocketException er)
            {
                Console.WriteLine(er.Message);
            }

        }

        // BeginReceive()'s call back fucntion
        public void CallBack_ReceiveMsg(IAsyncResult ar)
        {

            int length;
            String MsgRecvStr = null;
            SensoresContext context = new SensoresContext(Configuration.GetConnectionString("DefaultConnection"));

            //CheckHub a = new CheckHub();

            try
            {
                // If the socket close, return the 0 value 
                length = clientsock.EndReceive(ar);

                if (length > 0)
                {

                    MsgRecvStr = Encoding.Default.GetString(MsgRecvBuff, 0, length);

                    Console.WriteLine("Dato recibido:" + MsgRecvStr + "\n");

                    string[] res = MsgRecvStr.Split(" ");


                    //Seteo la temperatura
                    //a.SetTemp(MsgRecvStr);

                    //Guardo en base de datos los registros
                    //
                    try
                    {
                        /*
                        System.Globalization.CultureInfo customCulture = new System.Globalization.CultureInfo("en-US", true);

                        customCulture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd h:mm tt";

                        System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
                        System.Threading.Thread.CurrentThread.CurrentUICulture = customCulture;

                        DateTime newDate = System.Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd h:mm tt"));
                        */

                        //string f = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");
                        DatosSensores datosSensores = new DatosSensores();
                        //System.Globalization.CultureInfo customCulture = new System.Globalization.CultureInfo("en-US", true);
                        //datosSensores.Fecha = newDate;
                        datosSensores.Temperatura = Convert.ToDecimal(res[0]);
                        datosSensores.Humedad = Convert.ToDecimal(res[1]); 
                        datosSensores.Luminosidad = Convert.ToDecimal(res[2]);
                        datosSensores.Voltspanel = Convert.ToDecimal(res[3]);
                        datosSensores.Voltsbateria = 0;
                        //datosSensores.Voltsbateria = Convert.ToDecimal(res[4]); 

                        context.Save(datosSensores);
                    }
                    catch (Exception ex) {
                        Console.WriteLine("Error al querer grabar",ex.Message);
                    }

                    /*Conexion con MongoDb*/
                    /*
                    try
                    {

                        MongoClient dbClient = new MongoClient("mongodb://127.0.0.1:27017");

                        //Database List  
                        var dbList = dbClient.ListDatabases().ToList();

                        Console.WriteLine("Las base de datos son:");
                        foreach (var item in dbList)
                        {
                            Console.WriteLine(item);
                        }

                        Console.WriteLine("\n\n");

                        //Get Database and Collection  
                        IMongoDatabase db = dbClient.GetDatabase("pruebadb");
                        var collList = db.ListCollections().ToList();
                        Console.WriteLine("las listas de colecciones son :");
                        Console.WriteLine("\n\n");
                        foreach (var item in collList)
                        {
                            Console.WriteLine(item);

                        }
                    }
                    catch (Exception ex) {
                        Console.WriteLine("Fallo la conexión con Mongodb");
                    }
                        */

                        //MySql context = new SensoresContext().ConnectionString(); //HttpContext.RequestServices.GetService(typeof(coreNetMysql.Models.SensoresContext)) as SensoresContext;
                        //  context.GetAll();


                        //SensoresContext context =  new SensoresContext();


                        // The socket can continuedly wait the receive message because of this function 
                        clientsock.BeginReceive(MsgRecvBuff, 0, MsgRecvBuff.Length, SocketFlags.None, new AsyncCallback(CallBack_ReceiveMsg), clientsock);
                }
                else
                {
                    // If the socket close, return the 0 value 
                    // Then, socket close.
                    clientsock.Close();

                }

            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
