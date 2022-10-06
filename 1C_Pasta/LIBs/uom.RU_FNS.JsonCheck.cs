using System.Text.Json;
using System.Windows.Media;

using uom.RU_FNS.JsonRAW;

using static uom.RU_FNS.JsonRAW.ReceiptBase;

using System.Drawing;
using Drawing = System.Drawing;
using PixelFormat = System.Drawing.Imaging.PixelFormat;
using Brushes = System.Drawing.Brushes;
using Color = System.Drawing.Color;

//using Brushes = System.Drawing.Brushes;
//using FontFamily = System.Drawing.FontFamily;
//using PixelFormat = System.Drawing.Imaging.PixelFormat;


namespace uom.RU_FNS
{



	/*
fsId — ФН
operationType — тип операции (1 — приход, 2 — возврат прихода, 3 — расход, 4 — возврат расхода)
documentId — ФД
fiscalSign — ФП
date — дата покупки
sum — сумма чека (без разделителей)
	 */

	namespace JsonRAW
	{


		/// <summary>Версия формата фискальных данных</summary>
		public enum FiscalDocumentFormatVersions : uint
		{
			/// <summary>версия ФФД 1.0 </summary>
			v_1_0 = 1,
			/// <summary> версия ФФД 1.05</summary>
			v_1_05 = 2,
			/// <summary>версия ФФД 1.1</summary>
			v_1_1 = 3,
			/// <summary>версия ФФД 1.2</summary>
			v_1_2 = 4,
		}

		public enum OperationTypes : uint
		{
			Приход = 1,
			ВозвратПрихода = 2,
			Расход = 3,
			ВозвратРасхода = 4
		}

		/// <summary>{0,1,2,4,16, 32,33,34,36, 48}</summary>
		public enum TaxationTypes : uint
		{
			ОСН = 1,
			УСН_доход = 2,
			УСН_доход_Расход = 4,
			ЕНВД = 8,
			ЕСХН = 16,
			Патент = 32,
		}


		public class JsonReceiptStreamHeader
		{

			public string _id { get; set; } = string.Empty;

			public DateTime? createdAt { get; set; } = null;

		}


		public class ReceiptBase
		{
			public int? fiscalDocumentFormatVer { get; set; } = null;

		}


		/// <summary>Элемент строки чека (товар или услуга)</summary>
		public class ItemBase
		{
			public string? name { get; set; } = null;
			public int? nds { get; set; } = null;
			public int? paymentType { get; set; } = null;
			public int? price { get; set; } = null;

			public int? productType { get; set; } = null;
			public float? quantity { get; set; } = null;
			public int? sum { get; set; } = null;



		}




		/// <summary>Кассовый чек v4</summary>
		public class Receipt_4 : JsonRAW.ReceiptBase
		{
			public DateTime? dateTime { get; set; } = null;
			public int? operationType { get; set; } = null;

			public int? code { get; set; } = null;


			public ItemBase[]? items { get; set; } = null;


			public int? nds0 { get; set; } = null;
			public int? nds10 { get; set; } = null;
			public int? nds18 { get; set; } = null;



			public int? cashTotalSum { get; set; } = null;
			public int? ecashTotalSum { get; set; } = null;
			public int? creditSum { get; set; } = null;





			public int? fiscalDocumentNumber { get; set; } = null;
			public string? fiscalDriveNumber { get; set; } = null;
			public int? fiscalSign { get; set; } = null;

			public string? fnsUrl { get; set; } = null;
			public string? kktRegId { get; set; } = null;


			public string? @operator { get; set; } = null;
			public int? prepaidSum { get; set; } = null;
			public int? provisionSum { get; set; } = null;
			public int? requestNumber { get; set; } = null;

			/// <summary>Место расчетов (свободная форма)<br/>
			/// String (Unicode) Макс 256 символов</summary>
			public string? retailPlace { get; set; } = null;

			/// <summary>Адрес расчетов (по ФИАС).<br/>
			/// Если с ККТ пришел адрес, тогда передавать его, иначе подставлять из отчета о регистрации или перерегистрации ККТ.<br/>
			/// String (Unicode) Макс 256 символов</summary>
			public string? retailPlaceAddress { get; set; } = null;


			public int? shiftNumber { get; set; } = null;
			public int? taxationType { get; set; } = null;
			public int? appliedTaxationType { get; set; } = null;
			public int? totalSum { get; set; } = null;
			public string? user { get; set; } = null;
			/// <summary>ИНН</summary>
			public string? userInn { get; set; } = null;

		}

	}


	/// <summary>Кассовый чек</summary>
	public class Receipt
	{





		private readonly ReceiptBase Raw;

		public FiscalDocumentFormatVersions FiscalDocumentFormatVersion => (FiscalDocumentFormatVersions)Raw.fiscalDocumentFormatVer!.Value!;

		public int? Code;

		/// <summary>Дата</summary>
		public readonly DateTime? DateTime;

		/// <summary>Тип операции</summary>
		public readonly JsonRAW.OperationTypes? OperationType;


		/// <summary>Итого</summary>
		public readonly float? TotalSum;


		/// <summary>Сумма расчета по чеку с НДС по ставке 0%</summary>
		public readonly float? Nds0;
		/// <summary>Сумма НДС чека по ставке 20%</summary>
		public readonly float? Nds18;
		/// <summary>Сумма НДС чека по ставке 10%</summary>
		public readonly float? Nds10;


		/// <summary>Итого Наличные</summary>
		public readonly float? CashTotalSum;
		/// <summary>Итого Безналичные</summary>
		public readonly float? ECashTotalSum;
		public readonly float? CreditSum;

		public readonly float? PrepaidSum;
		public readonly float? ProvisionSum;


		/// <summary>Система налогообложения</summary>
		public readonly JsonRAW.TaxationTypes? TaxationType;
		/// <summary>Применяемая cистема налогообложения</summary>
		public readonly JsonRAW.TaxationTypes? AppliedTaxationType;



		/// <summary>ФД</summary>
		public readonly int? FiscalDocumentNumber;
		/// <summary>ФН</summary>
		public readonly string? FiscalDriveNumber;
		/// <summary>ФПД</summary>
		public readonly int? FiscalSign;


		public readonly string? FnsUrl;

		/// <summary>Рег номер ККТ</summary>
		public readonly string? KktRegId;

		/// <summary>НомерЧека</summary>
		public readonly int? RequestNumber;


		/// <summary>Пользователь (ИП или ООО)</summary>
		public readonly string? User;

		/// <inheritdoc cref="Receipt_4.userInn"/>
		public readonly string? UserInn;

		/// <inheritdoc cref="Receipt_4.retailPlace"/>
		public readonly string? RetailPlace;

		/// <inheritdoc cref="Receipt_4.retailPlaceAddress"/>
		public readonly string? RetailPlaceAddress;

		/// <summary>Номер смены</summary>
		public readonly int? ShiftNumber;
		/// <summary>Кассир</summary>
		public readonly string? @Operator;


		/// <summary>Предмет расчета.
		/// Описание элемента представлено в таблице items</summary>
		public readonly System.Collections.ObjectModel.ReadOnlyCollection<ItemBase>? Items;



		public Receipt(Receipt_4 raw)
		{
			Raw = raw;

			this.Code = raw.code;

			this.DateTime = raw.dateTime;
			this.OperationType = raw.operationType.AsEnum<OperationTypes>();
			this.TaxationType = raw.taxationType.AsEnum<TaxationTypes>();
			this.AppliedTaxationType = raw.appliedTaxationType.AsEnum<TaxationTypes>();

			this.TotalSum = raw.totalSum.AsMoney();
			this.Nds0 = raw.nds0.AsMoney();
			this.Nds10 = raw.nds10.AsMoney();
			this.Nds18 = raw.nds18.AsMoney();

			this.PrepaidSum = raw.prepaidSum.AsMoney();
			this.ProvisionSum = raw.provisionSum.AsMoney();
			this.CreditSum = raw.creditSum.AsMoney();
			this.CashTotalSum = raw.cashTotalSum.AsMoney();
			this.ECashTotalSum = raw.ecashTotalSum.AsMoney();

			this.FnsUrl = raw.fnsUrl.AsText();
			this.FiscalDocumentNumber = raw.fiscalDocumentNumber;
			this.FiscalSign = raw.fiscalSign;
			this.FiscalDriveNumber = raw.fiscalDriveNumber.AsText();


			this.User = raw.user.AsText();
			this.UserInn = raw.userInn.AsText();
			this.KktRegId = raw.kktRegId.AsText();
			this.RetailPlace = raw.retailPlace.AsText();
			this.RetailPlaceAddress = raw.retailPlaceAddress.AsText();


			this.ShiftNumber = raw.shiftNumber;
			this.@Operator = raw.@operator.AsText();
			this.RequestNumber = raw.requestNumber;

			Items = new(raw.items!);
		}


		public Bitmap Draw()
		{
			int resolution = 300;
			float checkPadding = 5f;
			float checkWidthMM = 80;


			float checkWidthIn = checkWidthMM / 25.4f;
			int checkWidthPx = (int)(checkWidthIn * resolution);

			Bitmap bm = new(checkWidthPx, checkWidthPx * 2, PixelFormat.Format32bppRgb);
			bm.SetResolution(resolution, resolution);

			using Graphics g = Graphics.FromImage(bm);


			g.Clear(System.Drawing.Color.Red);
			g.PageUnit = GraphicsUnit.Millimeter;

			RectangleF rcf = new(checkPadding, checkPadding, checkWidthMM - (checkPadding * 2), 10);
			g.FillRectangle(Drawing.Brushes.Green, rcf);


			var ssss = Drawing.FontFamily.GenericMonospace;

			var ff = new Font(ssss, 5f, FontStyle.Regular, GraphicsUnit.Millimeter);


			var ts = g.eDrawTextEx("КАССОВЫЙ ЧЕК", ff, Color.Blue, rcf, ContentAlignment.TopCenter, autoHeightRect: true);
			g.DrawRectangle(Pens.Magenta, new RectangleF(rcf.Location, ts));


			return bm;
		}
	}




	internal static class Extensions_FNS
	{

		public static JsonElement eGetPropertyByPath(this JsonElement je, string path)
		{
			var pp = path.Split(".", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
			foreach (string s in pp)
			{
				je = je.GetProperty(s);
			}
			return je;
		}


		public static (JsonReceiptStreamHeader Header, Receipt @Receipt) ReadFNSCheck(this Stream s)
		{
			JsonDocument jd = JsonDocument.Parse(s);
			JsonElement re = jd.RootElement;
			JsonElement[] elements = [.. re.EnumerateArray()];
			JsonElement je = elements[0];


			var rawHdr = je.Deserialize<JsonReceiptStreamHeader>(JsonSerializerOptions.Default);
			var jereceipt = je.eGetPropertyByPath("ticket.document.receipt");
			var receipt = jereceipt.Deserialize<ReceiptBase>(JsonSerializerOptions.Default);
			if (receipt == null) throw new Exception("Failed to deserialize JSON stream!");

			if (!receipt.fiscalDocumentFormatVer.HasValue) throw new Exception($"'{nameof(receipt.fiscalDocumentFormatVer)}' field has no value!");

			uint format = (uint)receipt.fiscalDocumentFormatVer.Value;
			if (!Enum.IsDefined(typeof(FiscalDocumentFormatVersions), format)) throw new Exception($"Invalid '{nameof(receipt.fiscalDocumentFormatVer)}' field value = '{format}'!");
			FiscalDocumentFormatVersions eformat = (FiscalDocumentFormatVersions)format;

			switch (eformat)
			{
				//
			}

			var rawReceipt_4 = jereceipt.Deserialize<Receipt_4>(JsonSerializerOptions.Default);

			return (rawHdr!, new Receipt(rawReceipt_4!));
		}



		public static float? AsMoney(this int? value)
			=> value.HasValue
				? value.Value / 100.0f
				: null;

		public static string? AsText(this string? value)
			=> value?.Trim();


		public static T? AsEnum<T>(this int? value) where T : Enum
		{
			if (!value.HasValue) return default;
			return (T)Enum.Parse(typeof(T), value.Value.ToString());
		}


	}
}