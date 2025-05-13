using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeReader.BLL.BarcodeReaders.Interfaces
{
    public interface IBarCodeReader
    {
        List<string> ReadBarcodesFromImg(string path, out Exception? error);
    }
}
