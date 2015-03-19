using System;
using System.Text;

public partial class Lipsum {
	public static string Header() { return Header(LipsumFormat.None); }
	public static string Header(LipsumFormat options) { return Header(Seed.Next(2, 6), options); }
	public static string Header(int size) { return Header(size, LipsumFormat.None); }
	public static string Header(int size, LipsumFormat options) {
		StringBuilder content = new StringBuilder();
		content.AppendFormat("<h{0}>{1}</h{0}>\r\n", size, Phrase);
		return content.ToString();
	}
}