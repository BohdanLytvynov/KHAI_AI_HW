﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace BarcodeReader.UI.ViewModels.Base.ViewModels
{
    internal class ViewModelBase : INotifyPropertyChanged
    {
        private Dispatcher? m_Dispatcher;

        public Dispatcher? Dispatcher
        {
            get => m_Dispatcher;
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                m_Dispatcher = value;
            }
        }

        #region INotify Property Changed Implementation

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propName)
        { 
            var temp = Volatile.Read(ref this.PropertyChanged);
            temp?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        #endregion

        public virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propName = "")
        { 
            if (field == null) throw new ArgumentNullException(nameof(field));

            if (value.Equals(field))
            {
                return false;
            }
            else
            {
                field = value;
                OnPropertyChanged(propName);
                return true;
            }
        }

        #region IDataErrorInfo

        public virtual string Error => throw new NotImplementedException();

        public virtual string this[string columnName] => throw new NotImplementedException();

        private bool[] m_ValidArray = null;

        #endregion       

        protected void InitValidArray(int count)
        { 
            m_ValidArray = new bool[count];
        }

        protected bool ValidateFields(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                if (!m_ValidArray[i])
                    return false;
            }

            return true;
        }

        protected void ResetValidArray()
        {
            int len = m_ValidArray.Length;

            for (int i = 0; i < len; i++)
            {
                m_ValidArray[i] = false;
            }
        }

        protected void SetValidArrayValue(int pos, bool value)
        {
            m_ValidArray[pos] = value;
        }

        protected int GetValidArrayLastIndex()
        {
            return m_ValidArray.Length - 1;        
        }

        protected int GetValidArrayCount()
        {
            return m_ValidArray.Length;
        }

        protected void QueueJobToDispatcher(Action action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            m_Dispatcher?.Invoke(action);
        }

    }
}
