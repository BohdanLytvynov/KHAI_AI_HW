using BarcodeReader.BLL.BarcodeReaders.Interfaces;
using IronOcr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeReader.BLL.BarcodeReaders.Realizations
{
    public class BarcodeReader : IBarCodeReader
    {
        IronTesseract m_tesseractInstance;

        public BarcodeReader()
        {
            m_tesseractInstance = new IronTesseract();

            m_tesseractInstance.Configuration.ReadBarCodes = true;
        }

        public List<string> ReadBarcodesFromImg(string path, out Exception? error)
        {
            error = null;
            List<string> res = new List<string>();
            using (var ocrInput = new OcrInput())
            {
                try
                {
                    ocrInput.LoadImage(path);

                    var r = m_tesseractInstance.Read(ocrInput);

                    foreach (var barcode in r.Barcodes)
                    {
                        res.Add(barcode.Value);
                    }
                }
                catch (Exception e)
                {
                    error = e;
                }
            }

            return res;
        }
    }
}
