using Microsoft.AspNetCore.Components;
using System.Xml.Serialization;

namespace etax_generate_pdf.Models
{
    [XmlRoot(ElementName = "detailTransaksi")]
    public class DetailTransaksi
    {

        [XmlElement(ElementName = "nama")]
        public string? Nama { get; set; }

        [XmlElement(ElementName = "hargaSatuan")]
        public double HargaSatuan { get; set; }

        [XmlElement(ElementName = "jumlahBarang")]
        public double JumlahBarang { get; set; }

        [XmlElement(ElementName = "hargaTotal")]
        public double HargaTotal { get; set; }

        [XmlElement(ElementName = "diskon")]
        public double Diskon { get; set; }

        [XmlElement(ElementName = "dpp")]
        public double Dpp { get; set; }

        [XmlElement(ElementName = "ppn")]
        public double Ppn { get; set; }

        [XmlElement(ElementName = "tarifPpnbm")]
        public double TarifPpnbm { get; set; }

        [XmlElement(ElementName = "ppnbm")]
        public double Ppnbm { get; set; }
    }

    [XmlRoot(ElementName = "resValidateFakturPm")]
    public class DJP
    {
        public string? ReturNumber { get; set; }

        public DateTime? ReturDate { get; set; }

        [XmlElement(ElementName = "kdJenisTransaksi")]
        public string? KdJenisTransaksi { get; set; }

        [XmlElement(ElementName = "fgPengganti")]
        public int FgPengganti { get; set; }

        [XmlElement(ElementName = "nomorFaktur")]
        public string? NomorFaktur { get; set; }

        public string FormatedNomorFaktur
        {
            get
            {
                if(KdJenisTransaksi != null)
                {

                return $"{KdJenisTransaksi}{FgPengganti}.{NomorFaktur.Substring(0, 3)}-{NomorFaktur.Substring(3, 2)}.{NomorFaktur.Substring(5, 8)}";
                }
                return $"{NomorFaktur}";
            }
        }

        [XmlElement(ElementName = "tanggalFaktur")]
        public string? TanggalFaktur { get; set; }

        [XmlElement(ElementName = "npwpPenjual")]
        public string? NpwpPenjual { get; set; }

        public string FormatedNpwpPenjual => $"{NpwpPenjual.Substring(0, 2)}.{NpwpPenjual.Substring(2, 3)}.{NpwpPenjual.Substring(5, 3)}.{NpwpPenjual.Substring(8, 1)}-{NpwpPenjual.Substring(9, 3)}.{NpwpPenjual.Substring(12, 3)}";

        [XmlElement(ElementName = "namaPenjual")]
        public string? NamaPenjual { get; set; }

        [XmlElement(ElementName = "alamatPenjual")]
        public string? AlamatPenjual { get; set; }

        [XmlElement(ElementName = "npwpLawanTransaksi")]
        public string? NpwpLawanTransaksi { get; set; }

        [XmlElement(ElementName = "namaLawanTransaksi")]
        public string? NamaLawanTransaksi { get; set; }

        [XmlElement(ElementName = "alamatLawanTransaksi")]
        public string? AlamatLawanTransaksi { get; set; }

        [XmlElement(ElementName = "jumlahDpp")]
        public double JumlahDpp { get; set; }

        [XmlElement(ElementName = "jumlahPpn")]
        public double JumlahPpn { get; set; }

        [XmlElement(ElementName = "jumlahPpnBm")]
        public double JumlahPpnBm { get; set; }

        [XmlElement(ElementName = "statusApproval")]
        public string? StatusApproval { get; set; }

        [XmlElement(ElementName = "statusFaktur")]
        public string? StatusFaktur { get; set; }

        [XmlElement(ElementName = "referensi")]
        public string? Referensi { get; set; }

        [XmlElement(ElementName = "detailTransaksi")]
        public List<DetailTransaksi>? DetailTransaksi { get; set; }

        public static implicit operator DJP(Task<object?> v)
        {
            throw new NotImplementedException();
        }
    }
}
