using BarcodeReader.BLL.BarcodeReaders.Interfaces;
using BarcodeReader.BLL.BarcodeReaders.Realizations;
using BarcodeReader.Services;
using BarcodeReader.UI.ViewModels.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;


namespace BarcodeReader.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {        
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ServiceWrapper.Init();
            ServiceWrapper.ConfigureServices(c =>
            {
                c.AddSingleton<IBarCodeReader, BarcodeReader.BLL.BarcodeReaders.Realizations.BarcodeReader>();

                c.AddSingleton<MainWindowViewModel>();

                c.AddTransient(config =>
                {
                    var vm = config.GetRequiredService<MainWindowViewModel>();

                    var view = new MainWindow();

                    view.DataContext = vm;
                    vm.Dispatcher = view.Dispatcher;

                    return view;
                });
            });

            var serviceProvider = ServiceWrapper.ServiceProvider;

            serviceProvider.GetRequiredService<MainWindow>().Show();
        }
    }

}
