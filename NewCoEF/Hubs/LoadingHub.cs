using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewCoEF.Hubs
{
    //loadingHub
    public class LoadingHub : Hub
    {
        public LoadingHub()
        {
            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, certificate, chain, sslPolicyErrors) => true;
        }

        /// <summary>
        /// Send start process notification
        /// </summary>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public async Task SendStartProcessToCaller(int recordCount)
        {
            await Clients.Caller.SendAsync("SendStartProcessToCaller", recordCount);
        }

        /// <summary>
        /// Send progress of loading notification
        /// </summary>
        /// <param name="progressValue"></param>
        /// <param name="elapsedTime"></param>
        /// <param name="eta"></param>
        /// <returns></returns>
        public async Task SendProgressToCaller(int progressValue, string elapsedTime, string eta)
        {
            await Clients.Caller.SendAsync("SendProgressToCaller", progressValue, elapsedTime, eta);
        }

        /// <summary>
        /// Send end process notification
        /// </summary>
        /// <param name="completed"></param>
        /// <returns></returns>
        public async Task SendEndProcessToCaller(bool completed)
        {
            await Clients.Caller.SendAsync("SendEndProcessToCaller", completed);
        }

        /// <summary>
        /// Send an error
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendErrorToCaller(string message)
        {
            await Clients.Caller.SendAsync("SendErrorToCaller", message);
        }

        //loadData
        public async Task LoadData(string user, bool simulateError)
        {

            DateTime startProcess = DateTime.Now;

            var itemsCount = 30;

            try
            {
                await SendStartProcessToCaller(itemsCount);

                for (int i = 0; i <= itemsCount; i++)
                {
                    Thread.Sleep(500); //Rallentamento simulato

                    var elapsed = DateTime.Now - startProcess;

                    var totalDuration = elapsed.Ticks;

                    var eta = new TimeSpan(totalDuration * itemsCount / (i == 0 ? 1 : i));

                    if ((simulateError) && (i > 3))
                        throw new Exception("Errore anomalo di caricamento. Riprova!");

                    await SendProgressToCaller(i, elapsed.ToString(@"hh\:mm\:ss"), eta.ToString(@"hh\:mm\:ss"));
                }


                await SendEndProcessToCaller(true);
            }
            catch (Exception ex)
            {
                await SendEndProcessToCaller(false);
                await SendErrorToCaller(ex.Message);
            }

        }
    }
}
