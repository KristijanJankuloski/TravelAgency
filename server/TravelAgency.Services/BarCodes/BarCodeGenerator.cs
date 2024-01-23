using IronBarCode;

namespace TravelAgency.Services.BarCodes
{
    public static class BarCodeGenerator
    {
        public static byte[] GenerateDataMatrix(string data)
        {
            GeneratedBarcode code = BarcodeWriter.CreateBarcode(data, BarcodeEncoding.DataMatrix);
            return code.ToPngBinaryData();
        }
    }
}
