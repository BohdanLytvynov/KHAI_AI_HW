using BarcodeReader.UI.ViewModels.Base.Commands;
using BarcodeReader.UI.ViewModels.Base.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BarcodeReader.UI.ViewModels.Windows
{
    internal class MainWindowViewModel : TitledViewModel
    {
        #region Fields
        private string m_path;

        private string m_result;
        #endregion

        #region Properties
        public string PathToImg 
        {
            get=>m_path;
            set=>Set(ref m_path, value);
        }

        public string Result 
        {
            get=>m_result;
            set=>Set(ref m_result, value);
        }
        #endregion

        #region Commands

        public ICommand OnReadBarcodeButtonPressed { get; }

        public ICommand OnClearButtonPressed { get; }

        public ICommand OnAboutButtonPressed { get; }

        #endregion

        #region Ctor
        public MainWindowViewModel()
        {
            SetTitle("Barcode Reader V 1.0.0.0");

            m_path = string.Empty;
            m_result = string.Empty;

            OnReadBarcodeButtonPressed = new Command(
                OnReadButtonPressedExecute,
                CanOnReadButtonPressedExecute
                );

            OnClearButtonPressed = new Command
                (
                    OnClearButtonPressedExecute,
                    CanOnClearButtonPressedExecute
                );

            OnAboutButtonPressed = new Command(
                OnAboutButtonPressedExecute,
                CanOnAboutButtonPressedExecute
                );
        }
        #endregion

        #region Methods
        #region On Read Button Pressed Execute

        private bool CanOnReadButtonPressedExecute(object p)
        { 
            return !string.IsNullOrEmpty(PathToImg);
        }

        private void OnReadButtonPressedExecute(object p)
        { 
            
        }

        #endregion

        #region On Clear Button Pressed Execute

        private bool CanOnClearButtonPressedExecute(object p)
        {
            return !string.IsNullOrEmpty(Result);
        }

        private void OnClearButtonPressedExecute(object p)
        { 
            Result = string.Empty;
        }

        #endregion

        #region On About Button Pressed Execute

        private bool CanOnAboutButtonPressedExecute(object p) => true;        

        private void OnAboutButtonPressedExecute(object p)
        {
            MessageBox.Show("This app made by Bohdan Lytvynov 125 group. " +
                "\nIt can load image to the Image Viewer and then process the barcode inside it.\n" +
                "How to use? \n" +
                "1) Load image to the viewer. Press Open and choose your Image" +
                "2) Press Read button and you will get your result!", Title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        #endregion

        #endregion
    }
}
