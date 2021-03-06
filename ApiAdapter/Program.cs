﻿using System.ServiceProcess;

namespace ApiAdapter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var servicesToRun = new ServiceBase[] 
            { 
                new ApiAdapter() 
            };
            ServiceBase.Run(servicesToRun);
        }
    }
}
