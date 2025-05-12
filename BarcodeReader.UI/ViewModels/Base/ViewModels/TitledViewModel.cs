using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeReader.UI.ViewModels.Base.ViewModels
{
    internal abstract class TitledViewModel : ViewModelBase
    {
        #region Fields
        private string m_Title;
        #endregion

        #region Properties
        public string Title { get=>m_Title; set=>Set(ref m_Title, value); }
        #endregion

        #region Methods
        protected void SetTitle(string value)
        {
            m_Title = value;        
        }
        #endregion
    }
}
