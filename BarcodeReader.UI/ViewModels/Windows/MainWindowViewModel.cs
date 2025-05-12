using BarcodeReader.UI.ViewModels.Base.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        #endregion

        #region Ctor
        public MainWindowViewModel()
        {
            SetTitle("Barcode Reader V 1.0.0.0");

            m_path = string.Empty;
            m_result = string.Empty;
        }
        #endregion

        #region Methods
        #region On Read Button Pressed Execute

        #endregion

        #region On Clear Button Pressed Execute

        #endregion
        #endregion
    }
}
