using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    public class GajiPegawai
    {
        public string NamaDepan { get; }
        public string NamaBelakang { get; }
        public string SocialSecurityNumber { get; }
        private decimal penjualanKotor;
        private decimal tingkatKomisi;



        public GajiPegawai(string namaDepan, string namaBelakang, string socialSecurityNumber, decimal penjualanKotor, decimal tingkatKomisis)
        {


            NamaDepan = namaDepan;
            NamaBelakang = namaBelakang;
            SocialSecurityNumber = socialSecurityNumber;
            PenjualanKotor = penjualanKotor;
            TingkatKomisi = tingkatKomisis;
        }


        public decimal PenjualanKotor
        {
            get
            {
                return penjualanKotor;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(PenjualanKotor)} must be >= 0");
                }

                penjualanKotor = value;
            }
        }


        public decimal TingkatKomisi
        {
            get
            {
                return tingkatKomisi;
            }
            set
            {
                if (value <= 0 || value >= 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(TingkatKomisi)} must be > 0 and < 1");
                }

                tingkatKomisi = value;
            }
        }


        public virtual decimal Pendapatan() => tingkatKomisi * penjualanKotor;


        public override string ToString() =>
        $"commission employee: {NamaDepan} {NamaBelakang}\n" +
        $"social security number: {SocialSecurityNumber}\n" +
        $"gross sales: {penjualanKotor:C}\n" +
        $"commission rate: {tingkatKomisi:F2}";
    }
    public class GajiPokokPlusKomisiPegawai : GajiPegawai
    {

        private decimal gajiPokok;
        public GajiPokokPlusKomisiPegawai(string namaDepan, string namaBelakang,
        string socialSecurityNumber, decimal penjualanKotor,
        decimal tingkatKomisis, decimal gajiPokok)
        : base(namaDepan, namaBelakang, socialSecurityNumber,
        penjualanKotor, tingkatKomisis)
        {
            GajiPokok = gajiPokok;
        }


        public decimal GajiPokok
        {
            get
            {
                return gajiPokok;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                      value, $"{nameof(GajiPokok)} must be >= 0");
                }

                gajiPokok = value;
            }
        }


        public override decimal Pendapatan() => GajiPokok + base.Pendapatan();


        public override string ToString() =>
        $"base-salaried {base.ToString() }\nbase salary: {GajiPokok:C}";
    }
    class PolymorphismTest
    {

        static void Main()
        {
            var komisiPegawai = new GajiPegawai("Sue", "Jones", "222-22-2222", 10000.00M, .06M);
            var GajiPokokPlusKomisiPegawai = new GajiPokokPlusKomisiPegawai("Bob", "Lewis", "333-33-3333", 5000.00M, .04M, 300.00M);
            Console.WriteLine("Call CommissionEmployee's ToString and Earnings methods " + "with base-class reference to base class object\n");
            Console.WriteLine(komisiPegawai.ToString());
            Console.WriteLine($"earnings: {komisiPegawai.Pendapatan() }\n");
            Console.WriteLine("Call BasePlusCommissionEmployee's ToString and" + " Earnings methods with derived class reference to" + " derived-class object\n");
            Console.WriteLine(GajiPokokPlusKomisiPegawai.ToString());
            Console.WriteLine($"earnings: {GajiPokokPlusKomisiPegawai.Pendapatan() }\n");

            GajiPegawai commissionEmployee2 = GajiPokokPlusKomisiPegawai;
            Console.WriteLine("Call BasePlusCommissionEmployee's ToString and Earnings " + "methods with base class reference to derived-class object");
            Console.WriteLine(commissionEmployee2.ToString());
            Console.WriteLine($"earnings: {GajiPokokPlusKomisiPegawai.Pendapatan() }\n");
            Console.ReadLine();
        }
    }
}
