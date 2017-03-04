using System.Drawing;
using System.Runtime.Serialization;

namespace BlackAccounting
{
	[DataContract]
	public class RecordType
	{
		/// <summary>
		/// ID типа
		/// </summary>
		[DataMember]
		public int ID { get; set; }
		/// <summary>
		/// Описание типа
		/// </summary>
		[DataMember]
		public string Description { get; set; }
		/// <summary>
		/// Цвет представления типа
		/// </summary>
		[DataMember]
		public Color Color { get; set; }
	}
}
