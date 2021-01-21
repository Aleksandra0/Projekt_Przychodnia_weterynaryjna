using System;
using System.Globalization;

namespace Projekt_Przychodnia_weterynaryjna
{
	public class Szczepienia
	{
		public enum Rodzaj_szczepienia { obowiazkowe, dodatkowe };
		
		private DateTime data_szczepienia;
		private DateTime data_nastepnego_szczepienia;
		private string preparat;
		private string przeciw_czemu;
		private Rodzaj_szczepienia rodzaj_szczepienia;


        public string Preparat { get => preparat; set => preparat = value; }
        public DateTime Data_nastepnego_szczepienia { get => data_nastepnego_szczepienia; set => data_nastepnego_szczepienia = value; }
        public DateTime Data_szczepienia { get => data_szczepienia; set => data_szczepienia = value; }
		public Rodzaj_szczepienia Rodzaj_Szczepienia { get => rodzaj_szczepienia; set => rodzaj_szczepienia = value; }
        public string Przeciw_czemu { get => przeciw_czemu; set => przeciw_czemu = value; }

        public Szczepienia(DateTime data_szczepienia, string preparat, string przeciw_czemu, DateTime data_nastepnego_szczepienia)
		{
			this.Data_szczepienia = data_szczepienia;
			this.Preparat = preparat;
			this.Przeciw_czemu = przeciw_czemu;
			this.Data_nastepnego_szczepienia = data_nastepnego_szczepienia;
		}

		public Szczepienia(string data_szczepienia, string preparat, string przeciw_czemu, string data_nastepnego_szczepienia)
		{
			DateTime.TryParseExact(data_szczepienia, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "yyyy.MM.dd", "dd-MM-yyyy", "dd/MM/yyyy", "dd.MM.yyyy" }, null, DateTimeStyles.None, out this.data_szczepienia);
			this.Preparat = preparat;
			this.Przeciw_czemu = przeciw_czemu;
			DateTime.TryParseExact(data_nastepnego_szczepienia, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "yyyy.MM.dd", "dd-MM-yyyy", "dd/MM/yyyy", "dd.MM.yyyy" }, null, DateTimeStyles.None, out this.data_nastepnego_szczepienia);
		}

        public override string ToString()
        {
			return "Szczepienie: " + this.data_szczepienia.ToString("dd-MM-yyyy") + ", przeciwko: " + this.przeciw_czemu + ", zastosowany preparat: " + this.preparat;
		}
    }
}
