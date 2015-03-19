using System;
using System.Text;

public partial class Lipsum {
	public static string OrderedList() { return OrderedList(LipsumFormat.None); }
	public static string OrderedList(LipsumFormat options) {
		StringBuilder content = new StringBuilder();

		// Generate HTML block
		content.AppendLine("<ol>");
		for (int i = Seed.Next(2, 5); i > 0; i--)
			content.AppendLine("<li>" + Phrase + "</li>");
		content.AppendLine("</ol>");

		return content.ToString();
	}
}