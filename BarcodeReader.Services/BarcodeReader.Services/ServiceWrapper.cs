﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeReader.Services
{
    public static class ServiceWrapper
    {
        private static IServiceCollection? m_services;

        private static IServiceProvider? m_serviceProvider;              

        public static void Init()
        {
            if (m_services == null)
            {
                m_services = new ServiceCollection();               
            }            
        }

        public static void ConfigureServices(Action<IServiceCollection> configurator)
        {              
            configurator(m_services);
        }

        public static IServiceProvider ServiceProvider 
        {
            get 
            {
                if(m_serviceProvider == null)
                    m_serviceProvider = m_services.BuildServiceProvider();

                return m_serviceProvider;
            }
        }
    }
}
